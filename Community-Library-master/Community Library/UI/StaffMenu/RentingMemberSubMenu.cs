using CAB301.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace CAB301.UI.StaffMenu
{
    public class RentingMemberSubMenu : StaffSubMenuBase
    {
        public override void DoWork()
        {
            Console.Write("Enter DVD's movie name: ");
            string title = Console.ReadLine();

            var movies = MovieService.GetMovieCollection();
            var movie = movies.Search(title);
            Console.WriteLine();
            if (movie == null)
            {
                Console.WriteLine("DVD's movie not in system! ");
                Console.WriteLine("Back to Staff Menu!");
                Console.WriteLine();
                return;
            }
            else
            {
                if (movie.Borrowers.IsEmpty())
                {
                    Console.WriteLine("No members currently borrows this movie!");
                }
                else
                {
                    Console.WriteLine("The DVD movie is borrowed by: ");
                    Console.WriteLine(movie.Borrowers.ToString());
                }
                Console.WriteLine();
            }
        }
    }
}
