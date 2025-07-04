using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using EntityModels;

namespace System_prototype_for_S_S_toy_Co__4915m_Project_.SuppyChain
{
    public partial class PurchaseOrder : Form
    {
        DataTable dtsm;
        DataTable dtwh;
        SupplyChainController control;
        public PurchaseOrder()
        {
            InitializeComponent();
        }
        public PurchaseOrder(SupplyChainController controller)
        {
            InitializeComponent();
            control = controller;
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            txtDate.Text = dateTimePicker1.Value.ToString("yyyy-MM-dd"); // Update the text box with the selected date
        }

        private async void PurchaseOrder_Load(object sender, EventArgs e)
        {
            dtsm = await control.GetSupplierMaterialData();
            dtwh = await control.GetWarehouseData();
            txtDate.Text = DateTime.Now.ToString("yyyy-MM-dd"); // Set default date to today
            if (dtsm == null || dtwh == null)
            {
                MessageBox.Show("Failed to load supplier or material data.");
                return;
            }
            // get warehouse data and populate the combobox
            if (dtwh.Rows.Count > 0)
            {
                foreach (DataRow row in dtwh.Rows)
                {
                    string warehouseName = row["Name"].ToString();
                    cbWarehouse.Items.Add(warehouseName);
                }
                cbWarehouse.SelectedIndex = 0; // Select the first warehouse by default
            }
            else
            {
                MessageBox.Show("No warehouses found.");
            }
        }

        private void txtsID_TextChanged(object sender, EventArgs e)
        {
            bool isFound = findById();
        }

        private void txtmID_TextChanged(object sender, EventArgs e)
        {
            bool isFound = findById();
        }
        private bool findById()
        {
            DataTable dt = dtsm.Copy();
            DataView dv = new DataView(dt);
            string sID = txtsID.Text.Trim();
            string mID = txtmID.Text.Trim();
            dv.RowFilter = $"SupplierID = '{sID}'";
            if (dv.Count > 0)
            { //Supplier exists, put its name in the text box
                txtsName.Text = dv[0]["SuppilierName"].ToString();
            }
            else
            {   //Supplier does not exist, clear the name text box
                txtsName.Text = string.Empty;
            }
            dv.RowFilter = $"MaterialID = '{mID}'";
            if (dv.Count > 0)
            { //Material exists, put its name in the text box
                txtmName.Text = dv[0]["MaterialName"].ToString();
            }
            else
            {//Material does not exist, clear the name text box
                txtmName.Text = string.Empty;
            }
            dv.RowFilter = $"SupplierID = '{sID}' AND MaterialID = '{mID}'";
            bool isFound = false;
            if (dv.Count > 0)
            { //Both Supplier and Material exist
                txtUnitPrice.Text = dv[0]["UnitPrice"].ToString();
                isFound = true;
            }
            else
            { //Either Supplier or Material does not exist, clear the UnitPrice text box
                txtUnitPrice.Text = string.Empty;
            }
            return isFound;
        }

        private void txtQty_TextChanged(object sender, EventArgs e)
        {
            bool isFound = findById();
            if (isFound)
            {
                if (int.TryParse(txtQty.Text, out int qty) && qty > 0)
                {
                    // Calculate total price
                    if (decimal.TryParse(txtUnitPrice.Text, out decimal unitPrice))
                    {
                        decimal totalPrice = qty * unitPrice;
                        txtAmount.Text = totalPrice.ToString("F2"); // Format to 2 decimal places
                    }
                    else
                    {
                        txtAmount.Text = string.Empty;
                    }
                }
                else
                {
                    txtAmount.Text = string.Empty;
                }
            }
            else
            {
                txtAmount.Text = string.Empty;
            }
        }

        private async void btnSubmit_Click(object sender, EventArgs e)
        {   //So, we have two tables to insert: purchase and purchaseline
            //Purchase table has PurchaseID, Date, Amount
            //PurchaseLine table has PurchaseID, SupplierID, MaterialID, Quantity
            if (string.IsNullOrEmpty(txtsID.Text) || string.IsNullOrEmpty(txtmID.Text) || string.IsNullOrEmpty(txtQty.Text) || string.IsNullOrEmpty(txtUnitPrice.Text) || string.IsNullOrEmpty(txtAmount.Text) || string.IsNullOrEmpty(txtDate.Text))
            {
                MessageBox.Show("Please fill in all fields before submitting.");
                return;
            }
            if (!findById())
            {
                MessageBox.Show("Supplier or Material not found. Please check the IDs.");
                return;
            }
            if (!int.TryParse(txtQty.Text, out int quantity) || quantity <= 0)
            {
                MessageBox.Show("Please enter a valid quantity greater than zero.");
                return;
            }
            if (!decimal.TryParse(txtAmount.Text, out decimal amount) || amount <= 0)
            {
                MessageBox.Show("Please enter a valid amount greater than zero.");
                return;
            }
            if (!DateTime.TryParse(txtDate.Text, out DateTime date))
            {
                MessageBox.Show("Please enter a valid date.");
                return;
            }
            if ((cbWarehouse.SelectedItem == null) || string.IsNullOrEmpty(cbWarehouse.SelectedItem.ToString()))
            {
                MessageBox.Show("Please select a warehouse.");
                return;
            }
            //Assuming control has methods to insert purchase and purchase line
            string dateText = txtDate.Text.Trim();
            amount = decimal.TryParse(txtAmount.Text, out decimal amt) ? amt : 0;
            string SupplierID = txtsID.Text.Trim();
            string MaterialID = txtmID.Text.Trim();
            quantity = int.TryParse(txtQty.Text, out int qty) ? qty : 0;

            // Get the selected warehouse ID from the combobox
            string selectedWarehouse = cbWarehouse.SelectedItem.ToString();
            string warehouseID = dtwh.AsEnumerable()
                .FirstOrDefault(row => row.Field<string>("Name") == selectedWarehouse)?["WarehouseID"].ToString();
            bool isInserted = false;
            try
            {
                isInserted = await control.insetNewPurchase(warehouseID, dateText, amount, SupplierID, MaterialID, quantity);
                if (isInserted)
                {
                    MessageBox.Show("Purchase order inserted successfully.");
                    this.Close(); // Close the form after successful insertion
                }
                else
                {
                    MessageBox.Show("Failed to insert purchase order. Please try again.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred while inserting the purchase order: {ex.Message}");

            }
        }
    }
}
