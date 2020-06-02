using System.Collections.Generic;
using System.Linq;

using Quinlan.Data.FilterOptions;
using Quinlan.Data.Services;
using Quinlan.Domain.Models;

namespace Quinlan.Domain.Services
{
    public class CardSearchService : ICollectibleSearchService<CardSearch,CardSearchFilterOptions>
    {
        private ICollectibleQueryService<CollectibleQueryFilterOptions> _collectibleQueryService;
        public CardSearchService(ICollectibleQueryService<CollectibleQueryFilterOptions> collectibleQueryService)
        {
            _collectibleQueryService = collectibleQueryService;
        }

        public CardSearch Get(CardSearchFilterOptions filterOptions)
        {
            var collectibleFilterOptions = QueryFilterService.BuildCollectibleFilterOptions(filterOptions);

            var collectiblesData = _collectibleQueryService.SelectCollectibles(collectibleFilterOptions);

            var cards = collectiblesData
                .Select(x => new Card
                {
                    Id = x.Id,
                    Identifier = x.Id.ToString(),
                    Title = string.Format("{0} {1} #{2} {3}{4}", x.Year, x.Set.Name, x.CardNumber, x.Person != null ? string.Format("{0} {1}", x.Person.FirstName, x.Person.LastName) : string.Format("{0} {1}", x.ImportCollectible.FirstName, x.ImportCollectible.LastName), x.RCFlag == true ? " (RC)" : ""),
                    Year = x.Year,
                    SetName = x.Set.Name,
                    Person = x.Person == null ? null : new Person
                    {
                        Id = x.Person.Id,
                        Identifier = x.Person.Identifier ,
                        FirstName = x.Person.FirstName ,
                        LastName = x.Person.LastName ,
                        MiddleName = x.Person.MiddleName ,
                        Suffix = x.Person.Suffix ,
                        HOFFlag =  x.Person.HOFFlag == true ? true : false
                    } ,
                    CardNumber = x.CardNumber , 
                    CardType = x.CardType == null ? null : new CardType
                    {
                        Id = x.CardType.Id,
                        Identifier = x.CardType.Identifier ,
                        Name = x.CardType.Name
                    },
                    Sport = x.Sport == null ? null : new Sport
                    {
                        Id = x.Sport.Id,
                        Name = x.Sport.Name
                    },
                    League = x.League == null ? null : new League
                    {
                        Id = x.League.Id,
                        Name = x.League.Name
                    },
                    Team = x.Team == null ? null : new Team
                    {
                        Id = x.Team.Id,
                        Identifier = x.Team.Identifier ,
                        City = x.Team.City ,
                        Nickname = x.Team.Nickname 
                    },
                    Grade = x.Grade == null ? null : new Grade
                    {
                        Id = x.Grade.Id ,
                        Identifier = x.Grade.Identifier ,
                        Name = x.Grade.Name
                    },
                    Condition = x.GradedFlag ? "" : x.Condition ,
                    RCFlag = x.RCFlag ,
                    AUFlag = x.AUFlag ,
                    PatchFlag = x.PatchFlag ,
                    GradedFlag = x.GradedFlag ,
                    SPFlag = x.SPFlag ,
                    Cost = x.Cost ?? 0,
                    Value = x.Value ?? 0
                })
                .ToList();

            var cardSearch = new CardSearch
            {
                FilterOptions = filterOptions,
                Cards = cards,
                NumCards = cards.Count,
                TotalCost = cards.Sum(x => x.Cost ?? 0) ,
                TotalValue = cards.Sum(x => x.Value ?? 0)
            };

            return cardSearch;
        }
        public List<Team> GetTeams(CardSearchFilterOptions filterOptions)
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
        public List<Person> GetPeople(CardSearchFilterOptions filterOptions)
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
        public List<College> GetColleges(CardSearchFilterOptions filterOptions)
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
     }
}
