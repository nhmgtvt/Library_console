using System;
using System.Collections.Generic;
using System.Text;

namespace CAB301.UI.MemberMenu
{
    public abstract class MemberSubMenuBase : BaseMenu
    {
        public override IMenu GetNextMenu()
        {
            return MenuHelper.GetNextMenu("Member Login", clearScreen: false);
        }
    }
}
