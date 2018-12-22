using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using TvMaze.API.Domain;

namespace TvMaze.API.UnitTests
{
    class DbContextMocker
    {
        public static TvMazeDbContext GetTvMazeDbContext(string dbName)
        {
            var options = new DbContextOptionsBuilder<TvMazeDbContext>()
                .UseInMemoryDatabase(databaseName: dbName)
                .Options;

            var dbContext = new TvMazeDbContext(options);
            dbContext.Seed();

            return dbContext;
        }
    }
}
