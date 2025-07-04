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

        internal void btnLogout()
        {
            System.Windows.Forms.DialogResult result = MessageBox.Show("Are you sure you want to log out?", "Logout Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == System.Windows.Forms.DialogResult.Yes)
            {
                systemController.logout();
            }
            else
            {
                // User chose not to log out, do nothing or handle accordingly
            }
        }
    }
}
