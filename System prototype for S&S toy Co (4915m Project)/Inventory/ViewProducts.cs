using EntityModels;
using Newtonsoft.Json;
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
        private DataTable productTable;
        private DataTable warehouseTable;
        private DataTable inventoryTable; // To store inventory data if needed

        public ViewProducts()
        {
            InitializeComponent();
        }

        private async void ViewProducts_Load(object sender, EventArgs e)
        {
            controll = new InventoryController();
            try
            {
                productTable = await controll.GetProductWithInventoryData();
                
                dtProduct.DataSource = productTable;
                productTable.AcceptChanges();
            }
            catch (Exception ex)
            {
                // Log any other exceptions
                MessageBox.Show($"An error occurred: {ex.Message}");
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            if (productTable == null)
            {
                MessageBox.Show("Product data has not been loaded yet, please try again later.");
                return;
            }
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

        private void btnAdd_Click(object sender, EventArgs e)
        {

        }

        private async void btnEdit_Click(object sender, EventArgs e)
        {
            using (var editForm = new EditProductForm())
            {
                if (editForm.ShowDialog() == DialogResult.OK)
                {
                    await RefreshProductTable();
                }
            }
        }

        private async void btnDelete_Click(object sender, EventArgs e)
        {
            if (dtProduct.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select a product to delete.");
                return;
            }
            var row = dtProduct.SelectedRows[0];
            string productId = row.Cells["ProductID"].Value.ToString();

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


        private void btnExport_Click(object sender, EventArgs e)
        {
            if (productTable == null)
            {
                MessageBox.Show("Product data is not loaded yet. Please try again later.");
                return;
            }
            using (SaveFileDialog sfd = new SaveFileDialog() { Filter = "CSV|*.csv" })
            {
                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    ExportToCsv(productTable, sfd.FileName);
                    MessageBox.Show("Export completed!");
                }
            }
        }


        private void ExportToCsv(DataTable table, string filePath)
        {
            var lines = new List<string>();

            // Header
            string[] columnNames = table.Columns.Cast<DataColumn>().Select(column => column.ColumnName).ToArray();
            lines.Add(string.Join(",", columnNames));

            // Data
            var valueLines = table.AsEnumerable()
                .Select(row => string.Join(",", row.ItemArray.Select(field => $"\"{field?.ToString().Replace("\"", "\"\"")}\"")));
            lines.AddRange(valueLines);

            System.IO.File.WriteAllLines(filePath, lines, Encoding.UTF8);
        }



        private async void btnStockIn_Click(object sender, EventArgs e)
        {
            if (dtProduct.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select a product！");
                return;
            }
            string productId = dtProduct.SelectedRows[0].Cells["ProductID"].Value.ToString();
            string warehouseId = dtProduct.SelectedRows[0].Cells["WarehouseID"].Value.ToString();
            int qty = (int)numStockQty.Value;
            if (qty <= 0)
            {
                MessageBox.Show("Please enter the correct quantity！");
                return;
            }
            try
            {
                await controll.AdjustInventory(productId, warehouseId, qty); // 進貨
                MessageBox.Show("Stock in successful！");
                await RefreshProductTable();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Stock in failed: {ex.Message}");
            }
        }

        private async void btnStockOut_Click(object sender, EventArgs e)
        {
            if (dtProduct.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select a product！");
                return;
            }
            string productId = dtProduct.SelectedRows[0].Cells["ProductID"].Value.ToString();
            string warehouseId = dtProduct.SelectedRows[0].Cells["WarehouseID"].Value.ToString();
            int qty = (int)numStockQty.Value;
            if (qty <= 0)
            {
                MessageBox.Show("Please enter the correct quantity！");
                return;
            }
            // 檢查庫存是否足夠
            int currentQty = Convert.ToInt32(dtProduct.SelectedRows[0].Cells["Qty"].Value);
            if (currentQty < qty)
            {
                MessageBox.Show("Insufficient stock, unable to ship！");
                return;
            }
            try
            {
                await controll.AdjustInventory(productId, warehouseId, -qty); // 出貨
                MessageBox.Show("Shipment successful！");
                await RefreshProductTable();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Shipment failed: {ex.Message}");
            }
        }
        private async Task RefreshProductTable()
        {
            productTable = await controll.GetProductWithInventoryData();
            dtProduct.DataSource = productTable;
        }

        private DataTable FilterProductTable(DataTable source)
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("ProductID");
            dt.Columns.Add("Name");

            foreach (DataRow row in source.Rows)
            {
                // 只複製 ProductID 和 Name 欄位
                dt.Rows.Add(row["ProductID"], row["Name"]);
            }
            return dt;
        }

        private void btnRecord_Click(object sender, EventArgs e)
        {
            using (var logForm = new ProductLogForm())
            {
                logForm.ShowDialog();
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
