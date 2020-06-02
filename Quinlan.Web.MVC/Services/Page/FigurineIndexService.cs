using Quinlan.MVC.Models;
using Quinlan.Domain.Models;
using Quinlan.Domain.Services;
using System.Linq;

namespace Quinlan.MVC.Services
{
    public class FigurineIndexService : IIndexService<FigurineIndex,FigurineFilterOptionsViewModel>
    {
        ICollectibleSearchService<FigurineSearch, FigurineSearchFilterOptions> _figurineSearchService;
        public FigurineIndexService(ICollectibleSearchService<FigurineSearch, FigurineSearchFilterOptions> figurineSearchService)
        {
            _figurineSearchService = figurineSearchService;
        }
        public FigurineIndex Build(FigurineFilterOptionsViewModel filterOptionsViewModel)
        {
            var figurineFilterOptions = SearchFilterService.BuildFigurineSearchFilterOptions(filterOptionsViewModel);
            var defaultFilterOptions = new FigurineSearchFilterOptions();

            if (figurineFilterOptions == null)
            {
                figurineFilterOptions = defaultFilterOptions;
            }
            var collectibleSearch = _figurineSearchService.Get(figurineFilterOptions);
            var people = _figurineSearchService.GetPeople(defaultFilterOptions);
            var figurines = collectibleSearch.Figurines.Select(x => new FigurineListItemViewModel
            {
                Id = x.Id ,
                Identifier = x.Identifier ,
                PersonName = x.PersonName ,
                PersonId = x.PersonId ,
                CompanyName = x.CompanyName ,
                LeagueName = x.LeagueName ,
                TeamName = x.TeamName ,
                TeamId = x.TeamId ,
                SportName = x.SportName ,
                Year = x.Year.ToString() ,
                Number = x.Number != null ? x.Number.ToString() : "--" ,
                Cost = x.Cost ,
                Value = x.Value
            })
            .ToList();

            var vm = new FigurineIndex
            {
                DisplayName = "Figurines" ,
                Figurines = figurines ,
                SearchTotalsVM = new SearchTotalsViewModel
                {
                    NumCollectibles = collectibleSearch.NumCollectibles,
                    TotalCost = collectibleSearch.TotalCost,
                    TotalValue = collectibleSearch.TotalValue
                },
                People = MvcService.BuildPeopleSelectList(people, figurineFilterOptions.PersonId ?? 0),
                FilterOptions = filterOptionsViewModel
            };

            return vm;
        }

    }
}
