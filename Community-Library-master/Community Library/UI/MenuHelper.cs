using CAB301.UI.MemberMenu;
using CAB301.UI.StaffMenu;
using System;
using System.Collections.Generic;
using System.Text;

namespace CAB301.UI
{
    public class MenuHelper
    {
        private static Dictionary<string, Dictionary<int, string>> _menuOptions = new Dictionary<string, Dictionary<int, string>>()
        {
            {"Main Menu", new Dictionary<int, string>()
                {   {1, "Staff Login" }, {2, "Member Login" },
                    {0, "Exit" }
                }
            },
            {"Staff Login", new Dictionary<int, string>()
                {   {0, "Staff Menu" }
                }
            },
            {"Staff Menu", new Dictionary<int, string>()
                {   {1, "Add new DVDs of a new movie to the system" }, {2, "Remove DVDs of a movie from the system" },
                    {3, "Register a new member with the system" }, {4,"Remove a registered member from the system" },
                    {5, "Display a member's contact phone number, given the member's name" },
                    {6, "Display all members who are currently renting a particular movie" },
                    {0, "Return to the main menu" }
                }
            },
            {"Member Login", new Dictionary<int, string>()
                {   {0, "Member Menu" }
                }
            },
            {"Member Menu", new Dictionary<int, string>()
                {   {1, "Browse all the movies" },
                    {2, "Display all the information about a movie, given the title of the movie" },
                    {3, "Borrow a movie DVD" }, {4,"Return a movie DVD" },
                    {5, "List current borrowing movies" },
                    {6, "Display the top 3 movies rented by the members" },
                    {0, "Return to the main menu"}
                }
            }
        };
        public static Dictionary<int, string> GetMenuOptions(string menu)
        {
            if (_menuOptions.TryGetValue(menu, out var result))
                return result;
            else
                return null;
        }
        public static IMenu GetNextMenu(string menu, int choice = 0, bool clearScreen = true)
        {
            switch (menu)
            {
                case "Main Menu":
                    switch (choice)
                    {
                        case 1:
                            return new StaffLoginSubMenu();
                        case 2:
                            return new MemberLoginSubMenu();
                        case 0:
                        default:
                            return null;
                    }
                case "Staff Login":
                    return new MainMenu("Staff Menu", clearScreen);
                case "Staff Menu":
                    switch (choice)
                    {
                        case 0:
                            return new MainMenu("Main Menu", clearScreen);
                        case 1:
                            return new AddDvdSubMenu();
                        case 2:
                            return new RemoveDvdSubMenu();
                        case 3:
                            return new RegisterMemberSubMenu();
                        case 4:
                            return new RemoveMemberSubMenu();
                        case 5:
                            return new PhoneNumberSubMenu();
                        case 6:
                            return new RentingMemberSubMenu();
                        default:
                            return null;
                    }
                case "Member Login":
                    return new MainMenu("Member Menu", clearScreen);
                case "Member Menu":
                    switch (choice)
                    {
                        case 0:
                            return new MainMenu("Main Menu", clearScreen);
                        case 1:
                            return new DisplayAllSubMenu();
                        case 2:
                            return new DisplayMovieDetailSubMenu();
                        case 3:
                            return new BorrowSubMenu();
                        case 4:
                            return new ReturnSubMenu();
                        case 5:
                            return new ListBorrowSubMenu();
                        case 6:
                            return new MostBorrowSubMenu();
                        default:
                            return null;
                    }
                default:
                    return null;
            }
        }
    }
}
