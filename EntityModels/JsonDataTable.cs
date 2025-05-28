using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityModels
{
    public class JsonDataTable
    {   
        public string tableName {  get; set; }
        public string keysName { get; set; }
        public string dtAdded { get; set; }
        public string dtModified { get; set; }
        public string dtDeleted { get; set; }
    }

}
