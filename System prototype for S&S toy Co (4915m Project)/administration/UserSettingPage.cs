using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace System_prototype_for_S_S_toy_Co__4915m_Project_.administration
{
    public partial class UserSettingPage : Form
    {
        AdminController controller;
        string employeeID;
        DataTable dtUser; // To store user data
        public UserSettingPage(AdminController adminController, string employeeID, DataTable dtUser)
        {
            InitializeComponent();
            this.controller = adminController;
            this.employeeID = employeeID;
            this.dtUser = dtUser;
        }


        private async void btnSumbit_Click(object sender, EventArgs e)
        {
            //vadidate the input
            if (string.IsNullOrWhiteSpace(txtUserName.Text) || string.IsNullOrWhiteSpace(txtUserPW.Text))
            {
                MessageBox.Show("Please enter both user name and password.");
                return;
            }
            // Show confirmation dialog
            DialogResult result = MessageBox.Show("Are you sure you want to submit the changes?", "Confirm Submission", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                // Proceed with the submission logic
                // Assuming you have a method in AdminController to handle user settings submission
                try {
                    bool success = await controller.SubmitUserSettings(dtUser, txtUserName.Text, txtUserPW.Text);
                    if (success) {
                        MessageBox.Show("User settings submitted successfully.");
                        this.Close(); // Close the form after successful submission
                    }
                    else
                    {
                        MessageBox.Show("Failed to submit user settings. Please try again.");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"An error occurred while submitting user settings: {ex.Message}");
                }
            }
            else
            {
                // User chose not to submit, do nothing or handle accordingly
            }
        }

        private void UserSettingPage_Load(object sender, EventArgs e)
        {
            // As this page is for user registratio or resetting, we will not allow the user to change the employee ID
            // if dtUser exists, only put the accuont name in the text box
            if (dtUser != null && dtUser.Rows.Count > 0)
            {
                // Assuming the first row contains the user data
                DataRow userRow = dtUser.Rows[0];
                txtUserName.Text = userRow["UserName"].ToString(); // Adjust column name as needed
            }
            else
            {
                // If dtUser is null or empty, we can set a default value or leave it blank
                txtUserName.Text = string.Empty;
            }
        }
    }
}
