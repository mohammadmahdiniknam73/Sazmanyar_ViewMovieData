using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViewMovieData.Model.Models;

namespace ViewMovieData.Model.Data.Configurations
{
    public class MovieConfiguration : IEntityTypeConfiguration<Movie>
    {
        public void Configure(EntityTypeBuilder<Movie> builder)
        {
            builder.Property(m => m.Id).IsRequired();
            builder.Property(m => m.ProductionDate).IsRequired();
            builder.Property(m => m.Name).IsRequired();
            builder.Property(m => m.IsOutNow).IsRequired();

            builder.HasOne(m => m.VideoType)
                .WithMany(v => v.Movies)
                .HasForeignKey(m => m.VideoTypeId)
                .OnDelete(DeleteBehavior.Restrict);
      
        
            builder.HasOne(m => m.Genre)
                .WithMany(g => g.Movies)
                .HasForeignKey(m => m.GenreId) 
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasData(
                new Movie { Id = 1, Name = "Movie 1", ProductionDate = DateOnly.Parse("2022-01-01"), IsOutNow = true, GenreId = 1, VideoTypeId = 1 },
                new Movie { Id = 2, Name = "Movie 2", ProductionDate = DateOnly.Parse("2023-02-02"), IsOutNow = false, GenreId = 2, VideoTypeId = 2 },
                new Movie { Id = 3, Name = "Movie 3", ProductionDate = DateOnly.Parse("2024-03-03"), IsOutNow = true, GenreId = 3, VideoTypeId = 3 },
                new Movie { Id = 4, Name = "Movie 4", ProductionDate = DateOnly.Parse("2022-01-04"), IsOutNow = false, GenreId = 4, VideoTypeId = 4 },
                new Movie { Id = 5, Name = "Movie 5", ProductionDate = DateOnly.Parse("2022-01-05"), IsOutNow = true, GenreId = 5, VideoTypeId = 5 },
                new Movie { Id = 6, Name = "Movie 6", ProductionDate = DateOnly.Parse("2022-01-06"), IsOutNow = false, GenreId = 1, VideoTypeId = 1 },
                new Movie { Id = 7, Name = "Movie 7", ProductionDate = DateOnly.Parse("2022-01-07"), IsOutNow = true, GenreId = 2, VideoTypeId = 2 },
                new Movie { Id = 8, Name = "Movie 8", ProductionDate = DateOnly.Parse("2022-01-08"), IsOutNow = false, GenreId = 3, VideoTypeId = 3 },
                new Movie { Id = 9, Name = "Movie 9", ProductionDate = DateOnly.Parse("2022-01-09"), IsOutNow = true, GenreId = 4, VideoTypeId = 4 },
                new Movie { Id = 10, Name = "Movie 10", ProductionDate = DateOnly.Parse("2022-01-10"), IsOutNow = false, GenreId = 5, VideoTypeId = 5 }
            );

        }
    }
}
