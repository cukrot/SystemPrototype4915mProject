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
                DataRow[] productInfo = await control.GetProductById(id);
                if (productInfo != null)
                {
                    DataTable dataTable = productInfo.CopyToDataTable(); // Convert DataRow array to DataTable
                    dtProductInfo.DataSource = dataTable;
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
            // Date format : "yyyy-MM-dd"
            DateTime currentDate = DateTime.Today;
            lblEmpID.Text = saleID;
            lblDate.Text = currentDate.ToString("yyyy-MM-dd");
        }

        private async void btnAddProduct_Click(object sender, EventArgs e) //Add product to the requirement
        {
            if (string.IsNullOrEmpty(txtQuantity.Text) || !int.TryParse(txtQuantity.Text, out int quantity) || quantity <= 0)
            {
                MessageBox.Show("Please enter a valid quantity.");
                return;
            }
            if (dtProductInfo.SelectedRows.Count > 0)
            {
                string productID = txtProductID.Text.Trim();

                // Assuming control has a method to add product to the requirement
                bool isAdded = false;
                try
                {
                    DataTable dt= await control.AddProductToRequirement(productID, quantity);
                    dtOrderline.DataSource = dt;
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
            if (dtOrderline.SelectedRows.Count == 0 || dtOrderline.SelectedRows[0].DataBoundItem == null)
            {
                MessageBox.Show("Please select a product to remove.");
                return;
            }
            DataRow selectedRow = ((DataRowView)dtOrderline.SelectedRows[0].DataBoundItem).Row;
            string productID = selectedRow["ProductID"].ToString();
            // Assuming control has a method to remove product from the requirement
            try
            {
                dtOrderline.DataSource = control.RemoveProductFromRequirement(productID);
                MessageBox.Show("Product removed successfully.");
                // Refresh the order line data grid view
                dtOrderline.Refresh();

            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error removing product: {ex.Message}");
            }
        }

        private void btnSubmit_Click(object sender, EventArgs e) //Insert the requirement into the database
        {
        }

        private void dtProductInfo_SelectionChanged(object sender, EventArgs e)
        {
            if (dtProductInfo.DataSource != null && dtProductInfo.SelectedRows.Count > 0)
            {
                DataRow selectedRow = ((DataRowView)dtProductInfo.SelectedRows[0].DataBoundItem).Row;
                txtProductID.Text = selectedRow["ProductID"].ToString();
                txtProductName.Text = selectedRow["Name"].ToString();
            }
        }
    }
}
