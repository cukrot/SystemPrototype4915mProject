using Microsoft.AspNetCore.Mvc;
using System.Data;
using DatabaseAccessController;
using Newtonsoft.Json;
using EntityModels;


namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SimpleGetAPIController : Controller
    {
        private readonly IConfiguration _configuration;

        public SimpleGetAPIController(IConfiguration configuration)
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
    }
}
