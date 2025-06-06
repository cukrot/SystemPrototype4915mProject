using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System_prototype_for_S_S_toy_Co__4915m_Project_.Login;
using System_prototype_for_S_S_toy_Co__4915m_Project_.Menu;

namespace System_prototype_for_S_S_toy_Co__4915m_Project_
{
    internal class SystemController
    {
        private LoginController _loginController;
        public SystemController(LoginController login)
        {
            _loginController = login;
        }
        public void Start()
        {
            MenuTest menu = new MenuTest();
            MenuController menuController = new MenuController(_loginController, menu);
            menu.Show();
        }
    }
}
