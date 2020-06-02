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
    public class CollectibleDataServiceTests : IDataServiceTests
    {
        public ServiceProvider BuildServiceProvider(string dbName)
        {
            var serviceProvider = new ServiceCollection()
                .AddDbContext<QdbContext>(options => options.UseInMemoryDatabase(databaseName: dbName))
                .AddScoped<IDataService<Collectible>, CollectibleDataService>()
                .BuildServiceProvider();

            return serviceProvider;
        }
        private static DbContextOptions<QdbContext> GetContextOptions(string dbName)
        {
            var options = new DbContextOptionsBuilder<QdbContext>()
               .UseInMemoryDatabase(databaseName: dbName)
               .Options;

            return options;
        }
        [Fact]
        public void SelectAll_Succeeds()
        {
            string dbName = "SelectAllCollectibles_Succeeds";

            // Create dependency injection provider using method as database name
            var serviceProvider = BuildServiceProvider(dbName);
            var options = GetContextOptions(dbName);

            // Retrieve service to be tested
            var serviceToTest = serviceProvider.GetService<IDataService<Collectible>>();

            // Seed data required for test
            SeedService.SeedCodeValues(options);

            int expectedCollectibleCount = 3;
            for (int i = 0; i < expectedCollectibleCount; i++)
            {
                SeedService.SeedCard(options, "NFL", 1, "Montana", "Joe", "San Francisco", "49ers", 1981 + i, "Topps", false, i == 0, true, false, 100, 80);
            }

            // Run the test
            var collectibleList = serviceToTest.Select();

            // Verify results match expected results
            Assert.Equal(expectedCollectibleCount, collectibleList.Count);            
        }
        [Fact]
        public void Select_Succeeds()
        {
            string dbName = "SelectCollectible_Succeeds";

            // Create dependency injection provider using method as database name
            var serviceProvider = BuildServiceProvider(dbName);
            var options = GetContextOptions(dbName);

            // Retrieve service to be tested
            var serviceToTest = serviceProvider.GetService<IDataService<Collectible>>();

            // Seed data required for test
            SeedService.SeedCodeValues(options);
            int cardId = SeedService.SeedCard(options, "NFL", 1, "Montana", "Joe", "San Francisco", "49ers", 1981, "Topps", false, true, true, false, 100, 80);

            // Run test
            var card = serviceToTest.Select(cardId);

            // Verify that card was returned
            Assert.NotNull(card);
            Assert.Equal(card.Id, cardId);
        }
        [Fact]
        public void Select_WithInvalidId_Fails()
        {
            string dbName = "SelectCollectible_WithInvalidId_Fails";

            // Create dependency injection provider using method as database name
            var serviceProvider = BuildServiceProvider(dbName);
            var options = GetContextOptions(dbName);

            // Retrieve service to be tested
            var serviceToTest = serviceProvider.GetService<IDataService<Collectible>>();

            // Seed data required for the test
            SeedService.SeedCodeValues(options);

            // Run the test

            try
            {
                var collectible = serviceToTest.Select(0);

                Assert.Null(collectible);
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
