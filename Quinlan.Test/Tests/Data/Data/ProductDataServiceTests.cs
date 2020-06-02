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
    public class ProductDataServiceTests : IDataServiceTests
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
                .AddScoped<IDataService<Product>, ProductDataService>()
                .BuildServiceProvider();

            return serviceProvider;
        }
        [Fact]
        public void SelectAll_Succeeds()
        {
            string dbName = "SelectAllProducts_Succeeds";

            // Create dependency injection provider using method as database name
            var serviceProvider = BuildServiceProvider(dbName);
            var options = GetContextOptions(dbName);

            // Retrieve service to be tested
            var serviceToTest = serviceProvider.GetService<IDataService<Product>>();

            // Seed data required for test
            SeedService.SeedCodeValues(options);

            int expectedProductCount = 3;
            for (int i = 0; i < expectedProductCount; i++)
            {
                SeedService.SeedProduct(options, string.Format("Product {0}", i));
            }

            // Run the test
            var productList = serviceToTest.Select();

            // Verify results match expected results
            Assert.Equal(expectedProductCount, productList.Count);
        }
        [Fact]
        public void Select_Succeeds()
        {
            string dbName = "SelectProduct_Succeeds";

            // Create dependency injection provider using method as database name
            var serviceProvider = BuildServiceProvider(dbName);
            var options = GetContextOptions(dbName);

            // Retrieve service to be tested
            var serviceToTest = serviceProvider.GetService<IDataService<Product>>();

            // Seed data required for test
            SeedService.SeedCodeValues(options);
            int productId = SeedService.SeedProduct(options, "Product");

            // Run test
            var product = serviceToTest.Select(productId);

            // Verify that card was returned
            Assert.NotNull(product);
            Assert.Equal(product.Id, productId);
        }
        [Fact]
        public void Select_WithInvalidId_Fails()
        {
            string dbName = "SelectProduct_WithInvalidId_Fails";

            // Create dependency injection provider using method as database name
            var serviceProvider = BuildServiceProvider(dbName);
            var options = GetContextOptions(dbName);

            // Retrieve service to be tested
            var serviceToTest = serviceProvider.GetService<IDataService<Product>>();

            // Seed data required for the test
            SeedService.SeedCodeValues(options);

            try
            {
                // Run the test
                var product = serviceToTest.Select(0);

                Assert.Null(product);
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
