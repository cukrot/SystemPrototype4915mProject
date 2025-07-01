using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityModels
{
    public class EmpInfo
    {
        /* * EmployeeID: Unique identifier for the employee.
         * Department: The department where the employee works.
         * Position: The job title or position of the employee.
         * Status: The employment status of the employee (e.g., Active, Inactive).
         * isLoginSuccess: Indicates whether the login was successful.
         */
        public string EmployeeID { get; set; }
        public string Department { get; set; }
        public string Position { get; set; }
        public string Status { get; set; }
        public string isLoginSuccess { get; set; }
    }
}
