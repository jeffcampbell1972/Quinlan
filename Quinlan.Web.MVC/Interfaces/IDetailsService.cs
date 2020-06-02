using Quinlan.MVC.Models;

namespace Quinlan.MVC.Services
{
    public interface IDetailsService<T>
    {
        public T Build(int id, CardFilterOptionsViewModel filterOptions);
    }
}
