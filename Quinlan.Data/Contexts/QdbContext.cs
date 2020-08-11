using Microsoft.EntityFrameworkCore;

using Quinlan.Data.Models;
using Quinlan.Data.Services;
using System;

namespace Quinlan.Data
{
    public class QdbContext : DbContext
    {
        public DbSet<CardType> CardTypes { get; set; }
        public DbSet<Collectible> Collectibles { get; set; }
        public DbSet<CollectibleStatus> CollectibleStatuses { get; set; }
        public DbSet<CollectibleType> CollectibleTypes { get; set; }
        public DbSet<College> Colleges { get; set; }
        public DbSet<Container> Containers { get; set; }
        public DbSet<Grader> Graders { get; set; }
        public DbSet<Grade> Grades { get; set; }
        public DbSet<ImportCollectible> ImportCollectibles { get; set; }
        public DbSet<ImportCollege> ImportColleges { get; set; }
        public DbSet<ImportPerson> ImportPeople { get; set; }
        public DbSet<ImportProduct> ImportProducts { get; set; }
        public DbSet<ImportTeam> ImportTeams { get; set; }
        public DbSet<League> Leagues { get; set; }
        public DbSet<Organization> Organizations { get; set; }
        public DbSet<Owner> Owners { get; set; }
        public DbSet<Manufacturer> Manufacturers { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductStatus> ProductStatuses { get; set; }
        public DbSet<ProductType> ProductTypes { get; set; }
        public DbSet<Person> People { get; set; }
        public DbSet<PersonSport> PersonSports { get; set; }
        public DbSet<Set> Sets { get; set; }
        public DbSet<Sport> Sports { get; set; }
        public DbSet<Team> Teams { get; set; }
        public DbSet<User> Users { get; set; }

        public QdbContext()
        {

        }
        public QdbContext(DbContextOptions<QdbContext> options) : base(options)
        {
            if (Database.ProviderName == "Microsoft.EntityFrameworkCore.SqlServer")
            {
                //Database.Migrate();
                Database.EnsureCreated();
            }
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Set up the many to many relationship between Person and Sport
            modelBuilder.Entity<PersonSport>()
                .HasKey(sc => new { sc.PersonId, sc.SportId });

            modelBuilder.Entity<PersonSport>()
                .HasOne<Person>(sc => sc.Person)
                .WithMany(s => s.PersonSports)
                .HasForeignKey(sc => sc.PersonId);

            modelBuilder.Entity<PersonSport>()
                .HasOne<Sport>(sc => sc.Sport)
                .WithMany(s => s.PersonSports)
                .HasForeignKey(sc => sc.SportId);

            //modelBuilder.Entity<PersonSport>()
            //    .HasOne<Sport>(sc => sc.Sport)
            //    .WithMany(s => s.PersonSports)
            //    .HasForeignKey(sc => sc.SportId);

            // Seed the data in code tables constant values
            modelBuilder.Entity<Sport>().HasData(SportCodeService.Select());
            modelBuilder.Entity<CollectibleStatus>().HasData(CollectibleStatusCodeService.Select());
            modelBuilder.Entity<CardType>().HasData(CardTypeCodeService.Select());
            modelBuilder.Entity<CollectibleType>().HasData(CollectibleTypeCodeService.Select());
            modelBuilder.Entity<League>().HasData(LeagueCodeService.Select());
            modelBuilder.Entity<ProductStatus>().HasData(ProductStatusCodeService.Select());
            modelBuilder.Entity<ProductType>().HasData(ProductTypeCodeService.Select());

            base.OnModelCreating(modelBuilder);
        }
    }
}
