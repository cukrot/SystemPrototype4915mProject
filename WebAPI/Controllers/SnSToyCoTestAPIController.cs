using EntityModels;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Data;
using DatabaseAccessController;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SnSToyCoTestAPIController : Controller
    {
        private readonly IConfiguration _configuration;
        public SnSToyCoTestAPIController(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        [HttpGet("GetCustomerData")]
        public String GetCustomerData()
        {
            dboGetCompanyData dboGetCompanyData = new dboGetCompanyData(_configuration["ConnectionStrings_of_snstoycotest"]);
            DataTable dtResult = dboGetCompanyData.GetTableData("customer");

            // Convert DataTable to JSON string
            string jsonString = JsonConvert.SerializeObject(dtResult);

            // Return JSON string
            return jsonString;
        }

        [HttpPost("UpdateCustomerData")]
        public int UpdateCustomerData([FromBody] JsonDataTable json)
        {
            try
            {
                DataTable dtUpdated = JsonConvert.DeserializeObject<DataTable>(json.dtModified);

                dboGetCompanyData dboGetCompanyData = new dboGetCompanyData(_configuration["ConnectionStrings_of_snstoycotest"]);
                String[] keyname = { "CustomerID" };
                int rowsUpdated = dboGetCompanyData.UpdateTable(dtUpdated, "customer", keyname);
                return rowsUpdated;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        [HttpPost("UpdateData")]
        public int UpdateData([FromBody] JsonDataTable json)
        {
            try
            {
                DataTable dtInserted = JsonConvert.DeserializeObject<DataTable>(json.dtAdded);
                DataTable dtUpdated = JsonConvert.DeserializeObject<DataTable>(json.dtModified);
                String tableName = JsonConvert.DeserializeObject<String>(json.tableName);
                String[] keysName = JsonConvert.DeserializeObject<String[]>(json.keysName);

                dboGetCompanyData dboGetCompanyData = new dboGetCompanyData(_configuration["ConnectionStrings_of_snstoycotest"]);
                int rowsUpdated = 0;
                if (dtUpdated != null)
                    rowsUpdated = dboGetCompanyData.UpdateTable(dtUpdated, tableName, keysName);
                if (dtInserted != null)
                    rowsUpdated = dboGetCompanyData.InsertTable(dtInserted, tableName, keysName);
                return rowsUpdated;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        [HttpPost("GetTableData")]
        public string UpdateData([FromBody] String tableName)
        {
            try
            {
                dboGetCompanyData dboGetCompanyData = new dboGetCompanyData(_configuration["ConnectionStrings_of_snstoycotest"]);
                DataTable dtResult = dboGetCompanyData.GetTableData(tableName);
                dtResult.TableName = tableName; // Set the table name for clarity
                // Convert DataTable to JSON string
                string jsonString = JsonConvert.SerializeObject(dtResult);

                // Return JSON string
                return jsonString;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpPost("InsertTableData")]
        public int InsertTableData([FromBody] JsonDataTable json)
        {
            try
            {
                DataTable dtInserted = JsonConvert.DeserializeObject<DataTable>(json.dtAdded);
                String tableName = JsonConvert.DeserializeObject<String>(json.tableName);
                string[] keysName = JsonConvert.DeserializeObject<String[]>(json.keysName);
                dboGetCompanyData dboGetCompanyData = new dboGetCompanyData(_configuration["ConnectionStrings_of_snstoycotest"]);
                int rowsInserted = dboGetCompanyData.InsertTable(dtInserted, tableName, keysName);
                return rowsInserted;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        [HttpPost("InsertOneToManyTable")]
        public int InsertOneToManyTables([FromBody] ManyJasonTable jasonTables)
        {
            try
            {
                DataTable dtInsertedOne = JsonConvert.DeserializeObject<DataTable>(jasonTables.singleKeyTable.dtAdded);
                String tableNameOne = JsonConvert.DeserializeObject<String>(jasonTables.singleKeyTable.tableName);
                DataTable dtInsertedMany = JsonConvert.DeserializeObject<DataTable>(jasonTables.manyKeyTable.dtAdded);
                String tableNameMany = JsonConvert.DeserializeObject<String>(jasonTables.manyKeyTable.tableName);
                dboGetCompanyData dboGetCompanyData = new dboGetCompanyData(_configuration["ConnectionStrings_of_snstoycotest"]);
                Dictionary<string, string[]> keyNames = TableColumns.PrimaryKeys;
                string singleKey = keyNames[tableNameOne][0]; // Assuming the first key is the primary key for the one side
                string[] manyKeys = keyNames[tableNameMany]; // Assuming the many side has multiple keys
                int rowsInserted = dboGetCompanyData.InsertOneToManyTables(dtInsertedOne, dtInsertedMany, tableNameOne, tableNameMany, singleKey, manyKeys);
                return rowsInserted;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        [HttpPut("SearchData")]
        public string SearchData([FromBody] String filterString)
        {
            try
            {
                dboGetCompanyData dboGetCompanyData = new dboGetCompanyData(_configuration["ConnectionStrings_of_snstoycotest"]);
                DataTable dtResult = dboGetCompanyData.SearchData(filterString);
                // Convert DataTable to JSON string
                string jsonString = JsonConvert.SerializeObject(dtResult);
                // Return JSON string
                return jsonString;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        [HttpPost("GetEmptyTable")]
        public string GetEmptyTable([FromBody] String tableName)
        {
            try
            {
                dboGetCompanyData dboGetCompanyData = new dboGetCompanyData(_configuration["ConnectionStrings_of_snstoycotest"]);
                DataTable dtResult = dboGetCompanyData.GetEmptyTable(tableName);
                // Convert DataTable to JSON string
                string jsonString = JsonConvert.SerializeObject(dtResult);
                // Return JSON string
                return jsonString;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        [HttpPost("ExecuteNonQuery")]
        public int ExecuteNonQuery([FromBody] String queryString)
        {
            try
            {
                dboGetCompanyData dboGetCompanyData = new dboGetCompanyData(_configuration["ConnectionStrings_of_snstoycotest"]);
                int rowsAffected = dboGetCompanyData.ExecuteNonQuery(queryString);
                return rowsAffected;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        [HttpPost("ExecuteGetQuery")]
        public string ExecuteGetQuery([FromBody] String queryString)
        {
            try
            {
                dboGetCompanyData dboGetCompanyData = new dboGetCompanyData(_configuration["ConnectionStrings_of_snstoycotest"]);
                DataTable dtResult = dboGetCompanyData.ExecuteGetQuery(queryString);
                string jsonString = JsonConvert.SerializeObject(dtResult);
                return jsonString;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
