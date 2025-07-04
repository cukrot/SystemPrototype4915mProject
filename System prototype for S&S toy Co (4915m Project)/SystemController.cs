using EntityModels;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System_prototype_for_S_S_toy_Co__4915m_Project_.JustTesting2;
using System_prototype_for_S_S_toy_Co__4915m_Project_.Login;
using System_prototype_for_S_S_toy_Co__4915m_Project_.MasterData;
using System_prototype_for_S_S_toy_Co__4915m_Project_.Menu;
using System_prototype_for_S_S_toy_Co__4915m_Project_.ProductRequirement;
using EntityModels;
using System_prototype_for_S_S_toy_Co__4915m_Project_.SuppyChain;
using System_prototype_for_S_S_toy_Co__4915m_Project_.JustTesting;
using System_prototype_for_S_S_toy_Co__4915m_Project_.Inventory;
using System_prototype_for_S_S_toy_Co__4915m_Project_.administration;

namespace System_prototype_for_S_S_toy_Co__4915m_Project_
{
    public class SystemController
    {
        private LoginController loginController;
        private MenuController menuController;
        private MasterDataController masterDataController;
        private SaleController saleController;
        private UserAccessController userAccessController;
        private SupplyChainController supplyChainController;
        private TestControll2 testcontroller2;
        private InvController invController;
        private AdminController adminController; // For administration management subsystem
        private string[] accessControlOfSubsytem;
        Dictionary<string, string[]> subSystemPages = new Dictionary<string, string[]> {};

        private EmpInfo empInfo;
        public static string empID = "";
        public static string getEmpID()
        {
            return empID;
        }
        public SystemController(LoginController login)
        {
            loginController = login;
        }
        public void login(EmpInfo empInfo)
        {
            SetEmployeeInfo(empInfo);
            empID = empInfo.EmployeeID;
            userAccessController = new UserAccessController();
            accessControlOfSubsytem = userAccessController.GetAccessControl(this.empInfo.Department, empInfo.Position);
            AccessPermission accessPermission = new AccessPermission();
            subSystemPages = accessPermission.SubSystemPages; // Get the pages for the subsystems based on access control
            menuController = new MenuController(this, accessControlOfSubsytem, subSystemPages);
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
                case "Product Requirements":
                    if (saleController == null)
                    {
                        saleController = new SaleController();
                    }
                    saleController.openProductRequirementPage(pageIndex);
                    break;
                case "Customer":
                    if (testcontroller2 == null)
                    {
                        testcontroller2 = new TestControll2();
                    }
                    testcontroller2.openPage(pageIndex);
                    break;
                case "Supply Chain Management":
                    if ( supplyChainController == null)
                    {
                        supplyChainController = new SupplyChainController();
                    }
                    supplyChainController.OpenPage(pageIndex);
                    break;
                case "MasterData Management":

                    if (invController == null)
                    {
                        invController = new InvController(getIsStaff());
                    }
                    switch (pageIndex)
                    {
                        case 0: // Master Data
                            if (masterDataController == null)
                            {
                                masterDataController = new MasterDataController();
                            }
                            masterDataController.OpenPage(pageIndex);
                            break;
                    }
                    break;
                case "Administraction Management":
                    switch (pageIndex)
                    {

                        case 0: // Admin Page
                            if (adminController == null)
                            {
                                AdminController adminController = new AdminController();
                            }
                            AdminController.OpenPage("AdminPage");
                            break;

                    }
                    break;
                case "Inventory Management":
                    switch (pageIndex)
                    {
                        case 0: // View Products
                            ViewProducts viewProducts = new ViewProducts();
                            viewProducts.Show();
                            break;
                        case 1:// View Material
                            ViewMaterial viewMaterial = new ViewMaterial();
                            viewMaterial.Show();
                            break;
                    }
                    break;
                default: 
                    throw new ArgumentException($"Subsystem '{menuCurrent}' is not recognized or not implemented.");
            }
        }

        private bool getIsStaff()
        {
            string role = empInfo.Position;
            if (role == "Staff")
            {
                return true; // User is a staff
            } else
            {
                return false; // User is not a staff
            }
        }

        internal async static Task<bool> vaildifyID(string v, string[] id)
        {
            // This method is used to validate the ID format, e.g., customerID, employeeID, etc.
            if (string.IsNullOrWhiteSpace(v) || id == null || id.Length == 0)
            {
                return false; // Invalid input
            }
            SubSystemController subSystemController = new SubSystemController();
            DataTable dt = await subSystemController.GetTableData(v); //specify table name
            if (dt == null || dt.Rows.Count == 0)
            {
                return false;
            }
            // Check if the ID exists in the DataTable with the EntittyModels TableColumns
            Dictionary<string, string[]> tableColumns = TableColumns.PrimaryKeys;
            string[] keys = TableColumns.GetPrimaryKeys(v); //v is table name

            bool isValid = false;
            
            for (int i = 0; i <keys.Length; i++) //compare id with the primary keys of the table
            {
                string keyName = keys[i];
                dt.Select($"{keyName} = '{id[i]}'"); // Use Select method to filter rows by ID
                if (dt.Rows.Count > 0)
                {
                    isValid = true; // ID exists in the table
                    break;
                }
            }
            return isValid;
        }

        internal void logout()
        {
            // Close all open forms
            // This will close all forms and return to the login screen
            // Check all the subsystem controllers and close their forms if they are open
            /*
            if (masterDataController != null)
            {
                masterDataController.CloseMasterDataPage(); // Close the master data page
            }
            if (saleController != null)
            {
                saleController.CloseProductRequirementPage(); // Close the product requirement page
            }
            if (supplyChainController != null)
            {
                supplyChainController.CloseSupplyChainPage(); // Close the supply chain page
            }
            if (testcontroller2 != null)
            {
                testcontroller2.CloseTestPage(); // Close the test page
            }
            if (invController != null)
            {
                invController.CloseInventoryPage(); // Close the inventory page
            }*/
            //some forms may not called by subsystem controllers, so we need to close all open forms
            foreach (Form form in Application.OpenForms.Cast<Form>().ToList())
            {
                if (form is not Login.Login) // Do not close the login page
                {
                    form.Close(); // Close all other open forms
                }
            }
            // Clear the employee info
            empInfo = null;
            empID = ""; // Reset the static employee ID

            // Clear all subsystem controllers except for the login controller and access controller
            // This is to ensure that the login controller remains active for the next login attempt
            masterDataController = null;
            saleController = null;
            userAccessController = null;
            supplyChainController = null;
            testcontroller2 = null;
            invController = null;
            adminController = null;
            menuController = null;


            //now you can return to the login page
            loginController.ShowLoginPage(); // Assuming this method shows the login page
        }
    }
}
