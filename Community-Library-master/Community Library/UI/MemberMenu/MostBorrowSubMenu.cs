using CAB301.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace CAB301.UI.MemberMenu
{
    public class MostBorrowSubMenu : MemberSubMenuBase
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
                List<IMovie> topMovies = null;
                if (movies.Length < 3)
                {
                    topMovies = new List<IMovie>(movies);
                }
                else
                {
                    var result = new IMovie[3];
                    result[0] = movies[0];
                    result[1] = movies[1];
                    result[2] = movies[2];
                    if (result[0].NoBorrowings < result[1].NoBorrowings)
                    {
                        var temp = result[1];
                        result[1] = result[0];
                        result[0] = temp;
                    }
                    if (result[1].NoBorrowings < result[2].NoBorrowings)
                    {
                        var temp = result[1];
                        result[1] = result[2];
                        result[2] = temp;
                    }
                    if (result[0].NoBorrowings < result[1].NoBorrowings)
                    {
                        var temp = result[1];
                        result[1] = result[0];
                        result[0] = temp;
                    }
                    for (int i = 3; i < movies.Length; i++)
                    {
                        if (movies[i].NoBorrowings > result[0].NoBorrowings)
                        {
                            result[2] = result[1];
                            result[1] = result[0];
                            result[0] = movies[i];
                        }
                        else
                        {
                            if (movies[i].NoBorrowings > result[1].NoBorrowings)
                            {
                                result[2] = result[1];
                                result[1] = movies[i];
                            }
                            else
                            {
                                if (movies[i].NoBorrowings > result[2].NoBorrowings)
                                    result[2] = movies[i];
                            }
                        }
                    }
                    topMovies = new List<IMovie>(result);
                }
                Console.WriteLine("Top 3 most frequently borrowed movies:");
                foreach (var movie in topMovies)
                    Console.WriteLine(movie.ToString());
            }
            Console.WriteLine();
            Console.WriteLine("Back to the member menu!");
            Console.WriteLine();
        }
    }
}
