using System.Collections.Generic;
using System.Linq;

using Quinlan.Data.FilterOptions;
using Quinlan.Data.Services;
using Quinlan.Domain.Models;

namespace Quinlan.Domain.Services
{
    public class FigurineSearchService : ICollectibleSearchService<FigurineSearch,FigurineSearchFilterOptions>
    {
        private ICollectibleQueryService<CollectibleQueryFilterOptions> _collectibleQueryService;
        public FigurineSearchService(ICollectibleQueryService<CollectibleQueryFilterOptions> collectibleQueryService)
        {
            _collectibleQueryService = collectibleQueryService;
        }

        public FigurineSearch Get(FigurineSearchFilterOptions filterOptions)
        {
            var collectibleFilterOptions = QueryFilterService.BuildCollectibleFilterOptions(filterOptions);

            var collectiblesData = _collectibleQueryService.SelectCollectibles(collectibleFilterOptions);

            var figurines = collectiblesData
                .Select(x => new Figurine 
                { 
                    Id = x.Id, 
                    Identifier = x.Id.ToString() ,
                    Title = string.Format("{0} {1} #{2} {3}{4}", x.Year, x.Set.Name, x.CardNumber, x.Person != null ? string.Format("{0} {1}", x.Person.FirstName, x.Person.LastName) : string.Format("{0} {1}", x.ImportCollectible.FirstName, x.ImportCollectible.LastName), x.RCFlag == true ? " (RC)" : "") ,
                    Year = x.Year ,
                    CompanyName = x.Set.Name ,
                    PersonName = x.Person != null ? string.Format("{0} {1}", x.Person.FirstName, x.Person.LastName) : string.Format("{0} {1}", x.ImportCollectible.FirstName, x.ImportCollectible.LastName),
                    Number = x.CardNumber , 
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

            var figurinesSearch = new FigurineSearch
            {
                FilterOptions = filterOptions,
                Figurines = figurines,
                NumCollectibles = figurines.Count,
                TotalCost = figurines.Sum(x => x.Cost) ,
                TotalValue = figurines.Sum(x => x.Value)
            };

            return figurinesSearch;
        }
        public List<Team> GetTeams(FigurineSearchFilterOptions filterOptions)
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
        public List<Person> GetPeople(FigurineSearchFilterOptions filterOptions)
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
        public List<College> GetColleges(FigurineSearchFilterOptions filterOptions)
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
        public List<Grade> GetGrades(FigurineSearchFilterOptions filterOptions)
        {
            throw new System.Exception("");
        }
        public List<Grader> GetGraders(FigurineSearchFilterOptions filterOptions)
        {
            throw new System.Exception("");
        }
    }
}
