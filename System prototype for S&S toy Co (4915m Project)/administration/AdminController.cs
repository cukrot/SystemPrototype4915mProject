using EntityModels;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System_prototype_for_S_S_toy_Co__4915m_Project_.MasterData;
using System.Security.Cryptography;

namespace System_prototype_for_S_S_toy_Co__4915m_Project_.administration
{
    public class AdminController : SubSystemController
    {
        private AdminPage adminPage;
        private string employeeID;
        private string empoyeeFilter_expression;
        private DataTable dtEmp;
        private DataTable dtUser;
        private DataTable alluserData;
        private string[] status = new string[]
        {
            "Active",
            "Inactive",
            "Locked"
        };
        private string[] employeeKeyColumns = new string[]
        {
            "EmployeeID"
        };
        private bool isUser;

        public AdminController()
        {
            this.adminPage = null;
            isUser = false; // Initialize isUser to false
        }
        // Add methods to handle administration tasks here
        // For example, managing user accounts, roles, permissions, etc.
        // These methods will interact with the AdminPage UI and the backend API as needed

        public void OpenAdminPage()
        {
            if (adminPage == null || adminPage.IsDisposed)
            {
                adminPage = new AdminPage(this);
            }
            adminPage.Show();
        }
        internal static void OpenPage(string v)
        {
            switch (v)
            {
                case "AdminPage":
                    AdminController adminController = new AdminController();
                    adminController.OpenAdminPage();
                    break;
                // Add cases for other pages if needed
                default:
                    throw new ArgumentException("Invalid page name.", nameof(v));
            }
        }

        internal async Task<DataTable[]> findEmployeeByID(string v) //return two DataTables if found, otherwise return null
        {
            try
            {
                if (string.IsNullOrWhiteSpace(v))
                {
                    throw new ArgumentException("Employee ID cannot be null or empty.", nameof(v));
                }
                // Assuming you have a method to get employee data by ID
                DataTable empData = await GetEmployeeDataByID(v);
                if (empData == null || empData.Rows.Count == 0)
                {
                    isUser = false; // Reset isUser flag if no employee found
                    //close the user setting page if it is open
                    // it is a form, so we can check if it is open
                    if (Application.OpenForms["UserSettingPage"] is UserSettingPage userSettingPage)
                    {
                        userSettingPage.Close(); // Close the UserSettingPage if it is open
                    }
                    return null; // No employee found with the given ID
                }
                DataTable userData = await GetUserDataByEmployeeID(v); // Assuming this method retrieves user data based on employee ID
                if (dtUser == null || dtUser.Rows.Count == 0)
                {
                    isUser = false; // Reset isUser flag if no user found
                }
                else
                {
                    isUser = true; // Set isUser to true if user data is found
                }
                return new DataTable[] { empData, userData };
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred while finding employee by ID: {ex.Message}");
                return null; // Return null if an error occurs
            }
        }

        private async Task<DataTable> GetUserDataByEmployeeID(string v)
        {

                try {
                    dtUser = await GetTableData("User"); // Assuming "User" is the table name for user data
                    alluserData = dtUser.Copy();
                }
                catch (Exception ex)
                {
                    throw new Exception("Error retrieving user data.", ex);
                }
            
            DataTable filteredUser = dtUser.Clone(); // Create a new DataTable with the same structure
            DataView view = new DataView(dtUser);
            view.RowFilter = $"EmployeeID = '{v}'"; // Filter by EmployeeID
            if (view.Count > 0 && view.Count < 2) // Ensure only one user is returned
            {
                filteredUser = view.ToTable(); // Convert the DataView to a DataTable
            }
            dtUser = filteredUser; // Update the class variable with the filtered data
            dtUser.AcceptChanges(); // Accept changes to the DataTable
            return filteredUser;
        }

        private async Task<DataTable> GetEmployeeDataByID(string employeeID)
        {

                try {
                    dtEmp = await GetTableData("Employee"); // Assuming "Employee" is the table name for employee data
                }
                catch (Exception ex)
                {
                    throw new Exception("Error retrieving employee data.", ex);
                }
            
            DataTable filteredEmp = dtEmp.Clone(); // Create a new DataTable with the same structure
            DataView view = new DataView(dtEmp);
            view.RowFilter = $"EmployeeID = '{employeeID}'"; // Filter by EmployeeID
            if (view.Count > 0 && view.Count < 2) // Ensure only one employee is returned
            {
                this.employeeID = employeeID; // Set the employeeID for further operations
                filteredEmp = view.ToTable(); // Convert the DataView to a DataTable
            }
            dtEmp = filteredEmp; // Update the class variable with the filtered data
            dtEmp.AcceptChanges(); // Accept changes to the DataTable
            return filteredEmp;
        }

        internal async Task<string[]> getDepartments()
        {
            /*
            try {
                DataTable dt = await GetTableData("Department"); // Assuming "Department" is the table name for departments
                if (dt != null && dt.Rows.Count > 0)
                {
                    return dt.AsEnumerable().Select(row => row.Field<string>("DepartmentName")).ToArray();
                }
                else
                {
                    return Array.Empty<string>(); // No departments found
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error retrieving departments.", ex);
            }*/
            // We will change to above code later, for now we will use data from EntityModels.AccessPermission
            AccessPermission accessPermissions = new AccessPermission();
            string[] departments = accessPermissions.Departments; // Assuming this method returns an array of department names
            if (departments != null && departments.Length > 0)
            {
                return departments;
            }
            else
            {
                return Array.Empty<string>(); // No departments found
            }
        }

        internal async Task<string[]> getRoles()
        {
            /*try {
                DataTable dt = await GetTableData("Role"); // Assuming "Role" is the table name for roles
                if (dt != null && dt.Rows.Count > 0)
                {
                    return dt.AsEnumerable().Select(row => row.Field<string>("RoleName")).ToArray();
                }
                else
                {
                    return Array.Empty<string>(); // No roles found
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error retrieving roles.", ex);
            }*/
            // We will change to above code later, for now we will use data from EntityModels.AccessPermission
            AccessPermission accessPermissions = new AccessPermission();
            string[] roles = accessPermissions.Roles; // Assuming this method returns an array of role names
            if (roles != null && roles.Length > 0)
            {
                return roles;
            }
            else
            {
                return Array.Empty<string>(); // No roles found
            }
        }

        public async Task<bool> UpdateEmployeeAndUser(Dictionary<string, string> empInfo, Dictionary<string, string> userInfo, DataRow drEmp, DataRow drUser)
        {
            if (empInfo == null || userInfo == null || drEmp == null || drUser == null)
            {
                throw new ArgumentNullException("Employee or user information cannot be null.");
            }
            try {
                // Assuming you have methods to update employee and user data
                bool empUpdated = await UpdateDataWithARow("employee", new string[] { "EmployeeID" },
                    empInfo, drEmp);
                bool userUpdated = await UpdateDataWithARow("user", new string[] { "UserID" },
                    userInfo, drUser); // Assuming this method updates user data based on the provided DataRow
                return empUpdated && userUpdated; // Return true if both updates were successful
            }
            catch (Exception ex)
            {
                throw new Exception("Error updating employee and user data.", ex);
            }
        }

        internal async Task<bool> UpdateEmployee(Dictionary<string, string> empInfo, DataRow dataRow)
        {
            if (empInfo == null || dataRow == null)
            {
                throw new ArgumentNullException("Employee information or DataRow cannot be null.");
            }
            try {
                // Assuming you have a method to update employee data
                return await UpdateDataWithARow("employee", new string[] { "EmployeeID" },
                    empInfo, dataRow); // Assuming this method updates employee data based on the provided DataRow
            }
            catch (Exception ex)
            {
                throw new Exception("Error updating employee data.", ex);
            }
        }

        internal void openUserSettingPage()
        {
            //check if employeeID is set
            if (string.IsNullOrWhiteSpace(employeeID))
            {
                MessageBox.Show("Please select an employee first.");
                return;
            }
            //open the user setting page for setup or reset user account
            //so we have to check if the user exists or not
            if (isUser)
            {
                // User exists, open the user setting page for the existing user
                UserSettingPage userSettingPage = new UserSettingPage(this, employeeID, dtUser);
                userSettingPage.Show();
            }
            else
            {
                // User does not exist, open the user setting page for creating a new user
                UserSettingPage userSettingPage = new UserSettingPage(this, employeeID, null);
                userSettingPage.Show();
            }
        }

        internal void reloadFromAdminPage()
        {
            isUser = false; // Reset the isUser flag
            employeeID = null; // Reset the employeeID
        }

        internal async Task<bool> SubmitUserSettings(DataTable dt, string text1, string text2)
        {
            // As this page is for user registration or resetting, while isUser is for checking if the user exists or not
            if (string.IsNullOrWhiteSpace(text1) || string.IsNullOrWhiteSpace(text2))
            {
                MessageBox.Show("Please enter both user name and password.");
                return false; // Submission failed
            }
            // Check if the text1 matches the user name in the DataTable
            DataTable dataT = alluserData.Copy();
            DataView dv = dataT.DefaultView;
            dv.RowFilter = $"UserName = '{text1}'"; // Filter by UserName
            if (dv.Count > 0)
            {
                MessageBox.Show("User name already exists. Please choose a different user name.");
                return false; // Submission failed due to duplicate user name
            }

            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] bytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(text2));
                StringBuilder builder = new StringBuilder();
                for (int i = 0; i < bytes.Length; i++)
                {
                    builder.Append(bytes[i].ToString("x2"));
                }
                text2 = builder.ToString();
            }
            if (isUser)
            {
                // Update existing user settings
                Dictionary<string, string> userInfo = new Dictionary<string, string>
                {
                    { "UserName", text1 },
                    { "Password", text2 }
                };
                DataRow drUser = dtUser.Rows[0]; // Assuming dtUser contains the user data
                bool success = await UpdateDataWithARow("user", new string[] { "UserID" }, userInfo, drUser); // Assuming this method updates user data
                if (success)
                {
                    MessageBox.Show("User settings updated successfully.");
                    return true; // Submission successful
                }
                else
                {
                    MessageBox.Show("Failed to update user settings.");
                    return false; // Submission failed
                }
            }
            else
            {
                // Create new user settings
                Dictionary<string, string> userInfo = new Dictionary<string, string>
                {
                    { "EmployeeID", employeeID },
                    { "UserName", text1 },
                    { "Password", text2 },
                    {"Status", "Active" } // Default status for new users
                };
                string[] primaryKeyNames = new string[] { "UserID" }; // Assuming UserID is the primary key for the user table
                // Here you would typically call a method to insert the new user into the database
                // Assuming you have a method to insert user data
                bool success = await InsertDataWithARow("user", primaryKeyNames, userInfo); // Assuming this method inserts user data
                if (success)
                {
                    MessageBox.Show("New user created successfully.");
                    return true; // Submission successful
                }
                else
                {
                    MessageBox.Show("Failed to create new user.");
                    return false; // Submission failed
                }
            }
        }
    }
}
