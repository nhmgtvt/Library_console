using System;
using System.Collections.Generic;
using System.Text;

namespace CAB301.UI.StaffMenu
{
    public abstract class StaffSubMenuBase : BaseMenu
    {
        public override IMenu GetNextMenu()
        {
            return MenuHelper.GetNextMenu("Staff Login", clearScreen: false);
        }
    }
}
