using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System_prototype_for_S_S_toy_Co__4915m_Project_.JustTesting;

namespace System_prototype_for_S_S_toy_Co__4915m_Project_.MasterData
{
    public partial class EmployeeData : Form
    {
        MasterDataController controll;
        public EmployeeData()
        {
            InitializeComponent();
        }

        private async void EmployeeData_Load(object sender, EventArgs e)
        {
            controll = new MasterDataController();

            try
            {
                DataTable dt = await controll.GetEmployeeData();
                dtEmployee.DataSource = dt;
                dt.AcceptChanges();
            }
            catch (Exception ex)
            {
                // Log any other exceptions
                MessageBox.Show($"An error occurred: {ex.Message}");
            }
        }
    }
}
