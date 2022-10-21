using CAB301.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace CAB301.UI.MemberMenu
{
    public class DisplayAllSubMenu : MemberSubMenuBase
    {
        public override void DoWork()
        {
            var movieCollection = MovieService.GetMovieCollection();
            if (movieCollection.IsEmpty())
            {
                Console.WriteLine("The community library does not have any movie DVDs currently!");
            }
            else
            {
                
                var movies = movieCollection.ToArray();
                Console.WriteLine("Currently the community library has {0} movie DVDs!", movieCollection.Number);
                for (int i = 0; i < movieCollection.Number; i++)
                    if (!movies[i].Equals(null))
                    {
                        Console.WriteLine(movies[i].ToString());
                    }
            }
            Console.WriteLine();
            Console.WriteLine("Back to the member menu!");
            Console.WriteLine();
        }
    }
}
