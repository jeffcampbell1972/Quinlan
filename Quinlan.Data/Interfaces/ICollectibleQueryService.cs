using System.Collections.Generic;

using Quinlan.Data.Models;

namespace Quinlan.Data.Services
{
    public interface ICollectibleQueryService<T>
    {
        public List<Collectible> SelectCollectibles(T filterOptions);
        public List<Person> SelectPeople(T filterOptions);
        public List<Team> SelectTeams(T filterOptions);
        public List<College> SelectColleges(T filterOptions);
    }
}
