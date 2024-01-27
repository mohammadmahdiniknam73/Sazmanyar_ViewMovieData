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
    public class VideoTypeConfiguration : IEntityTypeConfiguration<VideoType>
    {

        public void Configure(EntityTypeBuilder<VideoType> builder)
        {
            builder.Property(v => v.Id).IsRequired();
            builder.Property(v => v.Name).IsRequired();

            builder.HasData(
                    new VideoType { Id = 1, Name = "Feature Film" },
                    new VideoType { Id = 2, Name = "Short Film" },
                    new VideoType { Id = 3, Name = "Documentary" },
                    new VideoType { Id = 4, Name = "Animated Film" },
                    new VideoType { Id = 5, Name = "Experimental Film" },
                    new VideoType { Id = 6, Name = "Commercial" },
                    new VideoType { Id = 7, Name = "Music Video" },
                    new VideoType { Id = 8, Name = "Educational Film" },
                    new VideoType { Id = 9, Name = "TV Show" },
                    new VideoType { Id = 10, Name = "Web Series" }

                );
        }
    }
}
