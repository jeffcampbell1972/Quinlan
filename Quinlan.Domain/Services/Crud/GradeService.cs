using System.Collections.Generic;
using System.Linq;

using Quinlan.Data.Services;
using Quinlan.Domain.Models;

namespace Quinlan.Domain.Services
{
    public class GradeService : ICrudService<Grade>
    {
        IDataService<Quinlan.Data.Models.Grade> _gradeDataService;

        public GradeService(IDataService<Quinlan.Data.Models.Grade> gradeDataService)
        {
            _gradeDataService = gradeDataService;
        }

        public List<Grade> Get()
        {
            var gradesData = _gradeDataService.Select();

            var grades = gradesData
                .Select(x => new Grade
                {
                    Id = x.Id,
                    Identifier = x.Identifier,
                    Name = x.Name
                })
                .ToList();

            return grades;
        }
        public Grade Get(int id)
        {
            var gradeData = _gradeDataService.Select(id);

            if (gradeData == null)
            {
                throw new DataNotFoundException("Grade not found.  Invalid id provided.");
            }

            return new Grade
            {
                Id = gradeData.Id,
                Identifier = gradeData.Identifier,
                Name = gradeData.Name
            };
        }
        public void Post(Grade grade)
        {
            var gradeData = new Quinlan.Data.Models.Grade
            {
                Identifier = grade.Identifier, // may need to revisit
                Name = grade.Name
            };

            _gradeDataService.Insert(gradeData);
        }
        public void Put(int id, Grade grade)
        {
            var gradeData = _gradeDataService.Select(id);

            gradeData.Name = grade.Name;

            _gradeDataService.Update(id, gradeData);
        }
        public void Delete(int id)
        {
            throw new DeleteNotSupportedException();
        }
    }
}
