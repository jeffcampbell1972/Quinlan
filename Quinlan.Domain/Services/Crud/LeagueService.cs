using System.Collections.Generic;
using System.Linq;

using Quinlan.Data.Services;
using Quinlan.Domain.Models;

namespace Quinlan.Domain.Services
{
    public class LeagueService : ICrudService<League>
    {
        public LeagueService()
        {
        }

        public List<League> Get()
        {
            var leaguesData = LeagueCodeService.Select();

            var leagues = leaguesData
                .Select(x => new League 
                { 
                    Id = x.Id, 
                    Name = x.Name ,
                    SportId = x.SportId ,
                    SearchDefault = x.SearchDefault
                })
                .ToList();

            return leagues;
        }
        public League Get(int id)
        {
            var leagueData = LeagueCodeService.Select(id);

            if (leagueData == null)
            {
                throw new ItemNotFoundException("League not found.  Invalid id provided.");
            }

            return new League 
            { 
                Id = leagueData.Id, 
                Name = leagueData.Name ,
                SportId = leagueData.SportId,
                SearchDefault = leagueData.SearchDefault
            };
        }
        public void Post(League league)
        {
            throw new PostNotSupportedException();
        }
        public void Put(int id, League league)
        {
            throw new PutNotSupportedException();
        }
        public void Delete(int id)
        {
            throw new DeleteNotSupportedException();
        }
    }
}
