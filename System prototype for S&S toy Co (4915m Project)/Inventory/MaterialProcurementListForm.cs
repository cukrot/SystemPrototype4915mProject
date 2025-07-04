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

    public partial class MaterialProcurementListForm : Form
    {
        
        private InventoryController controll;
        public MaterialProcurementListForm()
        {
            InitializeComponent();
            controll = new InventoryController();
            dgvProcurement.ReadOnly = false;
        }

        private async void btnSearch_Click(object sender, EventArgs e)
        {
            var dt = await SearchProcurement(
    dtpStart.Value, dtpEnd.Value, txtKeyword.Text);

            // 強制 Date 欄位型別為 DateTime
            if (dt.Columns["Date"].DataType != typeof(DateTime))
            {
                dt.Columns["Date"].ReadOnly = false;
                foreach (DataRow row in dt.Rows)
                {
                    if (DateTime.TryParse(row["Date"]?.ToString(), out var dateValue))
                        row["Date"] = dateValue.ToString("yyyy-MM-dd"); // 格式化為 yyyy-MM-dd
                    else
                        row["Date"] = DateTime.Today.ToString("yyyy-mm-dd"); // 預設值為今天
                }
                dt.Columns["Date"].ReadOnly = true;
            }
            dt.AcceptChanges();
            dgvProcurement.DataSource = dt;

            // 將 DataGridView 的 Date 欄位設為唯讀
            if (dgvProcurement.Columns["Date"] != null)
            {
                dgvProcurement.Columns["Date"].ReadOnly = true;
                dgvProcurement.Columns["Date"].DefaultCellStyle.BackColor = Color.LightGray; // 可選：讓唯讀欄位顏色不同
            }
        }




        private async Task<DataTable> SearchProcurement(DateTime start, DateTime end, string keyword)
        {
            
            string sql = $@"
SELECT ProcurementID, Date, SupplierID, Status, Remark
FROM ProcurementHeader
WHERE Date BETWEEN '{start:yyyy-MM-dd}' AND '{end:yyyy-MM-dd}'";
            
            if (!string.IsNullOrWhiteSpace(keyword))
            {
                sql += $" AND (ProcurementID LIKE '%{keyword}%' OR SupplierID LIKE '%{keyword}%' OR Remark LIKE '%{keyword}%')";
            }
            sql += " ORDER BY Date DESC";
            return await controll.QueryTableBySql(sql);
        }

        // 匯出 CSV
        private void ExportToCsv(DataTable table, string filePath)
        {
            var lines = new System.Collections.Generic.List<string>();
            string[] columnNames = table.Columns.Cast<DataColumn>().Select(column => column.ColumnName).ToArray();
            lines.Add(string.Join(",", columnNames));
            var valueLines = table.AsEnumerable()
                .Select(row => string.Join(",", row.ItemArray.Select(field => $"\"{field?.ToString().Replace("\"", "\"\"")}\"")));
            lines.AddRange(valueLines);
            System.IO.File.WriteAllLines(filePath, lines, Encoding.UTF8);
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {

        }

        private async void btnEdit_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvProcurement.DataSource is DataTable dt)
                {

                    string[] keys = { "ProcurementID" };
                    int updated = await controll.UpdateData(dt, "ProcurementHeader", keys);
                    MessageBox.Show($"Save completed! {updated} row(s) updated.");
                    var refreshed = await SearchProcurement(dtpStart.Value, dtpEnd.Value, txtKeyword.Text);
                    dgvProcurement.DataSource = refreshed;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void btnDelete_Click(object sender, EventArgs e)
        {
            if (dgvProcurement.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select the purchase order to delete first！");
                return;
            }
            string procurementId = dgvProcurement.SelectedRows[0].Cells["ProcurementID"].Value.ToString();
            if (MessageBox.Show($"Are you sure you want to delete the purchase order {procurementId}？", "Yes", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                // 假設你有一個刪除方法
                string sql = $"DELETE FROM ProcurementHeader WHERE ProcurementID = '{procurementId}'";
                await controll.QueryTableBySql(sql); 
                btnSearch.PerformClick();
                MessageBox.Show("Deleted！");
            }
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            if (dgvProcurement.DataSource is DataTable dt)
            {
                using (SaveFileDialog sfd = new SaveFileDialog() { Filter = "CSV|*.csv" })
                {
                    if (sfd.ShowDialog() == DialogResult.OK)
                    {
                        ExportToCsv(dt, sfd.FileName);
                        MessageBox.Show("Export completed！");
                    }
                }
            }
        }
        
    }

}
