using Quinlan.MVC.Models;
using Quinlan.Domain.Models;
using Quinlan.Domain.Services;
using System.Linq;
using System.Collections.Generic;

namespace Quinlan.MVC.Services
{
    public class PersonIndexService : IIndexService<PersonIndex, PersonFilterOptionsViewModel>
    {
        ISearchService<PersonSearch, PersonSearchFilterOptions> _personSearchService;
        ICrudService<Team> _teamService;
        ICrudService<Sport> _sportService;
        ICrudService<League> _leagueService;
        public PersonIndexService(ISearchService<PersonSearch, PersonSearchFilterOptions> personSearchService, ICrudService<Team> teamService, ICrudService<Sport> sportService, ICrudService<League> leagueService)
        {
            _personSearchService = personSearchService;
            _teamService = teamService;
            _sportService = sportService;
            _leagueService = leagueService;
        }
        public PersonIndex Build(PersonFilterOptionsViewModel filterOptionsViewModel)
        {
            var personSearchFilterOptions = SearchFilterService.BuildPersonSearchFilterOptions(filterOptionsViewModel);
            if (personSearchFilterOptions == null)
            {
                personSearchFilterOptions = new PersonSearchFilterOptions();
            }
            var personSearch = _personSearchService.Get(personSearchFilterOptions);
            var teams = _teamService.Get();

            var sports = _sportService.Get();
            var leagues = _leagueService.Get();
            var peopleList = personSearch.People.Select(x => new PersonListItemViewModel
            {
                Id = x.Id ,
                Name = x.LastName == null ? string.Format("[{0}]", x.Identifier) : x.ToString() ,
                CollegeId = x.College != null ? x.College.Id : 0,
                CollegeName = x.College != null ? x.College.Name : "" ,
                SportNames = x.Sports != null ? BuildSportNames(x.Sports) : "" ,
                HOFFlag = x.HOFFlag == true ? "HOF" : "",
                HeismanFlag = x.HeismanFlag == true ? "Heisman" : "",
                NotableFlag = x.NotableFlag == true ? "Notable" : "",
            })
            .ToList();

            var personSearchViewModel = new PersonIndex
            {
                 PersonFilterOptionsViewModel = filterOptionsViewModel,
                 People = peopleList ,
                 Sports = MvcService.BuildSportsSelectList(sports, personSearchFilterOptions.SportId ?? 0) ,
                 Leagues = MvcService.BuildLeaguesSelectList(leagues, personSearchFilterOptions.LeagueId ?? 0) ,
                 Teams = MvcService.BuildTeamsSelectList(teams, personSearchFilterOptions.TeamId ?? 0)
            };

            return personSearchViewModel;
        }

        private string BuildSportNames (List<Sport> sports)
        {
            string sportName = "";

            foreach (var sport in sports)
            {
                if (sportName != "")
                {
                    sportName += " / ";
                }
                sportName += sport.Name;
            }

            return sportName;
        }
    }
}
