using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Extensions.Configuration;

using Quinlan.Windows.Forms;

using Quinlan.Data;
using Quinlan.Data.FilterOptions;
using Quinlan.Data.Services;
using Quinlan.Domain.Services;
using Quinlan.Domain.Models;
using Microsoft.EntityFrameworkCore;


namespace Quinlan.Windows
{
    static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.SetHighDpiMode(HighDpiMode.SystemAware);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);


            var services = new ServiceCollection();

            ConfigureServices(services);

            using (ServiceProvider serviceProvider = services.BuildServiceProvider())
            {
                var form1 = serviceProvider.GetRequiredService<Main>();
                Application.Run(form1);
            }


            //Application.Run(new Main());
        }
        public static void ConfigureServices(IServiceCollection services)
        {
            //string configString = Configuration.GetConnectionString("QDatabase");
            string configString = "Server=(localdb)\\mssqllocaldb;Database=QDb;Trusted_Connection=True;";
            services.AddDbContext<QdbContext>(options => options.UseSqlServer(configString));

            services.AddScoped<Main>();

            // Data and Query services required by Domain services
            services.AddScoped<IDataService<Quinlan.Data.Models.Collectible>, CollectibleDataService>();
            services.AddScoped<IDataService<Quinlan.Data.Models.College>, CollegeDataService>();
            services.AddScoped<IDataService<Quinlan.Data.Models.Container>, ContainerDataService>();
            services.AddScoped<IDataService<Quinlan.Data.Models.Grade>, GradeDataService>();
            services.AddScoped<IDataService<Quinlan.Data.Models.Grader>, GraderDataService>();
            services.AddScoped<IDataService<Quinlan.Data.Models.Person>, PersonDataService>();
            services.AddScoped<IDataService<Quinlan.Data.Models.Product>, ProductDataService>();
            services.AddScoped<IDataService<Quinlan.Data.Models.Team>, TeamDataService>();

            services.AddScoped<ICollectibleQueryService<CollectibleQueryFilterOptions>, CollectibleQueryService>();
            services.AddScoped<IQueryService<Quinlan.Data.Models.Person, PersonQueryFilterOptions>, PersonQueryService>();
            services.AddScoped<IQueryService<Quinlan.Data.Models.Team, TeamQueryFilterOptions>, TeamQueryService>();

            // CRUD and Search services required by MVC services
            services.AddScoped<ICrudService<Card>, CardService>();
            services.AddScoped<ICrudService<College>, CollegeService>();
            services.AddScoped<ICrudService<Quinlan.Domain.Models.Container>,ContainerService>();
            services.AddScoped<ICrudService<Grade>, GradeService>();
            services.AddScoped<ICrudService<Grader>, GraderService>();
            services.AddScoped<ICrudService<League>, LeagueService>();
            services.AddScoped<ICrudService<Person>, PersonService>();
            services.AddScoped<ICrudService<Product>, ProductService>();
            services.AddScoped<ICrudService<Sport>, SportService>();
            services.AddScoped<ICrudService<Team>, TeamService>();

            services.AddScoped<ICollectibleSearchService<CardSearch, CardSearchFilterOptions>, CardSearchService>();
            services.AddScoped<ISearchService<TeamSearch, TeamSearchFilterOptions>, TeamSearchService>();
            services.AddScoped<ISearchService<PersonSearch, PersonSearchFilterOptions>, PersonSearchService>();


        }


    }
}
