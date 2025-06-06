using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace System_prototype_for_S_S_toy_Co__4915m_Project_.Delivery
{
    public partial class ViewDeliveryOrder : Form
    {
        DeliveryController controll;
        public ViewDeliveryOrder()
        {
            InitializeComponent();
        }

        private async void ViewDeliveryOrder_Load(object sender, EventArgs e)
        {
            controll = new DeliveryController();
            try
            {
                DataTable dt = await controll.GetDeliveryData();
                dtDOrders.DataSource = dt;
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
