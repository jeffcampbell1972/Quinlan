using System.Linq;

using Quinlan.MVC.Models;
using Quinlan.Domain.Models;
using Quinlan.Domain.Services;


namespace Quinlan.MVC.Services
{
    public class CollegeDetailsService : IDetailsService<CollegeDetails>
    {
        ICrudService<College> _collegeService;
        ICollectibleSearchService<CardSearch, CardSearchFilterOptions> _cardSearchService;
        public CollegeDetailsService(ICrudService<College> collegeService, ICollectibleSearchService<CardSearch, CardSearchFilterOptions> cardSearchService)
        {
            _collegeService = collegeService;
            _cardSearchService = cardSearchService;
        }
        public CollegeDetails Build(int id, CardFilterOptionsViewModel filterOptionsVM, bool hasOwnerRights)
        {
            if (filterOptionsVM == null)
            {
                filterOptionsVM = new CardFilterOptionsViewModel();
            }
            filterOptionsVM.CollegeId = id;


            var defaultFilterOptionsVM = new CardFilterOptionsViewModel
            {
                CollegeId = id
            };

            var cardFilterOptions = SearchFilterService.BuildCardSearchFilterOptions(filterOptionsVM);
            var defaultFilterOptions = SearchFilterService.BuildCardSearchFilterOptions(defaultFilterOptionsVM);

            var college = _collegeService.Get(id);
            var cardSearch = _cardSearchService.Get(cardFilterOptions);
            var people = _cardSearchService.GetPeople(defaultFilterOptions);
            var teams = _cardSearchService.GetTeams(defaultFilterOptions);
            var cards = cardSearch.Cards
               .Select(x => new CardListItemViewModel
               {
                   Id = x.Id,
                   CardNumber = x.CardNumber != null? x.CardNumber.ToString() : "--" ,
                   FormattedCost = FormatService.FormatDollars(x.Cost),
                   FormattedValue = FormatService.FormatDollars(x.Value),
                   PersonName = x.Person == null ? "" : x.Person.ToString(),
                   PersonId = x.Person == null ? 0 : x.Person.Id,
                   TeamName = x.Team == null ? "" : x.Team.ToString(),
                   TeamId = x.Team == null ? 0 : x.Team.Id,
                   Grade = x.Grade == null ? "" : x.Grade.Name,
                   Company = x.SetName,
                   RC = x.RCFlag ? "RC" : "" ,
                   HOF = x.Person != null ? x.Person.HOFFlag ? "(HOF)" : "" : "" ,
                   Year = x.Year.ToString(),
                   Attributes = FormatService.BuildAttributes(x)
               })
               .ToList();

            var collegeViewModel = new CollegeDetails
            {
                Id = college.Id , 
                Identifier = college.Identifier , 
                DisplayName = college.ToString() ,
                HasOwnerRights = hasOwnerRights,
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

            return collegeViewModel;
        }
    }
}
