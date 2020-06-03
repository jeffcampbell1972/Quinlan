using Quinlan.MVC.Models;

namespace Quinlan.MVC.Services
{
    public interface IHomeService<T>
    {
        public T Build();
    }
}
