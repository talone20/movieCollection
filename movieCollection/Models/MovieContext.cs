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
        public DbSet<Category> Categories { get; set; }


        //Seeding the data
        protected override void OnModelCreating(ModelBuilder mb)
        {
            mb.Entity<Category>().HasData(
                new Category { CategoryId=1, CategoryName="Action/Adventure"},
                new Category { CategoryId=2, CategoryName="Drama"},
                new Category { CategoryId = 3, CategoryName = "Comedy" },
                new Category { CategoryId = 4, CategoryName = "Family" },
                new Category { CategoryId = 5, CategoryName = "Horror/Suspense" },
                new Category { CategoryId = 6, CategoryName = "Miscellaneous" },
                new Category { CategoryId = 7, CategoryName = "Television" },
                new Category { CategoryId = 8, CategoryName = "VHS" }
                );

            mb.Entity<MovieResponse>().HasData(
                new MovieResponse
                {
                    MovieId = 1,
                    CategoryId = 1,
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
                    CategoryId = 1,
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
                    CategoryId = 2,
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
