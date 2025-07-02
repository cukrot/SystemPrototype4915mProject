using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace System_prototype_for_S_S_toy_Co__4915m_Project_
{
    public class UserAccessController
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
        private string[] menuOfSubsystem =
        {
            "MasterData Management", //IT
            "Product Requirements", //sale, marketing, sale & marketing
            "Production Processing Management", //Production
            "Material Procurement", //Supply Chain Management
            "Inventory Management", //Inventory Management, Supply Chain Management
            "Dispatch Processing", //Supply Chain Management
            "After Service Management", //Customer Service Department
            "Administration Management", //IT
            "Test Menu" //Just for testing purposes
        };
        private Dictionary<string, string[]> accessControl; // Key: Department, Value: Dictionary of access control for each subsystem
        public UserAccessController()
        {
            //Note : NOt all departments have access to any menu items, so some entries may be empty
            accessControl = new Dictionary<string, string[]>
            {
                { "R & D Department", new string[] {} }, // No access to any subsystem in this prototype
                { "Sale Management", new string[] { "Product Requirements"} },
                { "Marketing Department", new string[] { "Product Requirements" }  },
                { "Sale & Marketing Department", new string[] { "Product Requirements"} },
                { "Production Department", new string[] { "Production Processing Management"} },
                { "Supply Chain Management", new string[] { "Material Procurement", "Inventory Management", "Dispatch Processing"} },
                { "Inventory Management", new string[] { "Inventory Management" }  },
                { "Customer Service Department", new string[] { "After Service Management"} },
                { "Finance Department", new string[] { } }, // No access to any subsystem in this prototype
                { "IT Department", new string[] { "Administration Management", "MasterData Management"} },
                { "root", menuOfSubsystem } // Root user has access to all subsystems
            };
        }
        public string[] GetDepartments()
        {
            return departments;
        }
        public string[] GetMenuOfSubsystem()
        {
            return menuOfSubsystem;
        }
        public string[] GetAccessControl(string department)
        {
            if (accessControl.ContainsKey(department))
            {
                return accessControl[department];
            }
            else
            {
                throw new ArgumentException($"Department '{department}' does not exist in access control.");
            }
        }
    }
}
