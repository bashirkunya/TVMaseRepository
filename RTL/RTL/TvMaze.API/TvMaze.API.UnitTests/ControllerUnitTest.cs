using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TvMaze.API.Controllers;
using TvMaze.API.Models;
using Xunit;

namespace TvMaze.API.UnitTests
{
    public class ControllerUnitTest
    {

        [Fact]
        public async Task TestGetMoviesAsync()
        {
            // Arrange
            var dbContext = DbContextMocker.GetTvMazeDbContext(nameof(TestGetMoviesAsync));
            var controller = new TvMazeController(null, dbContext);

            // Act
            var response = await controller.GetMoviesAsync() as ObjectResult;
            var value = response.Value as IPagedResponse<Movie>;

            dbContext.Dispose();

            // Assert
            Assert.False(value.DidError);
        }


        [Fact]
        public async Task TestPostMovieAsync()
        {
            // Arrange
            var dbContext = DbContextMocker.GetTvMazeDbContext(nameof(TestPostMovieAsync));
            var controller = new TvMazeController(null, dbContext);
            Cast cast = new Cast();
            cast.name = "Deniz Akdeniz";
            cast.birthday = DateTime.Parse("1993-05-21");
            Cast cast1 = new Cast();
            cast1.name = "Filiz Ahmet";
            cast1.birthday = DateTime.Parse("1990-12-05");
            Cast[] cast2 = { cast, cast1 };
            var requestModel = new PostMovieRequest
            {
                name = "Magnificient Century",
                cast = cast2
            };

            // Act
            var response = await controller.PostMovieAsync(requestModel) as ObjectResult;
            var value = response.Value as ISingleResponse<Movie>;

            dbContext.Dispose();

            // Assert
            Assert.False(value.DidError);
        }
    }
}
