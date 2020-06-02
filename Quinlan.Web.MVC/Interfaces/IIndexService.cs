
namespace Quinlan.MVC.Services
{
    public interface IIndexService<T, U>
    {
        public T Build(U filterOptions);
    }
}
