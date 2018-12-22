using System;
using System.Collections.Generic;
using System.Text;
using TvMaze.API.Domain;
using TvMaze.API.Models;

namespace TvMaze.API.UnitTests
{
    public  static class DbContextExtensions
    {
        public static void Seed(this TvMazeDbContext dbContext)
        {
            // Add entities for DbContext instance
            Cast cast1 = new Cast();
            cast1.Id =7;
            cast1.name = "Mike Vogel";
            cast1.birthday = DateTime.Parse("1979-07-17");
            Cast cast2 = new Cast();
            cast2.Id = 9;
            cast2.name = "Dean Norris";
            cast2.birthday = DateTime.Parse("1963-04-08");
            Cast[] cast = { cast1, cast2 };
            dbContext.movie.Add(new Movie
            {
                Id = 1,
                name = "Game of Thrones"//,
                //cast = cast
            });

            // Add entities for DbContext instance
            Cast cast3 = new Cast();
            cast1.Id = 6;
            cast1.name = "Michael Emerson";
            cast1.birthday = DateTime.Parse("1950-01-01");
 
            Cast[] cast4 = { cast3};
            dbContext.movie.Add(new Movie
            {
                Id = 4,
                name = "Big Bang Theory"//,
                //cast = cast4
            });


        }
    }
}
