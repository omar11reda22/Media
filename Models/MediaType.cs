using System.ComponentModel.DataAnnotations;

namespace IMDB.Models
{
    public class MediaType
    {
        [Key]
        public int MediaTypeId { get; set; }

        [Required]
        public string Name { get; set; } // Example values: "Movie", "Anime", "Series"

        public ICollection<Media> Media { get; set; }
    }
}
