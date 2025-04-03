namespace IMDB.ViewModels
{
    public class DirectorViewModel
    {
        public int Director_ID { get; set; }
        public string Name { get; set; }
        public string BIO { get; set; }
        public DateOnly birthdate { get; set; }
        public string nationality  { get; set; }
        public string image { get; set; }
        public List<MediaViewModel> mediaViewModels { get; set; } = new List<MediaViewModel>();  
    }
}
