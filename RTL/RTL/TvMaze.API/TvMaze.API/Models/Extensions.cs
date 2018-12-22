using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TvMaze.API.Domain;

namespace TvMaze.API.Models
{
    public static class TvMazeDbContextExtensions
    {
        public static IQueryable<Movie> GetMovieList(this TvMazeDbContext dbContext, int pageSize = 10, int pageNumber = 1)
        {
            // Get query from DbSet
            var query = dbContext.movie
                .Include(m=> m.Casts)
                .AsQueryable();
            return query;
        }
       public static async Task<Movie> GetMovieAsync(this TvMazeDbContext dbContext, Movie entity)
    => await dbContext.movie
            .FirstOrDefaultAsync(m =>m.name == entity.name);
    }
    public static class IQueryableExtensions
    {
        public static IQueryable<TModel> Paging<TModel>(this IQueryable<TModel> query, int pageSize = 0, int pageNumber = 0) where TModel : class
            => pageSize > 0 && pageNumber > 0 ? query.Skip((pageNumber - 1) * pageSize).Take(pageSize) : query;
    }
}
