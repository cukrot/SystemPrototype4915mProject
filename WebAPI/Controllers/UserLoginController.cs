using DatabaseAccessController;
using EntityModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserLoginController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        public UserLoginController(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        [HttpPost("Login")]
        public string Login([FromBody] LoginRequest loginRequest)
        {
            try
            {
                String username = loginRequest.username;
                String password = loginRequest.password;

                DboUserLogin dboLogin = new DboUserLogin(_configuration["ConnectionStrings_of_snstoycotest"]);
                //string loginEmp = dboLogin.UserLogin(username, password);
                Dictionary<string, string> loginEmp = dboLogin.UserLogin(username, password);
                EmpInfo empInfo = new EmpInfo();
                empInfo.EmployeeID = loginEmp.ContainsKey("EmployeeID") ? loginEmp["EmployeeID"] : string.Empty;
                empInfo.Department = loginEmp.ContainsKey("Department") ? loginEmp["Department"] : string.Empty;
                empInfo.Position = loginEmp.ContainsKey("Role") ? loginEmp["Role"] : string.Empty;
                empInfo.Status = loginEmp.ContainsKey("Status") ? loginEmp["Status"] : string.Empty;
                empInfo.isLoginSuccess = loginEmp.ContainsKey("isLoginSuccess") ? loginEmp["isLoginSuccess"] : "false";
                string jasonString = JsonConvert.SerializeObject(empInfo);
                return jasonString;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
