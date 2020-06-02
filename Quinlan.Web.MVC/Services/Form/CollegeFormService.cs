using System.Linq;

using Quinlan.MVC.Models;
using Quinlan.Domain.Models;
using Quinlan.Domain.Services;
using System;

namespace Quinlan.MVC.Services
{
    public class CollegeFormService : IFormService<CollegeViewModel>
    {
        ICrudService<College> _collegeService;
        public CollegeFormService(ICrudService<College> collegeService)
        {
            _collegeService = collegeService;
        }
        public void Save(CollegeViewModel collegeVM)
        {
            if (collegeVM == null)
            {
                throw new Exception();
            }

            var college = new College
            {
                Identifier = collegeVM.Identifier,
                Name = collegeVM.Name,
                Nickname = collegeVM.Nickname
            };

            _collegeService.Post(college);
        }
        public void Save(int id, CollegeViewModel collegeVM)
        {
            if (collegeVM == null)
            {
                throw new Exception();
            }

            var college = new College
            {
                Identifier = collegeVM.Identifier ,
                Name = collegeVM.Name ,
                Nickname = collegeVM.Nickname
            };

            _collegeService.Put(id, college);
        }
    }
}
