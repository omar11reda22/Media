using System.ComponentModel.DataAnnotations;

namespace IMDB.ViewModels
{
    public class MediaViewModel
    {
        public int MediaId { get; set; }

        [Required]
        public string Title { get; set; }

        public int Year { get; set; }
        public float? Rating { get; set; }
        public string? Poster { get; set; }
        public string Description { get; set; }
        public DateOnly ReleaseDate { get; set; }
        public string TrailerURL { get; set; }

        public int MediaTypeId { get; set; }
        public string? Name { get; set; }
    }
}
