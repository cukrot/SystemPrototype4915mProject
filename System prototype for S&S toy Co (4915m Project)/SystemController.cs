using EntityModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System_prototype_for_S_S_toy_Co__4915m_Project_.JustTesting2;
using System_prototype_for_S_S_toy_Co__4915m_Project_.Login;
using System_prototype_for_S_S_toy_Co__4915m_Project_.MasterData;
using System_prototype_for_S_S_toy_Co__4915m_Project_.Menu;
using System_prototype_for_S_S_toy_Co__4915m_Project_.ProductRequirement;

namespace System_prototype_for_S_S_toy_Co__4915m_Project_
{
    public class SystemController
    {
        private LoginController loginController;
        private MenuController menuController;
        private MasterDataController masterDataController;
        private SaleController saleController;
        private UserAccessController userAccessController;
        private string[] accessControlOfSubsytem;
        Dictionary<string, string[]> subSytemPages = new Dictionary<string, string[]>
        {
            { "MasterData Management", new string[] { "Customer Data", "Employee Data", } },
            { "Product Requirements", new string[] { "View Product Requirements", "Edit Product Requirements" } },
            { "Production Processing Management", new string[] { "View Production Order", "Add Production Order" } },
            { "Material Procurement", new string[] { "View Material Order", "Add Material Order" } },
            { "Dispatch Processing", new string[] { "View Dispatch Order", "Add Dispatch Order" } },
            { "After Service Management", new string[] { "View After Service Request", "Add After Service Request" } },
            { "Administration Management", new string[] { "System Settings", "User Management" } },
            { "Inventory Management", new string[] { "View Products", "View Material" } },
            { "Test Menu", new string[] { "Just Testing 2", "TestAnything" } }
        };
        /*private string[] menuOfSubsystem =
        {
            "MasterData Management", //IT
            "Product Requirements", //sale, marketing, sale & marketing
            "Production Processing Management", //Production
            "Material Procurement", //Supply Chain Management
            "Inventory Management", //Inventory Management, Supply Chain Management
            "Dispatch Processing", //Supply Chain Management
            "After Service Management", //Customer Service Department
            "Administration Management", //IT
            "Test Menu" //Just for testing purposes
        };*/
        private EmpInfo empInfo;
        public static string empID = "";
        public static string getEmpID()
        {
            return empID;
        }
        public SystemController(LoginController login)
        {
            loginController = login;
            userAccessController = new UserAccessController();
        }
        public void login(EmpInfo empInfo)
        {
            SetEmployeeInfo(empInfo);
            empID = empInfo.EmployeeID;
            accessControlOfSubsytem = userAccessController.GetAccessControl(this.empInfo.Department);
            menuController = new MenuController(this, accessControlOfSubsytem, subSytemPages);
            menuController.callMenu();
        }

        private void SetEmployeeInfo(EmpInfo empInfo)
        {
            if (empInfo != null)
            {
                this.empInfo = empInfo;
                // You can also set the menu based on the employee's department or position if needed
            }
            else
            {
                throw new ArgumentNullException(nameof(EmpInfo), "Employee information cannot be null.");
            }
        }

        internal void openSubSystemPage(string menuCurrent, int pageIndex)
        {
            switch (menuCurrent)
            {
                case "MasterData Management":
                    if (masterDataController == null)
                    {
                        masterDataController = new MasterDataController();
                    }
                    masterDataController.OpenPage(pageIndex);
                    break;
                case "Product Requirements":
                    if (saleController == null)
                    {
                        saleController = new SaleController();
                    }
                    saleController.openProductRequirementPage(pageIndex);
                    break;
                case "Test Menu":
                    // Implement test menu functionality here
                    if (menuCurrent == "Test Menu")
                    {
                        // Example: Just for testing purposes
                        JustingTestingTwo_menu testMenu = new JustingTestingTwo_menu();
                        testMenu.Show();
                    }
                    break;
                default: 
                    throw new ArgumentException($"Subsystem '{menuCurrent}' is not recognized or not implemented.");


            }
        }
    }
}
