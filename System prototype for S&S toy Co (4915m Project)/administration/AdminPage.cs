using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System_prototype_for_S_S_toy_Co__4915m_Project_.administration;

namespace System_prototype_for_S_S_toy_Co__4915m_Project_.MasterData
{
    public partial class AdminPage : Form
    {
        private AdminController controller;
        public AdminPage()
        {
            InitializeComponent();
        }
        public AdminPage(AdminController controller)
        {
            InitializeComponent();
            this.controller = controller;
        }

        private void UserAccountPage_Load(object sender, EventArgs e)
        {
            plModify.Visible = false;
        }
        private void btnFindByID_Click(object sender, EventArgs e)
        {
            controller.findEmployeeByID(textBox1.Text.Trim());
        }
    }
}
