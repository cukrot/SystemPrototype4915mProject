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
    public partial class EditRequirement : Form
    {
        SaleController control;
        public EditRequirement()
        {
            InitializeComponent();
        }
        public EditRequirement(SaleController control)
        {
            InitializeComponent();
            this.control = control;
        }

        private void EditRequirement_Load(object sender, EventArgs e)
        {
            sbIDType.Items.Add("Order ID");
            sbIDType.Items.Add("Customer ID");
            string[] statusOptions = { "Pending", "In Progress", "Completed", "In Delivery", "Cancelled" };
            cbStatus.Items.AddRange(statusOptions);
        }

        private async void btnFindByID_Click(object sender, EventArgs e)
        {
            if (sbIDType.SelectedItem != null && !string.IsNullOrEmpty(txtFindByID.Text.Trim()))
            {
                string id = txtFindByID.Text.Trim();
                string idType = sbIDType.SelectedItem.ToString();
                DataRow orderRecord = null;
                try
                {
                    orderRecord = await control.GetRequirementById(id, idType);
                    if (orderRecord != null)
                    {
                        txtOrderID.Text = orderRecord["OrderID"].ToString();
                        txtCustID.Text = orderRecord["CustomerID"].ToString();
                        txtDate.Text = orderRecord["OrderDate"].ToString();
                        txtSaleID.Text = orderRecord["SaleID"].ToString();
                        cbStatus.SelectedIndex = cbStatus.Items.IndexOf(orderRecord["Status"].ToString());
                        // Populate other fields as necessary
                    }
                    else
                    {
                        MessageBox.Show("No requirement found for the given ID.");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error retrieving requirement: {ex.Message}");
                }
            }
            else
            {
                MessageBox.Show("Please select an ID type and enter an ID value.");
            }
        }

        private void EditRequirement_FormClosing(object sender, FormClosingEventArgs e)
        {
            control.endEditRequirement();
        }

        private void dateTimePicker_ValueChanged(object sender, EventArgs e)
        {
            dateTimePicker.CustomFormat = "yyyy-MM-dd"; // Set the format to 'yyyy-MM-dd'
            dateTimePicker.Format = DateTimePickerFormat.Custom; // Ensure the format is set to custom

            txtDate.Text = dateTimePicker.Value.ToString("yyyy-MM-dd"); // Update the text box with the selected date in 'yyyy-MM-dd' format
        }

        private async void btnEdit_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtSaleID.Text.Trim()) ||
                string.IsNullOrEmpty(txtOrderID.Text.Trim()) ||
                string.IsNullOrEmpty(txtCustID.Text.Trim()) ||
                string.IsNullOrEmpty(txtDate.Text.Trim()) ||
                cbStatus.SelectedItem == null)
            {
                MessageBox.Show("Please fill in all fields before editing.");
                return;
            }
            Dictionary<string, string> updatedFields = new Dictionary<string, string>
            {
                { "SaleID", txtSaleID.Text.Trim() },
                { "OrderDate", txtDate.Text.Trim() },
                { "Status", cbStatus.SelectedItem.ToString() }
            };
            bool isUpdated = false;
            try
            {
                isUpdated = await control.UpdateRequirement(updatedFields);
                MessageBox.Show("Requirement updated successfully.");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error updating requirement: {ex.Message}");
            }
        }
    }
}
