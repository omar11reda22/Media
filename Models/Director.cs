using System.ComponentModel.DataAnnotations;

namespace IMDB.Models
{
    public class Director
    {
        [Key]
        public int Director_ID { get; set; }
        public string Name { get; set; }
        public string BIO { get; set; }
        public DateOnly birthdate { get; set; }
        public string nationality { get; set; }
        public string image { get; set; }

        public ICollection<Media> medias { get; set; }
    }
}
