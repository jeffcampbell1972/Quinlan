using System.Collections.Generic;
using System.Linq;

using Quinlan.Data.Models;

namespace Quinlan.Data.Services
{
    public class CollegeDataService : IDataService<College>
    {
        QdbContext _qDb;
        public CollegeDataService(QdbContext qDb)
        {
            _qDb = qDb;
        }

        public List<College> Select()
        {
            var collegesData = _qDb.Colleges
               .ToList();

            return collegesData;
        }
        public College Select(int id)
        {
            var collegeData = _qDb.Colleges.SingleOrDefault(x => x.Id == id);

            if (collegeData == null)
            {
                throw new InvalidIdException("Id not found in Colleges.");
            }

            return collegeData;
        }
        public void Insert(College college)
        {
            _qDb.Colleges.Add(college);
            _qDb.SaveChanges();
        }
        public void Update(int id, College college)
        {
            var collegeData = _qDb.Colleges.SingleOrDefault(x => x.Id == id);

            if (collegeData == null)
            {
                throw new InvalidIdException("Id not found in Colleges.");
            }
            collegeData = college;
            _qDb.SaveChanges();
        }
        public void Delete(int id)
        {
            var collegeData = _qDb.Colleges.SingleOrDefault(x => x.Id == id);

            if (collegeData == null)
            {
                throw new InvalidIdException("Id not found in Colleges.");
            }
            _qDb.Colleges.Remove(collegeData);
            _qDb.SaveChanges();
        }
    }
}
