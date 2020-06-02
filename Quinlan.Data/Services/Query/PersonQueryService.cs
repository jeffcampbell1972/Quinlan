using System.Collections.Generic;
using System.Linq;

using Quinlan.Data.FilterOptions;
using Quinlan.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace Quinlan.Data.Services
{
    public class PersonQueryService : IQueryService<Person, PersonQueryFilterOptions>
    {
        QdbContext _qDb;
        public PersonQueryService(QdbContext qDb)
        {
            _qDb = qDb;
        }
        public List<Person> Execute(PersonQueryFilterOptions filterOptions)
        {
            var people = _qDb.People
                .Include(x => x.College)
                .Include(x => x.PersonSports)
                .Where(x =>
                    (filterOptions.SportId == null || x.PersonSports.Where(x => x.SportId == filterOptions.SportId).Count() > 0) &&
                    (!filterOptions.HOFFlag || (x.HOFFlag == true)) &&
                    (!filterOptions.HeismanFlag || (x.HeismanFlag == true)) &&
                    (!filterOptions.NotableFlag || (x.NotableFlag == true))
                )
                .OrderBy(x => x.LastName)
                .ThenBy(x => x.FirstName)
                .ToList();

            return people;
        }
    }
}
