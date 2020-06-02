
namespace Quinlan.MVC.Services
{
    public interface IViewService<T>
    {
        public T Build(int id);
    }
}
