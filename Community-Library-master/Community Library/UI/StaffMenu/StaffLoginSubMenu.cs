using System;
using System.Collections.Generic;
using System.Text;

namespace CAB301.UI.StaffMenu
{
    public class StaffLoginSubMenu : BaseMenu
    {
        private readonly string _staffUserName = "staff";
        private readonly string _password = "today123";
        private Boolean home = false;

        public override void DoWork()
        {
            bool valid = false;
            while (!valid)
            {
                Console.Write("Staff Username: ");
                string user = Console.ReadLine();
                Console.Write("Staff Password: ");
                string password = Console.ReadLine();
                if (user.Equals(_staffUserName) && password.Equals(_password))
                    valid = true;
                else
                {
                    Console.WriteLine("Wrong username/password!");
                    Console.WriteLine();
                    Console.WriteLine("1. Attempt staff login again");
                    Console.WriteLine("0. Return to Main Menu");
                    Console.WriteLine("Enter your choice ==> (1/0)");
                    Boolean staffResponse = false;
                    while (!staffResponse)
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
                                    staffResponse = true;
                                }
                                else
                                {
                                    Console.WriteLine("Attempting to login again!");
                                    staffResponse = true;
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
                return new MainMenu("Main Menu", clearScreen:true);
            }
            return MenuHelper.GetNextMenu("Staff Login", clearScreen : true);
        }
    }
}
