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
    public class PersonDataServiceTests : IDataServiceTests
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
                .AddScoped<IDataService<Person>, PersonDataService>()
                .BuildServiceProvider();

            return serviceProvider;
        }
        [Fact]
        public void SelectAll_Succeeds()
        {
            string dbName = "SelectAllPeople_Succeeds";

            // Create dependency injection provider using method as database name
            var serviceProvider = BuildServiceProvider(dbName);
            var options = GetContextOptions(dbName);

            // Retrieve service to be tested
            var serviceToTest = serviceProvider.GetService<IDataService<Person>>();

            // Seed data required for test
            SeedService.SeedCodeValues(options);

            int expectedPeopleCount = 3;
            for (int i = 0; i < expectedPeopleCount; i++)
            {
                SeedService.SeedPerson(options, string.Format("Montana{0}", i), "Joe", null, null, "FB", true, false, false, "Notre Dame", "Fighting Irish");
            }

            // Run the test
            var peopleList = serviceToTest.Select();

            // Verify results match expected results
            Assert.Equal(expectedPeopleCount, peopleList.Count);
        }
        [Fact]
        public void Select_Succeeds()
        {
            string dbName = "SelectPerson_Succeeds";

            // Create dependency injection provider using method as database name
            var serviceProvider = BuildServiceProvider(dbName);
            var options = GetContextOptions(dbName);

            // Retrieve service to be tested
            var serviceToTest = serviceProvider.GetService<IDataService<Person>>();

            // Seed data required for test
            SeedService.SeedCodeValues(options);
            int personId = SeedService.SeedPerson(options, "Montana", "Joe", null, null, "FB", true, false, false, "Notre Dame", "Fighting Irish");

            // Run test
            var person = serviceToTest.Select(personId);

            // Verify that card was returned
            Assert.NotNull(person);
            Assert.Equal(person.Id, personId);
        }
        [Fact]
        public void Select_WithInvalidId_Fails()
        {
            string dbName = "SelectPerson_WithInvalidId_Fails";

            // Create dependency injection provider using method as database name
            var serviceProvider = BuildServiceProvider(dbName);
            var options = GetContextOptions(dbName);

            // Retrieve service to be tested
            var serviceToTest = serviceProvider.GetService<IDataService<Person>>();

            // Seed data required for the test
            SeedService.SeedCodeValues(options);

            // Run the test

            try
            {
                var person = serviceToTest.Select(0);

                Assert.Null(person);
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
