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

    public partial class ViewProducts : Form
    {
        InventoryController controll;
        public ViewProducts()
        {
            InitializeComponent();
        }

        private async void ViewProducts_Load(object sender, EventArgs e)
        {
            controll = new InventoryController();
            try
            {
                DataTable dt = await controll.GetProductData();
                dtProduct.DataSource = dt;
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
