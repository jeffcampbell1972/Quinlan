using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Quinlan.Data.Models;

namespace Quinlan.Data.Services
{
    public class TeamDataService : IDataService<Team>
    {
        QdbContext _qDb;
        public TeamDataService(QdbContext qDb)
        {
            _qDb = qDb;
        }

        public List<Team> Select()
        {
            var teamsData = _qDb.Teams
               .ToList();

            return teamsData;
        }
        public Team Select(int id)
        {
            var teamData = _qDb.Teams
                .Include(x => x.League)
                .Include(x => x.Sport)
                .Include(x => x.College)
                .SingleOrDefault(x => x.Id == id);

            if (teamData == null)
            {
                throw new InvalidIdException("Id not found in Teams.");
            }

            return teamData;
        }
        public void Insert(Team team)
        {
            _qDb.Teams.Add(team);
            _qDb.SaveChanges();
        }
        public void Update(int id, Team team)
        {
            var teamData = _qDb.Teams.SingleOrDefault(x => x.Id == id);

            if (teamData == null)
            {
                throw new InvalidIdException("Id not found in Teams.");
            }
            teamData = team;
            _qDb.SaveChanges();
        }
        public void Delete(int id)
        {
            var teamData = _qDb.Teams.SingleOrDefault(x => x.Id == id);

            if (teamData == null)
            {
                throw new InvalidIdException("Id not found in Teams.");
            }
            else if (teamData.ImportTeam != null)
            {
                throw new InvalidDeleteException("Cannot delete imported team");
            }
            _qDb.Teams.Remove(teamData);
            _qDb.SaveChanges();
        }
    }
}
