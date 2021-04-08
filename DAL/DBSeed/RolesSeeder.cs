using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Domain;

namespace DAL.DBSeed
{
    class RolesSeeder
    {
        public static void SeedData(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Role>()
                .HasData(new Role
                {
                    Id = new Guid().ToString(),
                    Name = "Admin",
                    NormalizedName = "ADMIN",
                    ConcurrencyStamp = new Guid().ToString()
                });

            modelBuilder.Entity<Role>()
                .HasData(new Role
                {
                    Id = new Guid().ToString(),
                    Name = "Student",
                    NormalizedName = "STUDENT",
                    ConcurrencyStamp = new Guid().ToString()
                });

            modelBuilder.Entity<Role>()
                .HasData(new Role
                {
                    Id = new Guid().ToString(),
                    Name = "Teacher",
                    NormalizedName = "TEACHER",
                    ConcurrencyStamp = new Guid().ToString()
                });
        }
    }
}
