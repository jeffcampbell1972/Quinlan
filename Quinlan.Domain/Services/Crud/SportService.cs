using System.Collections.Generic;
using System.Linq;

using Quinlan.Data.Services;
using Quinlan.Domain.Models;

namespace Quinlan.Domain.Services
{
    public class SportService : ICrudService<Sport>
    {
        public SportService()
        {
        }

        public List<Sport> Get()
        {
            var sportsData = SportCodeService.Select();

            var sports = sportsData
                .Select(x => new Quinlan.Domain.Models.Sport 
                { 
                    Id = x.Id,
                    Identifier = x.Identifier,
                    Name = x.Name 
                })
                .ToList();

            return sports;
        }
        public Sport Get(int id)
        {
            try
            {
                var sportData = SportCodeService.Select(id);

                if (sportData == null)
                {
                    throw new DataNotFoundException("Sport not found.  Invalid id provided.");
                }

                var sport = new Sport
                {
                    Id = sportData.Id,
                    Identifier = sportData.Identifier,
                    Name = sportData.Name
                };

                return sport;
            }
            catch
            {
                throw new DataNotFoundException("Sport not found.  Invalid id provided.");
            }      
        }
        public void Post(Sport sport)
        {
            throw new PostNotSupportedException();
        }
        public void Put(int id, Sport sport)
        {
            throw new PutNotSupportedException();
        }
        public void Delete(int id)
        {
            throw new DeleteNotSupportedException();
        }
    }
}
