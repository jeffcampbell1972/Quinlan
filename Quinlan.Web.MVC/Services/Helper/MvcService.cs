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
        public static List<SelectListItem> BuildGradersSelectList(List<Grader> graders, int graderId, string allMessage = "N/A")
        {
            var gradersList = graders.Select(x => new SelectListItem
            {
                Value = x.Id.ToString(),
                Text = x.Name,
                Selected = x.Id == graderId
            })
            .ToList();

            gradersList.Insert(0, new SelectListItem
            {
                Value = "0",
                Text = string.Format("[{0}]", allMessage),
                Selected = graderId == 0
            });

            return gradersList;
        }
        public static List<SelectListItem> BuildGradesSelectList(List<Grade> grades, int gradeId, string allMessage = "N/A")
        {
            var gradesList = grades.Select(x => new SelectListItem
            {
                Value = x.Id.ToString(),
                Text = x.Name,
                Selected = x.Id == gradeId
            })
            .ToList();

            gradesList.Insert(0, new SelectListItem
            {
                Value = "0",
                Text = string.Format("[{0}]", allMessage),
                Selected = gradeId == 0
            });

            return gradesList;
        }
        public static List<SelectListItem> BuildValuesSelectList(decimal cardValue, string allMessage = "N/A")
        {
            var cardValuesList = new List<SelectListItem>
            {
                new SelectListItem { Value = "0",    Text=string.Format("[{0}]", allMessage),   Selected = cardValue == 0 } ,
                new SelectListItem { Value = "25",   Text="$25",   Selected = cardValue == 25 } ,
                new SelectListItem { Value = "50",   Text="$50",   Selected = cardValue == 50 } ,
                new SelectListItem { Value = "100",  Text="$100",  Selected = cardValue == 100 } ,
                new SelectListItem { Value = "200",  Text="$200",  Selected = cardValue == 200 } ,
                new SelectListItem { Value = "500",  Text="$500",  Selected = cardValue == 500 } ,
                new SelectListItem { Value = "1000", Text="$1000", Selected = cardValue == 1000 } 
            };

            return cardValuesList;
        }
    }
}
