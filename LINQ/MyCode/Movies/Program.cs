using System;
using System.Collections.Generic;
using System.Linq;

namespace Movies
{
    class Program
    {
        static void Main(string[] args)
        {
           var movies = new List<Movie>
           {
               new Movie  {Title = "The Dark Night", Rating = 8.9f, Year = 2008},
               new Movie  {Title = "The King's Speech", Rating = 8.0f, Year = 2010},
               new Movie  {Title = "Casablanca", Rating = 8.5f, Year = 1980},
               new Movie  {Title = "Star Wars", Rating = 8.7f, Year = 1970}
           };

            var query = movies.Filter(m => m.Year > 2000);
            
            foreach (var movie in query)
            {
                Console.WriteLine(movie.Title);
            }

        }
    }
}
