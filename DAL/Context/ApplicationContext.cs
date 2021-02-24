using System;
using DAL.Domain;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace DAL.Context
{
    public class ApplicationContext : IdentityDbContext<User>
    {
        public ApplicationContext()
        {
            Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@Environment.GetEnvironmentVariable("TestingDBConnectionString"));
        }
    }
}