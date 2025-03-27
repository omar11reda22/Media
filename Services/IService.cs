namespace IMDB.Services
{
    public interface IService<T>
    {
        T add(T entity);

        List<T> getall();

      
    }
}
