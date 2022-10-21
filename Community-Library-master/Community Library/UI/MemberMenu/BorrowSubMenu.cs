using CAB301.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace CAB301.UI.MemberMenu
{
    public class BorrowSubMenu : MemberSubMenuBase
    {
        public override void DoWork()
        {
            Console.Write("Enter DVD's movie name that you want to borrow: ");
            string title = Console.ReadLine();

            IMovieCollection movies = MovieService.GetMovieCollection();
            IMovie existedMovie = movies.Search(title);
            Console.WriteLine();
            if (existedMovie != null)
            {
                var currentMember = MemberService.GetCurrentMember();
                if (existedMovie.AvailableCopies > 0)
                {
                    if (existedMovie.AddBorrower(currentMember))
                        Console.WriteLine("DVD movie borrowed successful!");
                    else
                        Console.WriteLine("Member is already borrowing this movie, Borrow failed!");
                }
                else
                {
                    Console.WriteLine("Movie does not have any availble copies, Borrow failed!");
                }
            }
            else
            {
                Console.WriteLine("Movie is not in the system, Borrow failed!");
            }
            Console.WriteLine();
            Console.WriteLine("Back to the member menu!");
            Console.WriteLine();
        }
    }
}
