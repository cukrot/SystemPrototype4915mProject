using Microsoft.VisualBasic.ApplicationServices;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System_prototype_for_S_S_toy_Co__4915m_Project_.administration;

namespace System_prototype_for_S_S_toy_Co__4915m_Project_.MasterData
{
    public partial class AdminPage : Form
    {
        DataTable dtEmp;
        DataTable dtUser; // To store user account information
        private AdminController controller;
        public AdminPage()
        {
            InitializeComponent();
        }
        public AdminPage(AdminController controller)
        {
            InitializeComponent();
            this.controller = controller;
        }

        private async void UserAccountPage_Load(object sender, EventArgs e)
        {
            await reloadPage();
        }

        private async Task reloadPage()
        {
            // Clear previous data
            textBox1.Clear(); // Clear the employee ID input field
            txtEmpName.Clear(); // Clear the employee name field
            txtUserName.Clear(); // Clear the username field
            txtMessage.Text = string.Empty; // Clear the message text box
            dtEmp = null; // Reset employee DataTable
            dtUser = null; // Reset user DataTable
            // Clear combo boxes
            cbDept.Items.Clear(); // Clear department combo box
            cbRole.Items.Clear(); // Clear role combo box
            cbUserStatus.Items.Clear(); // Clear user status combo box
            cbEmpStatus.Items.Clear(); // Clear employee status combo box


            plModify.Visible = false; // Hide the modify panel initially
            // Initialize the combo boxes with predefined values
            cbUserStatus.Items.AddRange(new string[] { "Active", "Inactive", "Locked" });
            cbEmpStatus.Items.AddRange(new string[] { "Active", "Inactive", "Left" });

            // set the combo boxes blank and cannot be selected
            cbDept.SelectedIndex = -1; // No selection
            cbRole.SelectedIndex = -1; // No selection
            cbDept.Enabled = false; // Disable selection
            cbRole.Enabled = false;
            cbEmpStatus.SelectedIndex = -1; // No selection
            cbEmpStatus.Enabled = false; // Disable selection
            // set the textbox of username readonly
            txtUserName.ReadOnly = true; // Make username read-only
            //set panel plModify to be invisible
            plModify.Visible = false; // Hide the modify panel initially
            try
            {
                // get the list of departments and roles from the controller
                string[] departments = await controller.getDepartments();
                string[] roles = await controller.getRoles();
                if (departments != null && departments.Length > 0)
                {
                    cbDept.Items.AddRange(departments);
                }
                else
                {
                    MessageBox.Show("No departments found.");
                }
                if (roles != null && roles.Length > 0)
                {
                    cbRole.Items.AddRange(roles);
                }
                else
                {
                    MessageBox.Show("No roles found.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred while loading departments or roles: {ex.Message}");
            }
        }

        private async void btnFindByID_Click(object sender, EventArgs e)
        {
            DataTable[] dts = await controller.findEmployeeByID(textBox1.Text.Trim());
            if (dts == null || dts.Length < 2)
            {
                MessageBox.Show("No employee found with the given ID.");
                return;
            }
            dtEmp = dts[0]; // First DataTable contains employee information
            dtUser = dts[1]; // Second DataTable contains user account information

            if (dtEmp == null || dtEmp.Rows.Count == 0)
            {
                MessageBox.Show("No employee found with the given ID.");
                return;
            }
            else
            {
                plModify.Visible = true;
                txtMessage.Text = "Employee found. You can modify the employee and user information.";
                if (dtUser == null || dtUser.Rows.Count == 0)
                {
                    txtMessage.Text += "\nNo user account found for this employee. You can create a new user account.";
                    btnUser.Text = "Create User Account"; // Change button text to indicate creation action
                }
                else
                {
                    txtMessage.Text += "\nUser account found. You can modify the employee and user information.";
                    btnUser.Text = "Reset User Name and Password"; // Change button text to indicate reset action
                }
                populateEmployeeInfoBoxes();
            }

        }
        public void populateEmployeeInfoBoxes()
        {
            txtEmpName.Text = dtEmp.Rows[0]["Name"].ToString();
            txtEmpName.ReadOnly = false; // Allow modification of employee name
            cbDept.SelectedItem = dtEmp.Rows[0]["Department"].ToString();
            cbDept.Enabled = true;
            cbRole.SelectedItem = dtEmp.Rows[0]["Role"].ToString();
            cbRole.Enabled = true;
            cbEmpStatus.SelectedItem = dtEmp.Rows[0]["Status"].ToString();
            cbEmpStatus.Enabled = true; // Enable the status combo box for modification

            if (dtUser == null || dtUser.Rows.Count == 0)
            {
                txtUserName.Text = string.Empty; // Clear the username field
                txtUserName.ReadOnly = true; // Keep the username field read-only
                cbUserStatus.SelectedIndex = -1; // Clear the user status selection
                cbUserStatus.Enabled = false; // Disable the status combo box
                return;
            }
            else
            {
                txtUserName.Text = dtUser.Rows[0]["UserName"].ToString();
                txtUserName.ReadOnly = true; // Keep the username field read-only
                cbUserStatus.SelectedItem = dtUser.Rows[0]["Status"].ToString();
                cbUserStatus.Enabled = true; // Enable the status combo box for modification
            }
        }

        private void btnUser_Click(object sender, EventArgs e)   //open a new form to setup a new user or reset Password
        {
            controller.openUserSettingPage();
        }

        private async void btnUpdate_Click(object sender, EventArgs e)
        {
            // Validate the input fields before updating
            if (string.IsNullOrWhiteSpace(txtEmpName.Text) || cbDept.SelectedIndex < 0 || cbRole.SelectedIndex < 0 || cbEmpStatus.SelectedIndex < 0)
            {
                MessageBox.Show("Please fill in all required fields.");
                return;
            }
            if (dtEmp == null || dtEmp.Rows.Count == 0)
            {
                MessageBox.Show("No employee data to update.");
                return;
            }
            // get employee information as Dictionary<string, string>, key is column name, value is the value of the column
            Dictionary<string, string> empInfo = new Dictionary<string, string>
                {
                    { "EmployeeID", dtEmp.Rows[0]["EmployeeID"].ToString() }, // EmployeeID
                    { "Name", txtEmpName.Text.Trim() }, // EmployeeName
                    { "Department", cbDept.SelectedItem.ToString() }, // Department
                    { "Role", cbRole.SelectedItem.ToString() }, // Role
                    { "Status", cbEmpStatus.SelectedItem.ToString() } // Status
                };
            if (!(dtUser == null || dtUser.Rows.Count == 0))
            {
                if (cbUserStatus.SelectedIndex < 0 || string.IsNullOrWhiteSpace(txtUserName.Text))
                {
                    MessageBox.Show("Please fill in all required fields for user account.");
                    return;
                }
                // dtEmp and dtUser are not null, proceed to update both employee and user information
                // get user information as Dictionary<string, string>, key is column name, value is the value of the column
                Dictionary<string, string> userInfo = new Dictionary<string, string>
                {
                    { "UserID", dtUser.Rows[0]["UserID"].ToString() }, // UserID
                    { "UserName", txtUserName.Text.Trim() }, // UserName
                    { "Status", cbUserStatus.SelectedItem.ToString() } // Status
                };
                // Call the controller method to update both employee and user information
                try
                {
                    // update with two string[] parameters and two DataRows parameters
                    bool isUpdated = await controller.UpdateEmployeeAndUser(empInfo, userInfo, dtEmp.Rows[0], dtUser.Rows[0]);
                    if (isUpdated)
                    {
                        MessageBox.Show("Employee and user information updated successfully.");
                    }
                    else
                    {
                        MessageBox.Show("Failed to update employee and user information. Please try again.");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"An error occurred while updating: {ex.Message}");
                }
            }
            else
            {
                // dtUser is null or empty, proceed to update only employee information
                try
                {
                    DataRow dr = dtEmp.Rows[0]; // Get the first row of the employee DataTable
                    dr.AcceptChanges();
                    bool isUpdated = await controller.UpdateEmployee(empInfo, dr);
                    if (isUpdated)
                    {
                        MessageBox.Show("Employee information updated successfully.");
                    }
                    else
                    {
                        MessageBox.Show("Failed to update employee information. Please try again.");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"An error occurred while updating: {ex.Message}");
                }
            }
        }

        private void btnReloadData_Click(object sender, EventArgs e)     //reset the form values to original state by calling populateEmployeeInfoBoxes method
        {
            if (dtEmp == null || dtEmp.Rows.Count == 0)
            {
                MessageBox.Show("No employee data to reset.");
                return;
            }
            // Reset the form values to the original state
            populateEmployeeInfoBoxes();
            txtMessage.Text = "Form values have been reset to original state.";
        }

        private async void btnReloadPage_Click(object sender, EventArgs e)
        {
            await reloadPage();
            controller.reloadFromAdminPage(); // Notify the controller to reload the admin page
        }
    }
}
