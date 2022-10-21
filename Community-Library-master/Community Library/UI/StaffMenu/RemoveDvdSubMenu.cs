using CAB301.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace CAB301.UI.StaffMenu
{
    public class RemoveDvdSubMenu : StaffSubMenuBase
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
                Console.WriteLine("DVD's movie not found! No movie deleted!");
                Console.WriteLine("Back to Staff Menu!");
                Console.WriteLine();
                return;
            }

            bool valid = false;
            int quantity = 0;
            while (!valid)
            {
                Console.Write("Enter DVD's quantity: ");
                if (!int.TryParse(Console.ReadLine(), out quantity))
                {
                    Console.WriteLine("Invalid input, not a number");
                }
                else
                {
                    if (quantity>=0 && quantity <=movie.AvailableCopies)
                        valid = true;
                    else
                        Console.WriteLine("Invalid input, number is out of range");
                }
            }
            if (quantity <= movie.AvailableCopies)
            {
                if(movie.NoBorrowings > 0)
                {
                    movie.AvailableCopies -= quantity;
                    Console.WriteLine("{0} copies removed! {1} left!", quantity, movie.AvailableCopies);
                    Console.WriteLine("Back to Staff Menu!");
                    Console.WriteLine();
                }
                else
                {
                    if(quantity == movie.AvailableCopies)
                    {
                        movies.Delete(movie);
                        Console.WriteLine("All DVD copies removed! Movie also removed!");
                    }
                    else
                    {
                        movie.AvailableCopies -= quantity;
                        Console.WriteLine("{0} copies removed! {1} left!", quantity, movie.AvailableCopies);
                    }
                    Console.WriteLine("Back to Staff Menu!");
                    Console.WriteLine();
                }
            }
            else
            {
                if (movies.Delete(movie))
                {
                    Console.WriteLine("All DVD copies removed! Movie also removed!");
                }
                else
                {
                    Console.WriteLine("DVD removal failed!");
                }
                Console.WriteLine("Back to Staff Menu!");
                Console.WriteLine();
            }

        }
    }
}
