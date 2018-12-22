using System;
using Microsoft.EntityFrameworkCore;
using TvMaze.API.Models;

namespace TvMaze.API.Domain
{
    public class TvMazeDbContext : DbContext
    {
        public TvMazeDbContext()
        {
        }

        public TvMazeDbContext(DbContextOptions<TvMazeDbContext> options) : base(options)
        {
        }

        public DbSet<Movie> movie { get; set; }

        public DbSet<Cast> cast { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
         modelBuilder.Entity<Movie>()
        .HasMany(c => c.Casts)
        .WithOne(e => e.Movie)
        .IsRequired(); 
        }

        public void Seed()
        {
           
        }
    }
}
