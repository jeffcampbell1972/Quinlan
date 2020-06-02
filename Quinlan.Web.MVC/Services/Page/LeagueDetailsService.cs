using System.Linq;

using Quinlan.MVC.Models;
using Quinlan.Domain.Models;
using Quinlan.Domain.Services;


namespace Quinlan.MVC.Services
{
    public class LeagueDetailsService : IDetailsService<LeagueDetails>
    {
        ICrudService<League> _leagueService;
        ICollectibleSearchService<CardSearch, CardSearchFilterOptions> _cardSearchService;
        public LeagueDetailsService(ICrudService<League> leagueService, ICollectibleSearchService<CardSearch, CardSearchFilterOptions> cardSearchService)
        {
            _leagueService = leagueService;
            _cardSearchService = cardSearchService;
        }
        public LeagueDetails Build(int id, CardFilterOptionsViewModel filterOptionsVM)
        {
            if (filterOptionsVM == null)
            {
                filterOptionsVM = new CardFilterOptionsViewModel();
            }
            filterOptionsVM.LeagueId = id;


            var defaultFilterOptionsVM = new CardFilterOptionsViewModel
            {
                LeagueId = id
            };

            var cardFilterOptions = SearchFilterService.BuildCardSearchFilterOptions(filterOptionsVM);
            var defaultFilterOptions = SearchFilterService.BuildCardSearchFilterOptions(defaultFilterOptionsVM);

            var league = _leagueService.Get(id);
            var cardSearch = _cardSearchService.Get(cardFilterOptions);
            var people = _cardSearchService.GetPeople(defaultFilterOptions);
            var teams = _cardSearchService.GetTeams(defaultFilterOptions);
            var cards = cardSearch.Cards
               .Select(x => new CardListItemViewModel
               {
                   Id = x.Id,
                   CardNumber = x.CardNumber != null? x.CardNumber.ToString() : "--" ,
                   FormattedCost = x.Cost.ToString(),
                   FormattedValue = x.Value.ToString(),
                   PersonName = x.Person == null ? "" : x.Person.ToString(),
                   PersonId = x.Person == null ? 0 : x.Person.Id,
                   TeamName = x.Team == null ? "" : x.Team.ToString(),
                   TeamId = x.Team == null ? 0 : x.Team.Id,
                   Grade = x.Grade == null ? "" : x.Grade.Name,
                   Company = x.SetName,
                   RC = x.RCFlag ? "RC" : "" ,
                   HOF = x.Person == null ? "" : x.Person.HOFFlag ? "HOF" : "" ,
                   Year = x.Year.ToString()
               })
               .ToList();

            var leagueViewModel = new LeagueDetails
            {
                Id = league.Id , 
                Identifier = league.Identifier , 
                DisplayName = league.Name ,
                Cards = cards,
                SearchTotalsVM = new SearchTotalsViewModel
                {
                    NumCollectibles = cardSearch.NumCards,
                    TotalCost = cardSearch.TotalCost,
                    TotalValue = cardSearch.TotalValue
                } ,
                FilterOptionsVM = new CardSearchViewModel
                {
                    People = MvcService.BuildPeopleSelectList(people, filterOptionsVM.PersonId) ,
                    Teams = MvcService.BuildTeamsSelectList(teams, filterOptionsVM.TeamId) ,
                    FilterOptions = filterOptionsVM
                }
            };

            return leagueViewModel;
        }
    }
}
