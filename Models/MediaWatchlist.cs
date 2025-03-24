namespace IMDB.Models
{
    public class MediaWatchlist
    {
        public int WatchlistId { get; set; }
        public Watchlist Watchlist { get; set; }

        public int MediaId { get; set; }
        public Media Media { get; set; }
    }
}
