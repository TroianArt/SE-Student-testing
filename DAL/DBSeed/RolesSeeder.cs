using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Domain;
using Microsoft.AspNetCore.Identity;

namespace DAL.DBSeed
{
    class RolesSeeder
    {
        public static void SeedData(ModelBuilder modelBuilder)
        {
            //modelBuilder.Entity<Role>()
            //    .HasData(new Role
            //    {
            //        Id = "e597fdd2-91b4-48bf-a881-dd6a2b020d6f",
            //        //Id = new Guid("1").ToString(),
            //        Name = "Admin",
            //        NormalizedName = "ADMIN",
            //        ConcurrencyStamp = new Guid().ToString()
            //    });

            //modelBuilder.Entity<Role>()
            //    .HasData(new Role
            //    {
            //        Id = "ea73ad8b-938f-40ae-bcd0-ff7474203577",
            //        //Id = new Guid("2").ToString(),
            //        Name = "Student",
            //        NormalizedName = "STUDENT",
            //        ConcurrencyStamp = new Guid().ToString()
            //    });

            //modelBuilder.Entity<Role>()
            //    .HasData(new Role
            //    {
            //        Id = "c71e75f6-dcd2-47d6-a2f6-ecd64d32585b",
            //        //Id = new Guid("3").ToString(),
            //        Name = "Teacher",
            //        NormalizedName = "TEACHER",
            //        ConcurrencyStamp = new Guid().ToString()
            //    });
            modelBuilder.Entity<Role>()
                .HasData(new Role("Teacher"));
        }
    }
}
