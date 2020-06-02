using System.Collections.Generic;

namespace Quinlan.Data.Services
{    
    public interface IDataService<T>
    {
        public List<T> Select();
        public T Select(int id);
        public void Insert(T t);
        public void Update(int id, T t);
        public void Delete(int id);
    }
}
