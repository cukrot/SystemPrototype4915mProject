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
    public partial class CreateRequirement : Form
    {
        SaleController control;
        public CreateRequirement()
        {
            InitializeComponent();
        }
        public CreateRequirement(SaleController control)
        {
            InitializeComponent();
            this.control = control;
        }

        private async void btnFindByID_Click(object sender, EventArgs e) //Find product by ID
        {
            string id = txtFindByID.Text.Trim();
            if (string.IsNullOrEmpty(id))
            {
                MessageBox.Show("Please enter a Product ID to search.");
                return;
            }
            // Assuming control has a method to find product by ID, and it returns a DataRow or similar object
            try
            {
                DataRow productInfo = await control.GetProductById(id);
                if (productInfo != null)
                {
                    dtProductInfo.DataSource = productInfo;
                }
                else
                {
                    MessageBox.Show("No product found with the given ID.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error retrieving product: {ex.Message}");
            }
        }

        private async void btnFilterAdd_Click(object sender, EventArgs e) //Find product by Name
        {
            string productName = txtFilter.Text.Trim();
            if (string.IsNullOrEmpty(productName))
            {
                MessageBox.Show("Please enter a Product Name to search.");
                return;
            }
            try
            {
                DataTable productInfo = await control.GetProductsByName(productName);
                if (productInfo != null && productInfo.Rows.Count > 0)
                {
                    dtProductInfo.DataSource = productInfo;
                }
                else
                {
                    MessageBox.Show("No products found with the given name.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error retrieving products: {ex.Message}");
            }
        }

        private void CreateRequirement_Load(object sender, EventArgs e)
        {
            string saleID = control.GetSaleID();
        }

        private async void btnAddProduct_Click(object sender, EventArgs e) //Add product to the requirement
        {
            if (dtProductInfo.SelectedRows.Count > 0)
            {
                DataRow selectedRow = ((DataRowView)dtProductInfo.SelectedRows[0].DataBoundItem).Row;
                string productID = selectedRow["ProductID"].ToString();

                // Assuming control has a method to add product to the requirement
                bool isAdded = false;
                try
                {   //affectedRows = await control.AddProductToRequirement(productID, quantity);
                    dtProductInfo.DataSource = null; // Clear the DataGridView after adding
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error adding product: {ex.Message}");
                }
            }
            else
            {
                MessageBox.Show("Please select a product to add.");
            }
        }

        private void btnRemoveProduct_Click(object sender, EventArgs e)
        {

        }

        private void btnSubmit_Click(object sender, EventArgs e) //Insert the requirement into the database
        {
        }
    }
}
