using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Zooflix.Models;

namespace Zooflix.Data
{
    public class ZooflixContext : DbContext
    {
        public ZooflixContext (DbContextOptions<ZooflixContext> options)
            : base(options)
        {
        }

        public DbSet<Zooflix.Models.Etoile> Etoile { get; set; } = default!;

        public DbSet<Zooflix.Models.Film>? Film { get; set; }

        public DbSet<Zooflix.Models.User>? User { get; set; }

        public DbSet<Zooflix.Models.Profile>? Profile { get; set; }

        public DbSet<Zooflix.Models.Order>? Order { get; set; }

        public DbSet<Zooflix.Models.OrderFilm>? OrderFilm { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<OrderFilm>()
                .HasKey(c => new {c.OrderId, c.FilmId })
                .HasName("PK_OF");
        }

    }
}
