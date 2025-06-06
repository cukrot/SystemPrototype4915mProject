using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace System_prototype_for_S_S_toy_Co__4915m_Project_.Login
{
    public partial class Login : Form
    {
        LoginController loginController;
        public Login()
        {
            InitializeComponent();
            loginController = new LoginController();
        }

        private async void btnLogin_Click(object sender, EventArgs e)
        {
            String username = txtUserName.Text;
            String password = txtPassword.Text;
            if (await loginController.Login(username, password))
            {
                Close();
            }
            else
            {
                MessageBox.Show("Incorrect user name or password. "
                            + "Please try again.");
                txtUserName.Text = "";
                txtPassword.Text = "";
            }
        }

        private void Login_Load(object sender, EventArgs e)
        {

        }

        private void btnForTesting_Click(object sender, EventArgs e)
        {
            loginController.logonInTest();
            Hide();
        }
    }
}
