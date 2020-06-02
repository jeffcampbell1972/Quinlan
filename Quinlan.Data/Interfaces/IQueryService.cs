using System.Collections.Generic;

namespace Quinlan.Data.Services
{
    public interface IQueryService<T, U>
    {
        public List<T> Execute(U filterOptions);
    }
}
