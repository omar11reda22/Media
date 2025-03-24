using IMDB.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace IMDB.Configurations
{
    public class MediaConfigurations : IEntityTypeConfiguration<Media>
    {
        public void Configure(EntityTypeBuilder<Media> builder)
        {
            // set configurations here 
            // first set relations 

            /*
             [one to many] [movie - director]
             [many to many] [movie - genre]
             [many to many] [movie - actors]
             [many to many] [movie - watchlist]
             [one to many] [movie - reviews] 
            [one to many] [movie - movieactor]
            [one to many] [movie - moviegenre]
            [one to many] [movie - moviewatchlist]

             */

            builder.HasOne(s => s.Director)
                .WithMany(s => s.medias)
                .HasForeignKey(s => s.DirectorId);

            builder.HasMany(s => s.Reviews)
                .WithOne(s => s.media)
                .HasForeignKey(s => s.MediaId);

            builder.HasMany(s => s.MediaGenres)
                .WithOne(s => s.Media)
                .HasForeignKey(s => s.MediaId);

            builder.HasMany(s => s.MediaActors)
                .WithOne(s => s.Media)
                .HasForeignKey(s => s.MediaId);

            builder.HasMany(s => s.MediaWatchlists)
                .WithOne(s => s.Media)
                .HasForeignKey(s => s.MediaId);



        }
    }
}
