using EntityModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System_prototype_for_S_S_toy_Co__4915m_Project_.ProductRequirement;

namespace System_prototype_for_S_S_toy_Co__4915m_Project_
{
    public class UserAccessController
    {
        private string[] departments;
        private string[] menuOfSubsystem;
        private Dictionary<string, string[]> accessControl; // Key: Department, Value: Dictionary of access control for each subsystem
        public UserAccessController()
        { //AccessPermission is a class that contains the access control information for each department and subsystem
            AccessPermission accessPermission = new AccessPermission();
            departments = accessPermission.Departments;
            menuOfSubsystem = accessPermission.MenuOfSubsystem;
            accessControl = accessPermission.AccessControl;
        }
        public string[] GetDepartments()
        {
            return departments;
        }
        public string[] GetMenuOfSubsystem()
        {
            return menuOfSubsystem;
        }
        public string[] GetAccessControl(string department, string role)
        {
            if (role == "root" || role == "Administrator") // Root or Admin has access to all subsystems
            {
                return accessControl[role];
            } else if (accessControl.ContainsKey(department))
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
