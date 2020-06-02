using System.Linq;

using Quinlan.MVC.Models;
using Quinlan.Domain.Models;
using Quinlan.Domain.Services;
using System;

namespace Quinlan.MVC.Services
{
    public class PersonFormService : IFormService<PersonViewModel>
    {
        ICrudService<Person> _personService;
        public PersonFormService(ICrudService<Person> personService)
        {
            _personService = personService;
        }
        public void Save(PersonViewModel personVM)
        {
            if (personVM == null)
            {
                throw new Exception();
            }

            var person = new Person
            {
                Identifier = personVM.Identifier ,
                LastName = personVM.LastName ,
                FirstName = personVM.FirstName ,
                MiddleName = personVM.MiddleName ,
                Suffix = personVM.Suffix ,
                HOFFlag = personVM.HOFFlag ,
                HeismanFlag = personVM.HeismanFlag ,
                NotableFlag = personVM.NotableFlag
            };

            _personService.Post(person);
        }
        public void Save(int id, PersonViewModel personVM)
        {
            if (personVM == null)
            {
                throw new Exception();
            }

            var person = new Person
            {
                Identifier = personVM.Identifier,
                LastName = personVM.LastName,
                FirstName = personVM.FirstName,
                MiddleName = personVM.MiddleName,
                Suffix = personVM.Suffix,
                HOFFlag = personVM.HOFFlag,
                HeismanFlag = personVM.HeismanFlag,
                NotableFlag = personVM.NotableFlag ,
                College = personVM.CollegeId == 0 ? null : new College
                {
                    Id = (int) personVM.CollegeId
                } ,
                Sports = personVM.SportIds == null ? null : personVM.SportIds.Select(x => new Sport { Id = x }).ToList()
            };

            _personService.Put(id, person);
        }
    }
}
