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
    public class PersonQueryServiceTests 
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
                .AddScoped<IQueryService<Person, PersonQueryFilterOptions>, PersonQueryService>()
                .BuildServiceProvider();

            return serviceProvider;
        }
        [Fact]
        public void Execute_WithSportFilter_Succeeds()
        {
            string dbName = "ExecutePersonQuery_WithSportFilter_Succeeds";

            // Create dependency injection provider using method as database name
            var serviceProvider = BuildServiceProvider(dbName);
            var options = GetContextOptions(dbName);

            // Retrieve service to be tested
            var serviceToTest = serviceProvider.GetService<IQueryService<Person, PersonQueryFilterOptions>>();

            // Seed data required for test
            SeedService.SeedCodeValues(options);

            string footballIdentifier = SportCodeService.Football.Identifier;
            string baseballIdentifier = SportCodeService.Baseball.Identifier;

            SeedService.SeedPerson(options, "Montana", "Joe", null, null, footballIdentifier, true, false, false, "Notre Dame", "Fighting Irish");
            SeedService.SeedPerson(options, "Battle", "Arnez", null, null, footballIdentifier, false, false, true, "Notre Dame", "Fighting Irish");
            SeedService.SeedPerson(options, "Zimmermann", "Ryan", null, null, baseballIdentifier, false, false, true, "Virginia", "Cavaliers");
            SeedService.SeedPerson(options, "Ripken", "Cal", null, null, baseballIdentifier, true, false, false, null, null);
            SeedService.SeedPerson(options, "Spurrior", "Steve", null, null, footballIdentifier, false, true, false, "Florida", "Gators");

            int expectedFootballPersonCount = 3;

            var personQueryFilterOptions = new PersonQueryFilterOptions
            {
                SportId = SportCodeService.Football.Id
            };

            // Run the test
            var personList = serviceToTest.Execute(personQueryFilterOptions);

            // Verify results match expected results
            Assert.Equal(expectedFootballPersonCount, personList.Count);
        }
        [Fact]
        public void Execute_WithLeagueFilter_Succeeds()
        {
            string dbName = "ExecutePersonQuery_WithLeagueFilter_Succeeds";

            // Create dependency injection provider using method as database name
            var serviceProvider = BuildServiceProvider(dbName);
            var options = GetContextOptions(dbName);

            // Retrieve service to be tested
            var serviceToTest = serviceProvider.GetService<IQueryService<Person, PersonQueryFilterOptions>>();

            // Seed data required for test
            SeedService.SeedCodeValues(options);

            string footballIdentifier = SportCodeService.Football.Identifier;
            string baseballIdentifier = SportCodeService.Baseball.Identifier;

            SeedService.SeedPerson(options, "Montana", "Joe", null, null, footballIdentifier, true, false, false, "Notre Dame", "Fighting Irish");
            SeedService.SeedPerson(options, "Battle", "Arnez", null, null, footballIdentifier, false, false, true, "Notre Dame", "Fighting Irish");
            SeedService.SeedPerson(options, "Zimmermann", "Ryan", null, null, baseballIdentifier, false, false, true, "Virginia", "Cavaliers");
            SeedService.SeedPerson(options, "Ripken", "Cal", null, null, baseballIdentifier, true, false, false, null, null);
            SeedService.SeedPerson(options, "Spurrior", "Steve", null, null, footballIdentifier, false, true, false, "Florida", "Gators");


            int expectedNFLPersonCount = 2;

            var personQueryFilterOptions = new PersonQueryFilterOptions
            {
                LeagueId = LeagueCodeService.NFL.Id
            };

            // Run the test
            var personList = serviceToTest.Execute(personQueryFilterOptions);

            // Verify results match expected results
            Assert.Equal(expectedNFLPersonCount, personList.Count);
        }
        [Fact]
        public void Execute_WithNotableFilter_Succeeds()
        {
            string dbName = "ExecutePersonQuery_WithNotableFilter_Succeeds";

            // Create dependency injection provider using method as database name
            var serviceProvider = BuildServiceProvider(dbName);

            // Retrieve service to be tested
            var serviceToTest = serviceProvider.GetService<IQueryService<Person, PersonQueryFilterOptions>>();
            var options = GetContextOptions(dbName);

            // Seed data required for test
            SeedService.SeedCodeValues(options);

            string footballIdentifier = SportCodeService.Football.Identifier;
            string baseballIdentifier = SportCodeService.Baseball.Identifier;

            SeedService.SeedPerson(options, "Montana", "Joe", null, null, footballIdentifier, true, false, false, "Notre Dame", "Fighting Irish");
            SeedService.SeedPerson(options, "Battle", "Arnez", null, null, footballIdentifier, false, false, false, "Notre Dame", "Fighting Irish");
            SeedService.SeedPerson(options, "Zimmermann", "Ryan", null, null, baseballIdentifier, false, false, true, "Virginia", "Cavaliers");
            SeedService.SeedPerson(options, "Ripken", "Cal", null, null, baseballIdentifier, true, false, false, null, null);
            SeedService.SeedPerson(options, "Spurrior", "Steve", null, null, footballIdentifier, false, true, true, "Florida", "Gators");

            int expectedNotablePersonCount = 2;

            var personQueryFilterOptions = new PersonQueryFilterOptions
            {
                NotableFlag = true
            };

            // Run the test
            var personList = serviceToTest.Execute(personQueryFilterOptions);

            // Verify results match expected results
            Assert.Equal(expectedNotablePersonCount, personList.Count);
        }
        [Fact]
        public void Execute_WithTeamFilter_Succeeds()
        {
            string dbName = "ExecutePersonQuery_WithTeamFilter_Succeeds";

            // Create dependency injection provider using method as database name
            var serviceProvider = BuildServiceProvider(dbName);
            var options = GetContextOptions(dbName);

            // Retrieve service to be tested
            var serviceToTest = serviceProvider.GetService<IQueryService<Person, PersonQueryFilterOptions>>();

            // Seed data required for test
            SeedService.SeedCodeValues(options);

            string footballIdentifier = SportCodeService.Football.Identifier;
            string baseballIdentifier = SportCodeService.Baseball.Identifier;

            SeedService.SeedPerson(options, "Montana", "Joe", null, null, footballIdentifier, true, false, false, "Notre Dame", "Fighting Irish");
            SeedService.SeedPerson(options, "Battle", "Arnez", null, null, footballIdentifier, false, false, false, "Notre Dame", "Fighting Irish");
            SeedService.SeedPerson(options, "Zimmermann", "Ryan", null, null, baseballIdentifier, false, false, true, "Virginia", "Cavaliers");
            SeedService.SeedPerson(options, "Ripken", "Cal", null, null, baseballIdentifier, true, false, false, null, null);
            SeedService.SeedPerson(options, "Spurrior", "Steve", null, null, footballIdentifier, false, true, true, "Florida", "Gators");

            int expectedNotablePersonCount = 2;

            var personQueryFilterOptions = new PersonQueryFilterOptions
            {
                NotableFlag = true
            };

            // Run the test
            var personList = serviceToTest.Execute(personQueryFilterOptions);

            // Verify results match expected results
            Assert.Equal(expectedNotablePersonCount, personList.Count);
        }
        [Fact]
        public void Execute_WithHeismanFilter_Succeeds()
        {
            string dbName = "ExecutePersonQuery_WithHeismanFilter_Succeeds";

            // Create dependency injection provider using method as database name
            var serviceProvider = BuildServiceProvider(dbName);
            var options = GetContextOptions(dbName);

            // Retrieve service to be tested
            var serviceToTest = serviceProvider.GetService<IQueryService<Person, PersonQueryFilterOptions>>();

            // Seed data required for test
            SeedService.SeedCodeValues(options);

            string footballIdentifier = SportCodeService.Football.Identifier;
            string baseballIdentifier = SportCodeService.Baseball.Identifier;

            SeedService.SeedPerson(options, "Montana", "Joe", null, null, footballIdentifier, true, false, false, "Notre Dame", "Fighting Irish");
            SeedService.SeedPerson(options, "Battle", "Arnez", null, null, footballIdentifier, false, false, false, "Notre Dame", "Fighting Irish");
            SeedService.SeedPerson(options, "Zimmermann", "Ryan", null, null, baseballIdentifier, false, false, true, "Virginia", "Cavaliers");
            SeedService.SeedPerson(options, "Ripken", "Cal", null, null, baseballIdentifier, true, false, false, null, null);
            SeedService.SeedPerson(options, "Spurrior", "Steve", null, null, footballIdentifier, false, true, true, "Florida", "Gators");

            int expectedNotablePersonCount = 1;

            var personQueryFilterOptions = new PersonQueryFilterOptions
            {
                HeismanFlag = true
            };

            // Run the test
            var personList = serviceToTest.Execute(personQueryFilterOptions);

            // Verify results match expected results
            Assert.Equal(expectedNotablePersonCount, personList.Count);
        }
        [Fact]
        public void Execute_WithHOFFilter_Succeeds()
        {
            string dbName = "ExecutePersonQuery_WithHOFFilter_Succeeds";

            // Create dependency injection provider using method as database name
            var serviceProvider = BuildServiceProvider(dbName);
            var options = GetContextOptions(dbName);

            // Retrieve service to be tested
            var serviceToTest = serviceProvider.GetService<IQueryService<Person, PersonQueryFilterOptions>>();

            // Seed data required for test
            SeedService.SeedCodeValues(options);

            string footballIdentifier = SportCodeService.Football.Identifier;
            string baseballIdentifier = SportCodeService.Baseball.Identifier;

            SeedService.SeedPerson(options, "Montana", "Joe", null, null, footballIdentifier, true, false, false, "Notre Dame", "Fighting Irish");
            SeedService.SeedPerson(options, "Battle", "Arnez", null, null, footballIdentifier, false, false, false, "Notre Dame", "Fighting Irish");
            SeedService.SeedPerson(options, "Zimmermann", "Ryan", null, null, baseballIdentifier, false, false, true, "Virginia", "Cavaliers");
            SeedService.SeedPerson(options, "Ripken", "Cal", null, null, baseballIdentifier, true, false, false, null, null);
            SeedService.SeedPerson(options, "Spurrior", "Steve", null, null, footballIdentifier, false, true, true, "Florida", "Gators");

            int expectedNotablePersonCount = 2;

            var personQueryFilterOptions = new PersonQueryFilterOptions
            {
                HOFFlag = true
            };

            // Run the test
            var personList = serviceToTest.Execute(personQueryFilterOptions);

            // Verify results match expected results
            Assert.Equal(expectedNotablePersonCount, personList.Count);
        }
    }
}
