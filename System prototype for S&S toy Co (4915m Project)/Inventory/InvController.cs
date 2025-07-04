using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System_prototype_for_S_S_toy_Co__4915m_Project_.ProductRequirement;

namespace System_prototype_for_S_S_toy_Co__4915m_Project_.Inventory
{
    public class InvController : SubSystemController
    {
        public bool isStaff;
        public InvController(bool isStaff)
        {
            this.isStaff = isStaff;
        }
        public bool getIsStaff() { return isStaff; }
        public void openPage(int pageIndex)
        {
            switch (pageIndex)
            {
                default:
                    MessageBox.Show("Invalid page index for Inventory subsystem.");
                    break;
            }
        }

        internal void CloseInventoryPage()
        {
            //close all the open forems related to Inventory subsystem
            FormCollection openForms = Application.OpenForms; // Get all open forms in the application
        }

        private void openShippingPage()
        {
            ShipInPageController controller = new ShipInPageController(isStaff);
            controller.openThePage();
        }

    }
}
