using System.Linq;

using Quinlan.MVC.Models;
using Quinlan.Domain.Models;
using Quinlan.Domain.Services;
using System;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Quinlan.MVC.Services
{
    public class TeamEditService : IEditService<TeamEdit>
    {
        ICrudService<Team> _teamService;
        ICrudService<Sport> _sportService;
        ICrudService<League> _leagueService;
        ICrudService<College> _collegeService;
        public TeamEditService(ICrudService<Team> teamService, ICrudService<Sport> sportService, ICrudService<League> leagueService, ICrudService<College> collegeService)
        {
            _teamService = teamService;
            _sportService = sportService;
            _leagueService = leagueService;
            _collegeService = collegeService;
        }
        public TeamEdit Build (int id)
        {
            var team = _teamService.Get(id);

            var sports = MvcService.BuildSportsSelectList(_sportService.Get(), team.Sport != null ? team.Sport.Id : 0);
            var leagues = MvcService.BuildLeaguesSelectList(_leagueService.Get(), team.League != null ? team.League.Id : 0);
            var colleges = MvcService.BuildCollegesSelectList(_collegeService.Get(), team.College != null ? team.College.Id : 0);

            var vm = new TeamEdit
            {
                DisplayName = team.ToString() ,
                Sports = sports ,
                Leagues = leagues ,
                Colleges = colleges , 
                TeamVM = new TeamViewModel
                {
                    Id = team.Id ,
                    Identifier = team.Identifier ,
                    City = team.City ,
                    Nickname = team.Nickname ,
                    NotableFlag = team.NotableFlag ,
                    CollegeId = team.College == null ? 0 : team.College.Id ,
                    SportId = team.Sport == null ? 0 : team.Sport.Id ,
                    LeagueId = team.League == null ? 0 : team.League.Id
                }
            };

            return vm;
        }
    }
}
