using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace System_prototype_for_S_S_toy_Co__4915m_Project_.Inventory
{
    public class ShipInPageController : InvController
    {
        public ShipInPageController(bool isStaff) : base(isStaff)
        {
        }
        public void ShipInPage()
        {
        }
        internal void openThePage()
        {
            ShipIn form = new ShipIn(this); // Create an instance of the ShipIn form
            form.Show(); // Show the form to the user
        }
        internal async Task<DataTable> GetWarehouseData()
        {
            DataTable dt = null;
            try
            {
                dt = await GetTableData("warehouse"); // specify table name
            }
            catch (Exception ex)
            {
                throw ex;
            }
            //Set ReadOnly for all columns
            if (dt != null && dt.Columns.Count > 0)
            {
                foreach (DataColumn col in dt.Columns)
                {
                    col.ReadOnly = true; // Set all columns to ReadOnly
                }
            }
            return dt; // Return the DataTable with warehouse data
        }


    }
}
