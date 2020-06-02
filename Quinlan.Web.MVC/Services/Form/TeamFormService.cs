using System.Linq;

using Quinlan.MVC.Models;
using Quinlan.Domain.Models;
using Quinlan.Domain.Services;
using System;

namespace Quinlan.MVC.Services
{
    public class TeamFormService : IFormService<TeamViewModel>
    {
        ICrudService<Team> _teamService;
        public TeamFormService(ICrudService<Team> teamService)
        {
            _teamService = teamService;
        }
        public void Save(TeamViewModel teamVM)
        {
            if (teamVM == null)
            {
                throw new Exception();
            }

            var team = new Team
            {
                Identifier = teamVM.Identifier ,
                City = teamVM.City ,
                Nickname = teamVM.Nickname 
            };

            _teamService.Post(team);
        }
        public void Save(int id, TeamViewModel teamVM)
        {
            if (teamVM == null)
            {
                throw new Exception();
            }

            var team = new Team
            {
                Identifier = teamVM.Identifier,
                City = teamVM.City,
                Nickname = teamVM.Nickname ,
                NotableFlag = teamVM.NotableFlag ,
                Sport = teamVM.SportId == 0 ? null : new Sport {  Id = (int) teamVM.SportId } ,
                League = teamVM.LeagueId == 0 ? null : new League { Id = (int)teamVM.LeagueId } ,
                College = teamVM.CollegeId == 0 ? null : new College { Id = (int)teamVM.CollegeId }
            };

            _teamService.Put(id, team);
        }
    }
}
