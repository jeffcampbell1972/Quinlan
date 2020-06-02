using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Xunit;

using Quinlan.Initialize.Services;
using Quinlan.Data;
using Quinlan.Data.FilterOptions;
using Quinlan.Data.Services;
using Quinlan.Domain.Services;

using Quinlan.Domain.Models;

namespace Quinlan.Domain.Test.SearchServices
{
    public class CardSearchServiceTests
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
                .AddScoped<ICollectibleSearchService<CardSearch, CardSearchFilterOptions>, CardSearchService>()
                .AddScoped<ICollectibleQueryService<CollectibleQueryFilterOptions>, CollectibleQueryService>()
                .BuildServiceProvider();

            return serviceProvider;
        }
        [Fact]
        public void FootballSearch_WithResults_Succeeds()
        {
            string dbName = "FootballSearch_WithResults_Succeeds";

            // Create dependency injection provider using method as database name
            var serviceProvider = BuildServiceProvider(dbName);
            var options = GetContextOptions(dbName);

            // Retrieve services necessary for test
            var serviceToTest = serviceProvider.GetService<ICollectibleSearchService<CardSearch, CardSearchFilterOptions>>();

            // Add Code Values for sports, leagues, collectible types, and collectible statuses
            SeedService.SeedCodeValues(options);
            SeedService.SeedCard(options, "NFL", 1, "Montana", "Joe", "San Francisco", "49ers", 1981, "Topps", false, true, true, false, 100, 80 );

            // Run test to search for football cards
            var filterOptions = new CardSearchFilterOptions
            {
                SportId = SportCodeService.Football.Id
            };
            var cardSearch = serviceToTest.Get(filterOptions);

            // Verify that results returned a single football card
            Assert.Equal(1, cardSearch.NumCards);
            
        }
        [Fact]
        public void FootballSearch_WithNoResults_Succeeds()
        {
            string dbName = "FootballSearch_WithNoResults_Succeeds";
            // Create dependency injection provider using method as database name
            var serviceProvider = BuildServiceProvider(dbName);
            var options = GetContextOptions(dbName);

            // Retrieve services necessary for test
            var serviceToTest = serviceProvider.GetService<ICollectibleSearchService<CardSearch, CardSearchFilterOptions>>();

            // Add Code Values for sports, leagues, collectible types, and collectible statuses
            SeedService.SeedCodeValues(options);

            // Seed a single baseball card
            SeedService.SeedCard(options, "MLB", 1, "Montana", "Joe", "San Francisco", "49ers", 1981, "Topps", false, true, true, false, 100, 80);

            // Run test to search for football cards
            var filterOptions = new CardSearchFilterOptions
            {
                SportId = SportCodeService.Football.Id
            };
            var collectibleSearch = serviceToTest.Get(filterOptions);

            // Verify that results returned zero football cards
            Assert.Equal(0, collectibleSearch.NumCards);

        }
    }
}
