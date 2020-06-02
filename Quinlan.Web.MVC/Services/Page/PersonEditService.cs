using System.Linq;

using Quinlan.MVC.Models;
using Quinlan.Domain.Models;
using Quinlan.Domain.Services;
using System;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Quinlan.MVC.Services
{
    public class PersonEditService : IEditService<PersonEdit>
    {
        ICrudService<Person> _personService;
        ICrudService<College> _collegeService;
        ICrudService<Sport> _sportService;

        public PersonEditService(ICrudService<Person> personService, ICrudService<College> collegeService, ICrudService<Sport> sportService)
        {
            _personService = personService;
            _collegeService = collegeService;
            _sportService = sportService;
        }
        public PersonEdit Build (int id)
        {
            var person = _personService.Get(id);


            var sportIds = person.Sports.Select(x => x.Id).ToList();
            
            int collegeId = 0;

            if (person.College != null)
            {
                collegeId = person.College.Id;
            }

            var colleges = _collegeService.Get();
            var sports = _sportService.Get();

            var collegesSelectList = MvcService.BuildCollegesSelectList(colleges, collegeId);
            var sportSelectList = MvcService.BuildSportsSelectList(sports, 0, "");
           
            var vm = new PersonEdit
            {
                DisplayName = person.ToString(),
                Colleges = collegesSelectList ,
                Sports = sportSelectList ,
                PersonVM = new PersonViewModel
                {
                    Id = person.Id ,
                    Identifier = person.Identifier ,
                    LastName = person.LastName ,
                    FirstName = person.FirstName ,
                    MiddleName = person.MiddleName ,
                    Suffix = person.Suffix ,
                    HOFFlag = person.HOFFlag ,
                    HeismanFlag = person.HeismanFlag ,
                    NotableFlag = person.NotableFlag ,
                    CollegeId = collegeId ,
                    SportIds = sportIds
                }
            };

            return vm;
        }
    }
}
