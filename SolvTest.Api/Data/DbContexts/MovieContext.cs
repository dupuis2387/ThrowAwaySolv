using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.IO;
using SolvTest.Api.Data.Entities;
using System.Collections.Generic;
using System.Linq;

namespace SolvTest.Api.Data.DbContexts
{
    public class MovieContext : DbContext
    {
        
        public MovieContext(DbContextOptions<MovieContext> options)
            : base(options)
        {
            
        }

        public virtual DbSet<MovieEntity> Movies { get; set; }
        public virtual DbSet<ShowTimeEntity> ShowTimes { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {

            var dummyMovieData = new List<MovieEntity>();


            dummyMovieData.Add(new MovieEntity() {
                Id = Guid.NewGuid(),
                Title = "The Matrix",
                PlaintextDescription = "Some judo flying nerds in VR",
                HtmlDescription = "<p>Neo (Keanu Reeves) believes that Morpheus (Laurence Fishburne), " +
                "an elusive figure considered to be the most dangerous man alive, can answer his question -- " +
                "What is the Matrix? " +
                "Neo is contacted by Trinity (Carrie-Anne Moss), a beautiful stranger who leads him into an " +
                "underworld where he meets Morpheus. They fight a brutal battle for their lives against a " +
                "cadre of viciously " +
                "intelligent secret agents. It is a truth that could cost Neo something more precious than " +
                "his life.</p>",
                ReleaseDate = DateTime.Parse("03/31/1999"),
                ArtUrl = "https://upload.wikimedia.org/wikipedia/en/thumb/c/c1/The_Matrix_Poster.jpg/220px-The_Matrix_Poster.jpg"
            }) ;


            dummyMovieData.Add(new MovieEntity()
            {
                Id = Guid.NewGuid(),
                Title = "Resident Evil: Apocalypse",
                PlaintextDescription = "Zombie flick with souped up chick",
                HtmlDescription = "<p>A deadly virus from a secret Umbrella Corporation laboratory underneath " +
                "Raccoon City is exposed to the world. Umbrella seals off the city to contain the virus, creating " +
                "a ghost town where everyone trapped inside turns into a mutant zombie. Alice (Milla Jovovich), " +
                "a survivor from Umbrella's secret lab, meets former Umbrella security officer " +
                "Jill Valentine (Sienna Guillory) and mercenary Carlos Oliviera (Oded Fehr). " +
                "Together, they search for a scientist (Jared Harris) who might be able to help.</p>",
                ReleaseDate = DateTime.Parse("09/10/2004"),
                ArtUrl = "https://upload.wikimedia.org/wikipedia/en/thumb/5/50/Resident_evil_apocalypse_poster.jpg/220px-Resident_evil_apocalypse_poster.jpg"
            });

            dummyMovieData.Add(new MovieEntity()
            {
                Id = Guid.NewGuid(),
                Title = "Resident Evil: Afterlife",
                PlaintextDescription = "Zombie flick with souped up chick and clones",
                HtmlDescription = "<p>In a world overrun with the walking dead, Alice (Milla Jovovich) continues her battle against Umbrella Corp., " +
                "rounding up survivors along the way. Joined by an old friend, Alice and her group set out for a rumored safe haven in Los Angeles. " +
                "Instead of sanctuary, they find the city overrun with zombies, and a trap about to spring.</p>",
                ReleaseDate = DateTime.Parse("09/10/2010"),
                ArtUrl = "https://upload.wikimedia.org/wikipedia/en/thumb/e/ea/Resident_Evil-_Afterlife.jpg/220px-Resident_Evil-_Afterlife.jpg"
            });



            var dummyShowTimeData = new List<ShowTimeEntity>();

            dummyMovieData.ForEach(i =>
            {
                dummyShowTimeData.Add(new ShowTimeEntity()
                {

                    Id = Guid.NewGuid(),
                    MovieId = i.Id,
                    MovieShowTime = DateTime.Now.AddDays(1)
                });

                dummyShowTimeData.Add(new ShowTimeEntity()
                {

                    Id = Guid.NewGuid(),
                    MovieId = i.Id,
                    MovieShowTime = DateTime.Now.AddDays(5)
                });

                // builder.Entity<MovieEntity>().HasData(i);
                dummyShowTimeData.Add(new ShowTimeEntity()
                {

                    Id = Guid.NewGuid(),
                    MovieId = i.Id,
                    MovieShowTime = DateTime.Now.AddDays(1).AddHours(5)
                });

                dummyShowTimeData.Add(new ShowTimeEntity()
                {

                    Id = Guid.NewGuid(),
                    MovieId = i.Id,
                    MovieShowTime = DateTime.Now.AddMonths(1)
                });


                dummyShowTimeData.Add(new ShowTimeEntity()
                {

                    Id = Guid.NewGuid(),
                    MovieId = i.Id,
                    MovieShowTime = DateTime.Now.AddDays(-15)
                });

                dummyShowTimeData.Add(new ShowTimeEntity()
                {

                    Id = Guid.NewGuid(),
                    MovieId = i.Id,
                    MovieShowTime = DateTime.Now.AddYears(-3)
                });

            });

            builder.Entity<MovieEntity>().HasData(dummyMovieData);
            builder.Entity<ShowTimeEntity>().HasData(dummyShowTimeData);

            

            base.OnModelCreating(builder);

        }





    }
}
