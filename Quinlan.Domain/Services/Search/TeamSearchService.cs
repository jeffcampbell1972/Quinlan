using System.Linq;

using Quinlan.Data.FilterOptions;
using Quinlan.Data.Services;
using Quinlan.Domain.Models;

namespace Quinlan.Domain.Services
{
    public class TeamSearchService : ISearchService<TeamSearch,TeamSearchFilterOptions>
    {
        IQueryService<Quinlan.Data.Models.Team, TeamQueryFilterOptions> _teamQueryService;
        public TeamSearchService(IQueryService<Quinlan.Data.Models.Team, TeamQueryFilterOptions> teamQueryService)
        {
            _teamQueryService = teamQueryService;
        }

        public TeamSearch Get(TeamSearchFilterOptions filterOptions)
        {
            var teamFilterOptions = QueryFilterService.BuildTeamFilterOptions(filterOptions);

            var teamsData = _teamQueryService.Execute(teamFilterOptions);

            var teams = teamsData
                .Select(x => new Team 
                { 
                    Id = x.Id, 
                    Name = string.Format("{0} {1}", x.City, x.Nickname) ,
                    City = x.City ,
                    Nickname = x.Nickname ,
                    League = x.League != null ? new League { Id = x.Id, Name = x.League.Name } : null ,
                    Sport = x.Sport != null ? new Sport { Id = x.Sport.Id, Name = x.Sport.Name } : null ,
                    College = x.College != null ? new College { Id = x.College.Id, Name = x.College.Name } : null
                })
                .ToList();

            var teamSearch = new TeamSearch
            {
                FilterOptions = filterOptions,
                Teams = teams
            };

            return teamSearch;
        }

    }
}
