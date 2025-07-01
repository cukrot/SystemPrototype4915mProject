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
        private MenuController menuController;
        public MenuTest()
        {
            InitializeComponent();
        }
        public MenuTest(MenuController menuController)
        {
            InitializeComponent();
            this.menuController = menuController;
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
        private void btnMasterData_Click(object sender, EventArgs e)
        {
            menuController.btnClicked_MasterData();

        }

        private void btnPRequirement_Click(object sender, EventArgs e)
        {
            menuController.btnClicked_ProductRequirement();
        }

        private void btnInv_Click(object sender, EventArgs e)
        {
            menuController.btnClicked_Inventory();
        }

        private void btnDelivery_Click(object sender, EventArgs e)
        {
            menuController.btnClicked_Delivery();
        }

        private void btnSub2_Click(object sender, EventArgs e)
        {
            menuController.btnClicked_Sub2();
        }

        private void btnSub1_Click(object sender, EventArgs e)
        {
            menuController.btnClicked_Sub1();
        }

        private void btnTestMenu_Click(object sender, EventArgs e)
        {
            hideAllSubButtons();
            menuController.btnClicked_TestMenu();
        }

        public void setSubButtons(string v, string[] subItems)
        {
            hideAllSubButtons();
            int length = subItems.Length;
            switch (length)
            {
                case 1:
                    btnSub1.Text = subItems[0];
                    btnSub1.Visible = true;
                    break; // Add break to prevent fall-through
                case 2:
                    btnSub1.Text = subItems[0];
                    btnSub1.Visible = true;
                    btnSub2.Text = subItems[1];
                    btnSub2.Visible = true;
                    break; // Add break to prevent fall-through
                case 3:
                    btnSub1.Text = subItems[0];
                    btnSub1.Visible = true;
                    btnSub2.Text = subItems[1];
                    btnSub2.Visible = true;
                    btnSub3.Text = subItems[2];
                    btnSub3.Visible = true;
                    break; // Add break to prevent fall-through
                case 4:
                    btnSub1.Text = subItems[0];
                    btnSub1.Visible = true;
                    btnSub2.Text = subItems[1];
                    btnSub2.Visible = true;
                    btnSub3.Text = subItems[2];
                    btnSub3.Visible = true;
                    btnSub4.Text = subItems[3];
                    btnSub4.Visible = true;
                    break; // Add break to prevent fall-through
                default:
                    MessageBox.Show("No Sub Menu Items Available");
                    break;
            }
        }
    }
}
