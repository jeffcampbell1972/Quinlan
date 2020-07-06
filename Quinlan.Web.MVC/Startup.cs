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
using Microsoft.AspNetCore.Identity;
using Quinlan.Identity.Data;
using System.Runtime.CompilerServices;

namespace Quinlan.Web.MVC
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
            services.AddRazorPages();

            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(
                    Configuration.GetConnectionString("DefaultConnection")));

            services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
                .AddRoles<IdentityRole>()
                .AddEntityFrameworkStores<ApplicationDbContext>();

            services.AddDbContext<QdbContext>(options => options.UseSqlServer(Configuration.GetConnectionString("QDatabase")));

            // Data and Query services required by Domain services
            services.AddScoped<IDataService<Quinlan.Data.Models.Collectible>, CollectibleDataService>();
            services.AddScoped<IDataService<Quinlan.Data.Models.College>, CollegeDataService>();
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
            services.AddScoped<ICrudService<Grade>, GradeService>();
            services.AddScoped<ICrudService<Grader>, GraderService>();
            services.AddScoped<ICrudService<League>, LeagueService>();
            services.AddScoped<ICrudService<Person>, PersonService>();
            services.AddScoped<ICrudService<Product>, ProductService>();
            services.AddScoped<ICrudService<Sport>, SportService>();
            services.AddScoped<ICrudService<Team>, TeamService>();

            services.AddScoped<ICollectibleSearchService<CardSearch, CardSearchFilterOptions>, CardSearchService>();
            services.AddScoped<ICollectibleSearchService<FigurineSearch, FigurineSearchFilterOptions>, FigurineSearchService>();
            services.AddScoped<ICollectibleSearchService<MagazineSearch, MagazineSearchFilterOptions>, MagazineSearchService>();
            services.AddScoped<ISearchService<TeamSearch, TeamSearchFilterOptions>, TeamSearchService>();
            services.AddScoped<ISearchService<PersonSearch, PersonSearchFilterOptions>, PersonSearchService>();

            services.AddScoped<ISummaryService<DataSummary>, CollectibleSummaryService>();

            // MVC services required by Controllers 
            services.AddScoped<IHomeService<Home>, HomeIndexService>();
            services.AddScoped<IHomeService<Summary>, HomeDetailsService>();

            services.AddScoped<IIndexService<FigurineIndex,FigurineFilterOptionsViewModel>, FigurineIndexService>();
            services.AddScoped<IIndexService<MagazineIndex, MagazineFilterOptionsViewModel>, MagazineIndexService>();

            services.AddScoped<IViewService<CardView>, CardViewService>();

            services.AddScoped<IDetailsService<CollegeDetails>, CollegeDetailsService>();
            services.AddScoped<IDetailsService<LeagueDetails>, LeagueDetailsService>();
            services.AddScoped<IDetailsService<PersonDetails>, PersonDetailsService>();
            services.AddScoped<IDetailsService<ProductDetails>, ProductDetailsService>();
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
            services.AddScoped<IIndexService<ProductIndex, ProductFilterOptionsViewModel>, ProductIndexService>();
            services.AddScoped<IIndexService<TeamIndex, TeamFilterOptionsViewModel>, TeamIndexService>();

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, IServiceProvider serviceProvider)
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

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");

                endpoints.MapRazorPages();
            });

            CreateRoles(serviceProvider).Wait();
        }
        private async Task CreateRoles(IServiceProvider serviceProvider)
        {
            var RoleManager = serviceProvider.GetRequiredService<RoleManager<IdentityRole>>();
            var UserManager = serviceProvider.GetRequiredService<UserManager<IdentityUser>>();

            IdentityResult roleResult;
            //here in this line we are adding Admin Role
            var adminCheck = await RoleManager.RoleExistsAsync("Admin");
            if (!adminCheck)
            {
                //here in this line we are creating admin role and seed it to the database
                roleResult = await RoleManager.CreateAsync(new IdentityRole("Admin"));
            }
            var ownerCheck = await RoleManager.RoleExistsAsync("Owner");
            if (!ownerCheck)
            {
                //here in this line we are creating admin role and seed it to the database
                roleResult = await RoleManager.CreateAsync(new IdentityRole("Owner"));
            }

            var susan = await UserManager.FindByNameAsync("susan@quinlan.com");
            if (susan == null)
            {
                var susanResult = await UserManager.CreateAsync(new IdentityUser 
                { 
                    UserName = "susan@quinlan.com", 
                    Email = "susan@quinlan.com" , 
                    PasswordHash = "AQAAAAEAACcQAAAAEGuSDVqbXDPUu6upDkeJVCRDk2V1sV1ylJJ8MT5lRN4J/OIPk5I0hi9rwoZ9vIUX1w=="   // P@ssword1
                });
                if (susanResult.Succeeded)
                {
                    susan = await UserManager.FindByNameAsync("susan@quinlan.com");
                }
                else
                {
                    return;
                }
            }
            var susanOwnerCheck = await UserManager.IsInRoleAsync(susan, "Owner");
            if (!susanOwnerCheck)
            {
                var x = await UserManager.AddToRoleAsync(susan, "Owner");
            }
        }
    }
}
