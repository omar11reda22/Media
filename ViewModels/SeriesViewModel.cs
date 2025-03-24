namespace IMDB.ViewModels
{
    public class SeriesViewModel:MediaViewModel
    {
        public int? Episodes { get; set; } // Only for Series
        public int? Seasons { get; set; } // Only for Series
    }
}
