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
        MenuTest menu;
        public MenuController()
        {
            menuCurrent = menuOfSubsystem[0]; // Default to the first item
            menu = null;
        }
        string [] menuOfSubsystem =
        {
            "MasterData Management",
            "Product Requirements",
            "Inventory Management",
            "Delivery Management",
            "Test Menu"
        };
        Dictionary<string, string[]> menuItems = new Dictionary<string, string[]>
        {
            { "MasterData Management", new string[] { "Customer Data", "Employee Data" } },
            { "Product Requirements", new string[] { "View Requirements", "Add Requirements" } },
            { "Inventory Management", new string[] { "View Products", "View Material" } },
            { "Delivery Management", new string[] { "View Delivery Order", "Add Delivery Order" } },
            { "Test Menu", new string[] { "Just Testing 2" } }
        };
        public String menuCurrent { get; set; }
        public void callMenu()
        {
            MenuTest menu = new MenuTest(this);
            this.menu = menu;
            menu.Show();
        }
        public void btnClicked_Sub1()
        {
            switch (menuCurrent)
            {
                case "MasterData Management":
                    Form form_masterdata_cus = new MasterData.CustomerData();
                    form_masterdata_cus.Show();
                    break;
                case "Product Requirements":
                    Form form_requirement_view = new ProductRequirement.ViewRequirements();
                    form_requirement_view.Show();
                    break;
                case "Inventory Management":
                    Form form_inv_viewProduct = new Inventory.ViewProducts();
                    form_inv_viewProduct.Show();
                    break;
                case "Delivery Management":
                    Form form_delivery_view = new Delivery.ViewDeliveryOrder();
                    form_delivery_view.Show();
                    break;
                case "Test Menu":
                    Form form_test = new JustTesting2.JustingTestingTwo_menu();
                    form_test.Show();
                    break;
                default:
                    throw new InvalidOperationException("Unknown menu item: " + menuCurrent);
            }
        }
        internal void btnClicked_Sub2()
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
                default:
                    throw new InvalidOperationException("Unknown menu item: " + menuCurrent);
            }
        }

        internal void btnClicked_MasterData()
        {
            menuCurrent = menuOfSubsystem[0];
            menu.setSubButtons(menuCurrent, menuItems[menuCurrent]);
        }

        internal void btnClicked_ProductRequirement()
        {
            menuCurrent = menuOfSubsystem[1];
            menu.setSubButtons(menuCurrent, menuItems[menuCurrent]);
        }

        internal void btnClicked_Inventory()
        {
            menuCurrent = menuOfSubsystem[2];
            menu.setSubButtons(menuCurrent, menuItems[menuCurrent]);
        }

        internal void btnClicked_Delivery()
        {
            menuCurrent = menuOfSubsystem[3];
            menu.setSubButtons(menuCurrent, menuItems[menuCurrent]);
        }

        internal void btnClicked_TestMenu()
        {
            menuCurrent = menuOfSubsystem[4];
            menu.setSubButtons(menuCurrent, menuItems[menuCurrent]);
        }
    }
}
