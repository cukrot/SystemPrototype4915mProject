using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace System_prototype_for_S_S_toy_Co__4915m_Project_.ProductRequirement
{
    internal class RequirementController : SubSystemController
    {
        public async Task<DataTable> GetProductRequirements()
        {
            DataTable dt = null;
            try
            {
                dt = await GetTableData("order"); // specify table name
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return dt;
        }
    }
}
