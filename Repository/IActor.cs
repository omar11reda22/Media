
namespace IMDB.Repository
{
    public interface IActor<T>
    {
       List<T> GetAll();
        T Add(T item); 


    }
}
