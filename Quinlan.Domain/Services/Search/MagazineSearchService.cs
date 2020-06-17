using System.Collections.Generic;
using System.Linq;

using Quinlan.Data.FilterOptions;
using Quinlan.Data.Services;
using Quinlan.Domain.Models;

namespace Quinlan.Domain.Services
{
    public class MagazineSearchService : ICollectibleSearchService<MagazineSearch,MagazineSearchFilterOptions>
    {
        private ICollectibleQueryService<CollectibleQueryFilterOptions> _collectibleQueryService;
        public MagazineSearchService(ICollectibleQueryService<CollectibleQueryFilterOptions> collectibleQueryService)
        {
            _collectibleQueryService = collectibleQueryService;
        }

        public MagazineSearch Get(MagazineSearchFilterOptions filterOptions)
        {
            var collectibleFilterOptions = QueryFilterService.BuildCollectibleFilterOptions(filterOptions);

            var collectiblesData = _collectibleQueryService.SelectCollectibles(collectibleFilterOptions);

            var magazines = collectiblesData
                .Select(x => new Magazine 
                { 
                    Id = x.Id, 
                    Identifier = x.Id.ToString() ,
                    Title = string.Format("{0} {1} #{2} {3}{4}", x.Year, x.Set.Name, x.CardNumber, x.Person != null ? string.Format("{0} {1}", x.Person.FirstName, x.Person.LastName) : string.Format("{0} {1}", x.ImportCollectible.FirstName, x.ImportCollectible.LastName), x.RCFlag == true ? " (RC)" : "") ,
                    Year = x.Year ,
                    PublisherName = x.Set.Name ,
                    PersonName = x.Person != null ? string.Format("{0} {1}", x.Person.FirstName, x.Person.LastName) : string.Format("{0} {1}", x.ImportCollectible.FirstName, x.ImportCollectible.LastName),
                    SportName = x.Sport != null ? x.Sport.Name : null ,
                    LeagueName = x.League != null ? x.League.Name : (x.Team != null && x.Team.League != null) ? x.Team.League.Name : "" ,
                    TeamName = x.Team != null ? string.Format("{0} {1}", x.Team.City, x.Team.Nickname) : "" ,
                    Description = x.ImportCollectible.Description ,
                    HOF = x.Person != null ? x.Person.HOFFlag == true ? "HOF" : "" : "",
                    PersonId = x.Person != null ? x.Person.Id : 0 ,
                    TeamId = x.Team != null ? x.Team.Id : 0 ,
                    Cost = x.Cost ?? 0,
                    Value = x.Value ?? 0
                })
                .ToList();

            var magazineSearch = new MagazineSearch
            {
                FilterOptions = filterOptions,
                Magazines = magazines,
                NumCollectibles = magazines.Count,
                TotalCost = magazines.Sum(x => x.Cost) ,
                TotalValue = magazines.Sum(x => x.Value)
            };

            return magazineSearch;
        }
        public List<Team> GetTeams(MagazineSearchFilterOptions filterOptions)
        {
            var collectibleFilterOptions = QueryFilterService.BuildCollectibleFilterOptions(filterOptions);
            var teamsData = _collectibleQueryService.SelectTeams(collectibleFilterOptions);

            var teams = teamsData
               .OrderBy(x => x.City)
               .Select(x => new Team
               {
                   Id = x.Id,
                   Name = string.Format("{0} {1}", x.City, x.Nickname) ,
                   League = x.League != null ? new League {  Id = x.League.Id, Name = x.League.Name } : null
               })
               .ToList();

            return teams;
        }
        public List<Person> GetPeople(MagazineSearchFilterOptions filterOptions)
        {
            var collectibleFilterOptions = QueryFilterService.BuildCollectibleFilterOptions(filterOptions);
            var peopleData = _collectibleQueryService.SelectPeople(collectibleFilterOptions);

            var people = peopleData
               .OrderBy(x => x.LastName)
               .Select(x => new Person
               {
                   Id = x.Id,
                   Name = string.Format("{0} {1}", x.FirstName, x.LastName)
               })
               .ToList();

            return people;
        }
        public List<College> GetColleges(MagazineSearchFilterOptions filterOptions)
        {
            var collectibleFilterOptions = QueryFilterService.BuildCollectibleFilterOptions(filterOptions);
            var collegesData = _collectibleQueryService.SelectColleges(collectibleFilterOptions);

            var colleges = collegesData
               .Select(x => new College
               {
                   Id = x.Id,
                   Name = string.Format("{0} {1}", x.Name ?? "", x.Nickname ?? "")
               })
               .ToList();

            return colleges;
        }

        public List<Grade> GetGrades(MagazineSearchFilterOptions filterOptions)
        {
            throw new System.Exception("");
        }
        public List<Grader> GetGraders(MagazineSearchFilterOptions filterOptions)
        {
            throw new System.Exception("");
        }
    }
}
