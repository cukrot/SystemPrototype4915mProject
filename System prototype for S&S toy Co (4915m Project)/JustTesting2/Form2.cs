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
                //Set the sbFilter to the columns of the DataTable
                sbFilter.Items.Clear();

                filterExpression = string.Empty;
                sbSelFilter.Items.Clear();
                foreach (DataColumn column in dt.Columns)
                {
                    sbFilter.Items.Add(column.ColumnName);
                }
                txtFilter.Visible = false;
                btnFilterAdd.Visible = false;
            }
            catch (Exception ex)
            {
                // Log any other exceptions
                MessageBox.Show($"An error occurred: {ex.Message}");
            }
        }

        private void clearFilterExpression()
        {
            // Clear the filter expression and selected filters
            filterExpression = string.Empty;
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
                //Append the filter expression
                //and add to sbSelFilter, then show the result in the DataGridView
                addFilter(filterColumn, filterValue);
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
            // Check if the text in txtFindByID is numberic or not
            string id = txtFindByID.Text;
            if (string.IsNullOrWhiteSpace(id))
            {
                MessageBox.Show("Please enter a Customer ID to search.");
                return;
            }
            else if (!int.TryParse(id, out _))
            {
                MessageBox.Show("Please enter a valid numeric Customer ID.");
                return;
            }

            //First filter with id by using DataView.RowFilter
            //If result is not empty
            //Check if the DataGridView is filtered or not,
            //then clear the existed filter expression and selected filters by calling clearFilterExpression().
            //Finally, set the filter expression to the new filter expression by calling addFilter() method and show the result in the DataGridView.
            //If result is empty then show a message

            DataTable dt = (DataTable)dataGridView1.DataSource;
            DataView dv = new DataView(dt.Copy());

            // Assuming first column is id column, get the first column name
            string idColumn = dt.Columns[0].ColumnName;
            string IDFilterExpression = $"{idColumn} = {id}";

            dv.RowFilter = IDFilterExpression; // Filter the DataView by ID

            if (dv.Count > 0)   // Check if the filtered DataView has any rows
            {
                // Clear the existing filter expression and selected filters
                clearFilterExpression();
                // Set the filter expression to the new filter expression
                addFilter(idColumn, id);
                // This is to ensure that the original data remains intact for further operations
                dataGridView1.DataSource = dt; // Keep the original DataTable as DataSource
                dt.DefaultView.RowFilter = filterExpression; // Apply the filter expression to the DataTable's DefaultView
            }
            else
            {
                // If no rows found, show a message and set the DataGridView to original data
                MessageBox.Show($"No customer found with ID: {id}");
            }
            DataTable dt_view = dt;
        }

        private void btnRemoveFilter_Click(object sender, EventArgs e)
        {
            //Remove the selected filter from the sbSelFilter
            //Note : Filter exists in the sbSelFilter and FilterExpression

            if (sbSelFilter.SelectedItem != null && sbSelFilter.Items.Count == 1) //Reset the filter expression and selected filters if only one filter exists //Case caused by wrong string manipluation from FindByID button
            {
                clearFilterExpression();
                DataTable dt = (DataTable)dataGridView1.DataSource;
                dt.DefaultView.RowFilter = string.Empty; // Clear the filter on DataGridView
                dataGridView1.DataSource = dt; // Reset the DataGridView to original data
                // Reset the sbFilter items
                sbFilter.Items.Clear();
                foreach (DataColumn column in dt.Columns)
                {
                    sbFilter.Items.Add(column.ColumnName);
                }
                txtFilter.Visible = false;
                btnFilterAdd.Visible = false;
            }
            else if (sbSelFilter.SelectedItem != null)
            {
                string selectedFilter = sbSelFilter.SelectedItem.ToString();
                sbSelFilter.Items.Remove(selectedFilter);
                //Remove the filter expression from the filterExpression
                string filterColumn = selectedFilter.Split(':')[0].Trim();
                string filterValue = selectedFilter.Split(':')[1].Trim();
                if (filterExpression.Contains($"{filterColumn} LIKE '%{filterValue}%'"))
                {
                    filterExpression = filterExpression.Replace($" AND {filterColumn} LIKE '%{filterValue}%'", string.Empty);
                    filterExpression = filterExpression.Replace($"{filterColumn} LIKE '%{filterValue}%'", string.Empty);
                }
                DataTable dt = (DataTable)dataGridView1.DataSource;
                dt.DefaultView.RowFilter = filterExpression;
            }
            else
            {
                MessageBox.Show("Please select a filter to remove.");
            }
        }
    }
}
