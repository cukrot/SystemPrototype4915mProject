using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System_prototype_for_S_S_toy_Co__4915m_Project_.Login;
using System_prototype_for_S_S_toy_Co__4915m_Project_.Menu;

namespace System_prototype_for_S_S_toy_Co__4915m_Project_
{
    internal class SystemController
    {
        private LoginController _loginController;
        private MenuTest menu;
        private MenuController menuController;
        private string[] departments = new string[]
        {
            "MasterData Management",
            "Product Requirements",
            "Inventory Management",
            "Delivery Management",
            "Human Resource Management"
        };
        Dictionary<string, string> employeeInfo = new Dictionary<string, string>
        {
            { "EmployeeID", "" },
            { "Department", "" },
            { "Position", "" },
            { "Status", "" }
        };
        public SystemController(LoginController login)
        {
            _loginController = login;
            menuController = new MenuController();
        }
        public void login()
        {
            menuController.callMenu();
        }

        internal void SetEmployeeInfo(string v1, string v2, string v3)
        {
            employeeInfo["EmployeeID"] = v1;
            employeeInfo["Department"] = v2;
            employeeInfo["Position"] = v3;
            // Set the status to "Active" by default
            employeeInfo["Status"] = "Active";
        }
    }
}
