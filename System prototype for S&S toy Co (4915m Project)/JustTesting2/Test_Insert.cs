using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System_prototype_for_S_S_toy_Co__4915m_Project_.JustTesting;

namespace System_prototype_for_S_S_toy_Co__4915m_Project_.JustTesting2
{
    public partial class Test_Insert : Form
    {
        TestControll2 controll;

        public Test_Insert()
        {
            InitializeComponent();
        }

        public Test_Insert(TestControll2 controll)
        {
            InitializeComponent();
            this.controll = controll;
        }

        private void Test_Insert_Load(object sender, EventArgs e)
        {
        }

        private async void btnSubmit_Click(object sender, EventArgs e)
        {
            string name = txtName.Text.Trim();
            string phoneNum = txtPhoneNum.Text.Trim();
            string address = txtAddress.Text.Trim();
            string email = txtEmail.Text.Trim();
            string[] values = new string[] { name, phoneNum, address, email };

            //pass values to controll.InsertData() method
            try
            {
                await controll.InsertCustomerData("customer", values);
                MessageBox.Show("Data inserted successfully.");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred while inserting data: {ex.Message}");
            }
        }
    }
}
