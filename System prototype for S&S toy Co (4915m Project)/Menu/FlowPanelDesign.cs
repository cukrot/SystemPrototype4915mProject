using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System_prototype_for_S_S_toy_Co__4915m_Project_;

namespace System_prototype_for_S_S_toy_Co__4915m_Project_.Menu
{
    public partial class FlowPanelDesign : Form
    {
        public FlowPanelDesign()
        {
            InitializeComponent();
        }

        private void btnViewCustomer_Click(object sender, EventArgs e)
        {
            Form customerForm = new MasterData.CustomerData();
            customerForm.Show();
        }

        private void btnViewEmp_Click(object sender, EventArgs e)
        {
        }
    }
}
