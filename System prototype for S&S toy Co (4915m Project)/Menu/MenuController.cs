using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System_prototype_for_S_S_toy_Co__4915m_Project_.Login;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace System_prototype_for_S_S_toy_Co__4915m_Project_.Menu
{
    public class MenuController
    {
        private SystemController systemController;
        private MenuTest menu;
        private string[] menuOfSubsystem;
        private Dictionary<string, string[]> subSystemPages;
        private string menuCurrent { get; set; }
        public MenuController(SystemController systemController, string[] accessControlOfSubsytem, Dictionary<string, string[]> subSystemPages)
        {
            this.systemController = systemController;
            menuOfSubsystem = accessControlOfSubsytem;
            this.subSystemPages = subSystemPages;
            menuCurrent = menuOfSubsystem[0]; // Default to the first item
            menu = null;
        }


        public void callMenu()
        {
            MenuTest menu = new MenuTest(this);
            this.menu = menu;
            menu.setSubMenuVisible(menuOfSubsystem.Length, menuOfSubsystem);
            menu.setSubButtonsVisible(subSystemPages[menuCurrent].Length, subSystemPages[menuCurrent]);
            menu.Show();
        }
        public void btnClicked_Sub(int pageIndex)
        {
            try {
            systemController.openSubSystemPage(menuCurrent, pageIndex);
            }
            catch (Exception ex)
            {
                // Handle any exceptions that may occur
                MessageBox.Show($"An error occurred: {ex.Message}");
            }
        }



        internal void btnClicked_Sub2() //This method is called by the sub button 2 in the menu   // < 2nd > sub button
        {
            switch (menuCurrent)
            {
                case "MasterData Management":
                    Form form_masterdata_emp = new MasterData.EmployeeData();
                    form_masterdata_emp.Show();
                    break;
                case "Product Requirements":
                    //Form form_requirement_add = new ProductRequirement.AddRequirements();
                    break;
                case "Inventory Management":
                    Form form_inv_viewMaterial = new Inventory.ViewMaterial();
                    form_inv_viewMaterial.Show();
                    break;
                case "Delivery Management":
                    //Form form_delivery_add = new Delivery.AddDeliveryOrder();
                    break;
                case "Test Menu":
                    Form form_test2 = new JustTesting.TestAnything();
                    form_test2.Show();
                    break;
                default:
                    throw new InvalidOperationException("Unknown menu item: " + menuCurrent);
            }
        }

        internal void setSubMenu(int index)
        {
            if (index > menuOfSubsystem.Length) //
            {
                MessageBox.Show("Invalid index for submenu selection.");
            }
            else if (index < 0)
            {
                MessageBox.Show("Invalid index for submenu selection.");
            }
            else
            {
                menuCurrent = menuOfSubsystem[index]; // Set the current menu to the selected submenu
                if (menu != null) // If the menu is already created, update the buttons
                {
                    menu.setSubButtonsVisible(subSystemPages[menuCurrent].Length, subSystemPages[menuCurrent]);
                }
            }
        }
        /*
        private string[] menuOfSubsystem =
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
        };
        */
    }
}
