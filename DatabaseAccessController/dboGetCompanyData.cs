using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseAccessController
{
    public class dboGetCompanyData : dboDatabaseController
    {
        Dictionary<string, string[]> primaryKeys = new Dictionary<string, string[]>
        {
            { "customer", new[] { "CustomerID" } },
            { "delivery", new[] { "DeliveryID" } },
            { "employee", new[] { "EmployeeID" } },
            { "file", new[] { "FileID" } },
            { "ingredient", new[] { "MaterialID" } },
            { "material", new[] { "MaterialID" } },
            { "meeting", new[] { "MeetingID" } },
            { "meetingparticipant", new[] { "MeetingID", "EmpID" } },
            { "order", new[] { "OrderID" } },
            { "orderline", new[] { "OrderID", "ProductID" } },
            { "payment", new[] { "PaymentID" } },
            { "product", new[] { "ProductID" } },
            { "productinventory", new[] { "ProductID", "WarehouseID" } },
            { "productorder", new[] { "POrderID" } },
            { "purchase", new[] { "PurchaseID" } },
            { "purchaseline", new[] { "PurchaseID", "SupplierID", "MaterialID" } },
            { "supplier", new[] { "SupplierID" } },
            { "warehouse", new[] { "WarehouseID" } }
        };
        public dboGetCompanyData(string connectionString) : base(connectionString)
        {
        }

        public DataTable GetAllCustomerData()
        {
            String sqlCmd = "SELECT * FROM customers";
            return GetData(sqlCmd);
        }

        public DataTable GetEmptyTable(string tableName)
        {
            // This method retrieves the structure of the specified table without any data.
            String sqlCmd = $"SELECT * FROM `{tableName}` WHERE 1=0;"; // This will return an empty result set with the table structure
            DataTable dt = GetData(sqlCmd);
            // Stuff a meaningful row into the DataTable to ensure it has columns
            DataRow dr = dt.NewRow();
            dr[0] = "Null";
            dt.Rows.Add(dr);
            return dt;
        }

        public DataTable GetTableData(String tableName)
        {
            String sqlCmd = $"SELECT * FROM `{tableName}`;";
            return GetData(sqlCmd);
        }

        public int InsertTable(DataTable dtInserted, string tableName) // Inserts multiple rows into the specified table
        {
            if (dtInserted == null || dtInserted.Rows.Count == 0)
            {
                throw new ArgumentException("The DataTable to insert cannot be null or empty.", nameof(dtInserted));
            }

            //We need to check the table if it has single or multiple keys
            // If the table has a single key, call InsertDataWithNoKeys
            if (primaryKeys.ContainsKey(tableName) && primaryKeys[tableName].Length == 1)
                // If the table has a single key, check if the key column values are null or empty, then generate new key values
                dtInserted = getNewKeyValuesForSingleKey(dtInserted, tableName);

            return InsertDataWithKey(dtInserted, tableName);
        }

        private int InsertDataWithKey(DataTable dtInserted, string tableName)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append($"INSERT INTO `{tableName}` (");
            sb.Append(string.Join(", ", dtInserted.Columns.Cast<DataColumn>().Select(col => $"`{col.ColumnName}`")));
            sb.Append(") VALUES ");

            var valueRows = new List<string>();
            foreach (DataRow row in dtInserted.Rows)
            {
                var values = dtInserted.Columns.Cast<DataColumn>()
                    .Select(col => $"'{row[col].ToString().Replace("'", "''")}'");
                valueRows.Add("(" + string.Join(", ", values) + ")");
            }
            sb.Append(string.Join(", ", valueRows));
            sb.Append(";");

            return BatchUpdate(sb.ToString());
        }

        private DataTable getNewKeyValuesForSingleKey(DataTable dtInserted, string tableName)
        {
            //first check if values in key column in the inserted table is null or empty string, else throw exception
            //primaryKeys[tableName] is the name of the key columns for the table
            //Assuming only one key column exists in the table
            if (primaryKeys.ContainsKey(tableName) && primaryKeys[tableName].Length == 1)
            {
                string keyColumn = primaryKeys[tableName][0];
                foreach (DataRow row in dtInserted.Rows)
                {
                    if (row[keyColumn] != DBNull.Value && !string.IsNullOrEmpty(row[keyColumn].ToString()))
                    {
                        throw new ArgumentException($"The key column '{keyColumn}' must be null or empty for insertion into '{tableName}'.", nameof(dtInserted));
                    }
                }
            }

            //Generate key values for the key columns
            //As key value is a string like "CUST001" or "ORD0001, we need to get the last value from the database by calling GetData method
            string keyName = primaryKeys[tableName][0];
            DataTable dtLastKey = GetData($"SELECT MAX(`{keyName}`) FROM `{tableName}`;");
            string lastKey = dtLastKey.Rows[0][0]?.ToString(); // Get the last key value from the database

            int prefixLength = 0;
            int numericPartLength = 0;
            if (string.IsNullOrEmpty(lastKey))
            {
                lastKey = "000"; // Start from 000 if no previous key exists
            }
            else
            {
                // Check number of aphabetical prefix and numeric suffix
                prefixLength = lastKey.TakeWhile(char.IsLetter).Count(); // Count letters at the start
                numericPartLength = lastKey.Length - prefixLength; // Remaining part is numeric

                // Now we can increment the numeric part
                if (numericPartLength < 3)
                {
                    throw new ArgumentException($"The key value '{lastKey}' is not in the expected format with at least 3 digits after the prefix.", nameof(dtInserted));
                }
                // Increment the numeric part
                lastKey = lastKey.Substring(0, prefixLength) + (int.Parse(lastKey.Substring(prefixLength)) + 1).ToString("D3"); // Increment the numeric part

            }
            // Assign the new key value to the key column in the inserted DataTable
            foreach (DataRow row in dtInserted.Rows)
            {
                row[keyName] = lastKey; // Assign the new key value
                lastKey = lastKey.Substring(0, prefixLength) + (int.Parse(lastKey.Substring(prefixLength)) + 1).ToString("D3"); // Increment for the next row
            }

            return dtInserted; // Return the modified DataTable with new key values
        }



        public DataTable SearchData(string filterString)
        {
            String sqlCmd = "SELECT * FROM customers WHERE " + filterString + ";";
            return GetData(sqlCmd);
        }

        public int UpdateCustomerData(DataTable dtUpdated)
        {
            StringBuilder sb = new StringBuilder();

            foreach (DataRow row in dtUpdated.Rows)
            {
                sb.Append($"UPDATE `customers` SET ");
                sb.Append($"`customerName` = '{row["customerName"]}', ");
                sb.Append($"`contactLastName` = '{row["contactLastName"]}', ");
                sb.Append($"`contactFirstName` = '{row["contactFirstName"]}', ");
                sb.Append($"`phone` = '{row["phone"]}', ");
                sb.Append($"`addressLine1` = '{row["addressLine1"]}', ");
                sb.Append($"`addressLine2` = '{row["addressLine2"]}', ");
                sb.Append($"`city` = '{row["city"]}', ");
                sb.Append($"`state` = '{row["state"]}', ");
                sb.Append($"`postalCode` = '{row["postalCode"]}', ");
                sb.Append($"`country` = '{row["country"]}', ");
                sb.Append($"`salesRepEmployeeNumber` = {row["salesRepEmployeeNumber"]}, ");
                sb.Append($"`creditLimit` = {row["creditLimit"]} ");
                sb.Append($"WHERE `customerNumber` = {row["customerNumber"]}; ");
            }

            return BatchUpdate(sb.ToString());
        }
        public int UpdateCustomerDataTest(DataTable dtUpdated)
        {
            StringBuilder sb = new StringBuilder();

            foreach (DataRow row in dtUpdated.Rows)
            {
                sb.Append($"UPDATE `customers` SET ");
                bool firstColumn = true;
                foreach (DataColumn col in dtUpdated.Columns)
                {
                    // 跳過 customerNumber 欄位
                    if (col.ColumnName == "customerNumber")
                        continue;

                    if (!firstColumn)
                        sb.Append(", ");
                    sb.Append($"`{col.ColumnName}` = '{row[col]}'");
                    firstColumn = false;
                }
                sb.Append($"WHERE `customerNumber` = {row["customerNumber"]}; ");
            }

            return BatchUpdate(sb.ToString());
        }
        public int UpdateTable(DataTable dtUpdated, String tableName, String[] keysName)
        {
            StringBuilder sb = new StringBuilder();

            foreach (DataRow row in dtUpdated.Rows)
            {
                sb.Append($"UPDATE `{tableName}` SET ");
                bool firstColumn = true;
                foreach (DataColumn col in dtUpdated.Columns)
                {
                    // 構建 SET 子句，排除 keysName 中的欄位
                    if (keysName.Contains(col.ColumnName, StringComparer.OrdinalIgnoreCase))
                        continue;

                    if (!firstColumn)
                        sb.Append(", ");
                    sb.Append($"`{col.ColumnName}` = '{row[col]}'");
                    firstColumn = false;
                }
                // 構建 WHERE 子句，使用 keysName
                sb.Append(" WHERE ");
                for (int i = 0; i < keysName.Length; i++)
                {
                    if (i > 0)
                        sb.Append(" AND ");
                    sb.Append($"`{keysName[i]}` = '{row[keysName[i]]}'");
                }
                sb.Append(";");
            }

            return BatchUpdate(sb.ToString());
        }
    }
}
