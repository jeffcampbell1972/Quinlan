using System.Linq;

using Quinlan.MVC.Models;
using Quinlan.Domain.Models;
using Quinlan.Domain.Services;
using System;

namespace Quinlan.MVC.Services
{
    public class PersonDetailsService : IDetailsService<PersonDetails>
    {
        ICrudService<Person> _personService;
        ICollectibleSearchService<CardSearch, CardSearchFilterOptions> _cardSearchService;
        public PersonDetailsService(ICrudService<Person> personService, ICollectibleSearchService<CardSearch, CardSearchFilterOptions> cardSearchService)
        {
            _personService = personService;
            _cardSearchService = cardSearchService;
        }
        public PersonDetails Build(int id, CardFilterOptionsViewModel filterOptionsVM)
        {
            if (filterOptionsVM == null)
            {
                filterOptionsVM = new CardFilterOptionsViewModel();
            }
            filterOptionsVM.PersonId = id;

            var defaultFilterOptionsVM = new CardFilterOptionsViewModel
            {
                PersonId = id
            };

            if (filterOptionsVM == null)
            {
                filterOptionsVM = defaultFilterOptionsVM;
            }
            var cardFilterOptions = SearchFilterService.BuildCardSearchFilterOptions(filterOptionsVM);
            var defaultFilterOptions = SearchFilterService.BuildCardSearchFilterOptions(defaultFilterOptionsVM);

            var person = _personService.Get(id);
            var cardSearch = _cardSearchService.Get(cardFilterOptions);
            var teams = _cardSearchService.GetTeams(defaultFilterOptions);
            var cards = cardSearch.Cards
               .Select(x => new CardListItemViewModel
               {
                   Id = x.Id,
                   CardNumber = x.CardNumber != null ? x.CardNumber.ToString() : "--" ,
                   FormattedCost = FormatService.FormatDollars(x.Cost) ,
                   FormattedValue = FormatService.FormatDollars(x.Value),
                   PersonName = x.Person == null ? "" : x.Person.ToString(),
                   PersonId = x.Person == null ? 0 : x.Person.Id,
                   TeamName = x.Team == null ? "" : x.Team.ToString(),
                   TeamId = x.Team == null ? 0 : x.Team.Id,
                   Grade = x.Grade == null ? "" : x.Grade.Name ,
                   Company = x.SetName,
                   RC = x.RCFlag ? "RC" : "" ,
                   HOF = x.Person == null ? "" : x.Person.HOFFlag ? "HOF" : ""  ,
                   Year = x.Year.ToString(),
                   CardType = x.CardType == null ? "" : x.CardType.Name == "Player" ? "" : x.CardType.Name ,
                   Attributes = FormatService.BuildAttributes(x)
               })
               .ToList();

            var displayName = person.Name;
            if (person.HOFFlag)
            {
                displayName += " (HOF)";
            }

            var personDetailsViewModel = new PersonDetails
            {
                Id = person.Id ,
                Identifier = person.Identifier , 
                Cards = cards,
                DisplayName = displayName,
                SearchTotalsVM = new SearchTotalsViewModel
                {
                    NumCollectibles = cardSearch.NumCards,
                    TotalCost = cardSearch.TotalCost,
                    TotalValue = cardSearch.TotalValue
                },
                FilterOptionsVM = new CardSearchViewModel
                {
                    Teams = MvcService.BuildTeamsSelectList(teams, cardFilterOptions.TeamId ?? 0),
                    ShowPeopleFilters = "hidden" ,
                    FilterOptions = filterOptionsVM
                }
            };

            return personDetailsViewModel;
        }
    }
    
}
