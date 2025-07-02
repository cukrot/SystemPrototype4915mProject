using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace System_prototype_for_S_S_toy_Co__4915m_Project_.Menu
{
    public partial class MenuTest : Form
    {
        Button[] buttonsOfSubButton;
        Button[] buttonsOfSubMenu;
        Dictionary<string, Button> buttonsOfSubSystem;

        private MenuController menuController;
        public MenuTest()
        {
            InitializeComponent();
        }
        public MenuTest(MenuController menuController)
        {
            InitializeComponent();
            this.menuController = menuController;
            this.buttonsOfSubButton = new Button[] {
                btnSub1, btnSub2, btnSub3, btnSub4
            };
            this.buttonsOfSubMenu = new Button[] {
                btnSubMenu1, btnSubMenu2, btnSubMenu3, btnSubMenu4, btnSubMenu5, btnSubMenu6, btnSubMenu7, btnSubMenu8, btnSubMenu9
            };
        }
        public void setMenuController(MenuController menuController)
        {
            this.menuController = menuController;
        }
        private void MenuTest_Load(object sender, EventArgs e)
        {
        }
        private void hideAllSubButtons()
        {
            btnSub1.Visible = false;
            btnSub2.Visible = false;
            btnSub3.Visible = false;
            btnSub4.Visible = false;
        }
        public void setSubMenuVisible(int numberOfSubMenus, string[] pagesOfSubsytem)
        {
            for (int i = 0; i < buttonsOfSubMenu.Length; i++)
            {
                buttonsOfSubMenu[i].Visible = false;
            }
            for (int i = 0; i < numberOfSubMenus; i++)
            {
                buttonsOfSubMenu[i].Visible = true;
                buttonsOfSubMenu[i].Text = pagesOfSubsytem[i];
            }
        }
        public void setSubButtonsVisible(int numberOfSubButtons, string[] pagesOfSubsytem)
        {
            hideAllSubButtons();
            for (int i = 0; i < numberOfSubButtons; i++)
            {
                buttonsOfSubButton[i].Visible = true;
                buttonsOfSubButton[i].Text = pagesOfSubsytem[i];
            }
        }

        private void btnSub2_Click(object sender, EventArgs e)
        {
            menuController.btnClicked_Sub(1);
        }

        private void btnSub1_Click(object sender, EventArgs e)
        {
            menuController.btnClicked_Sub(0);
        }

        private void btnSubMenu1_Click(object sender, EventArgs e)
        {
            menuController.setSubMenu(0);
        }

        private void btnSubMenu2_Click(object sender, EventArgs e)
        {
            menuController.setSubMenu(1);
        }

        private void btnSubMenu3_Click(object sender, EventArgs e)
        {
            menuController.setSubMenu(2);
        }

        private void btnSubMenu4_Click(object sender, EventArgs e)
        {
            menuController.setSubMenu(3);
        }

        private void btnSubMenu5_Click(object sender, EventArgs e)
        {
            menuController.setSubMenu(4);
        }

        private void btnSubMenu6_Click(object sender, EventArgs e)
        {
            menuController.setSubMenu(5);
        }

        private void btnSubMenu7_Click(object sender, EventArgs e)
        {
            menuController.setSubMenu(6);
        }

        private void btnSubMenu8_Click(object sender, EventArgs e)
        {
            menuController.setSubMenu(7);
        }

        private void btnSubMenu9_Click(object sender, EventArgs e)
        {
            menuController.setSubMenu(8);
        }
    }
}
