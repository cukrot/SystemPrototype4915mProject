using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntityModels;

namespace EntityModels
{
    public class ManyJasonTable
    {
        public JsonDataTable singleKeyTable { get; set; } // Single key table
        public JsonDataTable manyKeyTable { get; set; } // Many key table
    }
}
