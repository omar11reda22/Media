namespace IMDB.Models
{
    public class Media_Actors
    {
        
        public int MediaId { get; set; }
        public Media? Media { get; set; }

        public int ActorId { get; set; }
        public Actor? Actor { get; set; }
    }
}
