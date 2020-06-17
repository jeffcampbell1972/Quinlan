using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using Microsoft.EntityFrameworkCore;
using Quinlan.Data.Models;

namespace Quinlan.Data.Services
{
    public class GraderDataService : IDataService<Grader>
    {
        QdbContext _qDb;
        public GraderDataService(QdbContext qDb)
        {
            _qDb = qDb;
        }

        public List<Grader> Select()
        {
            var gradersData = _qDb.Graders
                .Include(x => x.Organization)
               .ToList();

            return gradersData;
        }
        public Grader Select(int id)
        {
            var graderData = _qDb.Graders.SingleOrDefault(x => x.Id == id);

            if (graderData == null)
            {
                throw new InvalidIdException("Id not found in Graders.");
            }

            return graderData;
        }
        public void Insert(Grader grader)
        {
            _qDb.Graders.Add(grader);
            _qDb.SaveChanges();
        }
        public void Update(int id, Grader grader)
        {
            var graderData = _qDb.Graders
                .Include(x => x.Organization)
                .SingleOrDefault(x => x.Id == id);

            if (graderData == null)
            {
                throw new InvalidIdException("Id not found in Graders.");
            }
            graderData = grader;
            _qDb.SaveChanges();
        }
        public void Delete(int id)
        {
            var graderData = _qDb.Graders.SingleOrDefault(x => x.Id == id);

            if (graderData == null)
            {
                throw new InvalidIdException("Id not found in Graders.");
            }

            _qDb.Graders.Remove(graderData);
            _qDb.SaveChanges();
        }
    }
}
