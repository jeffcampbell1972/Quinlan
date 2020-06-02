namespace Quinlan.Domain.Services
{
    public interface ISearchService<T, U>
    {
        public T Get(U filterOptions);
    }
}
