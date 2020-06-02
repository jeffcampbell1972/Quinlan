using System.Linq;

using Quinlan.MVC.Models;
using Quinlan.Domain.Models;
using Quinlan.Domain.Services;
using System;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Quinlan.MVC.Services
{
    public class CollegeEditService : IEditService<CollegeEdit>
    {
        ICrudService<College> _collegeService;
        public CollegeEditService(ICrudService<College> collegeService)
        {
            _collegeService = collegeService;
        }
        public CollegeEdit Build (int id)
        {
            var college = _collegeService.Get(id);

           
            var vm = new CollegeEdit
            {
                DisplayName = college.ToString() ,
                CollegeVM = new CollegeViewModel
                {
                    Id = college.Id ,
                    Identifier = college.Identifier ,
                    Name = college.Name ,
                    Nickname = college.Nickname
                }
            };

            return vm;
        }
    }
}
