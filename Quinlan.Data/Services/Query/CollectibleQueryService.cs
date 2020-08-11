using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;

using Quinlan.Data.FilterOptions;
using Quinlan.Data.Models;

namespace Quinlan.Data.Services
{
    public class CollectibleQueryService : ICollectibleQueryService<CollectibleQueryFilterOptions>
    {
        QdbContext _qDb;
        public CollectibleQueryService(QdbContext qDb)
        {
            _qDb = qDb;
        }
        public List<Collectible> SelectCollectibles(CollectibleQueryFilterOptions filterOptions)
        {
            var collectibles = _qDb.Collectibles
                .Include(x => x.ImportCollectible)
                .Include(x => x.Grade)
                .Include(x => x.Grade.Grader)
                .Include(x => x.Grade.Grader.Organization)
                .Include(x => x.Person)
                .Include(x => x.Set)
                .Include(x => x.Team)
                .Include(x => x.CollectibleType)
                .Include(x => x.CardType)
                .Include(x => x.Container)
                .Where(x =>
                    (filterOptions.ProductId == null || x.ProductId == filterOptions.ProductId) &&
                    (filterOptions.SportId == null || x.SportId == filterOptions.SportId) &&
                    (filterOptions.LeagueId == null || x.LeagueId == filterOptions.LeagueId || x.Team.LeagueId == filterOptions.LeagueId) &&
                    (filterOptions.TeamId == null || x.TeamId == filterOptions.TeamId) &&
                    (filterOptions.PersonId == null || x.PersonId == filterOptions.PersonId) &&
                    (filterOptions.CollegeId == null || (x.Person != null && x.Person.CollegeId == filterOptions.CollegeId)) &&
                    (filterOptions.ContainerId == null || x.ContainerId == filterOptions.ContainerId) &&
                    (!filterOptions.HOFFlag || (x.Person != null && x.Person.HOFFlag == true)) &&
                    (!filterOptions.HeismanFlag || (x.Person != null && x.Person.HeismanFlag == true)) &&
                    (!filterOptions.NotablePersonFlag || (x.Person != null && x.Person.NotableFlag == true)) &&
                    (!filterOptions.NotableFlag || x.NotableFlag == true) &&
                    (!filterOptions.AutographedFlag || x.AUFlag == true) &&
                    (!filterOptions.RelicFlag || x.PatchFlag == true) &&
                    (!filterOptions.RCFlag || x.RCFlag == true) &&
                    (!filterOptions.GradedFlag || x.GradedFlag == true) &&
                    (!filterOptions.VintageFlag || x.Year < 1970) &&
                    (filterOptions.CollectibleTypeId == null || x.CollectibleTypeId == filterOptions.CollectibleTypeId) &&
                    (filterOptions.GraderId == null || (x.Grade != null && x.Grade.GraderId == filterOptions.GraderId)) &&
                    (filterOptions.GradeId == null || (x.Grade != null && x.Grade.Id == filterOptions.GradeId)) &&
                    (filterOptions.MinValue == null || (x.Value >= filterOptions.MinValue)) &&
                    (filterOptions.MaxValue == null || (x.Value <= filterOptions.MaxValue)) &&
                    (filterOptions.NoContainerFlag == null || filterOptions.NoContainerFlag == false || x.ContainerId == null)
                )
                .OrderBy(x => x.Year)
                .ThenBy(x => x.Set.Name)
                .ThenBy(x => x.CardNumber)
                .ToList();

            return collectibles;
        }
        public List<Person> SelectPeople(CollectibleQueryFilterOptions filterOptions)
        {
            var people = _qDb.Collectibles
                .Include(x => x.Person)
               .Where(x =>
                    x.Person != null &&
                    (filterOptions.SportId == null || x.SportId == filterOptions.SportId) &&
                    (filterOptions.LeagueId == null || x.LeagueId == filterOptions.LeagueId || x.Team.LeagueId == filterOptions.LeagueId) &&
                    (filterOptions.TeamId == null || x.TeamId == filterOptions.TeamId) &&
                    (filterOptions.PersonId == null || x.PersonId == filterOptions.PersonId) &&
                    (filterOptions.CollectibleTypeId == null || x.CollectibleTypeId == filterOptions.CollectibleTypeId)
                )
                .Select(x => x.Person)
                .Distinct()
                .ToList();

            return people;
        }
        public List<Team> SelectTeams(CollectibleQueryFilterOptions filterOptions)
        {
            var teams = _qDb.Collectibles
               .Include(x => x.Team)
               .Where(x =>
                    x.Team != null &&
                    (filterOptions.SportId == null || x.SportId == filterOptions.SportId) &&
                    (filterOptions.LeagueId == null || x.LeagueId == filterOptions.LeagueId || x.Team.LeagueId == filterOptions.LeagueId) &&
                    (filterOptions.TeamId == null || x.TeamId == filterOptions.TeamId) &&
                    (filterOptions.PersonId == null || x.PersonId == filterOptions.PersonId) &&
                    (filterOptions.CollectibleTypeId == null || x.CollectibleTypeId == filterOptions.CollectibleTypeId)
               )
               .Select(x => x.Team)
               .Distinct()
               .ToList();

            return teams;
        }
        public List<College> SelectColleges(CollectibleQueryFilterOptions filterOptions)
        {
            var colleges = _qDb.Collectibles
               .Include(x => x.Team)
               .Where(x =>
                    x.Person != null &&
                    x.Person.College != null &&
                    (filterOptions.SportId == null || x.SportId == filterOptions.SportId) &&
                    (filterOptions.LeagueId == null || x.LeagueId == filterOptions.LeagueId || x.Team.LeagueId == filterOptions.LeagueId) &&
                    (filterOptions.TeamId == null || x.TeamId == filterOptions.TeamId) &&
                    (filterOptions.PersonId == null || x.PersonId == filterOptions.PersonId) &&
                    (filterOptions.CollectibleTypeId == null || x.CollectibleTypeId == filterOptions.CollectibleTypeId)
               )
               .Select(x => x.Person.College)
               .Distinct()
               .ToList();

            return colleges;
        }
        public List<Grade> SelectGrades(CollectibleQueryFilterOptions filterOptions)
        {
            var colleges = _qDb.Collectibles
               .Include(x => x.Grade)
               .Where(x =>
                    x.Grade != null &&
                    (filterOptions.SportId == null || x.SportId == filterOptions.SportId) &&
                    (filterOptions.LeagueId == null || x.LeagueId == filterOptions.LeagueId || x.Team.LeagueId == filterOptions.LeagueId) &&
                    (filterOptions.TeamId == null || x.TeamId == filterOptions.TeamId) &&
                    (filterOptions.PersonId == null || x.PersonId == filterOptions.PersonId) &&
                    (filterOptions.CollectibleTypeId == null || x.CollectibleTypeId == filterOptions.CollectibleTypeId)
               )
               .Select(x => x.Grade)
               .Distinct()
               .ToList();

            return colleges;
        }
        public List<Grader> SelectGraders(CollectibleQueryFilterOptions filterOptions)
        {
            var colleges = _qDb.Collectibles
               .Include(x => x.Grade)
               .Include(x => x.Grade.Grader)
               .Include(x => x.Grade.Grader.Organization)
               .Where(x =>
                    x.Grade != null &&
                    x.Grade.Grader != null &&
                    (filterOptions.SportId == null || x.SportId == filterOptions.SportId) &&
                    (filterOptions.LeagueId == null || x.LeagueId == filterOptions.LeagueId || x.Team.LeagueId == filterOptions.LeagueId) &&
                    (filterOptions.TeamId == null || x.TeamId == filterOptions.TeamId) &&
                    (filterOptions.PersonId == null || x.PersonId == filterOptions.PersonId) &&
                    (filterOptions.CollectibleTypeId == null || x.CollectibleTypeId == filterOptions.CollectibleTypeId)
               )
               .Select(x => x.Grade.Grader)
               .Distinct()
               .ToList();

            return colleges;
        }
    }
}
