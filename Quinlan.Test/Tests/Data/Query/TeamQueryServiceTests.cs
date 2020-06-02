using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Xunit;

using Quinlan.Initialize.Services;
using Quinlan.Data.FilterOptions;
using Quinlan.Data.Models;
using Quinlan.Data.Services;
using System;

namespace Quinlan.Data.Test.QueryServices
{
    public class TeamQueryServiceTests
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
                .AddScoped<IQueryService<Team, TeamQueryFilterOptions>, TeamQueryService>()
                .BuildServiceProvider();

            return serviceProvider;
        }
        [Fact]
        public void Execute_WithAllFilters_Succeeds()
        {
            string dbName = "ExecuteTeamsQuery_WithAllFilters_Succeeds";

            // Create dependency injection provider using method as database name
            var serviceProvider = BuildServiceProvider(dbName);
            var options = GetContextOptions(dbName);

            // Retrieve service to be tested
            var serviceToTest = serviceProvider.GetService<IQueryService<Team, TeamQueryFilterOptions>>();

            // Seed data required for test
            SeedService.SeedCodeValues(options);

            var nfl = LeagueCodeService.NFL;
            var cfl = LeagueCodeService.CFL;
            var nhl = LeagueCodeService.NHL;

            SeedService.SeedTeam(options, "SanFrancisco49ers", "San Francisco", "49ers", nfl.Identifier, true);
            SeedService.SeedTeam(options, "SanJoseSharks", "San Jose", "Sharks", nhl.Identifier, false);
            SeedService.SeedTeam(options, "TorontoArgonauts", "Toronto", "Argonauts", cfl.Identifier, true);
            SeedService.SeedTeam(options, "LosAngelesChargers", "Los Angeles", "Chargers", nfl.Identifier, false);

            int expectedTeamCount = 1;

            var teamQueryFilterOptions = new TeamQueryFilterOptions
            {
                SportId = SportCodeService.Football.Id ,
                LeagueId = LeagueCodeService.CFL.Id ,
                NotableFlag = true
            };

            // Run the test
            var teamList = serviceToTest.Execute(teamQueryFilterOptions);

            // Verify results match expected results
            Assert.Equal(expectedTeamCount, teamList.Count);
        }
        [Fact]
        public void Execute_WithSportFilter_Succeeds()
        {
            string dbName = "ExecuteTeamsQuery_WithSportFilter_Succeeds";

            // Create dependency injection provider using method as database name
            var serviceProvider = BuildServiceProvider(dbName);
            var options = GetContextOptions(dbName);

            // Retrieve service to be tested
            var serviceToTest = serviceProvider.GetService<IQueryService<Team, TeamQueryFilterOptions>>();

            // Seed data required for test
            SeedService.SeedCodeValues(options);

            var nfl = LeagueCodeService.NFL;
            var nhl = LeagueCodeService.NHL;

            SeedService.SeedTeam(options, "SanFrancisco49ers", "San Francisco", "49ers", nfl.Identifier, true);
            SeedService.SeedTeam(options, "SanJoseSharks", "San Jose", "Sharks", nhl.Identifier, false);
            SeedService.SeedTeam(options, "LosAngelesChargers", "Los Angeles", "Chargers", nfl.Identifier, false);

            int expectedFootballTeamCount = 2;

            var teamQueryFilterOptions = new TeamQueryFilterOptions
            {
                SportId = SportCodeService.Football.Id
            };

            // Run the test
            var teamList = serviceToTest.Execute(teamQueryFilterOptions);

            // Verify results match expected results
            Assert.Equal(expectedFootballTeamCount, teamList.Count);
        }
        [Fact]
        public void Execute_WithLeagueFilter_Succeeds()
        {
            string dbName = "ExecuteTeamsQuery_WithLeagueFilter_Succeeds";

            // Create dependency injection provider using method as database name
            var serviceProvider = BuildServiceProvider(dbName);
            var options = GetContextOptions(dbName);

            // Retrieve service to be tested
            var serviceToTest = serviceProvider.GetService<IQueryService<Team, TeamQueryFilterOptions>>();

            // Seed data required for test
            SeedService.SeedCodeValues(options);

            var nfl = LeagueCodeService.NFL;
            var nhl = LeagueCodeService.NHL;

            SeedService.SeedTeam(options, "SanFrancisco49ers", "San Francisco", "49ers", nfl.Identifier, true);
            SeedService.SeedTeam(options, "SanJoseSharks", "San Jose", "Sharks", nhl.Identifier, false);
            SeedService.SeedTeam(options, "LosAngelesChargers", "Los Angeles", "Chargers", nfl.Identifier, false);

            int expectedNFLTeamCount = 2;

            var teamQueryFilterOptions = new TeamQueryFilterOptions
            {
                LeagueId = nfl.Id
            };

            // Run the test
            var teamList = serviceToTest.Execute(teamQueryFilterOptions);

            // Verify results match expected results
            Assert.Equal(expectedNFLTeamCount, teamList.Count);
        }
        [Fact]
        public void Execute_WithNotableFilter_Succeeds()
        {
            string dbName = "ExecuteTeamsQuery_WithNotableFilter_Succeeds";

            // Create dependency injection provider using method as database name
            var serviceProvider = BuildServiceProvider(dbName);
            var options = GetContextOptions(dbName);

            // Retrieve service to be tested
            var serviceToTest = serviceProvider.GetService<IQueryService<Team, TeamQueryFilterOptions>>();

            // Seed data required for test
            SeedService.SeedCodeValues(options);

            SeedService.SeedTeam(options, "SanFrancisco49ers", "San Francisco", "49ers", "NFL", true);  // only one notable team
            SeedService.SeedTeam(options, "SanJoseSharks", "San Jose", "Sharks", "NHL", false);
            SeedService.SeedTeam(options, "LosAngelesChargers", "Los Angeles", "Chargers", "NFL", false);

            int expectedNotableTeamCount = 1;

            var teamQueryFilterOptions = new TeamQueryFilterOptions
            {
                NotableFlag = true
            };

            // Run the test
            var teamList = serviceToTest.Execute(teamQueryFilterOptions);

            // Verify results match expected results
            Assert.Equal(expectedNotableTeamCount, teamList.Count);
        }

    }
}
