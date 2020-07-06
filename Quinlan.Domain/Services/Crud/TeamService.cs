using System.Collections.Generic;
using System.Linq;

using Quinlan.Data.Services;
using Quinlan.Domain.Models;

namespace Quinlan.Domain.Services
{
    public class TeamService : ICrudService<Team>
    {
        IDataService<Quinlan.Data.Models.Team> _teamDataService;
        
        public TeamService(IDataService<Quinlan.Data.Models.Team> teamDataService)
        {
            _teamDataService = teamDataService;
        }

        public List<Team> Get()
        {
            var teamsData = _teamDataService.Select();

            var teams = teamsData
                .Select(x => new Team 
                { 
                    Id = x.Id, 
                    Identifier = x.Identifier ,
                    Name = string.Format("{0} {1}", x.City , x.Nickname) 
                })
                .ToList();

            return teams;
        }
        public Team Get(int id)
        {
            var teamData = _teamDataService.Select(id);

            if (teamData == null)
            {
                throw new DataNotFoundException("Team not found.  Invalid id provided.");
            }

            return new Team 
            { 
                Id = teamData.Id,
                Identifier = teamData.Identifier,
                Name = string.Format("{0} {1}", teamData.City, teamData.Nickname)  ,
                City = teamData.City,
                Nickname = teamData.Nickname,
                NotableFlag = teamData.NotableFlag ,
                League = teamData.League == null ? null : new League
                {
                    Id = teamData.League.Id,
                    Identifier = teamData.League.Identifier,
                    Name = teamData.League.Name
                } ,
                Sport = teamData.Sport == null ? null : new Sport
                {
                    Id = teamData.Sport.Id,
                    Identifier = teamData.Sport.Identifier,
                    Name = teamData.Sport.Name
                } ,
                College = teamData.College == null ? null : new College
                {
                    Id = teamData.College.Id ,
                    Identifier = teamData.College.Identifier ,
                    Name = teamData.College.Name ,
                    Nickname = teamData.College.Nickname
                }
            };
        }
        public void Post(Team team)
        {
            var teamData = new Quinlan.Data.Models.Team
            {
                Identifier = team.City + team.Nickname , // may need to revisit
                City = team.City,
                Nickname = team.Nickname ,
                NotableFlag = team.NotableFlag 
            };

            _teamDataService.Insert(teamData);
        }
        public void Put(int id, Team team)
        {
            var teamData = _teamDataService.Select(id);

            teamData.City = team.City;
            teamData.Nickname = team.Nickname;
            teamData.NotableFlag = team.NotableFlag;
            if (team.Sport != null)
            {
                teamData.SportId = team.Sport.Id;
            }
            if (team.League != null)
            {
                teamData.LeagueId = team.League.Id;
            }
            if (team.College != null)
            {
                teamData.CollegeId = team.College.Id;
            }

            _teamDataService.Update(id, teamData);
        }
        public void Delete(int id)
        {
            throw new DeleteNotSupportedException();
        }
    }
}
