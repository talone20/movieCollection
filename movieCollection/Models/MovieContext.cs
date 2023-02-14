using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace movieCollection.Models
{
    public class MovieContext : DbContext 
    {

        //Constructor
        public MovieContext (DbContextOptions<MovieContext>options) : base (options)
        {

        }

        public DbSet<MovieResponse> Movies { get; set; }

        protected override void OnModelCreating(ModelBuilder mb)
        {
            mb.Entity<MovieResponse>().HasData(
                new MovieResponse
                {
                    MovieId = 1,
                    Category = "Action/Adventure",
                    MovieTitle = "Dark Knight, The",
                    Year = 2008,
                    Director = "Christopher Nolan",
                    Rating = "PG-13",
                    Edited = false,
                    LentTo = "Your Mom",
                    Notes = "Great Movie"
                },
                new MovieResponse
                {
                    MovieId = 2,
                    Category = "Action/Adventure",
                    MovieTitle = "Iron Man",
                    Year = 2008,
                    Director = "Jon Favreau",
                    Rating = "PG-13",
                    Edited = false,
                    LentTo = "Your Dad",
                    Notes = ""
                },
                new MovieResponse
                {
                    MovieId = 3,
                    Category = "Drama",
                    MovieTitle = "Shawshank Redemption, The",
                    Year = 1994,
                    Director = "Frank Darabont",
                    Rating = "R",
                    Edited = true,
                    LentTo = "Bill",
                    Notes = ""
                }
                ) ;
        }
    }
}
