
using System.Collections.Generic;

namespace Quinlan.API.Services
{
    public interface IApiService<T>
    {
        public List<T> Get();
        public T Get(int id);
        public void Post(T t);
        public void Put(int id, T t);
        public void Delete(int id);
    }
}
