using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Quinlan.Data.Models;

namespace Quinlan.Data.Services
{
    public class PersonDataService : IDataService<Person>
    {
        QdbContext _qDb;
        public PersonDataService(QdbContext qDb)
        {
            _qDb = qDb;
        }
        public List<Person> Select()
        {
            var peopleData = _qDb.People
               .ToList();

            return peopleData;
        }
        public Person Select(int id)
        {
            var personData = _qDb.People
                .Include(x => x.College)
                .Include(x => x.PersonSports)
                .SingleOrDefault(x => x.Id == id);

            if (personData == null)
            {
                throw new InvalidIdException("Id not found in People.");
            }

            return personData;
        }
        public void Insert(Person person)
        {
            _qDb.People.Add(person);
            _qDb.SaveChanges();
        }
        public void Update(int id, Person t)
        {
            var personData = _qDb.People.SingleOrDefault(x => x.Id == id);

            if (personData == null)
            {
                throw new InvalidIdException("Id not found in People.");
            }
            personData = t;
            _qDb.SaveChanges();
        }
        public void Delete(int id)
        {
            var personData = _qDb.People.SingleOrDefault(x => x.Id == id);

            if (personData == null)
            {
                throw new InvalidIdException("Id not found in People.");
            }
            _qDb.People.Remove(personData);
            _qDb.SaveChanges();
        }
    }
}
