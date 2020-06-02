using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Xunit;

using Quinlan.Data;
using Quinlan.Data.Services;
using Quinlan.Domain.Models;
using Quinlan.Domain.Services;

namespace Quinlan.Domain.Test.CrudServices
{
    public class TeamServiceTests
    {
        public ServiceProvider BuildServiceProvider(string dbName)
        {
            var serviceProvider = new ServiceCollection()
                .AddDbContext<QdbContext>(options => options.UseInMemoryDatabase(databaseName: dbName))
                .AddScoped<IDataService<Quinlan.Data.Models.Team>, TeamDataService>()
                .AddScoped<ICrudService<Team>, TeamService>()
                .BuildServiceProvider();

            return serviceProvider;
        }
        [Fact]
        public void GetAll_Succeeds()
        {
            Assert.Equal(1, 0);
        }
        [Fact]
        public void Get_Succeeds()
        {
            Assert.Equal(1, 0);
        }
        [Fact]
        public void Get_WithInvalidId_Fails()
        {
            Assert.Equal(1, 0);
        }
        [Fact]
        public void Post_Succeeds()
        {
            Assert.Equal(1, 0);
        }
        [Fact]
        public void Put_Succeeds()
        {
            Assert.Equal(1, 0);
        }
        [Fact]
        public void Put_WithInvalidId_Fails()
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
