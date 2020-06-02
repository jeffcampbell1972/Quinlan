using System.Collections.Generic;
using System.Linq;

using Quinlan.Data;
using Quinlan.Data.Models;

namespace Quinlan.Data.Services
{
    public static class LeagueCodeService
    {
        private static List<League> values;
        public static List<League> Select()
        {
            if (values == null)
            {
                PopulateList();
            }
            return values;
        }
        public static League Select(int id)
        {
            if (values == null)
            {
                PopulateList();
            };

            var league = values.SingleOrDefault(x => x.Id == id);

            if (league == null)
            {
                throw new InvalidIdException("Id not found in Leagues collection.");
            }

            return league;
        }
        public static League Select(string identifier)
        {
            if (values == null)
            {
                PopulateList();
            }
            return values.Single(x => x.Identifier == identifier);
        }
        private static void PopulateList()
        {
            values = new List<League>() {
                    MLB ,
                    NBA ,
                    NCAAB ,
                    NCAAF ,
                    NFL ,
                    NHL ,
                    CFL ,
                    ABA ,
                    PGA ,
                    NLB ,
                    AFL ,
                    USFL
                };
        }
        
        static private League mlb;
        static private League nba;
        static private League ncaab;
        static private League ncaaf;
        static private League nfl;
        static private League nhl;
        static private League cfl;
        static private League aba;
        static private League pga;
        static private League nlb;
        static private League afl;
        static private League usfl;

        static public League MLB { get { return mlb ?? (mlb = new League { Id = 1, Identifier = "MLB", Name = "MLB", SportId = SportCodeService.Baseball.Id, SearchDefault = true, SortOrder = 1 }); } }
        static public League NBA { get { return nba ?? (nba = new League { Id = 2, Identifier = "NBA", Name = "NBA", SportId = SportCodeService.Basketball.Id, SearchDefault = true, SortOrder = 1 }); } }
        static public League NCAAB { get { return ncaab ?? (ncaab = new League { Id = 3, Identifier = "NCAAB", Name = "NCAAB", SportId = SportCodeService.Basketball.Id, SearchDefault = false, SortOrder = 3 }); } }
        static public League NCAAF { get { return ncaaf ?? (ncaaf = new League { Id = 4, Identifier = "NCAAF", Name = "NCAAF", SportId = SportCodeService.Football.Id, SearchDefault = false, SortOrder = 3 }); } }
        static public League NFL { get { return nfl ?? (nfl = new League { Id = 5, Identifier = "NFL", Name = "NFL", SportId = SportCodeService.Football.Id, SearchDefault = true, SortOrder = 1 }); } }
        static public League NHL { get { return nhl ?? (nhl = new League { Id = 6, Identifier = "NHL", Name = "NHL", SportId = SportCodeService.Hockey.Id, SearchDefault = true, SortOrder = 1 }); } }
        static public League CFL { get { return cfl ?? (cfl = new League { Id = 7, Identifier = "CFL", Name = "CFL", SportId = SportCodeService.Football.Id, SearchDefault = false, SortOrder = 2 }); } }
        static public League ABA { get { return aba ?? (aba = new League { Id = 8, Identifier = "ABA", Name = "ABA", SportId = SportCodeService.Basketball.Id, SearchDefault = false, SortOrder = 2 }); } }
        static public League PGA { get { return pga ?? (pga = new League { Id = 9, Identifier = "PGA", Name = "PGA", SportId = SportCodeService.Golf.Id, SearchDefault = true, SortOrder = 1 }); } }
        static public League NLB { get { return nlb ?? (nlb = new League { Id = 10, Identifier = "NLB", Name = "NLB", SportId = SportCodeService.Baseball.Id, SearchDefault = false, SortOrder = 1 }); } }
        static public League AFL { get { return afl ?? (afl = new League { Id = 11, Identifier = "AFL", Name = "AFL", SportId = SportCodeService.Football.Id, SearchDefault = false, SortOrder = 2 }); } }
        static public League USFL { get { return usfl ?? (usfl = new League { Id = 12, Identifier = "USFL", Name = "USFL", SportId = SportCodeService.Football.Id, SearchDefault = false, SortOrder = 3 }); } }
    }
}
