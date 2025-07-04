using Google.Protobuf.WellKnownTypes;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System_prototype_for_S_S_toy_Co__4915m_Project_.ProductRequirement;

namespace System_prototype_for_S_S_toy_Co__4915m_Project_.SuppyChain
{
    public class SupplyChainController : SubSystemController
    {
        // Open page method for Supply Chain Management
        public void OpenPage(int pageIndex)
        {
            switch (pageIndex)
            {
                case 0:
                    ViewPurchase view = new ViewPurchase(this);
                    view.Show(); // Open View Purchase page
                    break;
                case 1:
                    ViewSupplier viewSupplier = new ViewSupplier(this);
                    viewSupplier.Show(); // Open View Supplier page
                    break;
                case 2:
                    PurchaseOrder purchaseOrder = new PurchaseOrder(this);
                    purchaseOrder.Show(); // Open Purchase Order page
                    break;
                case 3:
                    ConfirmInward confirmInward = new ConfirmInward(this);
                    confirmInward.Show(); // Open Confirm Inward page
                    break;
            }
        }

        internal void CloseSupplyChainPage()
        {
            //close all the open forems related to Supply Chain Management
            FormCollection openForms = Application.OpenForms; // Get all open forms in the application
            if (openForms != null)
            {
                foreach (Form form in openForms)
                {
                    if (form is ViewPurchase || 
                        form is ViewSupplier || 
                        form is PurchaseOrder || 
                        form is ConfirmInward
                        )// Check if the form is one of the specified types
                    {
                        form.Close(); // Close the form if it matches the specified types
                    }
                }
            }
        }

        internal async Task<bool> confirmInward(DataTable dti, DataTable dtmWh)
        {
            // This method is used to insert inward records into the database
            // and insert the material inventory records into the database
            // dti: DataTable containing inward records
            // dtmWh: DataTable containing material inventory records
            bool isSuccess = false;
            try
            {
                // Insert inward records into the database
                int inwardRowsInserted = await InsertTable(dti, "inwardrecord", new string[] { "InwardID" } );
                if (inwardRowsInserted > 0)
                {
                    // If inward records are inserted successfully, update material inventory records
                    int materialInventoryRowsInserted = await UpdateData(dtmWh, "materialinventory", new string[] { "MaterialID", "WarehouseID" });
                    if (materialInventoryRowsInserted > 0)
                    {
                        isSuccess = true; // If both insertions are successful, set isSuccess to true
                    }
                    else
                    {
                        isSuccess = false; // If material inventory insertion fails, set isSuccess to false
                    }
                }
                else
                {
                    isSuccess = false; // If inward insertion fails, set isSuccess to false
                }
            }
            catch (Exception ex)
            {
                throw ex; // Throw the exception for further handling
            }
            return isSuccess;
        }

        internal async Task<DataTable> GetMaterialInventory()
        {
            DataTable dti = null;
            try
            {
                dti = await GetTableData("materialinventory"); // specify table name
            }
            catch (Exception ex)
            {
                throw ex; // Throw the exception for further handling
            }
            return dti;
        }

        internal async Task<DataTable> GetPurchaseLineRecords()
        {
            DataTable dt = null;
            try
            {
                dt = await GetTableData("purchaseline"); // specify table name
            }
            catch (Exception ex)
            {
                throw ex;
            }
            //Set ReadOnly for all columns
            if (dt != null && dt.Columns.Count > 0)
            {
                foreach (DataColumn col in dt.Columns)
                {
                    col.ReadOnly = true; // Set all columns to ReadOnly
                }
            }
            return dt;
        }

        internal async Task<DataTable> GetPurchaseOrders()
        {
            DataTable dtpr = null;
            DataTable dtpl = null;
            DataTable dts = null;
            DataTable dtm = null;
            DataTable dtwh = null; // Initialize DataTable for warehouse data
            DataTable dt = null; // Initialize DataTable to null
            try
            {
                dtpr = await GetPurchaseRecords(); // Get purchase records
                dtm = await GetTableData("material"); // Get material records
                dts = await GetTableData("supplier"); // Get supplier records
                dtpl = await GetTableData("purchaseline"); // Get purchase line records
                dtwh = await GetWarehouseData(); // Get warehouse data

                // Create a new DataTable to hold the combined data
                dt = new DataTable("PurchaseOrderWithDetails");
                // Add columns for purchase order details
                // dt : DataTable to hold purchase order details
                //PurchaseID, SupplierName, MaterialName, Qty, Date, Amount, SupplierID, MaterialID
                dt.Columns.Add(new DataColumn("PurchaseID", typeof(string)));
                dt.Columns.Add(new DataColumn("WarehouseName", typeof(string))); // Assuming WareHouseName is part of the purchase order
                dt.Columns.Add(new DataColumn("SupplierName", typeof(string)));
                dt.Columns.Add(new DataColumn("MaterialName", typeof(string)));
                dt.Columns.Add(new DataColumn("Qty", typeof(int)));
                dt.Columns.Add(new DataColumn("Date", typeof(DateTime)));
                dt.Columns.Add(new DataColumn("Amount", typeof(decimal)));
                dt.Columns.Add(new DataColumn("WarehouseID", typeof(string))); // Assuming WareHouseID is part of the purchase order
                dt.Columns.Add(new DataColumn("SupplierID", typeof(string)));
                dt.Columns.Add(new DataColumn("MaterialID", typeof(string)));

                // for each row in the purchaseline table, find the corresponding purchase record
                foreach (DataRow row in dtpl.Rows)
                {
                    DataRow newRow = dt.NewRow();
                    newRow["PurchaseID"] = row["PurchaseID"];
                    newRow["SupplierID"] = row["SupplierID"];
                    newRow["MaterialID"] = row["MaterialID"];
                    newRow["Qty"] = row["Qty"];
                    // Find the corresponding purchase record
                    DataRow purchaseRow = dtpr.Select($"PurchaseID = '{row["PurchaseID"]}'").FirstOrDefault();
                    if (purchaseRow != null)
                    {
                        newRow["WareHouseID"] = purchaseRow["WareHouseID"]; // Assuming WareHouseID is part of the purchase order
                        // Find the warehouse name based on WareHouseID
                        string warehouseID = purchaseRow["WareHouseID"].ToString();
                        string warehouseName = dtwh.Select($"WarehouseID = '{warehouseID}'").FirstOrDefault()?["Name"]?.ToString() ?? "Unknown";
                        newRow["WarehouseName"] = warehouseName; // Set the warehouse name
                        newRow["Date"] = purchaseRow["Date"];
                        newRow["Amount"] = purchaseRow["Amount"];
                    }
                    else
                    {
                        newRow["WareHouseID"] = DBNull.Value; // Set to DBNull if no corresponding purchase record found
                        newRow["WarehouseName"] = DBNull.Value; // Set to DBNull if no corresponding warehouse found
                        newRow["Date"] = DBNull.Value;
                        newRow["Amount"] = DBNull.Value;
                    }
                    // Find the supplier name and material name
                    string sID = row["SupplierID"].ToString();
                    string mID = row["MaterialID"].ToString();
                    string supplierName = dts.Select($"SupplierID = '{sID}'").FirstOrDefault()?["Name"]?.ToString() ?? "Unknown";
                    string materialName = dtm.Select($"MaterialID = '{mID}'").FirstOrDefault()?["Name"]?.ToString() ?? "Unknown";

                    // Set the supplier and material names
                    newRow["SupplierName"] = supplierName;
                    newRow["MaterialName"] = materialName;

                    // Add the new row to the DataTable
                    dt.Rows.Add(newRow);
                    dt.AcceptChanges(); // Accept changes to the DataTable
                }

                // Set ReadOnly for all columns
                if (dt != null && dt.Columns.Count > 0)
                {
                    foreach (DataColumn col in dt.Columns)
                    {
                        col.ReadOnly = true; // Set all columns to ReadOnly
                    }
                }
                return dt; // Return the combined DataTable with purchase order details
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        internal async Task<DataTable> GetPurchaseRecords()
        {
            DataTable dt = null;
            try
            {
                dt = await GetTableData("purchase"); // specify table name
            }
            catch (Exception ex)
            {
                throw ex;
            }
            //Set ReadOnly for all columns
            if (dt != null && dt.Columns.Count > 0)
            {
                foreach (DataColumn col in dt.Columns)
                {
                    col.ReadOnly = true; // Set all columns to ReadOnly
                }
            }
            return dt;
        }

        internal async Task<DataTable> GetSupplierData()
        {
            throw new NotImplementedException();
        }

        internal async Task<DataTable> GetSupplierMaterialData()
        {
            DataTable dtsm = null;
            DataTable dtsName = null;
            DataTable dtmName = null;
            DataTable dt = null; // Initialize DataTable to null
            try
            {
                dtsm = await GetTableData("supplierMaterial"); // specify table name
                dtsName = await GetTableData("supplier"); // specify table name for supplier names
                dtmName = await GetTableData("material"); // specify table name for material names
                if (dtsName != null && dtmName != null && dtsm != null)
                {
                    //dt.Columns.Add("SupplierName", typeof(string)); // Add SupplierName column
                    dt = new DataTable("SupplierMaterialWithNames");
                    dt.Columns.Add(new DataColumn("SupplierID", typeof(string)));
                    dt.Columns.Add(new DataColumn("SuppilierName", typeof(string)));
                    dt.Columns.Add(new DataColumn("MaterialID", typeof(string)));
                    dt.Columns.Add(new DataColumn("MaterialName", typeof(string)));
                    dt.Columns.Add(new DataColumn("UnitPrice", typeof(decimal)));

                    // Populate the new DataTable with Supplier and Material names
                    for (int i = 0; i < dtsm.Rows.Count; i++)
                    {
                        DataRow newRow = dt.NewRow();
                        newRow["SupplierID"] = dtsm.Rows[i]["SupplierID"];
                        newRow["SuppilierName"] = dtsName.Select($"SupplierID = '{dtsm.Rows[i]["SupplierID"]}'").FirstOrDefault()?["Name"] ?? "Unknown";
                        newRow["MaterialID"] = dtsm.Rows[i]["MaterialID"];
                        newRow["MaterialName"] = dtmName.Select($"MaterialID = '{dtsm.Rows[i]["MaterialID"]}'").FirstOrDefault()?["Name"] ?? "Unknown";
                        newRow["UnitPrice"] = dtsm.Rows[i]["UnitPrice"];
                        dt.Rows.Add(newRow);
                        dt.AcceptChanges(); // Accept changes to the DataTable
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            if (dt != null && dt.Columns.Count > 0)
            {
                foreach (DataColumn col in dt.Columns)
                {
                    col.ReadOnly = true; // Set all columns to ReadOnly
                }
            }
            return dt;
        }

        internal async Task<DataTable> GetWarehouseData()
        {
            DataTable dt = null;
            try
            {
                dt = await GetTableData("warehouse"); // specify table name
            }
            catch (Exception ex)
            {
                throw ex;
            }
            //Set ReadOnly for all columns
            if (dt != null && dt.Columns.Count > 0)
            {
                foreach (DataColumn col in dt.Columns)
                {
                    col.ReadOnly = true; // Set all columns to ReadOnly
                }
            }
            return dt; // Return the DataTable with warehouse data
        }

        internal async Task<bool> insetNewPurchase(string warehouseId, string date, decimal amount, string supplierID, string materialID, int quantity)
        {   //So, we have two tables to insert: purchase and purchaseline
            //Purchase table has PurchaseID, Date, Amount
            //PurchaseLine table has PurchaseID, SupplierID, MaterialID, Qty
            string[] purchaseColumns = {"WareHouseID", "PurchaseID", "Date", "Amount" };
            string[] purchaseLineColumns = { "PurchaseID", "SupplierID", "MaterialID", "Qty" };
            DataTable purchaseTable = new DataTable("Purchase");
            DataTable purchaseLineTable = new DataTable("PurchaseLine");
            purchaseTable.Columns.AddRange(purchaseColumns.Select(c => new DataColumn(c)).ToArray());
            purchaseLineTable.Columns.AddRange(purchaseLineColumns.Select(c => new DataColumn(c)).ToArray());
            DataRow purchaseRow = purchaseTable.NewRow();

            // PurchaseID will be auto-generated by the API, so we can leave it empty or set it to null
            string strDate = date;
            purchaseRow["Date"] = strDate;
            purchaseRow["Amount"] = amount;
            purchaseTable.Rows.Add(purchaseRow);

            purchaseTable.AcceptChanges(); // Accept changes to the DataTable
            purchaseRow.SetAdded(); // Mark the row as added

            DataRow purchaseLineRow = purchaseLineTable.NewRow();
            purchaseLineRow["PurchaseID"] = purchaseRow["PurchaseID"]; // This will be set by the API after insertion
            purchaseRow["WareHouseID"] = warehouseId; // Set the WarehouseID
            purchaseLineRow["SupplierID"] = supplierID;
            purchaseLineRow["MaterialID"] = materialID;
            purchaseLineRow["Qty"] = quantity;
            purchaseLineTable.Rows.Add(purchaseLineRow);
            purchaseLineTable.AcceptChanges();
            purchaseLineRow.SetAdded(); // Mark the row as added
            bool isSuccess = false;
            try
            {
                // Insert the purchase record first to get the PurchaseID
                int purchaseRowsInserted = await InsertOneToManyTables(purchaseTable, purchaseLineTable, "purchase", "purchaseline");
                if (purchaseRowsInserted > 0)
                {
                    isSuccess = true; // If insertion is successful, set isSuccess to true
                }
                else
                {
                    isSuccess = false; // If no rows were inserted, set isSuccess to false
                }
            }
            catch (Exception ex)
            {
                throw ex;

            }
            return isSuccess; // Return the success status of the insertion
        }
    }
}
