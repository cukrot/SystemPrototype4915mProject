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
                DataTable dtUpdated = JsonConvert.DeserializeObject<DataTable>(json.dtModified);
                String tableName = JsonConvert.DeserializeObject<String>(json.tableName);
                String[] keysName = JsonConvert.DeserializeObject<String[]>(json.keysName);

                dboGetCompanyData dboGetCompanyData = new dboGetCompanyData(_configuration["ConnectionStrings_of_snstoycotest"]);
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

                dboGetCompanyData dboGetCompanyData = new dboGetCompanyData(_configuration["ConnectionStrings_of_snstoycotest"]);
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
