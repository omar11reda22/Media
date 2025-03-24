using System.ComponentModel.DataAnnotations;

namespace IMDB.Models
{
    public class Genre
    {
        [Key]
        public int Genre_ID { get; set; }
        public string Name { get; set; }
        public ICollection<Media_Genre> media_Genres { get; set; }

    }
}
