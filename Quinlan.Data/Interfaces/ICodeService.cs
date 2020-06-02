using System.Collections.Generic;

namespace Quinlan.Data.Services
{    
    public interface ICodeService<T>
    {
        public List<T> Select();
        public T Select(int id);
    }
}
