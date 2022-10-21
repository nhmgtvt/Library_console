using System;
using System.Collections.Generic;
using System.Text;

namespace CAB301.UI
{
    public abstract class BaseMenu : IMenu
    {
        public void Process()
        {
            DoWork();
            ProcessNextMenu();
        }

        private void ProcessNextMenu()
        {
            IMenu nextMenu = GetNextMenu();
            if (nextMenu != null)
                nextMenu.Process();
        }

        public abstract void DoWork();

        public abstract IMenu GetNextMenu();


    }
}
