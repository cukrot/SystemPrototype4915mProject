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
        DataColumn[] columns;

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
            try
            {
                //load columns into the listbox
                // Assuming controll.GetColumns() returns a list of column names
                columns = controll.GetColumns();
                if (columns != null && columns.Length > 0)
                {
                    lbColumns.Items.Clear();
                    foreach (var column in columns)
                    {
                        lbColumns.Items.Add(column.ColumnName);
                    }
                }
                else
                {
                    MessageBox.Show("No columns found.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred while loading columns: {ex.Message}");
                return;
            }
        }
    }
}
