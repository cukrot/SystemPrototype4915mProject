using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;
using System_prototype_for_S_S_toy_Co__4915m_Project_.JustTesting;

namespace System_prototype_for_S_S_toy_Co__4915m_Project_.JustTesting2
{
    public partial class Form2 : Form
    {
        TestControll2 controll;
        string filterExpression;
        public Form2()
        {
            InitializeComponent();
        }

        public Form2(TestControll2 controll)
        {
            InitializeComponent();
            this.controll = controll;
        }

        private async void Form2_Load(object sender, EventArgs e)
        {
            try
            {
                DataTable dt = await controll.GetCustomerData(); 
                dataGridView1.DataSource = dt;
                dt.AcceptChanges();
                sbFilter.Items.Clear();
                sbSelFilter.Items.Clear();
                foreach (DataColumn column in dt.Columns)
                    sbFilter.Items.Add(column.ColumnName);
                txtFilter.Visible = false;
                btnFilterAdd.Visible = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}");
            }
        }

        private void clearFilterExpression()
        {
            controll.ClearFilter();
            sbSelFilter.Items.Clear();
            sbFilter.Items.Clear();
            sbSelFilter.Text = string.Empty;
            sbFilter.Text = string.Empty;
            txtFilter.Visible = false;
            btnFilterAdd.Visible = false;
        }

        private void addFilter(string filterColumn, string filterValue)     //Append filterExpression and sbSelFilter with the new filter, then show the result in the DataGridView
        {
            // Append the filter expression and add to sbSelFilter
            appendFilterExpression(filterColumn, filterValue);
            DataTable dt = (DataTable)dataGridView1.DataSource;
            dt.DefaultView.RowFilter = filterExpression;
            dataGridView1.DataSource = dt.DefaultView.ToTable();
        }

        private void appendFilterExpression(string filterColumn, string filterValue)
        {
            // Append the filter expression
            if (!string.IsNullOrEmpty(filterExpression))
            {
                filterExpression += " AND ";
            }
            filterExpression += $"{filterColumn} = {filterValue}";
            // Add to sbSelFilter
            sbSelFilter.Items.Add($"{filterColumn}: {filterValue}");
            sbSelFilter.Text = string.Empty; // Clear the selection in sbSelFilter
        }
        
        private async void button1_Click(object sender, EventArgs e)    //This button should be renamed as btnReload
        {
            //Note: This button is used to reload the data from controller
            //And reset the filter expression and selected filters
            try
            {
                DataTable dt = await controll.GetCustomerData();
                dataGridView1.DataSource = dt;
                dt.AcceptChanges();
                //Reset the filter expression and selected filters
                clearFilterExpression();
                foreach (DataColumn column in dt.Columns)
                {
                    sbFilter.Items.Add(column.ColumnName);
                }
                txtFilter.Visible = false;
                btnFilterAdd.Visible = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred while reloading data: {ex.Message}");
            }
        }

        private async void button2_Click(object sender, EventArgs e) //This button should be renamed as btnUpdate
        {
            DataTable dtUpdated = (DataTable)dataGridView1.DataSource;
            dtUpdated = dtUpdated.GetChanges();

            if (dtUpdated != null)
            {
                int rowsUpdated = await controll.UpdateCustomerDataToAPI(dtUpdated);
                if (rowsUpdated > 0)
                {
                    dtUpdated.AcceptChanges();
                    dataGridView1.DataSource = dtUpdated.Copy();
                }
                MessageBox.Show($"{rowsUpdated} rows updated successfully.");
            }
        }

        private void btnFilterAdd_Click(object sender, EventArgs e)
        {
            if (sbFilter.SelectedItem != null && !string.IsNullOrEmpty(txtFilter.Text))
            {
                string filterColumn = sbFilter.SelectedItem.ToString();
                string filterValue = txtFilter.Text;
                controll.AddCustomerFilter(filterColumn, filterValue);
                dataGridView1.DataSource = controll.GetFilteredCustomerData();
                UpdateFilterUI();
            }
            else
            {
                MessageBox.Show("Please select a column and enter a filter value.");
            }
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

        private void btnFindByID_Click(object sender, EventArgs e)
        {
            string id = txtFindByID.Text;
            if (string.IsNullOrWhiteSpace(id))
            {
                MessageBox.Show("Please enter a Customer ID to search.");
                return;
            }

            DataTable result = controll.FindCustomerByID(id);

            if (result != null && result.Rows.Count > 0)
            {
                dataGridView1.DataSource = result;
                UpdateFilterUI();
            }
            else
            {
                MessageBox.Show($"No customer found with ID: {id}");
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
                    controll.RemoveCustomerFilter(parts[0].Trim(), parts[1].Trim());
                    dataGridView1.DataSource = controll.GetFilteredCustomerData();
                    UpdateFilterUI();
                }
            }
            else
            {
                MessageBox.Show("Please select a filter to remove.");
            }
        }

        private void UpdateFilterUI()
        {
            sbSelFilter.Items.Clear();
            foreach (var filter in controll.FilterList)
                sbSelFilter.Items.Add(filter);
            sbSelFilter.Text = string.Empty;
        }
    }
}
