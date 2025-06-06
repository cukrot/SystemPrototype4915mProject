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
            hideAllSubButtons();
            menuController.btnClicked_MasterData();
            btnSub1.Text = "View Customer Data";
            btnSub1.Visible = true;
            btnSub2.Text = "View Employee Data";
            btnSub2.Visible = true;
        }

        private void btnPRequirement_Click(object sender, EventArgs e)
        {
            hideAllSubButtons();
            menuController.btnClicked_ProductRequirement();
            btnSub1.Text = "View Product Requirements";
            btnSub1.Visible = true;
        }

        private void btnInv_Click(object sender, EventArgs e)
        {
            hideAllSubButtons();
            menuController.btnClicked_Inventory();
            btnSub1.Text = "View Product Inventory";
            btnSub1.Visible = true;
            btnSub2.Text = "View Material Inventory";
            btnSub2.Visible = true;
        }

        private void btnDelivery_Click(object sender, EventArgs e)
        {
            hideAllSubButtons();
            menuController.btnClicked_Delivery();
            btnSub1.Text = "View Delivery Order Data";
            btnSub1.Visible = true;
        }

        private void btnSub2_Click(object sender, EventArgs e)
        {
            menuController.btnClicked_Sub2();
        }

        private void btnSub1_Click(object sender, EventArgs e)
        {
            menuController.btnClicked_Sub1();
        }
    }
}
