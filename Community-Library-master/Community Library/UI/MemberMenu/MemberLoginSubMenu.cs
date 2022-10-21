using CAB301.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace CAB301.UI.MemberMenu
{
    public class MemberLoginSubMenu : BaseMenu
    {
        private Boolean home = false;

        public override void DoWork()
        {
            bool valid = false;
            while (!valid)
            {
                Console.Write("Member first name: ");
                string firstName = Console.ReadLine();
                Console.Write("Member last name: ");
                string lastName = Console.ReadLine();
                Console.Write("Member Password: ");
                string password = Console.ReadLine();
                MemberCollection members = (MemberCollection)MemberService.GetMemberCollection();
                IMember member = members.Find(new Member(firstName, lastName));

                if (member != null && password.Equals(member.Pin))
                {
                    valid = true;
                    MemberService.SetCurrentMember(member);
                }
                else
                {
                    Console.WriteLine("Wrong username/password!");
                    Console.WriteLine();
                    Console.WriteLine("1. Attempt member login again");
                    Console.WriteLine("0. Return to Main Menu");
                    Console.WriteLine("Enter your choice ==> (1/0)");
                    Boolean memberResponse = false;
                    while (!memberResponse)
                    {
                        string again = Console.ReadLine();
                        if (!int.TryParse(again, out int result))
                        {
                            Console.WriteLine("Invalid input, not a number");
                        }
                        else
                        {
                            if (again == "0" || again == "1")
                            {
                                if (again.Equals("0"))
                                {
                                    Console.WriteLine("Returning to Main Menu!");
                                    home = true;
                                    valid = true;
                                    memberResponse = true;
                                }
                                else
                                {
                                    Console.WriteLine("Attempting to login again!");
                                    memberResponse = true;
                                }
                            }
                            else
                            {
                                Console.WriteLine("Invalid input, number is out of range");
                            }
                        }
                    }
                }
            }
        }
        public override IMenu GetNextMenu()
        {
            if (home)
            {
                return new MainMenu("Main Menu", clearScreen: true);
            }
            else
            {
                return MenuHelper.GetNextMenu("Member Login", clearScreen: true);
            }
        }
    }
}
