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
            //check the data type of the first column and set it to a random value
            if (dt.Columns.Count > 0)
            {
                DataColumn firstColumn = dt.Columns[0];
                if (firstColumn.DataType == typeof(int) || firstColumn.DataType == typeof(long))
                {
                    dr[firstColumn] = 1; // Set to 0 for numeric types
                }
                else if (firstColumn.DataType == typeof(string))
                {
                    dr[firstColumn] = "Sample"; // Set to a sample string for string types
                }
                else if (firstColumn.DataType == typeof(DateTime))
                {
                    dr[firstColumn] = DateTime.Now; // Set to current date for DateTime types
                }
            }
            dt.Rows.Add(dr);
            return dt;
        }

        public DataTable GetTableData(String tableName)
        {
            String sqlCmd = $"SELECT * FROM `{tableName}`;";
            return GetData(sqlCmd);
        }

        public int InsertTable(DataTable dtInserted, string tableName, string[] keysName) // Inserts multiple rows into the specified table
        {
            if (dtInserted == null || dtInserted.Rows.Count == 0)
            {
                throw new ArgumentException("The DataTable to insert cannot be null or empty.", nameof(dtInserted));
            }

            //We need to check the table if it has single or multiple keys
            // keysName is an array of key column names
            // If the table has a single key, call InsertDataWithNoKeys
            if (keysName.Length == 1)
            {
                // If the table has a single key, we need to generate the key values for the inserted rows
                dtInserted = getNewKeyValuesForSingleKey(dtInserted, tableName, keysName);
            }
            else if (keysName.Length > 1)
            {
                // If the table has multiple keys, we assume that the keys are already set in the DataTable
                // We do not need to generate new key values
            }
            else
            {
                throw new ArgumentException("The keysName array must contain at least one key column name.", nameof(keysName));
            }

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

        private DataTable getNewKeyValuesForSingleKey(DataTable dtInserted, string tableName, string[] primaryKeys)
        {
            if (dtInserted == null || dtInserted.Rows.Count == 0)
                throw new ArgumentException("The DataTable to insert cannot be null or empty.", nameof(dtInserted));
            if (primaryKeys == null || primaryKeys.Length == 0)
                throw new ArgumentException("primaryKeys must contain at least one key column name.", nameof(primaryKeys));

            string keyName = primaryKeys[0];
            DataColumn keyColumn = dtInserted.Columns[keyName];
            if (keyColumn == null)
                throw new ArgumentException($"Key column '{keyName}' does not exist in the DataTable.", nameof(dtInserted));

            // 取得目前資料庫中最大主鍵值
            DataTable dtLastKey = GetData($"SELECT MAX(`{keyName}`) FROM `{tableName}`;");
            object lastKeyObj = dtLastKey.Rows[0][0];
            string lastKeyStr = lastKeyObj == DBNull.Value ? null : lastKeyObj.ToString();

            if (keyColumn.DataType == typeof(int) || keyColumn.DataType == typeof(long))
            {
                // 處理數字型主鍵
                int lastKey = 0;
                if (!string.IsNullOrEmpty(lastKeyStr))
                    int.TryParse(lastKeyStr, out lastKey);

                foreach (DataRow row in dtInserted.Rows)
                {
                    lastKey++;
                    row[keyName] = lastKey;
                }
            }
            else if (keyColumn.DataType == typeof(string))
            {
                // 處理字串型主鍵（如 CUST001）
                string prefix = "";
                int numericPart = 0;
                int numericLength = 3; // 預設數字長度

                if (!string.IsNullOrEmpty(lastKeyStr))
                {
                    int prefixLength = lastKeyStr.TakeWhile(char.IsLetter).Count();
                    prefix = lastKeyStr.Substring(0, prefixLength);
                    string numericStr = lastKeyStr.Substring(prefixLength);
                    numericLength = numericStr.Length;
                    int.TryParse(numericStr, out numericPart);
                }

                foreach (DataRow row in dtInserted.Rows)
                {
                    numericPart++;
                    string newKey = prefix + numericPart.ToString($"D{numericLength}");
                    row[keyName] = newKey;
                }
            }
            else
            {
                throw new NotSupportedException($"Key column type '{keyColumn.DataType.Name}' is not supported for auto-generation.");
            }

            return dtInserted;
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

        public int InsertOneToManyTables(DataTable dtInsertedOne, DataTable dtInsertedMany, string tableNameOne, string tableNameMany, string singleKey, string[] manyKey)
        {
            if (dtInsertedOne == null || dtInsertedMany == null || string.IsNullOrEmpty(tableNameOne) || string.IsNullOrEmpty(tableNameMany))
            {
                throw new ArgumentException("The DataTables and table names cannot be null or empty.");
            } 

            int rowsInsertedOne = InsertTable(dtInsertedOne, tableNameOne, new string[] { singleKey });
            // As first table is inserted, we can assume that the key values are generated correctly for the second table
            // Assuming that the first table has a single key and the second table has a foreign key referencing the first table
            for (int i = 0; i < dtInsertedMany.Rows.Count; i++)
            {
                // Set the foreign key value in the second table to match the primary key of the first table
                dtInsertedMany.Rows[i][singleKey] = dtInsertedOne.Rows[0][singleKey]; // Assuming singleKey is the primary key of the first table
            }
            int rowsInsertedMany = InsertTable(dtInsertedMany, tableNameMany, manyKey);
            return rowsInsertedMany;
        }

        public int ExecuteNonQuery(string queryString)
        {
            if (string.IsNullOrEmpty(queryString))
            {
                throw new ArgumentException("The query string cannot be null or empty.", nameof(queryString));
            }
            return BatchUpdate(queryString);
        }

        public DataTable ExecuteGetQuery(string queryString)
        {
            if (string.IsNullOrEmpty(queryString))
            {
                throw new ArgumentException("The query string cannot be null or empty.", nameof(queryString));
            }
            return GetData(queryString);
        }
    }
}
