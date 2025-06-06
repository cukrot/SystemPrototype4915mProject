using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace System_prototype_for_S_S_toy_Co__4915m_Project_.MasterData
{
    internal class MasterDataController : SubSystemController
    {
        public async Task<DataTable> GetCustomerData()
        {
            DataTable dt = null;
            try
            {
                dt = await GetTableData("customer");
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return dt;
        }

        public async Task<DataTable> GetEmployeeData()
        {
            DataTable dt = null;
            try
            {
                dt = await GetTableData("employee");
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return dt;
        }
    }
}
