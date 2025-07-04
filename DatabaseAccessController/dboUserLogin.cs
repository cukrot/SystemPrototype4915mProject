using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseAccessController
{
    public class DboUserLogin :dboDatabaseController
    {
        public DboUserLogin(string connectionString) : base(connectionString)
        {
        }
        public Dictionary<string, string> UserLogin(string username, string password) //return EmployeeID, Department, Postion, Status, isLoginSuccess
        {
            //First sql: String sqlCmdForID = "SELECT EmployeeID FROM user WHERE UserName = '" + username + "' and Password = '" + password + "'";
            //Second sql: String sqlCmForInfo = "SELECT EmployeeID, Department, Position, Status FROM e,ployee WHERE EmployeeID = (above query result)";
            String sqlCmdForID = $"SELECT UserID, EmployeeID, Status FROM user WHERE UserName = '{username}' AND Password = '{password}'";
            // Note: In a real application, you should use parameterized queries to prevent SQL injection attacks.
            String sqlCmd = sqlCmdForID; // Assuming the first query returns all necessary fields
            DataTable dt = GetData(sqlCmd);
            if (dt.Rows.Count == 0)
            {
                return new Dictionary<string, string>
                {
                    { "isLoginSuccess", "false" } // Indicating login was not successful
                };
            }
            else if // Check if the user is locked out by checking the "Status" column or similar logic
            (dt.Rows[0]["Status"].ToString() == "Locked")
            {
                // If the user is inactive, return Status as "Locked" while other fields are null or empty
                Dictionary<string, string> loginEmpInfo = new Dictionary<string, string>
                {
                    { "EmployeeID", string.Empty },
                    { "Department", string.Empty },
                    { "Role", string.Empty },
                    { "Status", "Locked" },
                    { "isLoginSuccess", "false" } // Indicating login was not successful due to lockout
                };
                return loginEmpInfo;
            }
            else if (dt.Rows.Count > 0) // If the user is found and not locked out
            {
                //get the EmployeeID in the first row of the DataTable for SQL query
                DataRow row = dt.Rows[0];
                //if the UserID is 0, it means the user is root user and should have access to all information
                if (row["UserID"].ToString() == "0")
                {
                    // Return the employee information in a dictionary for root user
                    return new Dictionary<string, string>
                    {
                        { "EmployeeID", "root" }, // Assuming root user does not have a specific EmployeeID
                        { "Department", "root" }, // Assuming root user has a special identifier
                        { "Position", "root" }, // Assuming root user has a special identifier
                        { "Status", "Active" }, // Assuming the root user is always active
                        { "isLoginSuccess", "true" } // Indicating login was successful
                    };
                }
                // If the user is not root, get the EmployeeID from the first row
                // and query the employee table for more information
                string employeeID = row["EmployeeID"].ToString();
                String sqlCmdForInfo = $"SELECT EmployeeID, Department, Role FROM employee WHERE EmployeeID = '{employeeID}'";
                DataTable infoDt = GetData(sqlCmdForInfo);
                row = infoDt.Rows[0]; // Assuming the query returns only one row for the employee
                // Return the employee information in a dictionary
                return new Dictionary<string, string>
                {
                    { "EmployeeID", row["EmployeeID"].ToString() },
                    { "Department", row["Department"].ToString() },
                    { "Role", row["Role"].ToString() },
                    { "Status", "Active" }, // Assuming the user is active if they are found in the database
                    { "isLoginSuccess", "true" } // Indicating login was successful
                };
            }
            else
            {
                // If no rows are returned, login was not successful
                return new Dictionary<string, string>
                {
                    { "isLoginSuccess", "false" } // Indicating login was not successful
                };
            }
        }
    }
}
