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
        private DataTable materialTable; // 用來暫存所有物料資料

        public ViewMaterial()
        {
            InitializeComponent();
        }

        private async void ViewMaterial_Load(object sender, EventArgs e)
        {
            controll = new InventoryController();
            try
            {
                materialTable = await controll.GetMaterialData(); // 已JOIN
                dtMaterials.DataSource = materialTable;
                materialTable.AcceptChanges();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}");
            }
        }

        public class MaterialController : SubSystemController
        {
            public MaterialController() { setApi("/api/MaterialAPI/"); }
            // 你可以根據實際 API 路徑調整 setApi 參數

            // 取得所有物料資料
            public async Task<DataTable> GetMaterialData()
            {
                DataTable dt = null;
                try
                {
                    dt = await GetTableData("material"); // 指定表名
                                                         // 或用 GetData("GetTableData", "material")
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                return dt;
            }

            // 更新物料資料
            public async Task<int> UpdateMaterialDataToAPI(DataTable dtUpdated)
            {
                String[] keysName = { "MaterialID" }; // 指定主鍵
                int rowsUpdated = await UpdateData(dtUpdated, "material", keysName);
                return rowsUpdated;
            }
        }

        private void btnSearch_Click_1(object sender, EventArgs e)
        {
            if (materialTable == null)
            {
                MessageBox.Show("Data has not been loaded yet, please try again later.");
                return;
            }
            string keyword = txtSearch.Text.Trim();
            if (string.IsNullOrEmpty(keyword))
            {
                dtMaterials.DataSource = materialTable;
                return;
            }
            var rows = materialTable.AsEnumerable()
                .Where(row =>
                    (row.Table.Columns.Contains("WarehouseID") && (row.Field<string>("WarehouseID")?.Contains(keyword, StringComparison.OrdinalIgnoreCase) ?? false)) ||
                    (row.Table.Columns.Contains("Loc") && (row.Field<string>("Loc")?.Contains(keyword, StringComparison.OrdinalIgnoreCase) ?? false)) ||
                    (row.Field<string>("MaterialID")?.Contains(keyword, StringComparison.OrdinalIgnoreCase) ?? false) ||
                    (row.Field<string>("Name")?.Contains(keyword, StringComparison.OrdinalIgnoreCase) ?? false)
                );
            dtMaterials.DataSource = rows.Any() ? rows.CopyToDataTable() : null;
        }

        private async void btnDelete_Click(object sender, EventArgs e)
        {
            if (dtMaterials.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select a material to delete.");
                return;
            }
            var row = dtMaterials.SelectedRows[0];
            string materialId = row.Cells["MaterialID"].Value.ToString();

            var dr = materialTable.AsEnumerable()
                .FirstOrDefault(r => r.Field<string>("MaterialID") == materialId);
            if (dr != null)
            {
                dr.Delete();
                await controll.UpdateData(materialTable, "material", new[] { "MaterialID" });
                dtMaterials.DataSource = materialTable;
            }
        }

        private async void btnEdit_Click(object sender, EventArgs e)
        {
            //await controll.UpdateData(materialTable, "material", new[] { "MaterialID" });
            //MessageBox.Show("Update successful!");
        }

        private void ExportToCsv(DataTable table, string filePath)
        {
            var lines = new List<string>();

            // 標題
            string[] columnNames = table.Columns.Cast<DataColumn>().Select(column => column.ColumnName).ToArray();
            lines.Add(string.Join(",", columnNames));

            // 資料
            var valueLines = table.AsEnumerable()
                .Select(row => string.Join(",", row.ItemArray.Select(field => $"\"{field?.ToString().Replace("\"", "\"\"")}\"")));
            lines.AddRange(valueLines);

            System.IO.File.WriteAllLines(filePath, lines, Encoding.UTF8);
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            if (materialTable == null)
            {
                MessageBox.Show("Data has not been loaded yet, please try again later.");
                return;
            }
            using (SaveFileDialog sfd = new SaveFileDialog() { Filter = "CSV|*.csv" })
            {
                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    ExportToCsv(materialTable, sfd.FileName);
                    MessageBox.Show("Export completed.");
                }
            }
        }

        private async void btnStockIn_Click(object sender, EventArgs e)
        {
            if (dtMaterials.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select material！");
                return;
            }
            string materialId = dtMaterials.SelectedRows[0].Cells["MaterialID"].Value.ToString();
            string warehouseId = dtMaterials.SelectedRows[0].Cells["WarehouseID"].Value.ToString();
            int qty = (int)numMaterialStockQty.Value;
            if (qty <= 0)
            {
                MessageBox.Show("Please enter the correct quantity！");
                return;
            }
            try
            {
                // 建議你在 InventoryController 新增 AdjustMaterialInventory 方法，參考 AdjustInventory
                await controll.AdjustMaterialInventory(materialId, warehouseId, qty);
                MessageBox.Show("Stock in successful！");
                await RefreshMaterialTable();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Stock in failed: {ex.Message}");
            }
        }

        private async void btnStockOut_Click(object sender, EventArgs e)
        {
            if (dtMaterials.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select material！");
                return;
            }
            string materialId = dtMaterials.SelectedRows[0].Cells["MaterialID"].Value.ToString();
            string warehouseId = dtMaterials.SelectedRows[0].Cells["WarehouseID"].Value.ToString();
            int qty = (int)numMaterialStockQty.Value;
            if (qty <= 0)
            {
                MessageBox.Show("Please enter the correct quantity！");
                return;
            }
            int currentQty = Convert.ToInt32(dtMaterials.SelectedRows[0].Cells["Qty"].Value);
            if (currentQty < qty)
            {
                MessageBox.Show("Insufficient stock, unable to ship！！");
                return;
            }
            try
            {
                await controll.AdjustMaterialInventory(materialId, warehouseId, -qty);
                MessageBox.Show("Shipment successful！");
                await RefreshMaterialTable();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Shipment failed: {ex.Message}");
            }
        }

        private async Task RefreshMaterialTable()
        {
            materialTable = await controll.GetMaterialData();
            dtMaterials.DataSource = materialTable;
        }

        private void btnRecord_Click(object sender, EventArgs e)
        {
            using (var logForm = new MaterialLogForm())
            {
                logForm.ShowDialog();
            }
        }

        private void btnProcurement_Click(object sender, EventArgs e)
        {
            using (var form = new MaterialProcurementListForm())
            {
                form.ShowDialog();
            }
        }
    }
}
