using Quinlan.Domain.Models;
using Quinlan.MVC.Models;

namespace Quinlan.MVC.Services
{
    public static class SearchFilterService
    {
        public static CardSearchFilterOptions BuildCardSearchFilterOptions(CardFilterOptionsViewModel cardFilterOptions)
        {
            if (cardFilterOptions == null)
            {
                return null;
            }

            var cardSearchFilterOptions = new CardSearchFilterOptions
            {
                SportId = GetNullableId(cardFilterOptions.SportId) ,
                LeagueId = GetNullableId(cardFilterOptions.LeagueId) ,
                PersonId = GetNullableId(cardFilterOptions.PersonId) ,
                TeamId = GetNullableId(cardFilterOptions.TeamId) ,
                CollegeId = GetNullableId(cardFilterOptions.CollegeId),
                HOFFlag = cardFilterOptions.HOFFlag,
                RCFlag = cardFilterOptions.RCFlag,
                AutographedFlag = cardFilterOptions.AUFlag ,
                RelicFlag = cardFilterOptions.RelicFlag,
                NotableFlag = cardFilterOptions.NotableFlag,
                NotablePersonFlag = cardFilterOptions.NotablePersonFlag,
                GradedFlag = cardFilterOptions.GradedFlag,
                HeismanFlag = cardFilterOptions.HeismanFlag,
                VintageFlag = cardFilterOptions.VintageFlag,
                Year = cardFilterOptions.Year ,
                GraderId = GetNullableId(cardFilterOptions.GraderId),
                GradeId = GetNullableId(cardFilterOptions.GradeId),
                ManufacturerId = GetNullableId(cardFilterOptions.ManufacturerId) , 
                MinValue = GetNullableValue(cardFilterOptions.MinValue) ,
                MaxValue = GetNullableValue(cardFilterOptions.MaxValue)
            };

            return cardSearchFilterOptions;
        }
        public static FigurineSearchFilterOptions BuildFigurineSearchFilterOptions(FigurineFilterOptionsViewModel figurineFilterOptions)
        {
            if (figurineFilterOptions == null)
            {
                return new FigurineSearchFilterOptions();
            }
            var figurineSearchFilterOptions = new FigurineSearchFilterOptions
            {
                SportId = figurineFilterOptions.SportId,
                LeagueId = figurineFilterOptions.LeagueId,
                PersonId = figurineFilterOptions.PersonId,
                TeamId = figurineFilterOptions.TeamId,
                HOFFlag = figurineFilterOptions.HOFFlag
            };

            return figurineSearchFilterOptions;
        }
        public static MagazineSearchFilterOptions BuildMagazineSearchFilterOptions(MagazineFilterOptionsViewModel magazineFilterOptions)
        {
            if (magazineFilterOptions == null)
            {
                return new MagazineSearchFilterOptions();
            }
            var magazineSearchFilterOptions = new MagazineSearchFilterOptions
            {
                SportId = magazineFilterOptions.SportId,
                LeagueId = magazineFilterOptions.LeagueId,
                PersonId = magazineFilterOptions.PersonId,
                TeamId = magazineFilterOptions.TeamId,
                HOFFlag = magazineFilterOptions.HOFFlag
            };

            return magazineSearchFilterOptions;
        }
        public static TeamSearchFilterOptions BuildTeamSearchFilterOptions(TeamFilterOptionsViewModel filterOptions)
        {
            if (filterOptions == null)
            {
                return new TeamSearchFilterOptions();
            }
            var teamSearchFilterOptions = new TeamSearchFilterOptions
            {
                LeagueId = filterOptions.LeagueId,
                NotableFlag = filterOptions.NotableFlag,
                SportId = filterOptions.SportId
            };

            return teamSearchFilterOptions;
        }
        public static PersonSearchFilterOptions BuildPersonSearchFilterOptions(PersonFilterOptionsViewModel filterOptions)
        {
            if (filterOptions == null)
            {
                return new PersonSearchFilterOptions();
            }
            var personSearchFilterOptions = new PersonSearchFilterOptions
            {
                TeamId = filterOptions.TeamId,
                LeagueId = filterOptions.LeagueId,
                NotableFlag = filterOptions.NotableFlag,
                HOFFlag = filterOptions.HOFFlag,
                HeismanFlag = filterOptions.HeismanFlag,
                SportId = filterOptions.SportId
            };

            return personSearchFilterOptions;
        }
        public static int? GetNullableId(int id)
        {
            int? nullableId = null;

            if (id > 0)
            {
                nullableId = id;
            }

            return nullableId;
        }
        public static decimal? GetNullableValue(decimal? val)
        {
            decimal? nullableValue = null;

            if (val > 0)
            {
                nullableValue = val;
            }

            return nullableValue;
        }
    }
}
