using System.ComponentModel.DataAnnotations;

namespace IMDB.Models
{
    public class Watchlist
    {
        [Key]
        public int WatchlistId { get; set; }
        public int UserId { get; set; }

        // Navigation Properties
        public User User { get; set; }
        public ICollection<MediaWatchlist> mediaWatchlists { get; set; }
    }
}
