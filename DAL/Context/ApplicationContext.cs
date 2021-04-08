using System;
using DAL.Domain;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using DAL.DBSeed;
using Microsoft.AspNetCore.Identity;

namespace DAL.Context
{
    public class ApplicationContext : IdentityDbContext<User>
    {
        public DbSet<Group> Groups { get; set; }
        public DbSet<Test> Tests { get; set; }
        public DbSet<Question> Questions { get; set; }
        public DbSet<Answer> Answers { get; set; }
        public DbSet<UserTest> UserTest { get; set; }
        public DbSet<Role> Role { get; set; }

        public ApplicationContext()
        {
            Database.EnsureCreated();
        }

        public ApplicationContext(DbContextOptions<ApplicationContext> options)
            : base(options)
        {
            Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder
                .UseLazyLoadingProxies()
                .UseSqlServer(@Environment.GetEnvironmentVariable("TestingDBConnectionString"));
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            if (builder == null) throw new ArgumentNullException(nameof(builder));
            base.OnModelCreating(builder);
        }

        private void SeedData(ModelBuilder builder)
        {
            RolesSeeder.SeedData(builder);
        }
    }
}