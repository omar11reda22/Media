namespace IMDB.ViewModels
{
    public class ActorViewModel
    {
        public int ActorId { get; set; }
        public string Name { get; set; }
        public string BIO { get; set; }

        public string Nationality { get; set; }
        public string? image { get; set; }
    }
}
