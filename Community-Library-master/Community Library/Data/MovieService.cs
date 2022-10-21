using System;
using System.Collections.Generic;
using System.Text;

namespace CAB301.Data
{
    public class MovieService
    {
        private static IMovieCollection _movieCollection = new MovieCollection();
        public static IMovieCollection GetMovieCollection()
        {
            return _movieCollection;
        }
    }
}
