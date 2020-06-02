using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc.Rendering;

using Quinlan.Domain.Models;

namespace Quinlan.MVC.Services
{
    public static class MvcService
    {
        public static List<SelectListItem> BuildTeamsSelectList(List<Team> teams, int teamId, string allMessage = "All Teams")
        {
            var teamsList = teams.Select(x => new SelectListItem
            {
                Value = x.Id.ToString(),
                Text = x.Name,
                Selected = x.Id == teamId
            })
            .ToList();

            teamsList.Insert(0, new SelectListItem
            {
                Value = "0",
                Text = string.Format("[{0}]", allMessage) ,
                Selected = teamId == 0
            });

            return teamsList;
        }
        public static List<SelectListItem> BuildPeopleSelectList(List<Person> people, int personId, string allMessage = "All People")
        {
            var peopleSelectList = people
                .Select(x => new SelectListItem
                {
                    Value = x.Id.ToString(),
                    Text = x.Name,
                    Selected = x.Id == personId
                })
                .ToList();

            peopleSelectList.Insert(0, new SelectListItem
            {
                Value = "0",
                Text = string.Format("[{0}]", allMessage),
                Selected = personId == 0
            });

            return peopleSelectList;
        }
        public static List<SelectListItem> BuildCollegesSelectList(List<College> colleges, int collegeId, string allMessage = "All Colleges")
        {
            var collegeSelectList = colleges
                .Select(x => new SelectListItem
                {
                    Value = x.Id.ToString(),
                    Text = x.Name,
                    Selected = x.Id == collegeId
                })
                .ToList();

            collegeSelectList.Insert(0, new SelectListItem
            {
                Value = "0",
                Text = string.Format("[{0}]", allMessage),
                Selected = collegeId == 0
            });

            return collegeSelectList;
        }
        public static List<SelectListItem> BuildSportsSelectList(List<Sport> sports, int sportId, string allMessage = "All Sports")
        {
            var sportsList = sports.Select(x => new SelectListItem
            {
                Value = x.Id.ToString(),
                Text = x.Name,
                Selected = x.Id == sportId
            })
            .ToList();

            if (allMessage != "")
            {
                sportsList.Insert(0, new SelectListItem
                {
                    Value = "0",
                    Text = string.Format("[{0}]", allMessage),
                    Selected = sportId == 0
                });
            }

            return sportsList;
        }
        public static List<SelectListItem> BuildLeaguesSelectList(List<League> leagues, int leagueId, string allMessage = "All Leagues")
        {
            var leaguesList = leagues.Select(x => new SelectListItem
            {
                Value = x.Id.ToString(),
                Text = x.Name,
                Selected = x.Id == leagueId
            })
            .ToList();

            leaguesList.Insert(0, new SelectListItem
            {
                Value = "0",
                Text = string.Format("[{0}]", allMessage),
                Selected = leagueId == 0
            });

            return leaguesList;
        }
    }
}
