using System.ComponentModel.DataAnnotations;

namespace IMDB.Models
{
    public class User
    {
        [Key]
        public int UserId { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Avatar { get; set; } = "";

        public string Role { get; set; } = "User";

        public ICollection<Review> reviews { get; set; }
        public ICollection<Watchlist> watchlists { get; set; }


    }
}
