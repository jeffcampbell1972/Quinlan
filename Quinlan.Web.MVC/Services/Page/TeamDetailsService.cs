using System.Linq;

using Quinlan.MVC.Models;
using Quinlan.Domain.Models;
using Quinlan.Domain.Services;
using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;

namespace Quinlan.MVC.Services
{
    public class TeamDetailsService : IDetailsService<TeamDetails>
    {
        ICrudService<Team> _teamService;
        ICollectibleSearchService<CardSearch, CardSearchFilterOptions> _cardSearchService;
        UserManager<IdentityUser> _userManager;
        public TeamDetailsService(ICrudService<Team> teamService, ICollectibleSearchService<CardSearch, CardSearchFilterOptions> cardSearchService)
        {
            _teamService = teamService;
            _cardSearchService = cardSearchService;
        }
        public TeamDetails Build(int id, CardFilterOptionsViewModel filterOptionsVM, bool hasOwnerRights)
        {
            if (filterOptionsVM == null)
            {
                filterOptionsVM = new CardFilterOptionsViewModel();
            }
            filterOptionsVM.TeamId = id;

            var defaultFilterOptionsVM = new CardFilterOptionsViewModel
            {
                TeamId = id
            };

            var cardFilterOptions = SearchFilterService.BuildCardSearchFilterOptions(filterOptionsVM);
            var defaultFilterOptions = SearchFilterService.BuildCardSearchFilterOptions(defaultFilterOptionsVM);

            var team = _teamService.Get(id);
            var cardSearch = _cardSearchService.Get(cardFilterOptions);
            var people = _cardSearchService.GetPeople(defaultFilterOptions);
            var cards = cardSearch.Cards
                .Select(x => new CardListItemViewModel
                {
                     Id = x.Id ,
                     CardNumber = x.CardNumber != null ? x.CardNumber.ToString() : "--" ,
                     FormattedCost = FormatService.FormatDollars(x.Cost) ,
                     FormattedValue = FormatService.FormatDollars(x.Value) ,
                     PersonName = x.Person == null ? "" : x.Person.ToString() ,
                     PersonId = x.Person == null ? 0 : x.Person.Id ,
                     TeamName = x.Team == null ? "" : x.Team.ToString() ,
                     TeamId = x.Team == null ? 0 : x.Team.Id ,
                    Grade = x.Grade == null ? "" : x.Grade.Name,
                    Company = x.SetName,
                     RC = x.RCFlag ? " RC" : "",
                     HOF = x.Person == null ? "" : x.Person.HOFFlag ? "(HOF)" : "" ,
                     Year = x.Year.ToString(),
                     Attributes = FormatService.BuildAttributes(x)
                })
                .ToList();

            
            var vm = new TeamDetails
            {
                Id = team.Id,
                Identifier = team.Identifier ,
                DisplayName = team.Name,
                Cards = cards ,
                HasOwnerRights = hasOwnerRights ,
                SearchTotalsVM = new SearchTotalsViewModel
                {
                    NumCollectibles = cardSearch.NumCards,
                    TotalCost = cardSearch.TotalCost,
                    ShowTotalCost = hasOwnerRights,
                    TotalValue = cardSearch.TotalValue
                },

                FilterOptionsVM = new CardSearchViewModel
                {
                    People = MvcService.BuildPeopleSelectList(people, cardFilterOptions.PersonId ?? 0),
                    MinValues = MvcService.BuildValuesSelectList(cardFilterOptions.MinValue ?? 0),
                    MaxValues = MvcService.BuildValuesSelectList(cardFilterOptions.MaxValue ?? 0)
                }
            };

            return vm;
        }
    }
}
