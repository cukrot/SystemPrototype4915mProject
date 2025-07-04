using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace System_prototype_for_S_S_toy_Co__4915m_Project_.Inventory
{
    public partial class menuInv : Form
    {
        public menuInv()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string item = comboBox1.SelectedItem?.ToString();
            switch (item)
            {
                case "EditProductForm":
                    new EditProductForm().ShowDialog();
                    break;
                case "MaterialEditForm":
                    new MaterialEditForm().ShowDialog();
                    break;
                case "MaterialLogForm":
                    new MaterialLogForm().ShowDialog();
                    break;
                case "MaterialProcurementListForm":
                    new MaterialProcurementListForm().ShowDialog();
                    break;
                case "ProductLogForm":
                    new ProductLogForm().ShowDialog();
                    break;
                case "ViewMaterial":
                    new ViewMaterial().ShowDialog();
                    break;
                case "ViewProducts":
                    new ViewProducts().ShowDialog();
                    break;
                default:
                    MessageBox.Show("Please select a valid form from the dropdown.");
                    break;
            }
        }

        private void menuInv_Load(object sender, EventArgs e)
        {
            string[] forms = new string[] { "EditProductForm", "MaterialEditForm", "MaterialLogForm", "MaterialProcurementListForm",
                "ProductLogForm", "ViewMaterial", "ViewProducts" };
            comboBox1.Items.AddRange(forms);
        }
    }
}
