using System;
using System.Linq;

using Quinlan.Data.FilterOptions;
using Quinlan.Data.Services;
using Quinlan.Domain.Models;


namespace Quinlan.Domain.Services
{
    public class PersonSearchService : ISearchService<PersonSearch,PersonSearchFilterOptions>
    {
        IQueryService<Quinlan.Data.Models.Person, PersonQueryFilterOptions> _personQueryService;
        public PersonSearchService(IQueryService<Quinlan.Data.Models.Person, PersonQueryFilterOptions> personQueryService)
        {
            _personQueryService = personQueryService;
        }

        public PersonSearch Get(PersonSearchFilterOptions filterOptions)
        {
            var personFilterOptions = QueryFilterService.BuildPersonFilterOptions(filterOptions);

            var peopleData = _personQueryService.Execute(personFilterOptions);
            var sportsData = SportCodeService.Select();

            var people = peopleData
                .Select(x => new Person
                {
                    Id = x.Id,
                    Identifier = x.Identifier ,
                    Name = String.Format("{0} {1}", x.FirstName ?? "", x.LastName) ,
                    LastName = x.LastName ,
                    FirstName = x.FirstName ,
                    MiddleName = x.MiddleName ,
                    Suffix = x.Suffix ,
                    College = x.College != null ? new College 
                    { 
                        Id = x.College.Id, 
                        Identifier = x.College.Identifier, 
                        Name = x.College.Name , 
                        Nickname = x.College.Nickname 
                    } : null ,
                    Sports = x.PersonSports.Select(ps => new Sport
                    {
                        Id = ps.SportId,
                        Identifier = sportsData.Single(s => s.Id == ps.SportId).Identifier,
                        Name = sportsData.Single(s => s.Id == ps.SportId).Name
                    }).ToList() ,
                    HOFFlag = x.HOFFlag == true ,
                    HeismanFlag = x.HeismanFlag == true ,
                    NotableFlag = x.NotableFlag == true 
                })
                .ToList();

            var personSearch = new PersonSearch
            {
                PersonFilterOptions = filterOptions,
                People = people
            };

            return personSearch;
        }
    }
}
