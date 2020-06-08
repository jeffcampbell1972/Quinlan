using System;
using System.Collections.Generic;
using System.Linq;

using Quinlan.API.Models;
using Quinlan.Domain.Models;
using Quinlan.Domain.Services;

namespace Quinlan.API.Services
{
    public class PeopleApiService : IApiService<PersonDTO>
    {
        ICrudService<Person> _personService;
        ICollectibleSearchService<CardSearch, CardSearchFilterOptions> _cardSearchService;
        public PeopleApiService(ICrudService<Person> personService, ICollectibleSearchService<CardSearch, CardSearchFilterOptions> cardSearchService)
        {
            _personService = personService;
            _cardSearchService = cardSearchService;
        }
        public List<PersonDTO> Get()
        {
            var people = _personService.Get();

            var personDTOs = people.Select(x => new PersonDTO
            {
                 Id = x.Id ,
                 Name = x.Name ,
                 Cards = new List<CardDTO>()
            })
            .ToList();

            return personDTOs;
        }
        public PersonDTO Get(int id)
        {
            var person = _personService.Get(id);

            var cardFilterOptions = new CardSearchFilterOptions
            {
                PersonId = id
            };

            var cardSearch = _cardSearchService.Get(cardFilterOptions);

            var cardDTOs = cardSearch.Cards.Select(x => new CardDTO
            {
                Id = x.Id ,
                CompanyName = x.SetName ,
                CardNumber = x.CardNumber.ToString() ,
                Year = x.Year.ToString() ,
                RC = x.RCFlag ? "RC" : "" ,
                PersonName = x.Person == null ? "" : x.Person.ToString() ,
                PersonId = x.Person == null ? 0 : x.Person.Id ,
                TeamName = x.Team == null ? "" : x.Team.ToString() ,
                TeamId = x.Team == null ? 0 : x.Team.Id
            })
            .ToList();

            var personDTO = new PersonDTO
            {
                Id = person.Id ,
                Name = person.Name ,
                Cards = cardDTOs
            };

            return personDTO;
        }
    
        public void Post(PersonDTO personDTO)
        {
            throw new Exception();
        }
        public void Put(int id, PersonDTO personDTO)
        {
            throw new Exception();
        }
        public void Delete(int id)
        {
            throw new Exception();
        }
    }
}
