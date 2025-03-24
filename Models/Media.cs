using Microsoft.AspNetCore.Mvc.Formatters;
using System.ComponentModel.DataAnnotations;

namespace IMDB.Models
{
    public class Media
    {
        [Key]
        public int MediaId { get; set; }

        [Required]
        public string Title { get; set; }

        public int Year { get; set; }
        public int Rating { get; set; }
        public string Poster { get; set; }
        public string Description { get; set; }
        public DateOnly ReleaseDate { get; set; }
        public string TrailerURL { get; set; }

        // Foreign Key to MediaType (Movie, Anime, Series)
        public int MediaTypeId { get; set; }
        public MediaType MediaType { get; set; }

        // Optional Fields for Different Media Types
        public int? Duration { get; set; } // Only for Movies
        public int? Episodes { get; set; } // Only for Anime/Series
        public int? Seasons { get; set; } // Only for Series
        public string? Studio { get; set; } // Only for Anime
        public int? DirectorId { get; set; } // Only for Movies
        public Director Director { get; set; } // Optional, only for Movies

        // ✅ **Keep Relationships**
        public ICollection<Media_Genre> MediaGenres { get; set; } // Many-to-Many with Genre
        public ICollection<Media_Actors> MediaActors { get; set; } // Many-to-Many with Actors
        public ICollection<MediaWatchlist> MediaWatchlists { get; set; } // Many-to-Many with Watchlists
        public ICollection<Review> Reviews { get; set; } // One-to-Many with Reviews
    }

}
