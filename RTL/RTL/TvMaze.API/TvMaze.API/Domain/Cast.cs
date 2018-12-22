using System;
using System.ComponentModel.DataAnnotations;

namespace TvMaze.API.Models
{
    public class Cast
    {
        public int Id { get; set; }

        [Required] public string name { get; set; }


        [Required] public DateTime birthday { get; set; }

        public Movie Movie { get; set; }
    }
}