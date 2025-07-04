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
    public partial class MaterialLogForm : Form
    {
        InventoryController controll;
        public MaterialLogForm()
        {
            InitializeComponent();
            controll = new InventoryController();
        }

        private async void btnQuery_Click(object sender, EventArgs e)
        {
            DateTime start = dtpStart.Value.Date;
            DateTime end = dtpEnd.Value.Date.AddDays(1).AddSeconds(-1);
            var logTable = await controll.GetInventoryLog(start, end); // 假設 log 表有記錄 material 的進出貨
            dtLog.DataSource = logTable;
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            if (dtLog.DataSource is DataTable logTable)
            {
                using (SaveFileDialog sfd = new SaveFileDialog() { Filter = "CSV|*.csv" })
                {
                    if (sfd.ShowDialog() == DialogResult.OK)
                    {
                        ExportToCsv(logTable, sfd.FileName);
                        MessageBox.Show("Export completed！");
                    }
                }
            }
        }
        private void ExportToCsv(DataTable table, string filePath)
        {
            var lines = new List<string>();
            string[] columnNames = table.Columns.Cast<DataColumn>().Select(column => column.ColumnName).ToArray();
            lines.Add(string.Join(",", columnNames));
            var valueLines = table.AsEnumerable()
                .Select(row => string.Join(",", row.ItemArray.Select(field => $"\"{field?.ToString().Replace("\"", "\"\"")}\"")));
            lines.AddRange(valueLines);
            System.IO.File.WriteAllLines(filePath, lines, Encoding.UTF8);
        }
    }
}
