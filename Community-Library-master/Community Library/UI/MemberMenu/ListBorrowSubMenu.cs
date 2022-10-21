using CAB301.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace CAB301.UI.MemberMenu
{
    public class ListBorrowSubMenu : MemberSubMenuBase
    {
        public override void DoWork()
        {
            var movieCollection = MovieService.GetMovieCollection();
            if (movieCollection.IsEmpty())
            {
                Console.WriteLine("The movie DVDs currently is empty!");
            }
            else
            {
                var movies = movieCollection.ToArray();
                var borrowedMovies = new List<IMovie>();
                var currentMember = MemberService.GetCurrentMember();
                for (int i = 0; i < movies.Length; i++)
                {
                    if (movies[i].Borrowers.Search(currentMember))
                        borrowedMovies.Add(movies[i]);
                }
                if (borrowedMovies.Count == 0)
                {
                    Console.WriteLine("No movies borrowed currently!");
                }
                else
                {
                    Console.WriteLine("Currently this member is borrowing {0} movie DVDs!", borrowedMovies.Count);
                    for (int i = 0; i < borrowedMovies.Count; i++)
                        Console.WriteLine(borrowedMovies[i].ToString());
                }
            }
            Console.WriteLine();
            Console.WriteLine("Back to the member menu!");
            Console.WriteLine();
        }
    }
}
