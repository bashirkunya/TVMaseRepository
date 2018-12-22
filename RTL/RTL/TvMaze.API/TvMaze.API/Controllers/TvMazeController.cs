using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using TvMaze.API.Domain;
using TvMaze.API.Models;

namespace TvMaze.API.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class TvMazeController : ControllerBase
    {
        protected readonly ILogger Logger;
        protected readonly TvMazeDbContext DbContext;
        public TvMazeController(ILogger<TvMazeController> logger, TvMazeDbContext dbContext)
        {
            Logger = logger;
            DbContext = dbContext;
        }
        // GET
        // api/v1/TvMaze/Movies

        [HttpGet("Movies")]
        public async Task<IActionResult> GetMoviesAsync(int pageSize = 10, int pageNumber = 1, int? lastEditedBy = null, int? colorID = null, int? outerPackageID = null, int? supplierID = null, int? unitPackageID = null)
        {
            Logger?.LogDebug("'{0}' has been invoked", nameof(GetMoviesAsync));

            var response = new PagedResponse<Movie>();

            try
            {
                var query = DbContext.GetMovieList();
    
                response.PageSize = pageSize;
                response.PageNumber = pageNumber;

                response.ItemsCount = await query.CountAsync();

                response.Model = await query.Paging(pageSize, pageNumber).ToListAsync();

                response.Message = string.Format("Page {0} of {1}, Total of Movies: {2}.", pageNumber, response.PageCount, response.ItemsCount);

                Logger?.LogInformation("Movies have been retrieved successfully.");
            }
            catch (Exception ex)
            {
                response.DidError = true;
                response.ErrorMessage = "There was an internal error, please contact to technical support.";

                Logger?.LogCritical("There was an error on '{0}' invocation: {1}", nameof(GetMoviesAsync), ex);
            }

            return response.ToHttpResponse();
        }
        // POST
        // api/v1/TvMaze/AddMovie

        [HttpPost("AddMovie")]
        public async Task<IActionResult> PostMovieAsync([FromBody]PostMovieRequest request)
        {
            Logger?.LogDebug("'{0}' has been invoked", nameof(PostMovieAsync));

            var response = new SingleResponse<Movie>();

            try
            {
                var existingEntity = await DbContext
                    .GetMovieAsync(new Movie { name = request.name });

                if (existingEntity != null)
                    ModelState.AddModelError("MovieEntity", "Movie with name already exists");

                if (!ModelState.IsValid)
                    return BadRequest();
       
                var movie= new Movie();
                movie.name = request.name;
       
                foreach(var cast in request.cast)
                {
                    movie.Casts.Add(cast);
                }
                DbContext.Add(movie);
                await DbContext.SaveChangesAsync();
                response.Message = "Bingo! Movie successfully added";
                response.Model = request.ToEntity();
            }
            catch (Exception ex)
            {
                response.DidError = true;
                response.ErrorMessage = "There was an internal error, please contact to technical support.";

                Logger?.LogCritical("There was an error on '{0}' invocation: {1}", nameof(PostMovieAsync), ex);
            }

            return response.ToHttpResponse();
        }
    }
}