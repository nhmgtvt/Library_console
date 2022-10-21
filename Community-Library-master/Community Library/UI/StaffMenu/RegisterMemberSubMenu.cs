using CAB301.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace CAB301.UI.StaffMenu
{
    public class RegisterMemberSubMenu : StaffSubMenuBase
    {
        public override void DoWork()
        {
            Console.Write("Enter member's first name: ");
            string firstName = Console.ReadLine();
            Console.Write("Enter member's last name: ");
            string lastName = Console.ReadLine();
            string phoneNumber = "", pin="";

            bool valid = false;
            while (!valid)
            {
                Console.WriteLine("A contact phone number is valid if it has 10 digits and the first digit is 0!");
                Console.Write("Enter member contact number: ");
                phoneNumber = Console.ReadLine();
                valid = IMember.IsValidContactNumber(phoneNumber);
            }

            valid = false;
            while (!valid)
            {
                Console.WriteLine("A pin is valid if it is a number which has a minimal of 4 and a maximal of 6 digits!");
                Console.Write("Enter member password: ");
                pin = Console.ReadLine();
                valid = IMember.IsValidPin(pin);
            }
            var member = new Member(firstName, lastName, phoneNumber, pin);
            IMemberCollection members = MemberService.GetMemberCollection();
            if (members.Search(member))
            {
                Console.WriteLine("Member already exists with the same first and last name, member not added to system!");
            }
            else
            {
                members.Add(member);
                Console.WriteLine("Member {0} {1} added to the system successfully!", member.FirstName, member.LastName);
            }
            Console.WriteLine();
            Console.WriteLine("Back to the staff menu!");
            Console.WriteLine();
        }
    }
}
