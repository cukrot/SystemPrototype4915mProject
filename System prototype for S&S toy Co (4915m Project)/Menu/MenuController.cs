using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System_prototype_for_S_S_toy_Co__4915m_Project_.Login;

namespace System_prototype_for_S_S_toy_Co__4915m_Project_.Menu
{
    public class MenuController
    {
        MenuTest menu;
        LoginController loginController;
        public MenuController() {
            menuCurrent = menuItems[0]; // Default to the first item
        }
        public MenuController(LoginController login, MenuTest menu)
        {
            menuCurrent = menuItems[0]; // Default to the first item
            loginController = login;
            this.menu = menu;
            menu.setMenuController(this);
        }
        String [] menuItems =
        {
            "MasterData Management",
            "Product Requirements",
            "Inventory Management",
            "Delivery Management",
        };
        public String menuCurrent { get; set; }
        public void callMenu()
        {
            MenuTest menu = new MenuTest(this);
            menu.Show();
        }
        internal void btnClicked_Sub1()
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
            menuCurrent = menuItems[0];
        }

        internal void btnClicked_ProductRequirement()
        {
            menuCurrent = menuItems[1];
        }

        internal void btnClicked_Inventory()
        {
            menuCurrent = menuItems[2];
        }

        internal void btnClicked_Delivery()
        {
            menuCurrent = menuItems[3];
        }


    }
}
