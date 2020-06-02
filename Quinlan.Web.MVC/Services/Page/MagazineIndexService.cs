using Quinlan.MVC.Models;
using Quinlan.Domain.Models;
using Quinlan.Domain.Services;
using System.Linq;

namespace Quinlan.MVC.Services
{
    public class MagazineIndexService : IIndexService<MagazineIndex, MagazineFilterOptionsViewModel>
    {
        ICollectibleSearchService<MagazineSearch, MagazineSearchFilterOptions> _magazineSearchService;
        public MagazineIndexService(ICollectibleSearchService<MagazineSearch, MagazineSearchFilterOptions> magazineSearchService)
        {
            _magazineSearchService = magazineSearchService;
        }
        public MagazineIndex Build(MagazineFilterOptionsViewModel filterOptionsViewModel)
        {
            var magazineFilterOptions = SearchFilterService.BuildMagazineSearchFilterOptions(filterOptionsViewModel);

            var defaultFilterOptions = new MagazineSearchFilterOptions();

            if (magazineFilterOptions == null)
            {
                magazineFilterOptions = defaultFilterOptions;
            }
            var magazineSearch = _magazineSearchService.Get(magazineFilterOptions);
            var people = _magazineSearchService.GetPeople(defaultFilterOptions);
            var magazines = magazineSearch.Magazines.Select(x => new MagazineListItemViewModel
            {
                Id = x.Id,
                Identifier = x.Identifier,
                PersonName = x.PersonName,
                PersonId = x.PersonId,
                PublisherName = x.PublisherName,
                LeagueName = x.LeagueName,
                TeamName = x.TeamName,
                TeamId = x.TeamId,
                SportName = x.SportName,
                Year = x.Year.ToString(),
                Cost = x.Cost,
                Value = x.Value
            })
            .ToList();

            var vm = new MagazineIndex
            {
                DisplayName = "Magazines" ,
                Magazines = magazines ,
                SearchTotalsVM = new SearchTotalsViewModel
                {
                    NumCollectibles = magazineSearch.NumCollectibles,
                    TotalCost = magazineSearch.TotalCost,
                    TotalValue = magazineSearch.TotalValue
                },
                People = MvcService.BuildPeopleSelectList(people, magazineFilterOptions.PersonId ?? 0),
                FilterOptions = filterOptionsViewModel
            };

            return vm;
        }
    }
}
