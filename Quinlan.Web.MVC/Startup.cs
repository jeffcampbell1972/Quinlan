using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

using Microsoft.EntityFrameworkCore;

using Quinlan.Data;
using Quinlan.Data.FilterOptions;
using Quinlan.Data.Services;
using Quinlan.Domain.Services;
using Quinlan.Domain.Models;
using Quinlan.MVC.Models;
using Quinlan.MVC.Services;

namespace Quinlan.MVC
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllersWithViews();

            services.AddDbContext<QdbContext>(options => options.UseSqlServer(Configuration.GetConnectionString("QDatabase")));         


            // Data services required by Domain services
            services.AddScoped<IDataService<Quinlan.Data.Models.Collectible>, CollectibleDataService>();
            services.AddScoped<IDataService<Quinlan.Data.Models.College>, CollegeDataService>();
            services.AddScoped<IDataService<Quinlan.Data.Models.Person>, PersonDataService>();
            services.AddScoped<IDataService<Quinlan.Data.Models.Team>, TeamDataService>();

            services.AddScoped<ICollectibleQueryService<CollectibleQueryFilterOptions>, CollectibleQueryService>();

            services.AddScoped<IQueryService<Quinlan.Data.Models.Person, PersonQueryFilterOptions>, PersonQueryService>();
            services.AddScoped<IQueryService<Quinlan.Data.Models.Team, TeamQueryFilterOptions>, TeamQueryService>();

            // Domain services required by MVC services
            services.AddScoped<ICrudService<Card>, CardService>();
            services.AddScoped<ICrudService<College>, CollegeService>();
            services.AddScoped<ICrudService<League>, LeagueService>();
            services.AddScoped<ICrudService<Person>, PersonService>();
            services.AddScoped<ICrudService<Sport>, SportService>();
            services.AddScoped<ICrudService<Team>, TeamService>();

            services.AddScoped<ICollectibleSearchService<CardSearch, CardSearchFilterOptions>, CardSearchService>();
            services.AddScoped<ICollectibleSearchService<FigurineSearch, FigurineSearchFilterOptions>, FigurineSearchService>();
            services.AddScoped<ICollectibleSearchService<MagazineSearch, MagazineSearchFilterOptions>, MagazineSearchService>();

            services.AddScoped<ISearchService<TeamSearch, TeamSearchFilterOptions>, TeamSearchService>();
            services.AddScoped<ISearchService<PersonSearch, PersonSearchFilterOptions>, PersonSearchService>();

            services.AddScoped<ISummaryService<DataSummary>, CollectibleSummaryService>();

            // MVC services required by Controllers
            services.AddScoped<IHomePageService, HomePageService>();

            services.AddScoped<IIndexService<FigurineIndex,FigurineFilterOptionsViewModel>, FigurineIndexService>();
            services.AddScoped<IIndexService<MagazineIndex, MagazineFilterOptionsViewModel>, MagazineIndexService>();

            services.AddScoped<IViewService<CardView>, CardViewService>();

            services.AddScoped<IDetailsService<CollegeDetails>, CollegeDetailsService>();
            services.AddScoped<IDetailsService<LeagueDetails>, LeagueDetailsService>();
            services.AddScoped<IDetailsService<PersonDetails>, PersonDetailsService>();
            services.AddScoped<IDetailsService<SportDetails>, SportDetailsService>();
            services.AddScoped<IDetailsService<TeamDetails>, TeamDetailsService>();

            services.AddScoped<IEditService<CardEdit>, CardEditService>();
            services.AddScoped<IEditService<CollegeEdit>, CollegeEditService>();
            services.AddScoped<IEditService<PersonEdit>, PersonEditService>();
            services.AddScoped<IEditService<TeamEdit>, TeamEditService>();

            services.AddScoped<IFormService<CardViewModel>, CardFormService>();
            services.AddScoped<IFormService<CollegeViewModel>, CollegeFormService>();
            services.AddScoped<IFormService<PersonViewModel>, PersonFormService>();
            services.AddScoped<IFormService<TeamViewModel>, TeamFormService>();

            services.AddScoped<IIndexService<PersonIndex, PersonFilterOptionsViewModel>, PersonIndexService>();
            services.AddScoped<IIndexService<TeamIndex, TeamFilterOptionsViewModel>, TeamIndexService>();

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
