using EntityModels;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Data;
using DatabaseAccessController;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestAPIController : Controller
    {
        private readonly IConfiguration _configuration;

        public TestAPIController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        [HttpGet("SimpleGetMethod")]
        public String Get()
        {
            return $"This is returned by the web API server. Current time is: {DateTime.Now}";
        }

        [HttpGet("GetCustomerData")]
        public String GetCustomerData()
        {
            dboGetCompanyData dboGetCompanyData = new dboGetCompanyData(_configuration["ConnectionStrings"]);
            DataTable dtResult = dboGetCompanyData.GetAllCustomerData();

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

                dboGetCompanyData dboGetCompanyData = new dboGetCompanyData(_configuration["ConnectionStrings"]);
                int rowsUpdated = dboGetCompanyData.UpdateCustomerData(dtUpdated);
                return rowsUpdated;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        [HttpPost("UpdateCustomerDataTest")]
        public int UpdateCustomerDataTest([FromBody] JsonDataTable json)
        {
            try
            {
                DataTable dtUpdated = JsonConvert.DeserializeObject<DataTable>(json.dtModified);

                dboGetCompanyData dboGetCompanyData = new dboGetCompanyData(_configuration["ConnectionStrings"]);
                int rowsUpdated = dboGetCompanyData.UpdateCustomerDataTest(dtUpdated);
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
                DataTable dtUpdated = JsonConvert.DeserializeObject<DataTable>(json.dtModified);
                String tableName = JsonConvert.DeserializeObject<String>(json.tableName);
                String[] keysName = JsonConvert.DeserializeObject<String[]>(json.keysName);

                dboGetCompanyData dboGetCompanyData = new dboGetCompanyData(_configuration["ConnectionStrings"]);
                int rowsUpdated = dboGetCompanyData.UpdateTable(dtUpdated, tableName, keysName);
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

                dboGetCompanyData dboGetCompanyData = new dboGetCompanyData(_configuration["ConnectionStrings"]);
                DataTable dtResult = dboGetCompanyData.GetTableData(tableName);

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
    }
}
