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
        
        public SubSystemController() { api = companyApi;}
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
        private StringContent convertDataTableToJasonString(DataTable dt, String tableName, String[] keysName)
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

        /*public async Task<int> InsertTableRow(string tableName, DataTable mmptyCustomer, Dictionary<string, string> values) //Useless method, below is the same method with different parameters
        {
            // This method inserts a new row into the specified tableName using the provided values
            // It returns the number of rows affected by the insert operation
            // Also, calls the API to insert the data
            // Endpoint: /api/SnSToyCoTestAPI/InsertTableData
            // Note: The values in key columns are not used in the insert operation, as they are auto-generated or not required for insert
            // As checking has been done in InsertTableRow method, so no need to check again here

        }*/

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
            else if (values.Keys.Any(k => !colsName_noKey.Contains(k) && !keyColumns.Contains(k)))
            {
                throw new ArgumentException("Values contain keys that are not in the specified columns.");
            }
            //Check values in all columns
            foreach (var col in colsName_noKey)
            {
                if (!values.ContainsKey(col) || string.IsNullOrWhiteSpace(values[col]))
                {
                    throw new ArgumentException($"Value for column '{col}' is required.");
                }
            }
            //Check values in key columns
            foreach (var keyCol in keyColumns)
            {
                if (!values.ContainsKey(keyCol) || !string.IsNullOrWhiteSpace(values[keyCol]))
                {
                    throw new ArgumentException($"Value for key column '{keyCol}' should be null or empty.");
                }
            }

            // If all checks passed, proceed to insert the row

            // Get the empty Table from API or predefined columns
            DataTable emptyTable = await GetEmptyTable(v);
            if (emptyTable == null || emptyTable.Columns.Count == 0)
            {
                throw new InvalidOperationException($"No empty table found for the specified table: {v}.");
            }
            // Create a new DataRow and populate it with the values
            DataRow newRow = emptyTable.NewRow();
            foreach (var col in colsName_noKey)
            {
                if (values.ContainsKey(col))
                {
                    newRow[col] = values[col];
                }
            }
            // Add the new row to the DataTable
            emptyTable.Rows.Add(newRow);

            // Insert the DataTable into the database using the API
            int rowsAffected = await InsertTable(emptyTable, v);
            return rowsAffected;
        }

        private async Task<int> InsertTable(DataTable emptyTable, string v)
        {
            int rowsAffected = 0;
            try
            {
                APICaller apiCaller = new APICaller();
                StringContent content = convertDataTableToJasonString(emptyTable);
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
    }
}
