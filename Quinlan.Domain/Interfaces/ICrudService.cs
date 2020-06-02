using System.Collections.Generic;

namespace Quinlan.Domain.Services
{    
    public interface ICrudService<T>
    {
        public List<T> Get();
        public T Get(int id);
        public void Post(T t);
        public void Put(int id, T t);
        public void Delete(int id);
    }
}
