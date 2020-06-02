using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Xunit;

using Quinlan.Initialize.Services;
using Quinlan.Data;
using Quinlan.Data.Models;
using Quinlan.Data.Services;
using System;

namespace Quinlan.Data.Test.DataServices
{
    public class TeamDataServiceTests : IDataServiceTests
    {
        private static DbContextOptions<QdbContext> GetContextOptions(string dbName)
        {
            var options = new DbContextOptionsBuilder<QdbContext>()
               .UseInMemoryDatabase(databaseName: dbName)
               .Options;

            return options;
        }
        public ServiceProvider BuildServiceProvider(string dbName)
        {
            var serviceProvider = new ServiceCollection()
                .AddDbContext<QdbContext>(options => options.UseInMemoryDatabase(databaseName: dbName))
                .AddScoped<IDataService<Team>, TeamDataService>()
                .BuildServiceProvider();

            return serviceProvider;
        }
        [Fact]
        public void SelectAll_Succeeds()
        {
            string dbName = "SelectAllTeams_Succeeds";

            // Create dependency injection provider using method as database name
            var serviceProvider = BuildServiceProvider(dbName);
            var options = GetContextOptions(dbName);

            // Retrieve service to be tested
            var serviceToTest = serviceProvider.GetService<IDataService<Team>>();

            // Seed data required for test
            SeedService.SeedCodeValues(options);

            int expectedTeamCount = 3;
            for (int i = 0; i < expectedTeamCount; i++)
            {
                SeedService.SeedTeam(options, string.Format("SanFrancisco49ers {0}", i), "San Francisco", "49ers", "NFL", i == 0);
            }

            // Run the test
            var teamList = serviceToTest.Select();

            // Verify results match expected results
            Assert.Equal(expectedTeamCount, teamList.Count);
        }
        [Fact]
        public void Select_Succeeds()
        {
            string dbName = "SelectTeam_Succeeds";

            // Create dependency injection provider using method as database name
            var serviceProvider = BuildServiceProvider(dbName);
            var options = GetContextOptions(dbName);

            // Retrieve service to be tested
            var serviceToTest = serviceProvider.GetService<IDataService<Team>>();

            // Seed data required for test
            SeedService.SeedCodeValues(options);
            int teamId = SeedService.SeedTeam(options, "SanFrancisco49ers", "San Francisco", "49ers", "NFL", true);

            // Run test
            var team = serviceToTest.Select(teamId);

            // Verify that card was returned
            Assert.NotNull(team);
            Assert.Equal(team.Id, teamId);
        }
        [Fact]
        public void Select_WithInvalidId_Fails()
        {
            string dbName = "SelectTeam_WithInvalidId_Fails";

            // Create dependency injection provider using method as database name
            var serviceProvider = BuildServiceProvider(dbName);
            var options = GetContextOptions(dbName);

            // Retrieve service to be tested
            var serviceToTest = serviceProvider.GetService<IDataService<Team>>();

            // Seed data required for the test
            SeedService.SeedCodeValues(options);

            try
            {
                // Run the test
                var team = serviceToTest.Select(0);

                Assert.Null(team);
            }
            catch (InvalidIdException invalidIdException)
            {
                Assert.NotNull(invalidIdException);
            }
            catch (Exception ex)
            {
                Assert.Null(ex);
            }

        }
        [Fact]
        public void Insert_Succeeds()
        {
            Assert.Equal(1, 0);
        }
        [Fact]
        public void Update_Succeeds()
        {
            Assert.Equal(1, 0);
        }
        [Fact]
        public void Update_WithInvalidId_Fails()
        {
            Assert.Equal(1, 0);
        }
        [Fact]
        public void Delete_Succeeds()
        {
            Assert.Equal(1, 0);
        }
        [Fact]
        public void Delete_WithInvalidId_Fails()
        {
            Assert.Equal(1, 0);
        }
    }
}
