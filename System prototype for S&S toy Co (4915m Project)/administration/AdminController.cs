using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System_prototype_for_S_S_toy_Co__4915m_Project_.MasterData;

namespace System_prototype_for_S_S_toy_Co__4915m_Project_.administration
{
    public class AdminController : SubSystemController
    {
        private Form adminPage;
        private string employeeID;
        private string empoyeeFilter_expression;
        private DataTable employeeTableData;
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
        public AdminController()
        {
            this.adminPage = null;
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

        internal async void findEmployeeByID(string v)
        {
            // This method should implement the logic to find an employee by exact same EmployeeID (case-sensitive, e.g., "EMP001")
            if (string.IsNullOrWhiteSpace(v) || employeeID == null)
            {
                throw new ArgumentException("Employee ID cannot be null or empty.");
            }
            // Implement the logic to find the employee by ID here
            // Get employee Table Data by calling the method from the base class or a specific method for employee data
            // Check if the employeeTableData is null or empty
            if (employeeTableData == null || employeeTableData.Rows.Count == 0)
            {  // get employee data by calling the method from the base class or a specific method for employee data
                employeeTableData = await GetTableData("empoyee");
            }
            // Filter the employeeTableData to find the employee with the given ID
            DataRow[] foundRows = employeeTableData.Select($"EmployeeID = '{v}'");
            // Check if no rows were found
            if (foundRows.Length == 0)
            {
                throw new Exception($"No employee found with ID: {v}");
            }
            // If found, you can return the employee data or perform any other action
            //
        }
    }
}
