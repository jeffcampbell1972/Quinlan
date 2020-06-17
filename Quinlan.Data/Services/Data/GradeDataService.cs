using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using Microsoft.EntityFrameworkCore;
using Quinlan.Data.Models;

namespace Quinlan.Data.Services
{
    public class GradeDataService : IDataService<Grade>
    {
        QdbContext _qDb;
        public GradeDataService(QdbContext qDb)
        {
            _qDb = qDb;
        }

        public List<Grade> Select()
        {
            var gradesData = _qDb.Grades
               .ToList();

            return gradesData;
        }
        public Grade Select(int id)
        {
            var gradeData = _qDb.Grades.SingleOrDefault(x => x.Id == id);

            if (gradeData == null)
            {
                throw new InvalidIdException("Id not found in Grades.");
            }

            return gradeData;
        }
        public void Insert(Grade grade)
        {
            _qDb.Grades.Add(grade);
            _qDb.SaveChanges();
        }
        public void Update(int id, Grade grade)
        {
            var gradeData = _qDb.Grades
                .SingleOrDefault(x => x.Id == id);

            if (gradeData == null)
            {
                throw new InvalidIdException("Id not found in Grades.");
            }
            gradeData = grade;
            _qDb.SaveChanges();
        }
        public void Delete(int id)
        {
            var gradeData = _qDb.Grades.SingleOrDefault(x => x.Id == id);

            if (gradeData == null)
            {
                throw new InvalidIdException("Id not found in Grades.");
            }

            _qDb.Grades.Remove(gradeData);
            _qDb.SaveChanges();
        }
    }
}
