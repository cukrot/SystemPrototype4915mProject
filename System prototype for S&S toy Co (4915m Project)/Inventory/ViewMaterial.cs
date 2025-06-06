using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace System_prototype_for_S_S_toy_Co__4915m_Project_.Inventory
{
    public partial class ViewMaterial : Form
    {
        InventoryController controll;
        public ViewMaterial()
        {
            InitializeComponent();
        }

        private async void ViewMaterial_Load(object sender, EventArgs e)
        {
            controll = new InventoryController();
            try
            {
                DataTable dt = await controll.GetMaterialData();
                dtMaterials.DataSource = dt;
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
