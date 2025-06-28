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
    public partial class JustingTestingTwo_menu : Form
    {
        String[] forms;
        TestControll2 controll;
        public JustingTestingTwo_menu()
        {
            InitializeComponent();
        }

        private void JustingTestingTwo_menu_Load(object sender, EventArgs e)
        {
            controll = new TestControll2();
            forms = new String[]
            {
                "Test_Insert",
                "Form2"
            }; // Add more forms as needed
            sbForm.Items.AddRange(forms);
        }

        private void btnOpenForm_Click(object sender, EventArgs e)
        {
            if (sbForm.SelectedItem != null)
            {
                String selectedForm = sbForm.SelectedItem.ToString();
                switch (selectedForm)
                {
                    case "Test_Insert":
                        Test_Insert testInsertForm = new Test_Insert(controll);
                        testInsertForm.Show();
                        break;
                    case "Form2":
                        Form2 form2 = new Form2(controll);
                        form2.Show();
                        break;
                    default:
                        MessageBox.Show("Selected form is not recognized.");
                        break;
                }
            }
        }
    }
}
