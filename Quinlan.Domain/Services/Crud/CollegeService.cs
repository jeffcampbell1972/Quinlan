using System;
using System.Collections.Generic;
using System.Linq;
using Quinlan.Data.Services;
using Quinlan.Domain.Models;

namespace Quinlan.Domain.Services
{
    public class CollegeService : ICrudService<College>
    {
        IDataService<Quinlan.Data.Models.College> _collegeDataService;
        public CollegeService(IDataService<Quinlan.Data.Models.College> collegeDataService)
        {
            _collegeDataService = collegeDataService;
        }

        public List<College> Get()
        {
            var collegesData = _collegeDataService.Select();

            var colleges = collegesData
                .Select(x => new College
                {
                    Id = x.Id,
                    Identifier = x.Identifier,
                    Name = x.Name ,
                    Nickname = x.Nickname
                })
                .ToList();

            return colleges;
        }
        public College Get(int id)
        {
            var collegeData = _collegeDataService.Select(id);

            if (collegeData == null)
            {
                throw new ItemNotFoundException("College not found.  Invalid id provided.");
            }


            return new College
            { 
                Id = collegeData.Id, 
                Identifier = collegeData.Identifier ,
                Name = collegeData.Name ,
                Nickname = collegeData.Nickname
            };
        }
        public void Post(College college)
        {
            var collegeData = new Quinlan.Data.Models.College
            {
                Identifier = college.Name + college.Nickname,
                Name = college.Name ,
                Nickname = college.Nickname 
            };

            _collegeDataService.Insert(collegeData);
        }
        public void Put(int id, College college)
        {
            var collegeData = _collegeDataService.Select(id);

            collegeData.Name = college.Name;
            collegeData.Nickname = college.Nickname;

            _collegeDataService.Update(id, collegeData);
        }
        public void Delete(int id)
        {
            throw new DeleteNotSupportedException();
        }
    }
}
