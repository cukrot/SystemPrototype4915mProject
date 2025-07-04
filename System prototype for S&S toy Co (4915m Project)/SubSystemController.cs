using EntityModels;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace System_prototype_for_S_S_toy_Co__4915m_Project_
{
    public class SubSystemController
    {
        private String simpleApi = "/api/SimpleGetAPI/";
        private String testApi = "/api/TestAPI/";
        private String companyApi = "/api/SnSToyCoTestAPI/";
        private String api;
        public string filterExpression = string.Empty;
        public List<string> filterList = new();

        public string FilterExpression => filterExpression;

        public IReadOnlyList<string> FilterList => filterList.AsReadOnly();

        public SubSystemController() { api = companyApi; }
        public SubSystemController(String apiString) { this.api = apiString; }
        public void setApi(String apiString) { this.api = apiString; }
        public async Task<DataTable> GetTableData(String tableName)
        {
            DataTable dt = null;
            try
            {
                APICaller apiCaller = new APICaller();
                string jsonTableName = JsonConvert.SerializeObject(tableName, Formatting.Indented);
                StringContent content = new StringContent(jsonTableName, Encoding.UTF8, "application/json");
                String jsonString = await apiCaller.GetApiResponse((api + "GetTableData"), content);
                dt = JsonConvert.DeserializeObject<DataTable>(jsonString);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return dt;
        }
        public async Task<DataTable> GetData(String endpoint, String tableName)
        {
            DataTable dt = null;
            try
            {
                APICaller apiCaller = new APICaller();
                string jsonTableName = JsonConvert.SerializeObject(tableName, Formatting.Indented);
                StringContent content = new StringContent(jsonTableName, Encoding.UTF8, "application/json");
                String jsonString = await apiCaller.GetApiResponse((api + endpoint), content);
                dt = JsonConvert.DeserializeObject<DataTable>(jsonString);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return dt;
        }
        public async Task<DataTable> GetData(String endpoint)
        {
            DataTable dt = null;
            try
            {
                APICaller apiCaller = new APICaller();
                String jsonString = await apiCaller.GetApiResponse(api + endpoint);
                dt = JsonConvert.DeserializeObject<DataTable>(jsonString);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return dt;
        }

        public async Task<int> UpdateData(DataTable dtUpdated, String tableName, String[] keysName)
        {
            APICaller apiCaller = new APICaller();
            try
            {
                // Serialize DataTable to JSON
                StringContent content = convertDataTableToJasonString(dtUpdated, tableName, keysName);

                // Send POST request to the Web API
                //specify endpoint
                int rowsUpdated = await apiCaller.PostAPIResponse((api + "UpdateData"), content);
                return rowsUpdated;
            }
            catch (HttpRequestException e)
            {
                // Log the exception message
                throw e;
            }
            catch (Exception ex)
            {
                // Log any other exceptions
                throw ex;
            }

        }
        public async Task<int> UpdateData(DataTable dtUpdated, String endpoint)
        {
            APICaller apiCaller = new APICaller();
            try
            {
                // Serialize DataTable to JSON
                String tableName = dtUpdated.TableName;
                DataColumn[] keys = dtUpdated.PrimaryKey;
                String[] keysName = new string[keys.Length];
                int i = 0;
                foreach (DataColumn col in keys)
                {
                    keysName[0] = col.ToString();
                    i++;
                }
                StringContent content = convertDataTableToJasonString(dtUpdated, tableName, keysName);

                // Send POST request to the Web API
                //specify endpoint
                int rowsUpdated = await apiCaller.PostAPIResponse((api + endpoint), content);
                return rowsUpdated;
            }
            catch (HttpRequestException e)
            {
                // Log the exception message
                throw e;
            }
            catch (Exception ex)
            {
                // Log any other exceptions
                throw ex;
            }
        }
        public StringContent convertDataTableToJasonString(DataTable dt, String tableName, String[] keysName)
        {
            // Serialize DataTable to JSON
            DataTable dtAdded = dt.GetChanges(DataRowState.Added);
            string jsonAdded = JsonConvert.SerializeObject(dtAdded, Formatting.Indented);
            DataTable dtModified = dt.GetChanges(DataRowState.Modified);
            string jsonModified = JsonConvert.SerializeObject(dtModified, Formatting.Indented);
            DataTable dtDeleted = dt.GetChanges(DataRowState.Deleted);
            string jsonDeleted = JsonConvert.SerializeObject(dtDeleted, Formatting.Indented);
            string jsonTableName = JsonConvert.SerializeObject(tableName, Formatting.Indented);
            string jsonKeysName = JsonConvert.SerializeObject(keysName, Formatting.Indented);

            JsonDataTable jsonDT = new JsonDataTable();
            jsonDT.dtAdded = jsonAdded;
            jsonDT.dtModified = jsonModified;
            jsonDT.dtDeleted = jsonDeleted;
            jsonDT.tableName = jsonTableName;
            jsonDT.keysName = jsonKeysName;
            string jsonString = JsonConvert.SerializeObject(jsonDT);

            StringContent content = new StringContent(jsonString, Encoding.UTF8, "application/json");
            return content;
        }
        private StringContent convertDataTableToJasonString(DataTable dt)
        {
            // Serialize DataTable to JSON
            DataTable dtAdded = dt.GetChanges(DataRowState.Added);
            string jsonAdded = JsonConvert.SerializeObject(dtAdded, Formatting.Indented);
            DataTable dtModified = dt.GetChanges(DataRowState.Modified);
            string jsonModified = JsonConvert.SerializeObject(dtModified, Formatting.Indented);
            DataTable dtDeleted = dt.GetChanges(DataRowState.Deleted);
            string jsonDeleted = JsonConvert.SerializeObject(dtDeleted, Formatting.Indented);

            JsonDataTable jsonDT = new JsonDataTable();
            jsonDT.dtAdded = jsonAdded;
            jsonDT.dtModified = jsonModified;
            jsonDT.dtDeleted = jsonDeleted;
            string jsonString = JsonConvert.SerializeObject(jsonDT);

            StringContent content = new StringContent(jsonString, Encoding.UTF8, "application/json");
            return content;
        }

        public void ClearFilter()
        {
            filterExpression = string.Empty;
            filterList.Clear();
        }





        public DataTable FindRowsByID(string id, DataTable dt)
        {
            string idColumn = dt.Columns[0].ColumnName;
            ClearFilter();

            filterExpression = $"{idColumn} LIKE '%{id.Replace("'", "''")}%'";

            filterList.Clear();
            filterList.Add($"{idColumn}: {id}");

            return GetFilteredTable(dt);
        }



        public void RemoveFilterItem(string column, string value, DataTable dt)
        {
            string filterItem = $"{column}: {value}";
            if (filterList.Contains(filterItem))
            {
                filterList.Remove(filterItem);
                // 重新組合 filterExpression
                filterExpression = string.Join(" AND ",
                    filterList.Select(f =>
                    {
                        var parts = f.Split(':');
                        var colName = parts[0].Trim();
                        var val = parts[1].Trim();
                        var col = dt?.Columns[colName];
                        if (col != null && col.DataType == typeof(string))
                            return $"{colName} = '{val.Replace("'", "''")}'";
                        else
                            return $"{colName} = {val}";
                    }));
            }
        }

        public void AddFilterItem(string column, string value, DataTable dt)
        {
            if (!string.IsNullOrEmpty(filterExpression))
                filterExpression += " AND ";

            var col = dt?.Columns[column];
            if (col != null && col.DataType == typeof(string))
            {
                filterExpression += $"{column} LIKE '%{value.Replace("'", "''")}%'";
            }
            else
                filterExpression += $"{column} = {value}";

            filterList.Add($"{column}: {value}");
        }
        public DataTable GetFilteredTable(DataTable dt)
        {
            DataView dv = new DataView(dt);
            dv.RowFilter = filterExpression;
            return dv.ToTable();
        }

        public DataTable GetFilteredTable(DataTable customer, string customerFilterExpression)
        {
            if (string.IsNullOrEmpty(customerFilterExpression) || customer == null)
                return customer;
            DataView dv = new DataView(customer);
            dv.RowFilter = customerFilterExpression;
            return dv.ToTable();
        }

        public DataTable FindRowsByID(string id, DataTable customer, string ilterExpression)
        {
            if (string.IsNullOrWhiteSpace(id) || customer == null)
                return null;
            string idColumn = customer.Columns[0].ColumnName;
            ClearFilter();
            filterExpression = $"{idColumn} LIKE '%{id.Replace("'", "''")}%'";
            filterList.Clear();
            filterList.Add($"{idColumn}: {id}");
            return GetFilteredTable(customer, filterExpression);
        }

        public string RemoveFilterItem(string column, string value, DataTable customer, string filterExpression)
        {
            string filterItem = $"{column}: {value}";
            if (filterList.Contains(filterItem))
            {
                filterList.Remove(filterItem);
                // 重新組合 filterExpression
                filterExpression = string.Join(" AND ",
                    filterList.Select(f =>
                    {
                        var parts = f.Split(':');
                        var colName = parts[0].Trim();
                        var val = parts[1].Trim();
                        var col = customer?.Columns[colName];
                        if (col != null && col.DataType == typeof(string))
                            return $"{colName} = '{val.Replace("'", "''")}'";
                        else
                            return $"{colName} = {val}";
                    }));
            }
            return filterExpression;
        }

        public string AddFilterItem(string column, string value, DataTable customer, string filterExpression)
        {
            if (!string.IsNullOrEmpty(filterExpression))
                filterExpression += " AND ";
            var col = customer?.Columns[column];
            if (col != null && col.DataType == typeof(string))
            {
                filterExpression += $"{column} LIKE '%{value.Replace("'", "''")}%'";
            }
            else
                filterExpression += $"{column} = {value}";
            filterList.Add($"{column}: {value}");
            return filterExpression;
        }

        public async Task<DataTable> GetEmptyTable(string tableName)
        {
            // This method retrieves an empty DataTable with the specified tableName from the API
            DataTable dt = null;
            try
            {
                APICaller apiCaller = new APICaller();
                string jsonTableName = JsonConvert.SerializeObject(tableName, Formatting.Indented);
                StringContent content = new StringContent(jsonTableName, Encoding.UTF8, "application/json");
                String jsonString = await apiCaller.GetApiResponse((api + "GetEmptyTable"), content);
                dt = JsonConvert.DeserializeObject<DataTable>(jsonString);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return dt;
        }

        public async Task<int> InsertTableRow(string v, Dictionary<string, string> values, string[] colsName_noKey, string[] keyColumns)
        {
            //Check if the values contain all columns(All columns are required for insert operation), also check if the values contain the key columns
            // Note that vaules in keyColumns should be null or empty, as they are auto-generated or not required for insert operation
            if (values == null || values.Count == 0 || colsName_noKey == null || colsName_noKey.Length == 0 || keyColumns == null || keyColumns.Length == 0)
            {
                throw new ArgumentException("Values or column names cannot be null or empty.");
            }
            else if (values.Count < colsName_noKey.Length + keyColumns.Length)
            {
                throw new ArgumentException("Not enough values provided for the insert operation.");
            }
            else if (values.Count > colsName_noKey.Length + keyColumns.Length)
            {
                throw new ArgumentException("Too many values provided for the insert operation.");
            }
            //Check values in all columns
            foreach (var col in colsName_noKey)
            {
                if (!values.Keys.Any(k => string.Equals(k, col, StringComparison.OrdinalIgnoreCase))
                    || string.IsNullOrWhiteSpace(values.FirstOrDefault(kv => string.Equals(kv.Key, col, StringComparison.OrdinalIgnoreCase)).Value))
                {
                    throw new ArgumentException($"Value for column '{col}' is required.");
                }
            }
            //Check values in key columns
            foreach (var keyCol in keyColumns)
            {
                if (!values.Keys.Any(k => string.Equals(k, keyCol, StringComparison.OrdinalIgnoreCase))
                    || !string.IsNullOrWhiteSpace(values.FirstOrDefault(kv => string.Equals(kv.Key, keyCol, StringComparison.OrdinalIgnoreCase)).Value))
                {
                    throw new ArgumentException($"Value for key column '{keyCol}' should be null or empty.");
                }
            }

            // If all checks passed, proceed to insert the row
            int rowsAffected = 0;
            try { rowsAffected = await InsertTable(v, colsName_noKey, values, keyColumns); }
            catch (HttpRequestException e)
            {
                throw e;
            }
            return rowsAffected;
        }

        private async Task<int> InsertTable(string v, string[] colsName_noKey, Dictionary<string, string> values, string[] keys)
        {
            // Get the empty Table from API or predefined columns
            DataTable newTable = await GetEmptyTable(v);
            if (newTable.Columns.Count == 0)
            {
                throw new InvalidOperationException($"No empty table found for the specified table: {v}.");
            }
            //Clear any existing rows in the DataTable
            newTable.Clear();
            // Create a new DataRow and populate it with the values
            DataRow newRow = newTable.NewRow();
            foreach (var col in colsName_noKey)
            {
                if (values.Keys.Any(k => string.Equals(k, col, StringComparison.OrdinalIgnoreCase)))
                {
                    newRow[col] = values[col];
                }
            }
            // Add the new row to the DataTable
            newTable.Rows.Add(newRow);
            // Accept changes to the DataTable
            newTable.AcceptChanges(); // This is optional, as we are inserting a new row
            newRow.SetAdded();
            // Insert the DataTable into the database using the API
            int rowsAffected = 0;
            try
            {
                APICaller apiCaller = new APICaller();
                //StringContent content = convertDataTableToJasonString(emptyTable);
                // Serialize DataTable to JSON by below method
                StringContent content = convertDataTableToJasonString(newTable, v, keys);
                // Send POST request to the Web API
                rowsAffected = await apiCaller.PostAPIResponse((api + "InsertTableData"), content);
            }
            catch (HttpRequestException e)
            {
                // Log the exception message
                throw e;
            }
            catch (Exception ex)
            {
                // Log any other exceptions
                throw ex;
            }
            return rowsAffected;
        }

        // So, there are a few tables need composite key columns, so we need to pass the key columns as well
        public async Task<int> InsertTableRowWithKeys(string tableName, Dictionary<string, string> values, string[] colsName_noKey, string[] keyColumns)
        {
            // This method inserts a new row into the specified tableName using the provided values
            // It returns the number of rows affected by the insert operation
            // Also, calls the API to insert the data
            // Endpoint: /api/SnSToyCoTestAPI/InsertTableData
            // Note: The values in key columns are not used in the insert operation, as they are auto-generated or not required for insert operation

            // There are a few checks to be done before inserting the data
            if (values == null || values.Count == 0 || colsName_noKey == null || colsName_noKey.Length == 0 || keyColumns == null || keyColumns.Length == 0)
            {
                throw new ArgumentException("Values or column names cannot be null or empty.");
            }
            else if (values.Count < colsName_noKey.Length + keyColumns.Length)
            {
                throw new ArgumentException("Not enough values provided for the insert operation.");
            }
            else if (values.Count > colsName_noKey.Length + keyColumns.Length)
            {
                throw new ArgumentException("Too many values provided for the insert operation.");
            }
            //Check values in all columns
            foreach (var col in colsName_noKey)
            {
                if (!values.Keys.Any(k => string.Equals(k, col, StringComparison.OrdinalIgnoreCase))
                    || string.IsNullOrWhiteSpace(values.FirstOrDefault(kv => string.Equals(kv.Key, col, StringComparison.OrdinalIgnoreCase)).Value))
                {
                    throw new ArgumentException($"Value for column '{col}' is required.");
                }
            }
            //No need to validate values in key columns, though they should exist or not in the database, also they should be null or empty, as they are auto-generated or not required for insert operation
            //So, we will not check the values in key columns, as they are not required for insert operation
            int rowsAffected = 0;
            try { rowsAffected = await InsertTable(tableName, colsName_noKey, values, keyColumns); }
            catch (HttpRequestException e)
            {
                throw e;
            }
            return rowsAffected;
        }

        public async Task<int> InsertOneToManyTables(DataTable dtOne, DataTable dtMany, string v1, string v2)
        {
            // This method inserts a new row into the specified tableName using the provided values
            // It returns the number of rows affected by the insert operation
            // Also, calls the API to insert the data
            // Endpoint: /api/SnSToyCoTestAPI/InsertTableData
            // Note: The values in key columns are not used in the insert operation, as they are auto-generated or not required for insert operation
            if (dtOne == null || dtMany == null)
            {
                throw new ArgumentException("DataTables cannot be null.");
            }
            if (dtOne.Columns.Count == 0 || dtMany.Columns.Count == 0)
            {
                throw new ArgumentException("DataTables cannot be empty.");
            }
            int rowsAffected = 0;
            try
            {
                APICaller apiCaller = new APICaller();
                StringContent content = convertDataTableToJasonString(dtOne, dtMany, v1, v2);
                // Send POST request to the Web API
                rowsAffected = await apiCaller.PostAPIResponse((api + "InsertOneToManyTable"), content);
            }
            catch (HttpRequestException e)
            {
                throw e;
            }
            return rowsAffected;
        }

        private StringContent convertDataTableToJasonString(DataTable dtOne, DataTable dtMany, string v1, string v2)
        {
            DataTable dtAdded = dtOne.GetChanges(DataRowState.Added);
            string jsonAdded = JsonConvert.SerializeObject(dtAdded, Formatting.Indented);
            DataTable dtModified = dtOne.GetChanges(DataRowState.Modified);
            string jsonModified = JsonConvert.SerializeObject(dtModified, Formatting.Indented);
            DataTable dtDeleted = dtOne.GetChanges(DataRowState.Deleted);
            string jsonDeleted = JsonConvert.SerializeObject(dtDeleted, Formatting.Indented);
            string jsonTableName = JsonConvert.SerializeObject(v1, Formatting.Indented);

            DataTable dtManyAdded = dtMany.GetChanges(DataRowState.Added);
            string jsonManyAdded = JsonConvert.SerializeObject(dtManyAdded, Formatting.Indented);
            DataTable dtManyModified = dtMany.GetChanges(DataRowState.Modified);
            string jsonManyModified = JsonConvert.SerializeObject(dtManyModified, Formatting.Indented);
            DataTable dtManyDeleted = dtMany.GetChanges(DataRowState.Deleted);
            string jsonManyDeleted = JsonConvert.SerializeObject(dtManyDeleted, Formatting.Indented);
            string jsonManyTableName = JsonConvert.SerializeObject(v2, Formatting.Indented);

            JsonDataTable jsonDT = new JsonDataTable();
            jsonDT.dtAdded = jsonAdded;
            jsonDT.dtModified = jsonModified;
            jsonDT.dtDeleted = jsonDeleted;
            jsonDT.tableName = jsonTableName;
            jsonDT.keysName = "";

            JsonDataTable JasonTableMany = new JsonDataTable();
            JasonTableMany.dtAdded = jsonManyAdded;
            JasonTableMany.dtModified = jsonManyModified;
            JasonTableMany.dtDeleted = jsonManyDeleted;
            JasonTableMany.tableName = jsonManyTableName;
            JasonTableMany.keysName = "";

            //JsonDataTable[] jsonDataTables = new JsonDataTable[] { jsonDT, JasonTableMany };
            ManyJasonTable manyJasonTable = new ManyJasonTable();
            manyJasonTable.singleKeyTable = jsonDT;
            manyJasonTable.manyKeyTable = JasonTableMany;

            string jsonString = JsonConvert.SerializeObject(manyJasonTable, Formatting.Indented);

            StringContent content = new StringContent(jsonString, Encoding.UTF8, "application/json");
            return content;
        }

        public async Task<int> InsertTable(DataTable dataTable, string tableName, string[] keyNames)
        {
            int rowsAffected = 0;
            try
            {
                APICaller apiCaller = new APICaller();
                //StringContent content = convertDataTableToJasonString(emptyTable);
                // Serialize DataTable to JSON by below method
                StringContent content = convertDataTableToJasonString(dataTable, tableName, new string[] { "InwardID" }); // Specify the table name and primary key column
                // Send POST request to the Web API
                rowsAffected = await apiCaller.PostAPIResponse((api + "InsertTableData"), content);
            }
            catch (HttpRequestException e)
            {
                // Log the exception message
                throw e;
            }
            catch (Exception ex)
            {
                // Log any other exceptions
                throw ex;
            }
            return rowsAffected;
        }

        public async Task<bool> UpdateDataWithARow(string tableName, string[] keyColumns, Dictionary<string, string> keyValuePairs, DataRow dr)
        {
            // Get column names from the DataRow
            string[] columns = dr.Table.Columns.Cast<DataColumn>().Select(c => c.ColumnName).ToArray();
            // Assuming keyValuePairs contains less than or equal to the number of columns in the DataRow
            if (keyValuePairs.Count > columns.Length)
            {
                throw new ArgumentException("Too many key-value pairs provided for the DataRow.", nameof(keyValuePairs));
            }
            // Update the DataRow with the provided key-value pairs
            try
            {
                foreach (var kvp in keyValuePairs)
                {
                    if (columns.Contains(kvp.Key))
                    {
                        dr[kvp.Key] = kvp.Value; // Update the DataRow with the value from the dictionary
                    }
                    else
                    {
                        throw new ArgumentException($"Column '{kvp.Key}' does not exist in the DataRow.", nameof(kvp));
                    }
                }
                // Convert the DataRow to a DataTable and update the database
                DataTable dt = dr.Table;
                if (dt == null || dt.Rows.Count == 0)
                {
                    throw new InvalidOperationException("DataRow is empty or not associated with a DataTable.");
                }
                // As we have table name, we can call the base method to update the DataTable in the database
                int rowsAffected = await UpdateData(dt, tableName, keyColumns);
                return rowsAffected > 0; // Return true if at least one row was updated
            }
            catch (Exception ex)
            {
                throw new Exception("Error updating DataRow.", ex);
            }
        }

        public async Task<bool> InsertDataWithARow(string tableName, string[] keyColumn, Dictionary<string, string> userInfo)
        {
            // This method inserts a new row into the specified tableName using the provided values
            // It returns true if the insert operation was successful, otherwise false
            // Also, calls the API to insert the data
            // Endpoint: /api/SnSToyCoTestAPI/InsertTableData
            // Note: The values in key columns are not used in the insert operation, as they are auto-generated or not required for insert operation
            // There are a few checks to be done before inserting the data
            if (userInfo == null || userInfo.Count == 0 || keyColumn == null || keyColumn.Length == 0)
            {
                throw new ArgumentException("User information or key columns cannot be null or empty.");
            }

            int rowsAffected = 0;
            //get the empty table from the API
            DataTable emptyTable = await GetEmptyTable(tableName);
            if (emptyTable == null || emptyTable.Columns.Count == 0)
            {
                throw new InvalidOperationException($"No empty table found for the specified table: {tableName}.");
            }
            //Clear any existing rows in the DataTable
            emptyTable.AcceptChanges();
            foreach (DataRow row in emptyTable.Rows)
            {
                row.Delete(); // Delete existing rows if any
            }
            emptyTable.AcceptChanges(); // Accept changes to clear the DataTable

            // Create a new DataRow and populate it with the values except key columns
            DataRow newRow = emptyTable.NewRow();
            foreach (var kvp in userInfo)
            {
                if (emptyTable.Columns.Contains(kvp.Key) && !keyColumn.Contains(kvp.Key)) // Check if the column exists and is not a key column
                {
                    newRow[kvp.Key] = kvp.Value; // Set the value for the column
                }
                else if (keyColumn.Contains(kvp.Key) && string.IsNullOrWhiteSpace(kvp.Value))
                {
                    newRow[kvp.Key] = DBNull.Value; // Set key columns to DBNull if they are empty or null
                    //set the key columns to Primary key if they are not already set
                    if (!emptyTable.PrimaryKey.Contains(emptyTable.Columns[kvp.Key]))
                    {
                        emptyTable.PrimaryKey = emptyTable.Columns.Cast<DataColumn>().Where(c => keyColumn.Contains(c.ColumnName)).ToArray();
                    }

                }
            }

            // Add the new row to the DataTable
            emptyTable.Rows.Add(newRow);
            // Accept changes to the DataTable
            emptyTable.AcceptChanges(); // This is optional, as we are inserting a new row
            newRow.SetAdded(); // Mark the new row as added

            // Insert the DataTable into the database using the API
            try
            {
                APICaller apiCaller = new APICaller();
                // Serialize DataTable to JSON by below method
                StringContent content = convertDataTableToJasonString(emptyTable, tableName, keyColumn);
                // Send POST request to the Web API
                rowsAffected = await apiCaller.PostAPIResponse((api + "InsertTableData"), content);
            }
            catch (HttpRequestException e)
            {
                // Log the exception message
                throw e;
            }
            catch (Exception ex)
            {
                // Log any other exceptions
                throw ex;
            }


            return rowsAffected > 0; // Return true if at least one row was inserted successfully
        }
        // This class is a placeholder for database connection logic.
        public async Task<DataTable> GetDataBySql(string sql)
        {
            APICaller apiCaller = new APICaller();

            try
            {
                
                // Assuming APICaller has a method to execute SQL queries and return DataTable
                DataTable result = await apiCaller.ExecuteGetTableQuery((api + "ExecuteGetQuery"), sql);
                return result;
            }
            catch (Exception ex)
            {
                // Handle exceptions, log errors, etc.
                Console.WriteLine($"Error executing SQL: {ex.Message}");
                return null; // or throw the exception based on your error handling strategy
            }
        }

        public void BatchUpdate(string sql)
        {
            APICaller apiCaller = new APICaller();
            try
            {
                // Assuming APICaller has a method to execute SQL commands without returning data
                apiCaller.ExecuteNonQuery((api + "ExecuteNonQuery"), sql); 
            }
            catch (Exception ex)
            {
                // Handle exceptions, log errors, etc.
                Console.WriteLine($"Error executing batch update: {ex.Message}");
            }
        }
        
    }
}
