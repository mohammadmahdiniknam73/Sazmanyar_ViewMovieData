using Microsoft.EntityFrameworkCore;
using System.Reflection;
using ViewMovieData.Model.Models;

namespace ViewMovieData.Model.Data
{
    public class ApllicationDbContext : DbContext
    {
        public ApllicationDbContext(DbContextOptions<ApllicationDbContext> options) : base(options)
        {
        }



        public DbSet<Movie> Movies { get; set; }
        public DbSet<Genre> Genres { get; set; }
        public DbSet<VideoType> VideoTypes { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}
