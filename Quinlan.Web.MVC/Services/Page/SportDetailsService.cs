using System.Linq;

using Quinlan.MVC.Models;
using Quinlan.Domain.Models;
using Quinlan.Domain.Services;
using System;

namespace Quinlan.MVC.Services
{
    public class SportDetailsService : IDetailsService<SportDetails>
    {
        ICrudService<Sport> _sportService;
        ICrudService<League> _leagueService;

        ICollectibleSearchService<CardSearch, CardSearchFilterOptions> _cardSearchService;
        public SportDetailsService(ICrudService<Sport> sportService, ICrudService<League> leagueService, ICollectibleSearchService<CardSearch, CardSearchFilterOptions> cardSearchService)
        {
            _sportService = sportService;
            _leagueService = leagueService;
            _cardSearchService = cardSearchService;
        }
        public SportDetails Build(int id, CardFilterOptionsViewModel filterOptionsVM)
        {
            var leagues = _leagueService.Get().Where(x => x.SportId == id).ToList();
            var defaultLeague = leagues.SingleOrDefault(x => x.SportId == id && x.SearchDefault);

            if (filterOptionsVM == null)
            {
                filterOptionsVM = new CardFilterOptionsViewModel
                {
                    SportId = id ,
                    PersonId = 0 ,
                    CollegeId = 0 ,
                    TeamId = 0 ,
                    LeagueId = defaultLeague != null ? defaultLeague.Id : 0
                };
            }
            filterOptionsVM.SportId = id;

            var defaultFilterOptionsVM = new CardFilterOptionsViewModel
            {
                SportId = id ,
                PersonId = 0,
                CollegeId = 0,
                TeamId = 0 ,
                LeagueId = defaultLeague != null ? defaultLeague.Id : 0
            };

            var cardFilterOptions = SearchFilterService.BuildCardSearchFilterOptions(filterOptionsVM);
            var defaultFilterOptions = SearchFilterService.BuildCardSearchFilterOptions(defaultFilterOptionsVM);

            var sport = _sportService.Get(id);

            var cardSearch = _cardSearchService.Get(cardFilterOptions);
            var people = _cardSearchService.GetPeople(defaultFilterOptions);
            var teams = _cardSearchService.GetTeams(defaultFilterOptions);
            var colleges = _cardSearchService.GetColleges(defaultFilterOptions);
            var grades = _cardSearchService.GetGrades(defaultFilterOptions);
            var graders = _cardSearchService.GetGraders(defaultFilterOptions);

            var cards = cardSearch.Cards
               .Select(x => new CardListItemViewModel
               {
                   Id = x.Id,
                   CardNumber = x.CardNumber != null ? x.CardNumber.ToString() : "--" ,
                   FormattedCost = FormatService.FormatDollars(x.Cost) ,
                   FormattedValue = FormatService.FormatDollars(x.Value) ,
                   PersonName = x.Person == null ? "" : x.Person.ToString() ,
                   PersonId = x.Person == null ? 0 : x.Person.Id ,
                   TeamName = x.Team == null ? "" : x.Team.ToString() ,
                   TeamId = x.Team == null ? 0 : x.Team.Id ,
                   Company = x.SetName ,
                   Grade = x.Grade != null ? x.Grade.Name : "" ,
                   GraderName = x.Grade != null ? x.Grade.GraderName : "" ,
                   RC = x.RCFlag ? "RC" : "" ,
                   HOF = x.Person == null ? "" : x.Person.HOFFlag ? " (HOF)" : "" ,
                   Year = x.Year.ToString() ,
                   Attributes = FormatService.BuildAttributes(x)
               })
               .ToList();


            var sportDetailsViewModel = new SportDetails
            {
                Id = sport.Id ,
                Identifier = sport.Identifier ,
                DisplayName = string.Format("{0} Cards", sport.Name) ,
                Cards = cards,
                SearchTotalsVM = new SearchTotalsViewModel
                {
                    NumCollectibles = cardSearch.NumCards ,
                    TotalCost = cardSearch.TotalCost,
                    TotalValue = cardSearch.TotalValue
                },
                FilterOptionsVM = new CardSearchViewModel
                {
                    ShowPeopleFilters = "" ,
                    ShowHeismanFilter = sport.Name == "Football" ? "" : "hidden",
                    People = MvcService.BuildPeopleSelectList(people, cardFilterOptions.PersonId ?? 0) ,
                    Leagues = MvcService.BuildLeaguesSelectList(leagues, cardFilterOptions.LeagueId ?? 0) ,
                    Teams = MvcService.BuildTeamsSelectList(teams, cardFilterOptions.TeamId ?? 0) ,
                    Colleges = MvcService.BuildCollegesSelectList(colleges, cardFilterOptions.CollegeId ?? 0),
                    Graders = MvcService.BuildGradersSelectList(graders, cardFilterOptions.GraderId ?? 0),
                    Grades = MvcService.BuildGradesSelectList(grades, cardFilterOptions.GradeId ?? 0)
                }
            };

            return sportDetailsViewModel;
        }
    }
}
