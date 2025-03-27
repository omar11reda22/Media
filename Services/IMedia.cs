namespace IMDB.Services
{
    public interface IMedia<T> where T : class 
    {
        IEnumerable<T> GetAll(); 

        T add(T item);

        T getbyid(int id);
    }
}
