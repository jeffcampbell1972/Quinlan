using System.Collections.Generic;
using System.Linq;
using Quinlan.Data.Models;

namespace Quinlan.Data.Services
{
    public static class CardTypeCodeService
    {
        public static List<CardType> Select()
        {
            if (values == null)
            {
                values = new List<CardType>() {
                    Player ,
                    Coach ,
                    Manager ,
                    Team ,
                    TeamLeader ,
                    TeamChecklist ,
                    Checklist ,
                    LeagueLeader ,
                    RecordBreaker ,
                    AllStar ,
                    AllPro ,
                    ProBowl ,
                    SuperBowl ,
                    Championship ,
                    Playoffs ,
                    HOF ,
                    MVP ,
                    Award ,
                    Puzzle ,
                    Other
                };
            }
            return values;
        }
        public static CardType Select(int id)
        {
            if (values == null)
            { 
                values = new List<CardType>() {
                    Player ,
                    Coach ,
                    Manager ,
                    Team ,
                    TeamLeader ,
                    TeamChecklist ,
                    Checklist ,
                    LeagueLeader ,
                    RecordBreaker ,
                    AllStar ,
                    AllPro ,
                    ProBowl ,
                    SuperBowl ,
                    Championship ,
                    Playoffs ,
                    HOF ,
                    MVP ,
                    Award ,
                    Puzzle ,
                    Other
                    };
            }
            return values.Single(x => x.Id == id);
        }

        private static List<CardType> values;

        static private CardType player;
        static private CardType coach;
        static private CardType manager;
        static private CardType team;
        static private CardType teamLeader;
        static private CardType teamChecklist;
        static private CardType checklist;
        static private CardType leagueLeader;
        static private CardType recordBreaker;
        static private CardType allStar;
        static private CardType allPro;
        static private CardType proBowl;
        static private CardType superBowl;
        static private CardType championship;
        static private CardType playoffs;
        static private CardType hof;
        static private CardType mvp;
        static private CardType award;
        static private CardType puzzle;
        static private CardType other;

        static public CardType Player { get { return player ?? (player = new CardType { Id = 1, Identifier = "Player", Name = "Player" }); } }
        static public CardType Coach { get { return coach ?? (coach = new CardType { Id = 2, Identifier = "Coach", Name = "Coach" }); } }
        static public CardType Manager { get { return manager ?? (manager = new CardType { Id = 3, Identifier = "Manager", Name = "Manager" }); } }
        static public CardType Team { get { return team ?? (team = new CardType { Id = 4, Identifier = "Team", Name = "Team" }); } }
        static public CardType TeamLeader { get { return teamLeader ?? (teamLeader = new CardType { Id = 5, Identifier = "TeamLeader", Name = "Team Leader" }); } }
        static public CardType TeamChecklist { get { return teamChecklist ?? (teamChecklist = new CardType { Id = 6, Identifier = "TeamChecklist", Name = "Team Checklist" }); } }
        static public CardType Checklist { get { return checklist ?? (checklist = new CardType { Id = 7, Identifier = "Checklist", Name = "Checklist" }); } }
        static public CardType LeagueLeader { get { return leagueLeader ?? (leagueLeader = new CardType { Id = 8, Identifier = "LeagueLeader", Name = "League Leader" }); } }
        static public CardType RecordBreaker { get { return recordBreaker ?? (recordBreaker = new CardType { Id = 9, Identifier = "RecordBreaker", Name = "Record Breaker" }); } }
        static public CardType AllStar { get { return allStar ?? (allStar = new CardType { Id = 10, Identifier = "AllStar", Name = "All-Star" }); } }
        static public CardType AllPro { get { return allPro ?? (allPro = new CardType { Id = 11, Identifier = "AllPro", Name = "All-Pro" }); } }
        static public CardType ProBowl { get { return proBowl ?? (proBowl = new CardType { Id = 12, Identifier = "ProBowl", Name = "Pro Bowl" }); } }
        static public CardType SuperBowl { get { return superBowl ?? (superBowl = new CardType { Id = 13, Identifier = "SuperBowl", Name = "Super Bowl" }); } }
        static public CardType Championship { get { return championship ?? (championship = new CardType { Id = 14, Identifier = "Championship", Name = "Championship" }); } }
        static public CardType Playoffs { get { return playoffs ?? (playoffs = new CardType { Id = 15, Identifier = "Playoffs", Name = "Playoffs" }); } }
        static public CardType HOF { get { return hof ?? (hof = new CardType { Id = 16, Identifier = "HOF", Name = "Hall of Fame" }); } }
        static public CardType MVP { get { return mvp ?? (mvp = new CardType { Id = 17, Identifier = "MVP", Name = "MVP" }); } }
        static public CardType Award { get { return award ?? (award = new CardType { Id = 18, Identifier = "Award", Name = "Award" }); } }
        static public CardType Puzzle { get { return puzzle ?? (puzzle = new CardType { Id = 19, Identifier = "Puzzle", Name = "Puzzle" }); } }
        static public CardType Other { get { return other ?? (other = new CardType { Id = 20, Identifier = "Other", Name = "Other" }); } }
    }
}
