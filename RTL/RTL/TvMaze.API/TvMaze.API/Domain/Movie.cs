using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TvMaze.API.Models
{
    public class Movie
    {
        public Movie()
        {
            this.Casts = new List<Cast>();
        }
        public int Id { get; set; }

        [Required] public string name { get; set; }

        public ICollection<Cast> Casts { get; set; }


    }
}
