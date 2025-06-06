using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace System_prototype_for_S_S_toy_Co__4915m_Project_.Delivery
{
    public class DeliveryController : SubSystemController
    {
        public async Task<DataTable> GetDeliveryData()
        {
            DataTable dt = null;
            try
            {
                dt = await GetTableData("delivery"); // Specify the table name for delivery orders
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return dt;
        }
    }
}
