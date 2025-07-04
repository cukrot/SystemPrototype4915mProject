using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System_prototype_for_S_S_toy_Co__4915m_Project_.MasterData;

namespace System_prototype_for_S_S_toy_Co__4915m_Project_.ProductRequirement
{
    public partial class ViewRequirements : Form
    {
        SaleController control;
        string filterExpression;
        public ViewRequirements()
        {
            InitializeComponent();
            control = new SaleController(this);
        }
        public ViewRequirements(SaleController control)
        {
            InitializeComponent();
            this.control = control;
        }

        private async void ViewRequirements_Load(object sender, EventArgs e)
        {
            try
            {
                DataTable dt = await control.GetProductRequirements();
                dtRequirement.DataSource = dt;
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
                // Log any other exceptions
                MessageBox.Show($"An error occurred: {ex.Message}");
            }
        }


        private async void btnReload_Click(object sender, EventArgs e)
        {
            try
            {
                DataTable dt = await control.GetProductRequirements(); // Assuming GetProductRequirements() is a method in RequirementController that fetches product requirements
                dtRequirement.DataSource = dt;
                dt.AcceptChanges();
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
                MessageBox.Show($"An error occurred: {ex.Message}");
            }
        }

        private async void btnUpdate_Click(object sender, EventArgs e)
        {
            DataTable dtUpdated = (DataTable)dtRequirement.DataSource;
            dtUpdated = dtUpdated.GetChanges();
            if (dtUpdated != null)
            {
                int rowsUpdated = await control.UpdateProductRequiremen(dtUpdated);
                if (rowsUpdated > 0)
                {
                    MessageBox.Show($"{rowsUpdated} rows updated successfully.");
                }
                else
                {
                    MessageBox.Show("No rows were updated. Please check your input.");
                }
            }
            else
            {
                MessageBox.Show("No changes detected to update.");
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
        private void UpdateFilterUI()
        {
            sbSelFilter.Items.Clear();
            foreach (var filter in control.FilterList)
                sbSelFilter.Items.Add(filter);
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
        private void btnFindByID_Click(object sender, EventArgs e)
        {
            string id = txtFindByID.Text;
            if (string.IsNullOrWhiteSpace(id))
            {
                MessageBox.Show("Please enter a Customer ID to search.");
                return;
            }
            DataTable result = control.FindOrderByCustomerID_view(id, filterExpression);

            if (result != null && result.Rows.Count > 0)
            {
                dtRequirement.DataSource = result;
                UpdateFilterUI();
            }
            else
            {
                MessageBox.Show($"No customer found with ID: {id}");
            }
        }
        private void btnFilterAdd_Click(object sender, EventArgs e)
        {
            if (sbFilter.SelectedItem != null && !string.IsNullOrEmpty(txtFilter.Text))
            {
                string filterColumn = sbFilter.SelectedItem.ToString();
                string filterValue = txtFilter.Text;
                filterExpression = control.AddCustomerFilter_view(filterColumn, filterValue, filterExpression);
                dtRequirement.DataSource = control.GetFilteredOrderData_view(filterExpression);
                UpdateFilterUI();
            }
            else
            {
                MessageBox.Show("Please select a column and enter a filter value.");
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
                    filterExpression = control.RemoveOrderFilter_view(parts[0].Trim(), parts[1].Trim(), filterExpression);
                    dtRequirement.DataSource = control.GetFilteredOrderData_view(filterExpression);
                    UpdateFilterUI();
                }
            }
            else
            {
                MessageBox.Show("Please select a filter to remove.");
            }
        }


    }
}
