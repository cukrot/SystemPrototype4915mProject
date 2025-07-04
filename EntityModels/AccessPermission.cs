using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityModels
{
    public class AccessPermission
    {
        private string[] departments = new string[]
{
            "R & D Department", // Not used in this prototype
            "Sale Department",
            "Marketing Department",
            "Sale & Marketing Department",
            "Production Department",
            "Supply Chain Department",
            "Inventory Department",
            "Customer Service Department",
            "Finance Department", //Not used in this prototype
            "IT Department",
            "root"
};
        public string[] Departments
        {
            get { return departments; }
        }
        private string[] menuOfSubsystem =
        {
            "MasterData Management", //IT
            "Product Requirements", //sale, marketing, sale & marketing
            "Supply Chain Management", //Supply Chain Management
            "Inventory Management", //Inventory Management, Supply Chain Management
            "Administraction Management", //Supply Chain Management
            "Customer", //sale
        };
        public string[] MenuOfSubsystem
        {
            get { return menuOfSubsystem; }
        }
        private Dictionary<string, string[]> subSystemPages = new Dictionary<string, string[]>
        {   
            { "Product Requirements", new string[] { "View Product Requirements", "Edit Product Requirements", "Create Product Requirements" } },
            { "Customer" , new string[] { "View Customer Data", "Insert Customer Data"} },
            { "Inventory Management", new string[] { 
                "View Product Inventory", "View Material Inventory"
            } },
            { "Supply Chain Management", new string[] { "View Purchase Order", "View Masterial Suppliers", "Add Purchase Order" ,"Confirm Inward", "View Inward Record" } },
            { "Administraction Management", new string[] { "Admin Page"} },
            { "MasterData Management", new string[] { "MasterData"} }

        };
        public Dictionary<string, string[]> SubSystemPages
        {
            get { return subSystemPages; }
        }
        private Dictionary<string, string[]> accessControl = new Dictionary<string, string[]>
        {
            { "R & D Department", new string[] {} }, // No access to any subsystem in this prototype
            { "Sale Department", new string[] { "Product Requirements", "Customer" } },
            { "Marketing Department", new string[] { "Product Requirements", "Customer" }  },
            { "Sale & Marketing Department", new string[] { "Product Requirements", "Customer" } },
            //{ "Production Department", new string[] { "Production Processing Management"} },
            { "Supply Chain Department", new string[] { "Inventory Management", "Supply Chain Management" } },
            { "Inventory Department", new string[] { "Inventory Management", "Supply Chain Management" }  },
            //{ "Customer Service Department", new string[] { "After Service Management"} },
            { "Finance Department", new string[] { } }, // No access to any subsystem in this prototype
            { "IT Department", new string[] { "Administraction Management", "MasterData Management"} },
        };
        public Dictionary<string, string[]> AccessControl
        {
            get
            { // add access control for root user and Administrator
                Dictionary<string, string[]> rootAccessControl = new Dictionary<string, string[]>(accessControl);
                rootAccessControl.Add("root", menuOfSubsystem);
                rootAccessControl.Add("Administrator", menuOfSubsystem);
                return rootAccessControl;
            }
        }
        private string[] roles = new string[]
        {
            "Administrator",
            "Manager",
            "Staff"
        };
        public string[] Roles 
        {
            get { return roles; }
        }
    }
}
