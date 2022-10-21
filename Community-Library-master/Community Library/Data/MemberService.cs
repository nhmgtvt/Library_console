using System;
using System.Collections.Generic;
using System.Text;

namespace CAB301.Data
{
    public class MemberService
    {
        private static MemberCollection _memberCollection = new MemberCollection(1000);
        private static IMember _currentMember = null;
        public static IMemberCollection GetMemberCollection()
        {
            return _memberCollection;
        }
        public static void SetCurrentMember(IMember member)
        {
            _currentMember = member; 
        }
        public static IMember GetCurrentMember()
        {
            return _currentMember;
        }
    }
    
}
