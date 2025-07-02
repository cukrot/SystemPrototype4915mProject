using EntityModels;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace System_prototype_for_S_S_toy_Co__4915m_Project_.ProductRequirement
{
    public class SaleController : SubSystemController
    {
        ViewRequirements viewRequirements;
        DataTable dtProductRequirements_view;
        DataTable dtProductRequirements_edit;
        DataRow row_editing; // This will hold the row being edited
        DataTable dtProducts;
        DataTable dtOrderLines; // Assuming this is used for order lines
        public SaleController()
        {
        }
        public SaleController(ViewRequirements viewRequirements)
        {
        }
        internal void openProductRequirementPage(int pageIndex)
        {
            switch (pageIndex)
            {
                case 0:
                    ViewRequirements view = new ViewRequirements(this);
                    view.Show();
                    break;
                case 1:
                    EditRequirement edit = new EditRequirement(this);
                    edit.Show();
                    break;

            }
        }
        public async Task<DataTable> GetProductRequirements()
        {
            DataTable dt = null;
            if (dtProductRequirements_view != null)
            {
                dt = dtProductRequirements_view.Copy();
                return dt;
            }
            try
            {
                dt = await GetTableData("order"); // specify table name
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
            dtProductRequirements_view = dt.Copy();
            return dt;
        }

        public async Task<int> UpdateProductRequiremen(DataTable dtUpdated)
        {
            int rowsUpdated = 0;
            try
            {
                rowsUpdated = await UpdateData(dtUpdated, "order", new string[] { "OrderID" }); // specify table name and key column
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return rowsUpdated;
        }

        internal void AddCustomerFilter_view(string? filterColumn, string filterValue)
        {
            throw new NotImplementedException();
        }

        internal DataTable FindOrderByCustomerID_view(string id)
        {
            throw new NotImplementedException();
        }

        internal object GetFilteredOrderData_view()
        {
            throw new NotImplementedException();
        }
        internal void RemoveOrderFilter_view(string v1, string v2)
        {
            throw new NotImplementedException();
        }


        internal async Task<DataRow> GetRequirementById(string id, string idType)
        {
            try
            {
                if (dtProductRequirements_edit == null)
                {
                    DataTable dt = await GetProductRequirements();
                    dtProductRequirements_edit = dt.Copy();
                }
                dtProductRequirements_edit.AcceptChanges();
                DataRow[] orderRecords = null;
                if (dtProductRequirements_edit != null && dtProductRequirements_edit.Rows.Count > 0)
                {
                    if (idType == "Order ID")
                    {
                        orderRecords = dtProductRequirements_edit.Select($"OrderID = '{id}'");
                    }
                    else if (idType == "Customer ID")
                    {
                        orderRecords = dtProductRequirements_edit.Select($"CustomerID = '{id}'");
                    }
                    else
                    {
                        throw new ArgumentException("Invalid ID type specified.");
                    }
                    if (orderRecords.Length > 0)
                    {
                        row_editing = orderRecords[0]; // Store the row being edited
                        return orderRecords[0]; // Return the first matching row
                    }
                }
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException($"Error retrieving product requirements: {ex.Message}", ex);
            }
            return null; // Return null if no matching row is found or an error occurs
        }

        internal async Task<DataRow> GetRequirementByOrderId(string id)
        {
            throw new NotImplementedException();
        }

        internal void endEditRequirement()
        {
            dtProductRequirements_edit = null; // Clear the edit DataTable when editing is done
            row_editing = null; // Clear the editing row
        }

        internal async Task<bool> UpdateRequirement(Dictionary<string, string> updatedFields)
        {   
            if (row_editing == null)
            {
                throw new InvalidOperationException("No row is currently being edited.");
            }
            try
            {
                // Update the row with the new values
                foreach (var field in updatedFields)
                {
                    if (row_editing.Table.Columns.Contains(field.Key))
                    {
                        row_editing[field.Key] = field.Value;
                    }
                    else
                    {
                        throw new ArgumentException($"Column '{field.Key}' does not exist in the DataTable.");
                    }
                }
                // Accept changes to the DataRow
                row_editing.AcceptChanges();
                // Accept changes to the DataTable
                dtProductRequirements_edit.AcceptChanges();

                // Update the DataTable in the API
                int rowsUpdated = await UpdateProductRequiremen(dtProductRequirements_edit);
                if (rowsUpdated > 0)
                {
                    // If the update was successful, refresh the view DataTable
                    dtProductRequirements_view = dtProductRequirements_edit.Copy();
                    return true; // Indicate success
                }
                else
                {
                    throw new InvalidOperationException("Update failed. Please check your input.");
                }
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException($"Error updating requirement: {ex.Message}", ex);
            }
        }

        //
        // Create Requirement
        //
        internal async Task<DataRow> GetProductById(string id)
        {
            try
            {
                if (dtProducts == null)
                {
                    DataTable dt = await GetTableData("product"); // specify table name
                    dtProducts = dt.Copy();
                }
                //Find the product by ID
                DataRow row = dtProducts.Select($"ProductID = '{id}'").FirstOrDefault();
                if (row != null)
                {
                    return row; // Return the found product row
                }
                else
                {
                    throw new KeyNotFoundException($"Product with ID '{id}' not found.");
                }
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException($"Error retrieving product by ID: {ex.Message}", ex);
            }
        }

        internal async Task<DataTable> GetProductsByName(string productName)
        {
            try
            {
                if (dtProducts == null)
                {
                    DataTable dt = await GetTableData("product"); // specify table name
                    dtProducts = dt.Copy();
                }
                // Find products by Name
                DataRow[] rows = dtProducts.Select($"ProductName LIKE '%{productName}%'");
                if (rows.Length > 0)
                {
                    DataTable resultTable = rows.CopyToDataTable(); // Convert the array of DataRows to a DataTable
                    return resultTable; // Return the found products
                }
                else
                {
                    throw new KeyNotFoundException($"No products found with the name '{productName}'.");
                }
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException($"Error retrieving products by name: {ex.Message}", ex);
            }
        }

        internal string GetSaleID()
        {
            string saleID = SystemController.getEmpID(); // Assuming GetEmpID() returns a unique ID for the sale
            return saleID;
        }

        internal async Task<bool> AddProductToRequirement(string? productID, int quantity)
        {   // { "orderline", new string[] { "OrderID", "ProductID", "Qty" } }
            try {
            if (dtOrderLines == null)
            {
                dtOrderLines = await GetEmptyTable("orderline"); // specify table name
            }
            if (string.IsNullOrEmpty(productID) || quantity <= 0)
            {
                throw new ArgumentException("Product ID cannot be null or empty and quantity must be greater than zero.");
            }
          
            
                if (dtOrderLines == null)
                {
                    DataTable dt = await GetTableData("orderline"); // specify table name
                    dtOrderLines = dt.Copy();
                }
                // Create a new DataRow for the order line
                DataRow newRow = dtOrderLines.NewRow();
                newRow["OrderID"] = GetSaleID(); // Assuming GetSaleID() returns the current sale ID
                newRow["ProductID"] = productID;
                newRow["Qty"] = quantity;
                
                // Add the new row to the DataTable
                dtOrderLines.Rows.Add(newRow);
                
                // Accept changes to the DataTable
                dtOrderLines.AcceptChanges();
                return true; // Return true to indicate success 
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException($"Error adding product to requirement: {ex.Message}", ex);
            }
            return false; // Return false if the operation fails
        }
    }
}
