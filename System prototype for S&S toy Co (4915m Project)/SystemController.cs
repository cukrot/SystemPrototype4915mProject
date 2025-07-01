using EntityModels;
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
        EmpInfo EmpInfo = null;
        public SystemController(LoginController login)
        {
            _loginController = login;
            menuController = new MenuController();
        }
        public void login()
        {
            menuController.callMenu();
        }

        public void SetEmployeeInfo(EmpInfo empInfo)
        {
            if (empInfo != null)
            {
                this.EmpInfo = EmpInfo;
                // You can also set the menu based on the employee's department or position if needed
            }
            else
            {
                throw new ArgumentNullException(nameof(EmpInfo), "Employee information cannot be null.");
            }
        }
    }
}
