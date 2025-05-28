using Newtonsoft.Json;
using System.Data;
using System_prototype_for_S_S_toy_Co__4915m_Project_.JustTesting;

namespace System_prototype_for_S_S_toy_Co__4915m_Project_
{
    public partial class Form1 : Form
    {
        TestControll controll;
        public Form1()
        {
            InitializeComponent();
        }

        private async void Form1_Load(object sender, EventArgs e)
        {
            controll = new TestControll();

            try
            {
                DataTable dt = await controll.GetCustomerData();
                dataGridView1.DataSource = dt;
                dt.AcceptChanges();
            }
            catch (Exception ex)
            {
                // Log any other exceptions
                MessageBox.Show($"An error occurred: {ex.Message}");
            }
        }
        private async void button1_Click(object sender, EventArgs e)
        {
            try
            {
                DataTable dt = await controll.GetCustomerData();
                dataGridView1.DataSource = dt;
                dt.AcceptChanges();
                if (dt.Rows.Count > 0)
                {
                    DataRow row = dt.Rows[0];
                    DataColumn col = dt.Columns[0];
                    label1.Text = col.ToString() + row[col].ToString();
                }
            }
            catch (Exception ex)
            {
                // Log any other exceptions
                MessageBox.Show($"An error occurred: {ex.Message}");
            }
        }

        private async void button2_Click(object sender, EventArgs e)
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
    }
}
