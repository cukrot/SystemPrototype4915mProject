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

        public DataTable GetFilteredTable(DataTable dt)
        {
            DataView dv = new DataView(dt);
            dv.RowFilter = filterExpression;
            return dv.ToTable();
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
    }
}
