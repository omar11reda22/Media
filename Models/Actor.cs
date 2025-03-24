using System.ComponentModel.DataAnnotations;

namespace IMDB.Models
{
    public class Actor
    {
        [Key]
        public int Actor_ID { get; set; }
        public string Name { get; set; }
        public string BIO { get; set; }
        public string nationality { get; set; }

        public string image { get; set; }

        public ICollection<Media_Actors> media_Actors { get; set; }
    }
}
