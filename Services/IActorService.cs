namespace IMDB.Services
{
    public interface IActorService<T>
    {
        T add(T entity); 
    }
}
