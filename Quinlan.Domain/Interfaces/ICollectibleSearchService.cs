using System.Collections.Generic;

using Quinlan.Domain.Models;

namespace Quinlan.Domain.Services
{
    public interface ICollectibleSearchService<T, U>
    {
        public T Get(U filterOptions);
        public List<Person> GetPeople(U filterOptions);
        public List<Team> GetTeams(U filterOptions);
        public List<College> GetColleges(U filterOptions);
        public List<Grade> GetGrades(U filterOptions);
        public List<Grader> GetGraders(U filterOptions);
    }
}
