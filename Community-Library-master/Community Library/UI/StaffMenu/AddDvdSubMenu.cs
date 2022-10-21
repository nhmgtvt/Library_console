using CAB301.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace CAB301.UI.StaffMenu
{
    public class AddDvdSubMenu : StaffSubMenuBase
    {
        public override void DoWork()
        {
            Console.Write("Enter DVD's movie name: ");
            string title = Console.ReadLine();
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
                    valid = true;
            }
            IMovieCollection movies = MovieService.GetMovieCollection();
            IMovie existedMovie = movies.Search(title);
            Console.WriteLine();
            if (existedMovie != null)
            {
                Console.WriteLine("Movie existed, DVD quantity updated");
                existedMovie.TotalCopies += quantity;
                existedMovie.AvailableCopies += quantity;
            }
            else //new movie, need to add all information into the system
            {
                Console.WriteLine("New movie, please enter additional information");
                Console.WriteLine();

                // Genre
                Console.WriteLine("Genre info: Action = 1, Comedy = 2,  History = 3, Drama = 4, Western = 5");
                Console.Write("Please enter genre: ");
                valid = false;
                int genre = 0;
                while (!valid)
                {
                    if (!int.TryParse(Console.ReadLine(), out genre))
                    {
                        Console.WriteLine("Invalid input, not a number");
                    }
                    else
                    {
                        if (genre >= 1 && genre <= 5)
                        {
                            valid = true;
                        }
                        else
                            Console.WriteLine("Invalid input, number is out of range");
                    }
                }
                var movieGenre = (MovieGenre)genre;

                // Classification
                Console.WriteLine("Classification info: G = 1, PG = 2,  M = 3, M15Plus = 4");
                Console.Write("Please enter classification: ");
                valid = false;
                int classification = 0;
                while (!valid)
                {
                    if (!int.TryParse(Console.ReadLine(), out classification))
                    {
                        Console.WriteLine("Invalid input, not a number");
                    }
                    else
                    {
                        if (classification >= 1 && classification <= 4)
                        {
                            valid = true;
                        }
                        else
                            Console.WriteLine("Invalid input, number is out of range");
                    }
                }
                var movieClassification = (MovieClassification)classification;

                // Duration
                valid = false;
                Console.Write("Please enter movie duration: ");
                int duration = 0;
                while (!valid)
                {
                    if (!int.TryParse(Console.ReadLine(), out duration))
                    {
                        Console.WriteLine("Invalid input, not a number");
                    }
                    else
                    {
                        valid = true;
                    }
                }

                var movie = new Movie(title, movieGenre, movieClassification, duration, quantity);
                Console.WriteLine();
                if (movies.Insert(movie))
                    Console.WriteLine("Movie added successfully!");
                else
                    Console.WriteLine("Movie adding failed!");
                Console.WriteLine();
                Console.WriteLine("Back to staff menu!");
                Console.WriteLine();
            }
        }
    }
}
