using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Repository.Entities;
using System;

namespace Repository
{
    public class TennisContext : DbContext
    {
        public DbSet<Nationality> Nationalities { get; set; }

        public DbSet<Entities.Player> Players { get; set; }

        public TennisContext(DbContextOptions<TennisContext> options, IConfiguration configuration)
            : base(options)
        {
            this.configuration = configuration;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(configuration["ConnectionString"]);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var serbianNationality = new Nationality { Id = 1, Name = "Serbia" };
            var russianNationality = new Nationality { Id = 2, Name = "Russia" };
            var germanNationality = new Nationality { Id = 3, Name = "Germany" };
            var greekNationality = new Nationality { Id = 4, Name = "Greece" };
            var spanishNationality = new Nationality { Id = 5, Name = "Spain" };
            var polishNationality = new Nationality { Id = 6, Name = "Poland" };

            modelBuilder.Entity<Nationality>(entity =>
            {
                entity.ToTable("Nationalities", "dbo");

                entity.HasData(
                    new Nationality { Id = 1, Name = "Serbia" },
                    new Nationality { Id = 2, Name = "Russia" },
                    new Nationality { Id = 3, Name = "Germany" },
                    new Nationality { Id = 4, Name = "Greece" },
                    new Nationality { Id = 5, Name = "Spain" },
                    new Nationality { Id = 6, Name = "Poland" }
                    );
            });

            modelBuilder.Entity<Entities.Player>(entity =>
            {
                entity.ToTable("Players", "dbo");

                entity.HasOne(player => player.Nationality).WithMany();

                entity.HasData(
                    new Entities.Player
                    {
                        Id = 1,
                        FirstName = "Rafael",
                        LastName = "Nadal",
                        NationalityId = 5,
                        BirthDate = DateTime.Parse("1986-06-03"),
                        Points = 4875,
                        Games = 1240
                    },
                    new Entities.Player
                    {
                        Id = 2,
                        FirstName = "Novak",
                        LastName = "Djokovic",
                        NationalityId = 1,
                        BirthDate = DateTime.Parse("1987-05-22"),
                        Points = 11015,
                        Games = 1188
                    },
                    new Entities.Player
                    {
                        Id = 3,
                        FirstName = "Roberto Bautista",
                        LastName = "Agut",
                        NationalityId = 5,
                        BirthDate = DateTime.Parse("1988-04-14"),
                        Points = 2385,
                        Games = 546
                    },
                    new Entities.Player
                    {
                        Id = 4,
                        FirstName = "Jan-Lennard",
                        LastName = "Struff",
                        NationalityId = 3,
                        BirthDate = DateTime.Parse("1990-04-25"),
                        Points = 1149,
                        Games = 359
                    },
                    new Entities.Player
                    {
                        Id = 5,
                        FirstName = "Dusan",
                        LastName = "Lajovic",
                        NationalityId = 1,
                        BirthDate = DateTime.Parse("1990-06-30"),
                        Points = 1346,
                        Games = 351
                    },
                    new Entities.Player
                    {
                        Id = 6,
                        FirstName = "Pablo Carreno",
                        LastName = "Busta",
                        NationalityId = 5,
                        BirthDate = DateTime.Parse("1991-07-12"),
                        Points = 2305,
                        Games = 419
                    },
                    new Entities.Player
                    {
                        Id = 7,
                        FirstName = "Filip",
                        LastName = "Krajinovic",
                        NationalityId = 1,
                        BirthDate = DateTime.Parse("1992-02-27"),
                        Points = 1427,
                        Games = 206
                    },
                    new Entities.Player
                    {
                        Id = 8,
                        FirstName = "Asla",
                        LastName = "Karatsev",
                        NationalityId = 2,
                        BirthDate = DateTime.Parse("1993-09-04"),
                        Points = 2553,
                        Games = 71
                    },
                    new Entities.Player
                    {
                        Id = 9,
                        FirstName = "Dominik",
                        LastName = "Koepfer",
                        NationalityId = 3,
                        BirthDate = DateTime.Parse("1994-04-29"),
                        Points = 1096,
                        Games = 74
                    },
                    new Entities.Player
                    {
                        Id = 10,
                        FirstName = "Daniil",
                        LastName = "Medvedev",
                        NationalityId = 2,
                        BirthDate = DateTime.Parse("1996-02-11"),
                        Points = 8935,
                        Games = 325
                    },
                    new Entities.Player
                    {
                        Id = 11,
                        FirstName = "Hubert",
                        LastName = "Hurkacz",
                        NationalityId = 6,
                        BirthDate = DateTime.Parse("1997-02-11"),
                        Points = 3336,
                        Games = 166
                    },
                    new Entities.Player
                    {
                        Id = 12,
                        FirstName = "Alexander",
                        LastName = "Zverev",
                        NationalityId = 3,
                        BirthDate = DateTime.Parse("1997-04-20"),
                        Points = 7970,
                        Games = 453
                    },
                    new Entities.Player
                    {
                        Id = 13,
                        FirstName = "Andrey",
                        LastName = "Rublev",
                        NationalityId = 2,
                        BirthDate = DateTime.Parse("1997-10-20"),
                        Points = 4785,
                        Games = 297
                    },
                    new Entities.Player
                    {
                        Id = 14,
                        FirstName = "Stefanos",
                        LastName = "Tsitsipas",
                        NationalityId = 4,
                        BirthDate = DateTime.Parse("1998-08-12"),
                        Points = 6540,
                        Games = 285
                    }
                );
            });
        }

        private readonly IConfiguration configuration;
    }
}
