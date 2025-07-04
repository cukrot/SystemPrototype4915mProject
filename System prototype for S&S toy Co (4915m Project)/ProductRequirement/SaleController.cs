using EntityModels;
using Google.Protobuf.WellKnownTypes;
using Newtonsoft.Json.Linq;
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
        DataTable dtProductRequirements_view;
        DataTable dtProductRequirements_edit;
        DataRow row_editing; // This will hold the row being edited
        DataTable dtProducts;

        DataTable dtOrderLines; // Assuming this is used for order lines
        DataTable dtOrderLines_view; // Assuming this is used for viewing order lines
        DataTable dtOrder_create; // Assuming this is used for creating orders
        private double totalPrice; // Assuming this is used to calculate the total price of the order
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
                case 2:
                    CreateRequirement create = new CreateRequirement(this);
                    create.Show();
                    break;
            }
        }
        public async Task<DataTable> GetProductRequirements()
        {
            DataTable dt = null;
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

        internal string AddCustomerFilter_view(string filterColumn, string filterValue, string filterExpression)
        {
            filterExpression = AddFilterItem(filterColumn, filterValue, dtProductRequirements_view.Copy() , filterExpression);
            return filterExpression;
        }

        internal DataTable FindOrderByCustomerID_view(string id, string filterExpression)
        {
            {
                if (string.IsNullOrWhiteSpace(id) || dtProductRequirements_view == null)
                    return null;
                return FindRowsByID(id, dtProductRequirements_view.Copy(), filterExpression);
            }
        }

        internal object GetFilteredOrderData_view(string filterExpression)
        {
            if (dtProductRequirements_view == null) return null;
            return GetFilteredTable(dtProductRequirements_view.Copy(), filterExpression);
        }
        internal string RemoveOrderFilter_view(string v1, string v2, string filterExpression)
        {
            filterExpression = RemoveFilterItem(v1, v2, dtProductRequirements_view.Copy(), filterExpression);
            return filterExpression;
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
            if (row_editing == null ||dtProductRequirements_edit == null)
            {
                throw new InvalidOperationException("No row is currently being edited.");
            }
            try
            {
                dtProductRequirements_edit.AcceptChanges(); // Ensure the DataTable is in a clean state before editing
                foreach (DataColumn col in dtProductRequirements_edit.Columns)
                {
                    col.ReadOnly = false; // Set all columns to ReadOnly
                }                // Update the row with the new values
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
                DataTable dtUpdated = dtProductRequirements_edit.GetChanges();

                // Update the DataTable in the API
                int rowsUpdated = await UpdateProductRequiremen(dtUpdated);
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
        internal async Task<DataRow[]> GetProductById(string id)
        {
            try
            {
                if (dtProducts == null)
                {
                    DataTable dt = await GetTableData("product"); // specify table name
                    dtProducts = dt.Copy();
                }
                //Find the product by ID
                DataRow[] rows = dtProducts.Select($"ProductID LIKE '%{id}%'");
                if (rows != null)
                {
                    return rows; // Return the found product row
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
                DataRow[] rows = dtProducts.Select($"Name LIKE '%{productName}%'");
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

        internal async Task<DataTable> AddProductToRequirement(string? productID, int quantity)
        {   // { "orderline", new string[] { "OrderID", "ProductID", "Qty" } }
            try {
                if (dtOrderLines == null)
                {
                    dtOrderLines = await GetEmptyTable("orderline"); // specify table name
                    dtOrderLines.Rows.Clear(); // Clear any existing rows
                    this.totalPrice = 0; // Reset total price
                }
                if (dtOrderLines_view == null)
                {
                    dtOrderLines_view = new DataTable("OrderLinesView");
                    dtOrderLines_view.Columns.Add("ProductID", typeof(string));
                    dtOrderLines_view.Columns.Add("Name", typeof(string)); // Assuming product name is available
                    dtOrderLines_view.Columns.Add("quantity", typeof(double));
                    dtOrderLines_view.Columns.Add("UnitPrice", typeof(double)); // Assuming unit price is available
                    dtOrderLines_view.Columns.Add("Amount", typeof(double)); // Assuming total price is calculated as Amount
                }
                if (string.IsNullOrEmpty(productID) || quantity <= 0)
                {
                    throw new ArgumentException("Product ID cannot be null or empty and quantity must be greater than zero.");
                }
                foreach (DataColumn col in dtOrderLines.Columns)
                {
                    col.ReadOnly = false; // Set all columns to ReadOnly
                }
                // Create a new DataRow for the order line view
                string productName = dtProducts.Select($"ProductID = '{productID}'").FirstOrDefault()?["Name"].ToString() ?? "Unknown Product";
                double unitPrice = dtProducts.Select($"ProductID = '{productID}'").FirstOrDefault()?["UnitPrice"] is int price ? price : 0;
                double amount = unitPrice * quantity; // Calculate total price based on unit price and quantity
                DataRow newRow = dtOrderLines_view.NewRow();
                newRow["ProductID"] = productID;
                newRow["Name"] = productName; // Assuming the product name is available in the DataTable
                newRow["quantity"] = quantity;
                newRow["UnitPrice"] = unitPrice; // Assuming the unit price is available in the DataTable
                newRow["Amount"] = amount; // Calculate total price
                this.totalPrice += amount; // Update the total price for the order

                // Add the new row to the DataTable
                dtOrderLines_view.Rows.Add(newRow);
                // Accept changes to the DataTable
                dtOrderLines_view.AcceptChanges();
                foreach (DataColumn col in dtOrderLines_view.Columns)
                {
                    col.ReadOnly = true; // Set all columns back to ReadOnly after adding the new row
                }

                // create a orderline
                DataRow orderline = dtOrderLines.NewRow();
                orderline["OrderID"] = "";
                orderline["ProductID"] = productID;
                orderline["Qty"] = quantity; // Set the quantity
                dtOrderLines.Rows.Add(orderline);


                return dtOrderLines_view.Copy(); // Return the updated DataTable with the new order line
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException($"Error adding product to requirement: {ex.Message}", ex);
            }
        }

        internal DataTable RemoveProductFromRequirement(string productID)
        {
            if (dtOrderLines == null)
            {
                throw new InvalidOperationException("Order lines DataTable is not initialized.");
            }
            try
            {
                // Find the row with the specified ProductID
                DataRow[] rowsToRemove = dtOrderLines.Select($"ProductID = '{productID}'");
                DataRow[] rowToRemove_view = dtOrderLines_view.Select($"ProductID = '{productID}'");
                if (rowsToRemove.Length > 0 && rowToRemove_view.Length > 0)
                {
                    // Remove the corresponding row from the view DataTable
                    foreach (DataRow row in rowToRemove_view)
                    {
                        dtOrderLines_view.Rows.Remove(row); // Remove the row from the view DataTable
                    }
                    dtOrderLines_view.AcceptChanges(); // Accept changes to the view DataTable
                    // Remove the order line from the main DataTable
                    
                    foreach (DataRow row in rowsToRemove)
                    {
                        dtOrderLines.Rows.Remove(row); // Remove the row from the DataTable
                    }
                    dtOrderLines.AcceptChanges(); // Accept changes to the DataTable
                }
                else
                {
                    throw new KeyNotFoundException($"No order line found with ProductID '{productID}'.");
                }
                return dtOrderLines_view.Copy(); // Return the updated DataTable
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException($"Error removing product from requirement: {ex.Message}", ex);
            }
        }

        internal async Task<bool> SubmitRequirement(string id)
        {
            if (string.IsNullOrEmpty(id))
            {
                throw new ArgumentException("Invalid Customer ID provided.");
            }
            string[] customerID = new string[] { id }; // Assuming id is the customer ID
            bool isValidCustomerID = await SystemController.vaildifyID("customer", customerID);
            if (!isValidCustomerID)
            {
                throw new ArgumentException("Invalid Customer ID provided.");
            }
            if (dtOrderLines == null || dtOrderLines.Rows.Count == 0)
            {
                throw new InvalidOperationException("No products have been added to the order.");
            }
            try
            {
                if (dtOrder_create == null)
                {
                    dtOrder_create = await GetEmptyTable("order"); // specify table name
                }
                dtOrder_create.Clear(); // Clear any existing rows in the order DataTable
                dtOrder_create.AcceptChanges(); // Accept changes to the DataTable
                // Create a new DataRow for the order
                //{ "order", new string[] { "OrderID", "OrderDate", "Status", "SaleID", "CustomerID", "Amount" } },
                string[] orderColumn = TableColumns.GetColumns("order"); // Get the columns for the order table

                DataRow newOrder = dtOrder_create.NewRow();
                newOrder["OrderID"] = null; //Key must be null for auto-increment
                newOrder["OrderDate"] = DateTime.Today; // Set the current date and time
                newOrder["Status"] = "Pending"; // Set the initial status of the order
                newOrder["SaleID"] = GetSaleID(); // Set the SaleID
                newOrder["CustomerID"] = id; // Set the CustomerID
                newOrder["Amount"] = this.totalPrice; // Set the total price of the order
                dtOrder_create.Rows.Add(newOrder); // Add the new order row to the DataTable
                dtOrder_create.AcceptChanges(); // Accept changes to the DataTable
                dtOrder_create.Rows[0].SetAdded(); // Mark the new row as added

                // Assume Sus=bSystemController has a method to add the order and order lines to the database
                int orderRowsAffected = await InsertOneToManyTables(dtOrder_create, dtOrderLines, "order", "orderline");
                if (orderRowsAffected > 0)
                {
                    return true; // Indicate success
                }
                else
                {
                    throw new InvalidOperationException("Failed to submit the requirement. Please check your input.");
                }
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException($"Error submitting requirement: {ex.Message}", ex);
            }
        }

        internal void CloseProductRequirementPage()
        {
            //close all the open forems related to product requirements
            FormCollection openForms = Application.OpenForms; // Get all open forms in the application
            if (openForms != null)
            {
                foreach (Form form in openForms)
                {
                    if (form is ViewRequirements || form is EditRequirement || form is CreateRequirement)
                    {
                        form.Close(); // Close the form if it matches the specified types
                    }
                }
            }
        }
    }
}
