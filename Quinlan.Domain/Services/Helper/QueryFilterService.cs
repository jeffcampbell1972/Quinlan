using Quinlan.Data.FilterOptions;
using Quinlan.Data.Services;
using Quinlan.Domain.Models;

namespace Quinlan.Domain.Services
{
    public static class QueryFilterService
    {
        public static CollectibleQueryFilterOptions BuildCollectibleFilterOptions(CardSearchFilterOptions cardFilterOptions)
        {
            var collectibleFilterOptions = new CollectibleQueryFilterOptions
            {
                CollectibleTypeId = CollectibleTypeCodeService.Card.Id,
                SportId = cardFilterOptions.SportId,
                LeagueId = cardFilterOptions.LeagueId,
                PersonId = cardFilterOptions.PersonId,
                TeamId = cardFilterOptions.TeamId,
                HOFFlag = cardFilterOptions.HOFFlag,
                RCFlag = cardFilterOptions.RCFlag,
                RelicFlag = cardFilterOptions.RelicFlag,
                AutographedFlag = cardFilterOptions.AutographedFlag ,
                NotableFlag = cardFilterOptions.NotableFlag,
                NotablePersonFlag = cardFilterOptions.NotablePersonFlag,
                CollegeId = cardFilterOptions.CollegeId,
                GradedFlag = cardFilterOptions.GradedFlag,
                HeismanFlag = cardFilterOptions.HeismanFlag,
                Year = cardFilterOptions.Year
            };

            return collectibleFilterOptions;
        }
        public static CollectibleQueryFilterOptions BuildCollectibleFilterOptions(FigurineSearchFilterOptions figurineFilterOptions)
        {
            var collectibleFilterOptions = new CollectibleQueryFilterOptions
            {
                CollectibleTypeId = CollectibleTypeCodeService.Figure.Id,
                SportId = figurineFilterOptions.SportId,
                LeagueId = figurineFilterOptions.LeagueId,
                PersonId = figurineFilterOptions.PersonId,
                TeamId = figurineFilterOptions.TeamId,
                HOFFlag = figurineFilterOptions.HOFFlag
            };

            return collectibleFilterOptions;
        }
        public static CollectibleQueryFilterOptions BuildCollectibleFilterOptions(MagazineSearchFilterOptions magazineFilterOptions)
        {
            var collectibleFilterOptions = new CollectibleQueryFilterOptions
            {
                CollectibleTypeId = CollectibleTypeCodeService.Magazine.Id,
                SportId = magazineFilterOptions.SportId,
                LeagueId = magazineFilterOptions.LeagueId,
                PersonId = magazineFilterOptions.PersonId,
                TeamId = magazineFilterOptions.TeamId,
                HOFFlag = magazineFilterOptions.HOFFlag
            };

            return collectibleFilterOptions;
        }
        public static TeamQueryFilterOptions BuildTeamFilterOptions(TeamSearchFilterOptions filterOptions)
        {
            var teamFilterOptions = new TeamQueryFilterOptions
            {
                LeagueId = filterOptions.LeagueId,
                NotableFlag = filterOptions.NotableFlag,
                SportId = filterOptions.SportId
            };

            return teamFilterOptions;
        }
        public static PersonQueryFilterOptions BuildPersonFilterOptions(PersonSearchFilterOptions filterOptions)
        {
            var personFilterOptions = new PersonQueryFilterOptions
            {
                TeamId = filterOptions.TeamId,
                LeagueId = filterOptions.LeagueId,
                NotableFlag = filterOptions.NotableFlag,
                HOFFlag = filterOptions.HOFFlag,
                HeismanFlag = filterOptions.HeismanFlag,
                SportId = filterOptions.SportId
            };

            return personFilterOptions;
        }
    }
}
