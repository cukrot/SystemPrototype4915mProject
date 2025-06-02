using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace System_prototype_for_S_S_toy_Co__4915m_Project_.Data
{
    internal class DataController : SubSystemController
    {
        public async Task<DataTable> GetData()
        {
            DataTable dt = null;
            try
            {
                dt = await GetTableData("customers"); //specify table name
                //Or you can use GetData()
                //dt = await GetData("GetTableData", "customers"); //specify endpoint & table name
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return dt;
        }
    }
}
