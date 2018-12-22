using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TvMaze.API.Models
{
    public class PostMovieRequest
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(200)]
        public string name { get; set; }
        public Cast[] cast { get; set; }

    }
    public static class Extensions
    {
        public static Movie ToEntity(this PostMovieRequest request)
            => new Movie
            {
                Id=request.Id,
                name = request.name
            };
    }
}
