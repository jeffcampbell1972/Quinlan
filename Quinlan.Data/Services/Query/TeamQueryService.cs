using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;

using Quinlan.Data.FilterOptions;
using Quinlan.Data.Models;

namespace Quinlan.Data.Services
{
    public class TeamQueryService : IQueryService<Team, TeamQueryFilterOptions>
    {
        QdbContext _qDb;
        public TeamQueryService(QdbContext qDb)
        {
            _qDb = qDb;
        }
        public List<Team> Execute(TeamQueryFilterOptions filterOptions)
        {
            var teams = _qDb.Teams
                .Include(x => x.League)
                .Include(x => x.Sport)
                .Include(x => x.College)
                .Where(x =>
                    (!filterOptions.NotableFlag || (x.NotableFlag == true)) &&
                    (filterOptions.SportId == null || x.SportId == filterOptions.SportId) &&
                    (filterOptions.LeagueId == null || x.LeagueId == filterOptions.LeagueId)
                )
                .OrderBy(x => x.City)
                .ThenBy(x => x.Nickname)
                .ToList();

            return teams;
        }
    }
}
