using System.Collections.Generic;

namespace Quinlan.Domain.Models
{
    public class TeamSearch
    {
        public TeamSearchFilterOptions FilterOptions { get; set; }
        public List<Team> Teams { get; set; }
    }
}
