using System.Collections.Generic;

using Quinlan.MVC.Models;
using Quinlan.Domain.Models;
using Quinlan.Domain.Services;
using System.Linq;

namespace Quinlan.MVC.Services
{
    public class HomePageService : IHomePageService
    {
        ISummaryService<DataSummary> _summaryService;
        ICollectibleSearchService<CardSearch, CardSearchFilterOptions> _cardSearchService;
        ISearchService<TeamSearch, TeamSearchFilterOptions> _teamSearchService;
        public HomePageService(ISummaryService<DataSummary> summaryService, ISearchService<TeamSearch, TeamSearchFilterOptions> teamSearchService, ICollectibleSearchService<CardSearch, CardSearchFilterOptions> cardSearchService)
        {
            _summaryService = summaryService;
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
        public Summary BuildSummary()
        {
            var dataSummary = _summaryService.Get();

            var vm = new Summary
            {
                DbTotals = new SubTotalViewModel
                {
                    Description = dataSummary.DbTotals.Description,
                    NumItems = dataSummary.DbTotals.NumItems,
                    TotalCost = dataSummary.DbTotals.TotalCost,
                    TotalValue = dataSummary.DbTotals.TotalValue
                },
                BaseballCardSubTotals = dataSummary.BaseballCardSubTotals.Select(x => new SubTotalViewModel
                {
                    Description = x.Description,
                    NumItems = x.NumItems,
                    TotalCost = x.TotalCost,
                    TotalValue = x.TotalValue
                })
                .ToList() ,
                BasketballCardSubTotals = dataSummary.BasketballCardSubTotals.Select(x => new SubTotalViewModel
                {
                    Description = x.Description,
                    NumItems = x.NumItems,
                    TotalCost = x.TotalCost,
                    TotalValue = x.TotalValue
                })
                .ToList(),
                FootballCardSubTotals = dataSummary.FootballCardSubTotals.Select(x => new SubTotalViewModel
                {
                    Description = x.Description,
                    NumItems = x.NumItems,
                    TotalCost = x.TotalCost,
                    TotalValue = x.TotalValue
                })
                .ToList(),
                HockeyCardSubTotals = dataSummary.HockeyCardSubTotals.Select(x => new SubTotalViewModel
                {
                    Description = x.Description,
                    NumItems = x.NumItems,
                    TotalCost = x.TotalCost,
                    TotalValue = x.TotalValue
                })
                .ToList(),
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
