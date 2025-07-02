using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace System_prototype_for_S_S_toy_Co__4915m_Project_.MasterData
{
    public partial class MasterDataMaintance : Form
    {
        MasterDataController masterDataController;
        public MasterDataMaintance()
        {
            InitializeComponent();
        }
        public MasterDataMaintance(MasterDataController masterDataController)
        {
            InitializeComponent();
            this.masterDataController = masterDataController;
        }

        private void MasterDataMaintance_Load(object sender, EventArgs e)
        {
            sbTable.DataSource = masterDataController.GetTableNames();
            txtFilter.Visible = false;
            btnFilterAdd.Visible = false;
        }

        private async void btnGet_Click(object sender, EventArgs e)
        {
            if (sbTable.SelectedItem != null)
            {
                try
                {
                    string selectedTable = sbTable.SelectedItem.ToString();
                    DataTable dt = await masterDataController.GetDataFromTable(selectedTable);
                    if (dt != null && dt.Rows.Count > 0)
                    {
                        dataGridView1.DataSource = dt;
                        dataGridView1.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);
                        dt.AcceptChanges(); // Accept changes to the DataTable
                        clearFilterExpression();
                        foreach (DataColumn column in dt.Columns)
                        {
                            sbFilter.Items.Add(column.ColumnName);
                        }
                        txtFilter.Visible = false;
                        btnFilterAdd.Visible = false;
                    }
                    else
                    {
                        MessageBox.Show("No data found in the selected table.");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"An error occurred while retrieving data: {ex.Message}");
                }
            }
            else
            {
                MessageBox.Show("Please select a table to view data.");
            }
        }

        private void btnReload_Click(object sender, EventArgs e)
        {
            try
            {
                DataTable dt = masterDataController.reloadMasterTable();
                if (dt != null && dt.Rows.Count > 0)
                {
                    dataGridView1.DataSource = dt;
                    dataGridView1.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);
                    dt.AcceptChanges(); // Accept changes to the DataTable
                    clearFilterExpression();
                    foreach (DataColumn column in dt.Columns)
                    {
                        sbFilter.Items.Add(column.ColumnName);
                    }
                    txtFilter.Visible = false;
                    btnFilterAdd.Visible = false;
                }
                else
                {
                    MessageBox.Show("No data found after reloading tables.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred while reloading tables: {ex.Message}");
            }
        }

        private async void btnUpdate_Click(object sender, EventArgs e)
        {
            DataTable dtUpdated = (DataTable)dataGridView1.DataSource;
            dtUpdated = dtUpdated.GetChanges(); // Get changes made to the DataTable
            try
            {
                if (dtUpdated != null)
                {
                    int rowsUpdated = await masterDataController.UpdateMasterTableData(dtUpdated);
                    if (rowsUpdated > 0)
                    {
                        dtUpdated.AcceptChanges();
                        dataGridView1.DataSource = dtUpdated.Copy();
                    }
                    MessageBox.Show($"{rowsUpdated} rows updated successfully.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred while updating data: {ex.Message}");
            }
        }
        private void clearFilterExpression()
        {
            sbSelFilter.Items.Clear();
            sbFilter.Items.Clear();
            sbSelFilter.Text = string.Empty;
            sbFilter.Text = string.Empty;
            txtFilter.Visible = false;
            btnFilterAdd.Visible = false;
        }

        private void btnFilterAdd_Click(object sender, EventArgs e)
        {
            if (sbFilter.SelectedItem != null && !string.IsNullOrEmpty(txtFilter.Text))
            {
                string filterColumn = sbFilter.SelectedItem.ToString();
                string filterValue = txtFilter.Text;
                masterDataController.AddMasterDataFilter(filterColumn, filterValue);
                dataGridView1.DataSource = masterDataController.GetFilteredMasterData();
                UpdateFilterUI();
            }
            else
            {
                MessageBox.Show("Please select a column and enter a filter value.");
            }
        }

        private void UpdateFilterUI()
        {
            sbSelFilter.Items.Clear();
            sbSelFilter.Text = string.Empty;
        }

        private void sbFilter_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (sbFilter.SelectedItem != null)
            {
                txtFilter.Visible = true;
                btnFilterAdd.Visible = true;
                txtFilter.Text = string.Empty; // Clear the filter text box
            }
            else
            {
                txtFilter.Visible = false;
                btnFilterAdd.Visible = false;
            }
        }

        private void btnRemoveFilter_Click(object sender, EventArgs e)
        {
            if (sbSelFilter.SelectedItem != null)
            {
                string selectedFilter = sbSelFilter.SelectedItem.ToString();
                var parts = selectedFilter.Split(':');
                if (parts.Length == 2)
                {
                    masterDataController.removeMasterDataFilter(parts[0].Trim(), parts[1].Trim());
                    dataGridView1.DataSource = masterDataController.GetFilteredMasterData();
                    UpdateFilterUI();
                }
            }
            else
            {
                MessageBox.Show("Please select a filter to remove.");
            }
        }

        private void btnFindByID_Click(object sender, EventArgs e)
        {
            string id = txtFindByID.Text;
            if (string.IsNullOrWhiteSpace(id))
            {
                MessageBox.Show("Please enter a ID to search.");
                return;
            }
            clearFilterExpression();
            DataTable result = masterDataController.FindMasterDataNyID(id);

            if (result != null && result.Rows.Count > 0)
            {
                dataGridView1.DataSource = result;
            }
            else
            {
                MessageBox.Show($"No data found with ID: {id}");
            }
        }
    }
}
