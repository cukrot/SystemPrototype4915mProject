using Microsoft.VisualBasic.Devices;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace System_prototype_for_S_S_toy_Co__4915m_Project_.SuppyChain
{
    public partial class ViewPurchase : Form
    {
        SupplyChainController control;
        DataTable dtpurhase;
        public ViewPurchase()
        {
            InitializeComponent();
        }
        public ViewPurchase(SupplyChainController control)
        {
            InitializeComponent();
            this.control = control;
        }
        private async void ViewPurchase_Load(object sender, EventArgs e)
        {
            try
            {
                DataTable dt = await getPurchases();
                dtPurchase.DataSource = dt;
                dt.AcceptChanges();
            }
            catch (Exception ex)
            {
                // Log any other exceptions
                MessageBox.Show($"An error occurred: {ex.Message}");
            }
        }

        private async void btnReload_Click(object sender, EventArgs e)
        {
            try
            {
                DataTable dt = await getPurchases();
                dtPurchase.DataSource = dt;
                dt.AcceptChanges();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}");
            }
        }
        private async Task<DataTable> getPurchases()
        {
            try
            {
                DataTable purchase = await control.GetPurchaseRecords();
                DataTable purchaseline = await control.GetPurchaseLineRecords();
                DataTable dt = new DataTable("PurchaseRecords");
                dt.Merge(purchaseline);
                dt.Merge(purchase);
                dtpurhase = dt.Copy(); // Store the DataTable for later use
                return dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error retrieving purchase records: {ex.Message}");
                return null;
            }
        }

        private void btnFindByID_Click(object sender, EventArgs e)
        {
            string id = txtFindByID.Text;
            if (string.IsNullOrWhiteSpace(id))
            {
                MessageBox.Show("Please enter a Customer ID to search.");
                return;
            }

            DataTable dt = dtpurhase.Copy();
            DataView dv = new DataView(dt);
            //PurchaseID, SuplplierID, MaterialID
            dv.RowFilter = $"PurchaseID LIKE '%{id}%'";
            dtPurchase.DataSource = dv;
        }
    }
}
