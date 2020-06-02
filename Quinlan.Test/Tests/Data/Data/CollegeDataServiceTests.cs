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
    public class CollegeDataServiceTests : IDataServiceTests
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
                .AddScoped<IDataService<College>, CollegeDataService>()
                .BuildServiceProvider();

            return serviceProvider;
        }
        [Fact]
        public void SelectAll_Succeeds()
        {
            string dbName = "SelectAllColleges_Succeeds";

            // Create dependency injection provider using method as database name
            var serviceProvider = BuildServiceProvider(dbName);
            var options = GetContextOptions(dbName);

            // Retrieve service to be tested
            var serviceToTest = serviceProvider.GetService<IDataService<College>>();

            // Seed data required for test
            SeedService.SeedCodeValues(options);

            int expectedCollegeCount = 3;
            for (int i = 0; i < expectedCollegeCount; i++)
            {
                SeedService.SeedCollege(options, string.Format("Va Tech {0}", i), "Va Tech", "Hokies"); 
            }

            // Run the test
            var collegeList = serviceToTest.Select();

            // Verify results match expected results
            Assert.Equal(expectedCollegeCount, collegeList.Count);
        }
        [Fact]
        public void Select_Succeeds()
        {
            string dbName = "SelectCollege_Succeeds";

            // Create dependency injection provider using method as database name
            var serviceProvider = BuildServiceProvider(dbName);
            var options = GetContextOptions(dbName);

            // Retrieve service to be tested
            var serviceToTest = serviceProvider.GetService<IDataService<College>>();

            // Seed data required for test
            SeedService.SeedCodeValues(options);
            int collegeId = SeedService.SeedCollege(options, "VaTech", "Va Tech", "Hokies");

            // Run test
            var college = serviceToTest.Select(collegeId);

            // Verify that card was returned
            Assert.NotNull(college);
            Assert.Equal(college.Id, collegeId);
        }
        [Fact]
        public void Select_WithInvalidId_Fails()
        {
            string dbName = "SelectCollege_WithInvalidId_Fails";

            // Create dependency injection provider using method as database name
            var serviceProvider = BuildServiceProvider(dbName);
            var options = GetContextOptions(dbName);

            // Retrieve service to be tested
            var serviceToTest = serviceProvider.GetService<IDataService<College>>();

            // Seed data required for the test
            SeedService.SeedCodeValues(options);

            try
            {
                // Run the test
                var college = serviceToTest.Select(0);

                Assert.Null(college);
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
