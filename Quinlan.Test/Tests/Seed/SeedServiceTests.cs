using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Xunit;

using Quinlan.Initialize.Services;
using Quinlan.Data;
using Quinlan.Data.Services;

using System.Linq;

namespace Quinlan.Initialize.Test
{
    public class SeedServiceTests
    {
        private QdbContext GetQdbContext(string dbName)
        {
            var qdbContext = new QdbContext(new DbContextOptionsBuilder<QdbContext>()
               .UseInMemoryDatabase(databaseName: dbName)
               .Options);

            return qdbContext;
        }
        private static DbContextOptions<QdbContext> GetContextOptions(string dbName)
        {
            var options = new DbContextOptionsBuilder<QdbContext>()
               .UseInMemoryDatabase(databaseName: dbName)
               .Options;

            return options;
        }

        [Theory]
        [InlineData("NFL", 1, "Joe", "Montana", "San Francisco", "49ers", 1981, "Topps", false, true, true, false, 100, 80)]
        [InlineData("NFL", 1, "Joe", "Montana", "San Francisco", "49ers", 1982, "Topps", false, false, true, false, 50, 40)]
        public void SeedCard_Succeeds(
            string leagueName,
            int cardNumber,
            string personLastName,
            string personFirstName,
            string teamCity,
            string teamNickname,
            int year,
            string companyName,
            bool auFlag,
            bool rcFlag,
            bool notableFlag,
            bool gradedFlag,
            decimal value,
            decimal cost
            )
        {
            // Note that since this is a Theory method, it will be called multiple times.  
            // And since the db name is the same for each, all of the tests will be handled within the same database.
            // It's unclear to me whether this is a good or bad this with regard to testing.  
            // Appending a timestamp will insure a clean db for each test.
            string dbName = "SeedCard_Succeeds";

            var options = GetContextOptions(dbName);

            // Add Code Values and test the service method
            SeedService.SeedCodeValues(options);

            int cardId = SeedService.SeedCard(options, leagueName, cardNumber, personLastName, personFirstName, teamCity, teamNickname, year, companyName, auFlag, rcFlag, notableFlag, gradedFlag, value, cost);

            // Create a new db context to use for verification - I don't know how to get a separate instance from the DI framework...
            using (var qdbContext = GetQdbContext(dbName))
            {

                // Retrieve data directly from entity framework context
                var collectible = qdbContext.Collectibles
                    .Include(x => x.CollectibleStatus)
                    .Include(x => x.CollectibleType)
                    .Include(x => x.League)
                    .Include(x => x.Person)
                    .Include(x => x.Team)
                    .Include(x => x.Set)
                    .SingleOrDefault(x => x.Id == cardId);

                // Verify results contain all expected relationships
                Assert.NotNull(collectible);
                Assert.NotNull(collectible.CollectibleStatus);
                Assert.NotNull(collectible.CollectibleType);
                Assert.NotNull(collectible.Set);
                Assert.NotNull(collectible.League);
                Assert.NotNull(collectible.Person);
                Assert.NotNull(collectible.Team);

                // Verify results contain values specified in service call
                Assert.Equal(cardNumber, collectible.CardNumber);
                Assert.Equal(year, collectible.Year);
                Assert.Equal(auFlag, collectible.AUFlag);
                Assert.Equal(rcFlag, collectible.RCFlag);
                Assert.Equal(notableFlag, collectible.NotableFlag);
                Assert.Equal(gradedFlag, collectible.GradedFlag);
                Assert.Equal(value, collectible.Value);
                Assert.Equal(cost, collectible.Cost);
                Assert.Equal(collectible.CollectibleStatus.Id, CollectibleStatusCodeService.Available.Id);
                Assert.Equal(collectible.CollectibleType.Id, CollectibleTypeCodeService.Card.Id);
                Assert.Equal(companyName, collectible.Set.Name);
                Assert.Equal(leagueName, collectible.League.Name);
                Assert.Equal(personLastName, collectible.Person.LastName);
                Assert.Equal(personFirstName, collectible.Person.FirstName);
                Assert.Equal(teamCity, collectible.Team.City);
                Assert.Equal(teamNickname, collectible.Team.Nickname);
            }
        }
        [Fact]
        public void SeedPerson_Succeeds()
        {
            string dbName = "SeedPerson_Succeeds";

            var options = GetContextOptions(dbName);


            // Run test
            string personLastName = "Montana";
            string personFirstName = "Joe";
            string personMiddleName = null;
            string personSuffix = null;
            string personSportIdentifier = "FB";
            bool personHOFFlag = true;
            bool personHeismanFlag = false;
            bool personNotableFlag = false;
            string personCollegeName = "Notre Dame";
            string personCollegeNickname = "Fightin Irish";

            SeedService.SeedCodeValues(options);

            int personId = SeedService.SeedPerson(options, personLastName, personFirstName, personMiddleName, personSuffix, personSportIdentifier, personHOFFlag, personHeismanFlag, personNotableFlag, personCollegeName, personCollegeNickname);

            // Create a new db context to use for verification - I don't know how to get a separate instance from the DI framework...
            using (var qdbContext = GetQdbContext(dbName))
            {

                // Retrieve data directly from entity framework context
                var person = qdbContext.People
                    .Include(x => x.College)
                    .SingleOrDefault(x => x.Id == personId);

                // Verify results contain all expected relationships
                Assert.NotNull(person);
                Assert.NotNull(person.College);

                // Verify results contain values specified in service call
                Assert.Equal(person.LastName, personLastName);
                Assert.Equal(person.FirstName, personFirstName);
                Assert.Equal(person.MiddleName, personMiddleName);
                Assert.Equal(person.Suffix, personSuffix);
                Assert.Equal(person.HOFFlag, personHOFFlag);
                Assert.Equal(person.HeismanFlag, personHeismanFlag);
                Assert.Equal(person.NotableFlag, personNotableFlag);

                Assert.Equal(person.College.Name, personCollegeName);
                Assert.Equal(person.College.Nickname, personCollegeNickname);

                var personSports = qdbContext.PersonSports
                    .Include(x => x.Sport)
                    .Where(x => x.PersonId == personId)
                    .ToList();

                var sport = personSports.Select(x => x.Sport).SingleOrDefault();

                Assert.NotNull(sport);
                Assert.Equal(personSportIdentifier, sport.Identifier);
            }
        }
    }
}
