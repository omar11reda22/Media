using System.ComponentModel.DataAnnotations;

namespace IMDB.Models
{
    public class Review
    {
        
        public int MediaId { get; set; }
        public int UserId { get; set; }

        public int Rating { get; set; } // 0 to 10
        public string ReviewText { get; set; }

        public Media media { get; set; }
        public User User { get; set; }
    }
}
