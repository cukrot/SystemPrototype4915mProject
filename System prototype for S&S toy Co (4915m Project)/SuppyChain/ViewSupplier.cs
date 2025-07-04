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
    public partial class ViewSupplier : Form
    {
        DataTable dtSuplplierMaterial;
        SupplyChainController control;
        public ViewSupplier()
        {
            InitializeComponent();
        }
        public ViewSupplier(SupplyChainController control)
        {
            InitializeComponent();
            this.control = control;
        }

        private async void ViewSupplier_Load(object sender, EventArgs e)
        {
            getSupplierToToTable();
        }

        private async void getSupplierToToTable()
        {
            try
            {
                dtSuplplierMaterial = await control.GetSupplierMaterialData();
                if (dtSuplplierMaterial != null)
                {
                    DataTable dt = dtSuplplierMaterial.Copy(); // Create a copy of the DataTable
                    dgv.DataSource = dt;
                    dtSuplplierMaterial.AcceptChanges();
                }
                else
                {
                    MessageBox.Show("No supplier data found.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred while loading supplier data: {ex.Message}");
            }
        }

        private async void btnReload_Click(object sender, EventArgs e)
        {
            getSupplierToToTable();
        }

        private void btnFindByID_Click(object sender, EventArgs e)
        {
            string id = txtFindByID.Text;
            if (string.IsNullOrWhiteSpace(id))
            {
                MessageBox.Show("Please enter a Customer ID to search.");
                return;
            }

            DataTable dt = dtSuplplierMaterial.Copy();
            DataView dv = new DataView(dt);
            dv.RowFilter = $"SupplierID LIKE '%{id}%' OR MaterialID LIKE '%{id}%'";
            dgv.DataSource = dv;
        }

        private void btnFindByName_Click(object sender, EventArgs e)
        {
            string name = txtName.Text;
            if (string.IsNullOrWhiteSpace(name))
            {
                MessageBox.Show("Please enter a Supplier Name to search.");
                return;
            }
            DataTable dt = dtSuplplierMaterial.Copy();
            DataView dv = new DataView(dt);
            dv.RowFilter = $"SuppilierName LIKE '%{name}%' OR MaterialName LIKE '%{name}%'";
            dgv.DataSource = dv;
        }
    }
}
