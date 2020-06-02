using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;

using Quinlan.Data;
using Quinlan.Data.Models;
using Quinlan.Data.Services;

namespace Quinlan.Initialize.Services
{
    public static class SeedService
    {
        public static void SeedCodeValues(DbContextOptions<QdbContext> options)
        {
            using (var context = new QdbContext(options))
            {
                if (context.CollectibleStatuses.Count() > 0)
                {
                    return;
                }

                foreach (var cardType in CardTypeCodeService.Select())
                {
                    context.CardTypes.Add(cardType);
                }
                foreach (var collectibleStatus in CollectibleStatusCodeService.Select())
                {
                    context.CollectibleStatuses.Add(collectibleStatus);
                }
                foreach (var collectibleType in CollectibleTypeCodeService.Select())
                {
                    context.CollectibleTypes.Add(collectibleType);
                }
                foreach (var league in LeagueCodeService.Select())
                {
                    context.Leagues.Add(league);
                }
                foreach (var productStatus in ProductStatusCodeService.Select())
                {
                    context.ProductStatuses.Add(productStatus);
                }
                foreach (var sport in SportCodeService.Select())
                {
                    context.Sports.Add(sport);
                }

                context.SaveChanges();
            }
        }
        public static int SeedPerson(DbContextOptions<QdbContext> options, string lastName, string firstName, string middleName, string suffix, string sportIdentifier, bool hofFlag, bool heismanFlag, bool notableFlag, string collegeName, string collegeNickname)
        {
            using (var context = new QdbContext(options))
            {
                var sport = context.Sports.SingleOrDefault(x => x.Identifier == sportIdentifier);
                if (sport == null)
                {
                    throw new Exception("Invalid sport identifier");
                }

                string collegeIdentifier = string.Format("", collegeName, collegeNickname);
                string personIdentifier = string.Format("{0}{1}", lastName, firstName);

                var person = context.People.SingleOrDefault(x => x.Identifier == personIdentifier);
                if (person == null)
                {
                    throw new Exception("Person already exists");
                }

                var college = context.Colleges.SingleOrDefault(x => x.Identifier == collegeIdentifier);
                if (college == null)
                {
                    college = AddCollege(context, collegeIdentifier, collegeName, collegeNickname);
                }
                person = AddPerson(context, personIdentifier, lastName, firstName, middleName, suffix, hofFlag, heismanFlag, notableFlag, sport, college);

                return person.Id;
            }        
        }
        public static int SeedTeam(DbContextOptions<QdbContext> options, string identifier, string city, string nickname, string leagueIdentifier, bool notableFlag)
        {
            using (var context = new QdbContext(options))
            {
                var league = LeagueCodeService.Select(leagueIdentifier);

                var team = context.Teams.SingleOrDefault(x => x.Identifier == identifier);
                if (team != null)
                {
                    throw new Exception("Team already exists");
                }

                team = AddTeam(context, identifier, city, nickname, league, notableFlag);

                return team.Id;
            }
        }
        public static int SeedCard(DbContextOptions<QdbContext> options, string leagueIdentifier, int cardNumber, string playerLastName, string playerFirstName, string teamCity, string teamName, int year, string setName, bool auFlag, bool rcFlag, bool notableFlag, bool gradedFlag, decimal value, decimal cost)
        {
            using (var context = new QdbContext(options))
            {
                var league = LeagueCodeService.Select(leagueIdentifier);

                string personIdentifier = string.Format("{0} {1}", playerLastName, playerFirstName);
                string teamIdentifier = string.Format("{0} {1}", teamCity, teamName);

                var person = context.People.SingleOrDefault(x => x.Identifier == personIdentifier);
                if (person == null)
                {
                    person = AddPerson(context, personIdentifier, playerLastName, playerFirstName, null, null, false, false, false, league.Sport, null);
                }
                
                var team = context.Teams.SingleOrDefault(x => x.Identifier == teamIdentifier);
                if (team == null)
                {
                    team = AddTeam(context, teamIdentifier, teamCity, teamName, league, false);
                }
                
                var company = context.Sets.SingleOrDefault(x => x.Name == setName);
                if (company == null)
                {
                    company = AddSet(context, setName);
                }

                var card = AddCollectible(context, league, person, team, company, cardNumber, year, notableFlag, auFlag, rcFlag, gradedFlag, value, cost);

                return card.Id;
            }
        }
        public static int SeedCollege(DbContextOptions<QdbContext> options, string identifier, string name, string nickname)
        {
            using (var context = new QdbContext(options))
            {
                var college = context.Colleges.SingleOrDefault(x => x.Identifier == identifier);

                if (college == null)
                {
                    college = AddCollege(context, identifier, name, nickname);
                }

                return college.Id;
            }
        }
        public static int SeedProduct(DbContextOptions<QdbContext> options, string productIdentifier)
        {
            using (var context = new QdbContext(options))
            {
                var product = context.Products.SingleOrDefault(x => x.Identifier == productIdentifier);

                if (product == null)
                {
                    throw new Exception("Product already exists");
                }

                product = AddProduct(context, productIdentifier, ProductStatusCodeService.ForSale.Id);

                return product.Id;
            }
        }
        
        private static Product AddProduct(QdbContext context, string identifier, int productStatusId)
        {
            var product = new Product
            {
                Identifier = identifier,
                ProductStatusId = productStatusId
            };

            context.Products.Add(product);
            context.SaveChanges();

            return product;
        }
        private static Person AddPerson (QdbContext context, string identifier, string lastName, string firstName, string middleName, string suffix, bool hofFlag, bool heismanFlag, bool notableFlag, Sport sport, College college)
        {
            var person = new Person
            {
                Identifier = identifier ,
                LastName = lastName,
                FirstName = firstName,
                MiddleName = middleName,
                Suffix = suffix,
                HOFFlag = hofFlag,
                HeismanFlag = heismanFlag,
                NotableFlag = notableFlag,
                College = college
            };
            var personSport = new PersonSport
            {
                Person = person,
                Sport = sport
            };

            context.People.Add(person);
            context.PersonSports.Add(personSport);
            context.SaveChanges();

            return person;
        }
        private static Team AddTeam(QdbContext context, string identifier, string city, string nickname, League league, bool notableFlag)
        {
            var team = new Team
            {
                Identifier = identifier,
                City = city,
                Nickname = nickname,
                SportId = league.SportId,
                LeagueId = league.Id,
                NotableFlag = notableFlag
            };

            context.Teams.Add(team);
            context.SaveChanges();

            return team;
        }
        private static College AddCollege(QdbContext context, string identifier, string name, string nickname)
        {
            var college = new College
            {
                Identifier = identifier,
                Name = name,
                Nickname = nickname
            };

            context.Colleges.Add(college);
            context.SaveChanges();

            return college;
        }
        private static Set AddSet(QdbContext context, string name)
        {
            var set = new Set
            {
                Name = name
            };

            context.Sets.Add(set);
            context.SaveChanges();

            return set;
        }
        private static Collectible AddCollectible(QdbContext context, League league, Person person, Team team, Set set, int? cardNumber, int year, bool notableFlag, bool auFlag, bool rcFlag, bool gradedFlag, decimal value, decimal cost)
        {
            var collectible = new Collectible
            {
                CollectibleTypeId = CollectibleTypeCodeService.Card.Id,
                CollectibleStatusId = CollectibleStatusCodeService.Available.Id,
                SportId = league.SportId,
                LeagueId = league.Id,
                CardNumber = cardNumber,
                Person = person,
                Team = team,
                Set = set,
                Year = year,
                AUFlag = auFlag,
                RCFlag = rcFlag,
                NotableFlag = notableFlag,
                Value = value,
                Cost = cost,
                GradedFlag = gradedFlag
            };

            context.Collectibles.Add(collectible);
            context.SaveChanges();

            return collectible;
        }
    }
}
