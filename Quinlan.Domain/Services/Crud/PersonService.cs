using System.Collections.Generic;
using System.Linq;

using Quinlan.Data.Services;
using Quinlan.Domain.Models;

namespace Quinlan.Domain.Services
{
    public class PersonService : ICrudService<Person>
    {
        IDataService<Quinlan.Data.Models.Person> _personDataService;
        public PersonService(IDataService<Quinlan.Data.Models.Person> personDataService)
        {
            _personDataService = personDataService;
        }

        public List<Person> Get()
        {
            var peopleData = _personDataService.Select();

            var people = peopleData
                .Select(x => new Quinlan.Domain.Models.Person 
                { 
                    Id = x.Id, 
                    Name = x.ToString() 
                })
                .ToList();

            return people;
        }
        public Person Get(int id)
        {
            var personData = _personDataService.Select(id);

            if (personData == null)
            {
                throw new ItemNotFoundException("Person not found.  Invalid id provided.");
            }

            var sportsData = SportCodeService.Select();

            var person = new Person
            {
                Id = personData.Id,
                Identifier = personData.Identifier,
                Name = string.Format("{0} {1}", personData.FirstName ?? "", personData.LastName),
                LastName = personData.LastName,
                FirstName = personData.FirstName,
                MiddleName = personData.MiddleName,
                Suffix = personData.Suffix,
                HOFFlag = personData.HOFFlag == true,
                HeismanFlag = personData.HeismanFlag == true,
                NotableFlag = personData.NotableFlag == true,
                College = personData.College == null ? null : new College
                {
                    Id = personData.College.Id,
                    Identifier = personData.College.Identifier,
                    Name = personData.College.Name,
                    Nickname = personData.College.Nickname
                },
                Sports = personData.PersonSports == null ? null : personData.PersonSports.Select(x => new Sport
                {
                    Id = x.SportId,
                    Identifier = sportsData.Single(s => s.Id == x.SportId).Identifier,
                    Name = sportsData.Single(s => s.Id == x.SportId).Name
                }).ToList()
            };

            return person;
        }
        public void Post(Person person)
        {
            var personData = new Quinlan.Data.Models.Person
            {
                Identifier = person.LastName + person.FirstName ,  // need to revisit
                LastName = person.LastName ,
                FirstName = person.FirstName ,
                MiddleName = person.MiddleName ,
                Suffix = person.Suffix ,
                CollegeId = person.College.Id ,
                HeismanFlag = person.HeismanFlag ,
                HOFFlag = person.HOFFlag ,
                NotableFlag = person.NotableFlag 
            };

            _personDataService.Insert(personData);

            //var personSports = person.Sports.Select(x => new Quinlan.Data.Models.PersonSport { Person = personData, SportId = x.Id }).ToList();

        }
        public void Put(int id, Person person)
        {
            var personData = _personDataService.Select(id);

            int? collegeId = null;

            if (person.College != null)
            {
                collegeId = person.College.Id;
            }

            personData.LastName = person.LastName;
            personData.FirstName = person.FirstName;
            personData.MiddleName = person.MiddleName;
            personData.Suffix = person.Suffix;
            personData.CollegeId = collegeId ;
            personData.HeismanFlag = person.HeismanFlag;
            personData.HOFFlag = person.HOFFlag;
            personData.NotableFlag = person.NotableFlag;
            personData.PersonSports = person.Sports == null ? null : person.Sports.Select(x => new Quinlan.Data.Models.PersonSport { PersonId = id, SportId = x.Id }).ToList();

            _personDataService.Update(id, personData);
        }
        public void Delete(int id)
        {
            throw new DeleteNotSupportedException();
        }
    }
}
