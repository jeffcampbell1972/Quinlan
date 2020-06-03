using System.Collections.Generic;

using Quinlan.MVC.Models;
using Quinlan.Domain.Models;
using Quinlan.Domain.Services;
using System.Linq;

namespace Quinlan.MVC.Services
{
    public class HomeIndexService : IHomeService<Home>
    {
        ICollectibleSearchService<CardSearch, CardSearchFilterOptions> _cardSearchService;
        ISearchService<TeamSearch, TeamSearchFilterOptions> _teamSearchService;
        public HomeIndexService(ISearchService<TeamSearch, TeamSearchFilterOptions> teamSearchService, ICollectibleSearchService<CardSearch, CardSearchFilterOptions> cardSearchService)
        {
            _teamSearchService = teamSearchService;
            _cardSearchService = cardSearchService;
        }
        public Home Build()
        {
            var notableCards = GetNotableCards();
            var notableTeams = GetNotableTeams();

            var vm = new Home
            {
                WelcomeMessage = "Lots of great deals in there!",
                Title = "Home" ,
                Header = "Welcome to Q's Closet",
                IsSeeded = true ,
                NotableCards = notableCards ,
                NotableTeams = notableTeams ,
                GolfId = 5,
            };

            return vm;
        }
        private List<TeamListItemViewModel> GetNotableTeams()
        {
            var filterOptions = new TeamSearchFilterOptions
            {
                NotableFlag = true
            };

            var teamSearch = _teamSearchService.Get(filterOptions);

            return teamSearch.Teams.Select(x => new TeamListItemViewModel
            {
                Id = x.Id ,
                LeagueName = x.League.Name ,
                SportName = x.Sport.Name ,
                Name = x.ToString()
            })
            .ToList();
        }
        private List<CardListItemViewModel> GetNotableCards()
        {
            var filterOptions = new CardSearchFilterOptions
            {
                NotableFlag = true
            };

            var collectibleSearch = _cardSearchService.Get(filterOptions);

            return collectibleSearch.Cards.Select(x => new CardListItemViewModel
            {
                Id = x.Id,
                Title = x.Title
            })
            .ToList();
        }
    }
}
