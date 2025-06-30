using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;
using EntityModels;

namespace System_prototype_for_S_S_toy_Co__4915m_Project_.Login
{
    public class LoginController
    {
        private Login loginPage;
        private SystemController systemController;
        public LoginController(Login loginPage) {
            this.loginPage = loginPage;
            this.systemController = new SystemController(this);
        }
        public async Task<bool> Login(String username, String password)
        {
            try
            {
                using (HttpClient client = new HttpClient())
                {
                    client.BaseAddress = new Uri(ConfigurationManager.AppSettings["ServerAddress"]);
                    LoginRequest jsonLoginRequest = new LoginRequest();
                    jsonLoginRequest.username = username;
                    jsonLoginRequest.password = HashPassword(password);
                    string jsonString = JsonConvert.SerializeObject(jsonLoginRequest);

                    StringContent content = new StringContent(jsonString, Encoding.UTF8, "application/json");

                    // Send POST request to the Web API
                    HttpResponseMessage response = await client.PostAsync("/api/UserLogin/Login", content);

                    // Ensure the request was successful
                    if (response.IsSuccessStatusCode)
                    {
                        // Read the response content as a string
                        string jasonString = await response.Content.ReadAsStringAsync();

                        // Deserialize the JSON response to a dictionary
                        Dictionary<string, string> loginEmpInfo = JsonConvert.DeserializeObject<Dictionary<string, string>>(jasonString);
                        // loginEmpInfo includes EmployeeID, Department, Position, and Status
                        // Check if the login was successful in isLoginSuccess field
                        if (!loginEmpInfo.ContainsKey("isLoginSuccess") || loginEmpInfo["isLoginSuccess"] != "true")
                        {
                            // Check if the user is locked out by checking the "Status" field
                            if (loginEmpInfo.ContainsKey("Status") && loginEmpInfo["Status"] == "Locked")
                            {
                                // If the user is locked out, show an error message
                                MessageBox.Show("Your account is locked. Please contact support.");
                                return false;
                            }
                            // If login is not successful, show an error message
                            MessageBox.Show("Login failed. Please check your username and password.");
                            return false;
                        }
                        else if (loginEmpInfo.ContainsKey("EmployeeID") && !string.IsNullOrEmpty(loginEmpInfo["EmployeeID" ]))
                        {
                            // If login is successful and EmployeeID is found, set the system controller's employee info
                            systemController.SetEmployeeInfo(loginEmpInfo["EmployeeID"], loginEmpInfo["Department"], loginEmpInfo["Position"]);

                            // If login is successful, start the system controller
                            systemController.login();
                            // Hide the login page
                            loginPage.Hide();

                        }
                        else
                        {
                            // If EmployeeID is not found, show an error message
                            MessageBox.Show("Login failed. Employee information not found.");
                            return false;
                        }
                        return true;
                    }
                    else
                    {
                        Console.WriteLine($"Error: {response.StatusCode} - {response.ReasonPhrase}");
                        MessageBox.Show($"Error: {response.StatusCode} - {response.ReasonPhrase}");
                        return false;
                    }
                }
            }
            catch (HttpRequestException e)
            {
                // Log the exception message
                MessageBox.Show($"Request error: {e.Message}");
                throw e;
            }
            catch (Exception ex)
            {
                // Log any other exceptions
                MessageBox.Show($"An error occurred: {ex.Message}");
                throw ex;
            }
        }
        public bool logonInTest()
        {
            // This method is for testing purposes only, it should not be used in production code.
            // It simulates a successful login without making an actual API call.
            systemController.SetEmployeeInfo("root", "root", "root"); // Set test employee info
            systemController.login();
            loginPage.Hide(); // Hide the login page
            return true;
        }

        public static string HashPassword(string password)
        {
            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] bytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(password));
                StringBuilder builder = new StringBuilder();
                for (int i = 0; i < bytes.Length; i++)
                {
                    builder.Append(bytes[i].ToString("x2"));
                }
                return builder.ToString();
            }
        }
    }
}
