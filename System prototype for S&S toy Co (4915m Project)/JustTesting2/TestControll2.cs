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

namespace System_prototype_for_S_S_toy_Co__4915m_Project_.JustTesting
{
    public class TestControll2 : SubSystemController
    {
        DataTable customer;
        DataColumn[] customerCols;

        // Add keyColumns field and property
        private string[] keyColumns = Array.Empty<string>();
        public string[] KeyColumns
        {
            get => keyColumns;
            set => keyColumns = value ?? Array.Empty<string>();
        }

        // Add constructor overload to accept keyColumns
        public TestControll2() { setApi("/api/SnSToyCoTestAPI/"); }
        public TestControll2(string[] keyColumns)
        {
            setApi("/api/SnSToyCoTestAPI/");
            this.keyColumns = keyColumns ?? Array.Empty<string>();
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
                if (keyColumns != null && customer != null)
                {
                    foreach (var colName in keyColumns)
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
            int rowsUpdated = await UpdateData(dtUpdated, "customer", keyColumns);
            return rowsUpdated;
        }

        public DataColumn[] GetColumns() //Assuming the method returns a list of column names from "customer" table
        {
            if (customer != null && customer.Columns.Count > 0)
            {
                customerCols = customer.Columns.Cast<DataColumn>().ToArray();
                return customerCols;
            }
            else
            {
                throw new Exception("No columns found in the customer DataTable.");
            }
        }

        public DataTable GetFilteredCustomerData()
        {
            if (customer == null) return null;
            return GetFilteredTable(customer);
        }

        public DataTable FindCustomerByID(string id)
        {
            if (string.IsNullOrWhiteSpace(id) || customer == null)
                return null;
            return FindRowsByID(id, customer);
        }
        public void RemoveFilter(string column, string value)
        {
            RemoveFilterItem(column, value, customer);
        }
    }
}
