using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace System_prototype_for_S_S_toy_Co__4915m_Project_.SuppyChain
{
    public partial class ConfirmInward : Form
    {
        DataTable dtPurchase; // PurchaseID, SupplierName, MaterialName, Qty, Date, Amount, SupplierID, MaterialID
        SupplyChainController controller;
        DataTable targetRow; // To store the row that matches the PurchaseID
        public ConfirmInward()
        {
            InitializeComponent();
        }
        public ConfirmInward(SupplyChainController controller)
        {
            InitializeComponent();
            this.controller = controller;
        }

        private async void ConfirmInward_Load(object sender, EventArgs e)
        {
            txtDate.Text = DateTime.Today.ToString("yyyy-MM-dd"); // Set the current date in the text box
            try
            {
                dtPurchase = await controller.GetPurchaseOrders();
                if (dtPurchase != null && dtPurchase.Rows.Count > 0)
                {
                    int i = 0;
                }
                else
                {
                    MessageBox.Show("No purchase orders found.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred while loading purchase orders: {ex.Message}");

            }
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            txtDate.Text = dateTimePicker1.Value.ToString("yyyy-MM-dd"); // Update the text box with the selected date
        }

        private void btnFindByID_Click(object sender, EventArgs e)
        {
            string purchaseID = txtpID.Text.Trim();
            DataTable dt = dtPurchase.Copy(); // Create a copy of the original DataTable to filter
            DataView dv = new DataView(dt);
            dv.RowFilter = $"PurchaseID = '{purchaseID}'"; // Assuming PurchaseID is a string, adjust if it's an int
            if (dv.Count == 0)
            {
                MessageBox.Show("No purchase order found with the given ID.");
            }
            else
            {
                targetRow = dv.ToTable(); // Convert the filtered DataView back to a DataTable
                if (targetRow.Rows.Count > 0)
                {
                    //populate the UI with the target row data
                    txtpID.Text = targetRow.Rows[0]["PurchaseID"].ToString();
                    txtsName.Text = targetRow.Rows[0]["SupplierName"].ToString();
                    txtmID.Text = targetRow.Rows[0]["MaterialID"].ToString();
                    txtmName.Text = targetRow.Rows[0]["MaterialName"].ToString();
                    txtQty.Text = targetRow.Rows[0]["Qty"].ToString();
                    txtWh.Text = targetRow.Rows[0]["WarehouseName"].ToString();
                    
                }
                else
                {
                    MessageBox.Show("No purchase order found with the given ID.");
                }
            }
        }

        private async void btnConfirm_Click(object sender, EventArgs e)
        {
            if (targetRow == null || targetRow.Rows.Count == 0)
            {
                MessageBox.Show("Please find a purchase order first.");
                return;
            } //compare the PurchaseID from the text box with the one in the target row
            if (txtpID.Text.Trim() == targetRow.Rows[0]["PurchaseID"].ToString())
            {
                MessageBox.Show("The Purchase ID does not match the selected order.");
                return;
            }
            if (string.IsNullOrWhiteSpace(txtDate.Text))
            {
                MessageBox.Show("Please fill in the date.");
                return;
            }
            if (string.IsNullOrWhiteSpace(txtWhShelf.Text))
            {
                MessageBox.Show("Please fill in the warehouse shelf.");
                return;
            }
            // Proceed with confirmation with a confirmation dialog
            bool isConfirmed = false;
            isConfirmed = MessageBox.Show("Are you sure you want to confirm this inward?", "Confirm Inward", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes;
            if (!isConfirmed)
            {
                return; // User chose not to confirm
            }

            // Proceed with the confirmation logic
            //Insert the inward record into the database
            //InwardID(null), PurchaseID, EmployeeID, Date, Remark
            try {
                string purchaseID = targetRow.Rows[0]["PurchaseID"].ToString();
                string employeeID = SystemController.getEmpID(); // Assuming this method retrieves the current employee ID
                string date = txtDate.Text.Trim();
                string remark = richTextBox1.Text.Trim(); // Assuming you have a text box for remarks
                DataTable dataTable = new DataTable("inwardrecord"); // Create a new DataTable to hold the inward data
                dataTable.Columns.Add("InwardID", typeof(string)); // Assuming InwardID is a string, adjust if it's an int
                dataTable.Columns.Add("PurchaseID", typeof(string));
                dataTable.Columns.Add("EmployeeID", typeof(string));
                dataTable.Columns.Add("Date", typeof(DateTime));
                dataTable.Columns.Add("Remark", typeof(string));
                DataRow newRow = dataTable.NewRow(); // Create a new row for the inward record
                newRow["InwardID"] = null; // Assuming InwardID is auto-generated, set it to DBNull
                newRow["PurchaseID"] = purchaseID; // Set the PurchaseID from the target row
                newRow["EmployeeID"] = employeeID; // Set the EmployeeID from the current session
                newRow["Date"] = date; // Parse the date from the text box
                newRow["Remark"] = remark; // Set the remark from the text box

                dataTable.Rows.Add(newRow); // Add the new row to the DataTable

                // Now update the warehouse stock based on the target row
                string materialID = targetRow.Rows[0]["MaterialID"].ToString();
                string warehouseID = targetRow.Rows[0]["WarehouseID"].ToString(); // Assuming you have a WarehouseID in the target row
                int qty = int.Parse(targetRow.Rows[0]["Qty"].ToString());
                string warehouseLoc = txtWhShelf.Text.Trim(); // Assuming you have a text box for the warehouse shelf

                DataTable dtmInv = await controller.GetMaterialInventory(); // Get the current warehouse inventory
                if (dtmInv == null || dtmInv.Rows.Count == 0)
                {
                    MessageBox.Show("No inventory data found.");
                    return; // Exit if no inventory data is available
                }
                // Find the row in the inventory DataTable that matches the MaterialID and WarehouseID
                DataRow[] inventoryRows = dtmInv.Select($"MaterialID = '{materialID}' AND WarehouseID = '{warehouseID}'");
                if (inventoryRows.Length == 0)
                { //A a new row if no matching inventory row is found
                    DataRow newInventoryRow = dtmInv.NewRow();
                    newInventoryRow["MaterialID"] = materialID;
                    newInventoryRow["WarehouseID"] = warehouseID;
                    newInventoryRow["Qty"] = qty; // Set the quantity from the target row
                    newInventoryRow["WarehouseLoc"] = warehouseLoc; // Set the warehouse shelf location
                    dtmInv.Rows.Add(newInventoryRow); // Add the new inventory row to the DataTable
                }
                else
                {
                    // Update the existing inventory row with the new quantity and warehouse shelf location
                    DataRow inventoryRow = inventoryRows[0];
                    inventoryRow["Qty"] = (int)inventoryRow["Qty"] + qty; // Increment the quantity by the received amount
                    inventoryRow["WarehouseLoc"] = warehouseLoc; // Update the warehouse shelf location
                }


                // Call the controller method to confirm the inward record
                bool isInserted = await controller.confirmInward(dataTable, dtmInv);

                if (isInserted)
                {
                    MessageBox.Show("Inward record confirmed successfully.");
                    // Optionally, clear the form or reset fields after confirmation
                    this.Close(); // Close the form after confirmation
                }
                else
                {
                    MessageBox.Show("Failed to confirm inward record. Please try again.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred while confirming inward record: {ex.Message}");
                return; // Exit if there was an error confirming the inward record
            }


        }


    }
}
