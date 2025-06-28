using EntityModels;
using MySqlX.XDevAPI;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace System_prototype_for_S_S_toy_Co__4915m_Project_.JustTesting
{
    public class TestControll2 : SubSystemController
    {
        DataTable customer;
        private String[] customerColsName = new string[]
        {
            "CustomerID", "Name", "PhoneNum", "Address", "Email"
        };
        private String[] customerColsName_noKey = new string[]
        {
            "Name", "PhoneNum", "Address", "Email"
        };
        private string[] customerKeyColumns = new string[]
        {
            "CustomerID"
        };
        private string customerFilterExpression = string.Empty;

        // Add constructor overload to accept keyColumns
        public TestControll2()
        {
            setApi("/api/SnSToyCoTestAPI/");
        }

        //recommend to see useable api in SubSystemController.cs

        //Useful tips       Useful tips     Useful tips
        //在不同表單中用於按鈕或載入（取得或修改資料）的每個方法中，
        //您只需指定table & keysName，然後呼叫下面的通用方法 GetData() & UpdateData() 即可。
        //這裡有兩個針對 Form2.cs 的範例方法，你可以看到它們是如何運作的

        //通用方法在parent class SubSystemController.cs

        //Methods for Form2.cs
        public async Task<DataTable> GetCustomerData()
        {
            DataTable dt = null;
            try
            {
                dt = await GetTableData("customer"); //specify table name
                customer = dt; //store the DataTable for later use
               
                // Set ReadOnly for key columns
                if (customerKeyColumns != null && customer != null)
                {
                    foreach (var colName in customerKeyColumns)
                    {
                        if (customer.Columns.Contains(colName))
                            customer.Columns[colName].ReadOnly = true;
                    }
                }
                //Or you can use GetData()
                //dt = await GetData("GetTableData", "customer"); //specify endpoint & table name
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return dt;
        }

        public async Task<int> UpdateCustomerDataToAPI(DataTable dtUpdated)
        {
            // Use keyColumns field instead of local variable
            int rowsUpdated = await UpdateData(dtUpdated, "customer", customerKeyColumns);
            return rowsUpdated;
        }

        //
        // Methods for filtering customer data
        //
        public DataTable GetFilteredCustomerData()
        {
            if (customer == null) return null;
            return GetFilteredTable(customer, customerFilterExpression);
        }

        public DataTable FindCustomerByID(string id)
        {
            if (string.IsNullOrWhiteSpace(id) || customer == null)
                return null;
            return FindRowsByID(id, customer, customerFilterExpression);
        }

        public void RemoveCustomerFilter(string column, string value)
        {
            customerFilterExpression = RemoveFilterItem(column, value, customer, customerFilterExpression);
        }

        public void AddCustomerFilter(string column, string value)
        {
            customerFilterExpression = AddFilterItem(column, value, customer, customerFilterExpression);
        }

        public String[] GetCustomerColumns()
        {
            return customerColsName;
        }


        public async void InsertCustomerData(string tableName, string[] values)
        {
            //Anyway, this method is used to insert data into the customer table
            //So no need of keyColumns, as it is not used in the insert operation

            //Get the DataColumns from API or predefined columns
            DataColumn[] columns = await GetCustomerColumns_noKey(tableName);
            if (columns == null || columns.Length == 0) { throw new InvalidOperationException("No columns found for the specified table."); }
            bool result = await InsertTableRow(tableName, columns, values);
        }

        public async Task<bool> InsertTableRow(string tableName, DataColumn[] columns, string[] values)
        {
            // Create a new DataTable with the specified columns
            //By the way, there is only a row of data from the form to insert
            DataTable dt = new DataTable(tableName);
            dt.Columns.AddRange(columns);

            // Create a new DataRow and populate it with the values
            DataRow newRow = dt.NewRow();
            for (int i = 0; i < columns.Length && i < values.Length; i++)
            {
                newRow[columns[i].ColumnName] = values[i];
            }
        }

        private DataColumn[] GetCustomerColumns_noKey(string v)
        {
            //This method should call GetTableColumns_noKey from SubSystemController.cs
            //or you can define the columns manually as below

            //For demonstration, we will create DataColumn array manually with customerColsName
            /*List<DataColumn> columns = new List<DataColumn>();
            foreach (var colName in customerColsName_noKey)
            {
                DataColumn column = new DataColumn(colName);
                if (keyColumns.Contains(colName))
                {
                    column.ReadOnly = true; // Set ReadOnly for key columns
                }
                columns.Add(column);
            }
            return columns.ToArray();*/

            //Or you can use GetTableColumns() method from SubSystemController.cs
            DataColumn[] columns = GetTableColumns(v);
            if (columns == null || columns.Length == 0)
            {
                throw new InvalidOperationException("No columns found for the specified table.");
            }
            return columns;
        }

        private async DataColumn[] GetTableColumns(string v) //It will move to SubSystemController.cs
        {
            //Call the API to get the DataColumns for the specified table
            try
            {
                DataTable dt = await GetData($"GetTableColumns_noKey", v); //specify endpoint & table name
                if (dt == null || dt.Columns.Count == 0)
                {
                    throw new InvalidOperationException($"No columns found for the table: {v}");
                }
                return dt.Columns;
            }
            catch (Exception ex)
            {
                throw new Exception($"Error getting columns for table {v}: {ex.Message}", ex);
            }
        }
    }
}
