using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Security.Cryptography;


namespace System_prototype_for_S_S_toy_Co__4915m_Project_.JustTesting
{
    public partial class TestAnything : Form
    {
        TestControll controll;
        public TestAnything()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string pw = textBox1.Text;
            string hasdhedPw = HashPassword(pw);
            string username = textBox2.Text;
            DataTable dt = (DataTable)dataGridView1.DataSource;
            // Get the first row of the DataTable to modify
            DataRow row = dt.Rows[0];
            row.BeginEdit();
            row[row.Table.Columns[1]] = username;
            row[row.Table.Columns[2]] = hasdhedPw;
            row.EndEdit();
            row.AcceptChanges(); // Accept changes to the row
            dataGridView1.DataSource = dt; // Refresh the DataGridView to show the new row
            dataGridView1.Refresh(); // Ensure the DataGridView is updated
            // Accept changes to the DataTable
            dt.AcceptChanges();
        }
        public static string HashPassword(string password)
        {
            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] bytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(password));
                StringBuilder builder = new StringBuilder();
                for (int i = 0; i < bytes.Length; i++)
                {
                    builder.Append(bytes[i].ToString("x2"));
                }
                return builder.ToString();
            }
        }

        private void btnReload_Click(object sender, EventArgs e)
        {

        }

        private async void button2_Click(object sender, EventArgs e)
        {
            DataTable dt = (DataTable)dataGridView1.DataSource;
            int affectedRows = await controll.UpdateUserData(dt);
            if (affectedRows > 0)
            {
                MessageBox.Show($"{affectedRows} rows updated successfully.");
            }
            else
            {
                MessageBox.Show("No rows were updated.");
            }
        }

        private async void TestAnything_Load(object sender, EventArgs e)
        {
            controll = new TestControll();
            dataGridView1.DataSource = await controll.GetUserData();
        }
    }
}
