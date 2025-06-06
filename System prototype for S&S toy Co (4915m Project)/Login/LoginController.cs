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
                        string responseString = await response.Content.ReadAsStringAsync();

                        // Parse the response string to an integer
                        bool login = bool.Parse(responseString);

                        // If login is successful, you can proceed with the next steps
                        startSystemController();
                        return login;
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
            startSystemController();
            return true;
        }
        public void startSystemController()
        {
            SystemController systemController = new SystemController(this);
            systemController.Start();
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
