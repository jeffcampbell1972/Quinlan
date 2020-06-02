
namespace Quinlan.MVC.Services
{

    public interface IFormService<T>
    {
        public void Save(T t);
        public void Save(int id, T t);
    }
}
