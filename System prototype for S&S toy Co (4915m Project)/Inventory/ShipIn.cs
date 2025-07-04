using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace System_prototype_for_S_S_toy_Co__4915m_Project_.Inventory
{
    public partial class ShipIn : Form
    {
        ShipInPageController controll;
        DataTable dtwh;
        DataTable dtmInv;
        DataTable dtpInv;
        bool isMaterial = true; // Default to Material type
        bool isProduct = false; // Default to not Product type
        public ShipIn()
        {
            InitializeComponent();
        }
        public ShipIn(ShipInPageController controll)
        {
            InitializeComponent();
            this.controll = controll;
        }

        private async void ShipIn_Load(object sender, EventArgs e)
        {
            cbGoodType.Items.Add("Material"); // Add Material option to the combobox
            cbGoodType.Items.Add("Product"); // Add Product option to the combobox
            cbGoodType.SelectedIndex = 0; // Set the default selected item to Material
            lblID.Text = "Product ID"; // Default label for Product ID
            try
            {
                dtwh = await controll.GetTableData("warehouse");
                dtmInv = await controll.GetTableData("materialinventory");
                dtpInv = await controll.GetTableData("productinventory");
                if (!(dtwh != null && dtmInv != null && dtpInv != null))
                {
                    MessageBox.Show("Failed to load data from the database. Please check your connection or try again later.");
                    return;
                }
                // Populate the warehouse combobox with warehouse names
                if (dtwh.Rows.Count > 0)
                {
                    foreach (DataRow row in dtwh.Rows)
                    {
                        string warehouseName = row["Name"].ToString();
                        cbWh.Items.Add(warehouseName);
                    }
                    // set the combo box to the first warehouse by default
                    if (cbWh.Items.Count > 0)
                    {
                        cbWh.SelectedIndex = 0; // Select the first warehouse by default
                    }

                }
                else
                {
                    MessageBox.Show("No warehouses found in the database.");
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred while loading data: {ex.Message}");
            }
        }

        private void cbGoodType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbGoodType.SelectedIndex == 0)
            {
                isMaterial = true; // Material selected
                isProduct = false; // Product not selected
                lblID.Text = "Material ID"; // Change label to Material ID
            }
            else if (cbGoodType.SelectedIndex == 1)
            {
                isProduct = true; // Product selected
                isMaterial = false; // Material not selected
                lblID.Text = "Product ID"; // Change label to Product ID
            }
            else
            {
                MessageBox.Show("Please select a valid good type.");
            }
        }

        private void txtID_TextChanged(object sender, EventArgs e)
        {
            string inputId = txtID.Text.Trim();
            txtName.Text = ""; // 預設清空名稱

            if (string.IsNullOrEmpty(inputId))
                return;

            DataTable targetTable = isMaterial ? dtmInv : dtpInv;
            string idColumn = isMaterial ? "MaterialID" : "ProductID";
            string nameColumn = isMaterial ? "MaterialName" : "ProductName";

            if (targetTable != null)
            {
                DataRow[] foundRows = targetTable.Select($"{idColumn} = '{inputId.Replace("'", "''")}'");
                if (foundRows.Length > 0)
                {
                    txtName.Text = foundRows[0][nameColumn]?.ToString();
                }
            }
        }

        private async void btnShipIn_Click(object sender, EventArgs e)
        {
            // Validate input: Name must not be empty, Qty must be a positive integer
            if (string.IsNullOrWhiteSpace(txtName.Text))
            {
                MessageBox.Show("Name cannot be empty. Please check if the ID is correct.");
                return;
            }

            if (!int.TryParse(txtQty.Text.Trim(), out int qty) || qty <= 0)
            {
                MessageBox.Show("Quantity must be a positive integer.");
                return;
            }

            // Show confirmation message box
            var confirmResult = MessageBox.Show(
                $"Please confirm the following:\nType: {cbGoodType.Text}\nID: {txtID.Text}\nName: {txtName.Text}\nQuantity: {qty}\nWarehouse: {cbWh.Text}\n\nProceed with stock-in?",
                "Confirm Stock-In",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (confirmResult != DialogResult.Yes)
                return;

            // Determine which table and columns to use
            DataTable invTable = isMaterial ? dtmInv : dtpInv;
            string idColumn = isMaterial ? "MaterialID" : "ProductID";
            string whColumn = "WarehouseID";
            string qtyColumn = "Qty";
            string nameColumn = isMaterial ? "MaterialName" : "ProductName";

            // Get selected warehouse ID
            string whName = cbWh.Text;
            string whId = "";
            if (dtwh != null)
            {
                DataRow[] whRows = dtwh.Select($"Name = '{whName.Replace("'", "''")}'");
                if (whRows.Length > 0)
                    whId = whRows[0]["WarehouseID"].ToString();
            }
            if (string.IsNullOrEmpty(whId))
            {
                MessageBox.Show("Selected warehouse not found. Please select again.");
                return;
            }

            // Check if a row with the same ID and WarehouseID exists
            DataRow[] foundRows = invTable.Select($"{idColumn} = '{txtID.Text.Trim().Replace("'", "''")}' AND {whColumn} = '{whId}'");

            if (foundRows.Length > 0)
            {
                // Row exists, update quantity
                int oldQty = 0;
                int.TryParse(foundRows[0][qtyColumn]?.ToString(), out oldQty);
                foundRows[0][qtyColumn] = oldQty + qty;
                MessageBox.Show("Stock-in successful. Quantity updated.");
            }
            else
            {
                // Row does not exist, ask for location and add new row
                string loc = Microsoft.VisualBasic.Interaction.InputBox("Please enter the location in warehouse:", "New Inventory", "");
                if (string.IsNullOrWhiteSpace(loc))
                {
                    MessageBox.Show("Location cannot be empty. Stock-in cancelled.");
                    return;
                }
                DataRow newRow = invTable.NewRow();
                newRow[idColumn] = txtID.Text.Trim();
                newRow[nameColumn] = txtName.Text.Trim();
                newRow[whColumn] = whId;
                newRow[qtyColumn] = qty;
                newRow["Location"] = loc;
                invTable.Rows.Add(newRow);
                MessageBox.Show("Stock-in successful. New inventory record added.");
            }

            // Optionally: Call controller to update database here
            // controll.UpdateInventory(invTable); // Uncomment if such method exists
            int isUpdated;
            try
            {
                if(isMaterial)
                {
                    isUpdated = await controll.UpdateData(invTable, "materialinventory", new string[] { "MtearialID", "WarehouseID" });
                } else if(isProduct)
                {
                    isUpdated = await controll.UpdateData(invTable, "productinventory", new string[] { "ProductID", "WarehouseID" });
                }
            } catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            // Clear input fields
            txtID.Clear();
            txtName.Clear();
            txtQty.Clear();
        }
    }
}
