namespace IMDB.Services
{
    public interface IAnime<T> where T : class 
    {
        IEnumerable<T> GetAll(); 

        T add(T item); 
    }
}
