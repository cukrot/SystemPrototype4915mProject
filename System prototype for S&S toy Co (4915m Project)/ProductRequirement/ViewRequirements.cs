using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace System_prototype_for_S_S_toy_Co__4915m_Project_.ProductRequirement
{
    public partial class ViewRequirements : Form
    {
        RequirementController control;
        public ViewRequirements()
        {
            InitializeComponent();
        }

        private async void ViewRequirements_Load(object sender, EventArgs e)
        {
            control = new RequirementController();
            try
            {
                DataTable dt = await control.GetProductRequirements();
                dtRequirement.DataSource = dt;
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
