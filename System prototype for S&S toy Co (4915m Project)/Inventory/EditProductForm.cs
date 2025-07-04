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
    public partial class EditProductForm : Form
    {
        InventoryController controll;
        private DataTable productTable;

        public EditProductForm()
        {
            InitializeComponent();
            controll = new InventoryController();
            this.Load += EditProductForm_Load;
        }

        private async void EditProductForm_Load(object sender, EventArgs e)
        {
            await RefreshProductTable();
        }

        private async void btnEdit_Click(object sender, EventArgs e)
        {
            var changes = productTable.GetChanges();
            if (changes == null)
            {
                MessageBox.Show("No change data！");
                return;
            }
            await controll.UpdateData(changes, "product", new[] { "ProductID" });
            MessageBox.Show("Update successful!");
            productTable.AcceptChanges();

            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private async void btnDelete_Click(object sender, EventArgs e)
        {
            var selectedRows = dtProduct.SelectedRows;
            if (selectedRows.Count == 0)
            {
                MessageBox.Show("Please select a product first");
                return;
            }
            string productId = selectedRows[0].Cells["ProductID"].Value.ToString();

            var dr = productTable.AsEnumerable()
                .FirstOrDefault(r => r.Field<string>("ProductID") == productId);
            if (dr != null)
            {
                dr.Delete();
                await controll.UpdateData(productTable, "product", new[] { "ProductID" });
                dtProduct.DataSource = productTable;
                MessageBox.Show("Delete successful!");
            }
        }

        private async Task RefreshProductTable()
        {
            productTable = await controll.GetProductData(); // 只查 product 表
            dtProduct.DataSource = productTable;
            productTable.AcceptChanges();
        }
        private void btnSearch_Click(object sender, EventArgs e)
        {
            string keyword = txtProductSearch.Text.Trim();
            if (string.IsNullOrEmpty(keyword))
            {
                dtProduct.DataSource = productTable;
                return;
            }
            var rows = productTable.AsEnumerable()
                .Where(row => row.Field<string>("ProductID")?.Contains(keyword, StringComparison.OrdinalIgnoreCase) == true
                           || row.Field<string>("Name")?.Contains(keyword, StringComparison.OrdinalIgnoreCase) == true);

            dtProduct.DataSource = rows.Any() ? rows.CopyToDataTable() : null;
        }

        private void EditProductForm_Load_1(object sender, EventArgs e)
        {

        }
    }
}
