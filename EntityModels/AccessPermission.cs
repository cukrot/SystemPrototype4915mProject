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
            "Sale Management",
            "Marketing Department",
            "Sale & Marketing Department",
            "Production Department",
            "Supply Chain Management",
            "Inventory Management",
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
            //"Production Processing Management", //Production
            "Supply Chain Management", //Supply Chain Management
            "Inventory Management", //Inventory Management, Supply Chain Management
            "Administraction Management", //Supply Chain Management
            "Inventory Management", //Customer Service Department
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
                "Product Log Form", "MaterialLogForm" ,
                "View Product", "Edit Material", 
                "View Product Inventory", "View Material Inventory"
            } },
            { "Supply Chain Management", new string[] { "View Purchase Order", "View Masterial Suppliers", "Add Purchase Order" ,"Confirm Inward", "View Inward Record" } },
            { "Administraction Management", new string[] { "MasterData", "Admin Page", "MAterial Procurement"} },
            { "MasterData Management", new string[] { "View Products", "View Material" } }

        };
        public Dictionary<string, string[]> SubSystemPages
        {
            get { return subSystemPages; }
        }
        private Dictionary<string, string[]> accessControl = new Dictionary<string, string[]>
        {
            { "R & D Department", new string[] {} }, // No access to any subsystem in this prototype
            { "Sale Management", new string[] { "Product Requirements"} },
            { "Marketing Department", new string[] { "Product Requirements" }  },
            { "Sale & Marketing Department", new string[] { "Product Requirements"} },
            { "Production Department", new string[] { "Production Processing Management"} },
            { "Supply Chain Management", new string[] { "Material Procurement", "Inventory Management", "Supply Chain Management" } },
            { "Inventory Management", new string[] { "Inventory Management" }  },
            { "Customer Service Department", new string[] { "After Service Management"} },
            { "Finance Department", new string[] { } }, // No access to any subsystem in this prototype
            { "IT Department", new string[] { "Administraction Management", "MasterData Management"} },
        };
        public Dictionary<string, string[]> AccessControl
        {
            get
            { // add access control for root user and Administrator
                var rootAccessControl = new Dictionary<string, string[]>(accessControl);
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
