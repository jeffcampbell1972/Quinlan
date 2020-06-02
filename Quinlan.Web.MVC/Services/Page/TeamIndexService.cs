using Quinlan.MVC.Models;
using Quinlan.Domain.Models;
using Quinlan.Domain.Services;
using System.Linq;

namespace Quinlan.MVC.Services
{
    public class TeamIndexService : IIndexService<TeamIndex, TeamFilterOptionsViewModel>
    {
        ISearchService<TeamSearch, TeamSearchFilterOptions> _teamSearchService;
        ICrudService<Sport> _sportService;
        ICrudService<League> _leagueService;
        public TeamIndexService(ISearchService<TeamSearch, TeamSearchFilterOptions> teamSearchService, ICrudService<Sport> sportService, ICrudService<League> leagueService)
        {
            _teamSearchService = teamSearchService;
            _sportService = sportService;
            _leagueService = leagueService;
        }
        public TeamIndex Build(TeamFilterOptionsViewModel filterOptionsVM)
        {
            var teamSearchFilterOptions = SearchFilterService.BuildTeamSearchFilterOptions(filterOptionsVM);
            if (teamSearchFilterOptions == null)
            {
                teamSearchFilterOptions = new TeamSearchFilterOptions();
            }
            var teamSearch = _teamSearchService.Get(teamSearchFilterOptions);
            var sports = _sportService.Get();
            var leagues = _leagueService.Get();
            var teamList = teamSearch.Teams.Select(x => new TeamListItemViewModel 
            { 
                Id = x.Id, 
                Name = x.ToString(), 
                LeagueName = x.League != null? x.League.Name : "" ,
                SportName = x.Sport != null ? x.Sport.Name : "" ,
                CollegeId = x.College != null ? x.College.Id : 0 ,
                CollegeName = x.College != null ? x.College.Name : ""
            })
            .ToList();

            var teamSearchViewModel = new TeamIndex
            {
                  TeamFilterOptionsViewModel = filterOptionsVM,
                  Teams = teamList ,
                  Sports = MvcService.BuildSportsSelectList(sports, teamSearchFilterOptions.SportId ?? 0) ,
                  Leagues = MvcService.BuildLeaguesSelectList(leagues, teamSearchFilterOptions.LeagueId ?? 0)
            };

            return teamSearchViewModel;
        }
    }
}
