using appcuoi.Bussiness.DTOs.Request;
using appcuoi.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace appcuoi.Data.Context
{
    public class AppDbContext:DbContext
    {
        private const string _connectionstring = @"Data Source=DESKTOP-4BEUPCN\SQLEXPRESS;
                                                   Initial Catalog=HouseRent;
                                                   Trusted_Connection=SSPI;Encrypt=false;TrustServerCertificate=true";

        public DbSet<UserRoles> UserRoles { get; set; }
        public DbSet<Houses> Houses { get; set; }
        public DbSet<Users> Users { get; set; }
        public DbSet<District> Districts { get; set; }
        public DbSet<Ward> Wards { get; set; }
        public DbSet<Street> Streets { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer(_connectionstring);

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Users>().Property(p=>p.Createdate).HasDefaultValue(DateTime.Now);
            modelBuilder.Entity<Users>().Property(p=>p.ActiveStatus).HasDefaultValue("Inactive");
            modelBuilder.Entity<Users>().Property(p => p.RoleId).HasDefaultValue(2);


            //seeding for District
            var districts = new List<District>()
            {
                new District()
                {
                    DistricId = 1,
                    DistrictName = "Quan Hai Ba Trung",

                },
                new District()
                {
                    DistricId = 2,
                    DistrictName = "Quan Hoang Mai",

                },
                new District()
                {
                    DistricId = 3,
                    DistrictName = "Quan CauGiay",

                },


            };
            modelBuilder.Entity<District>().HasData(districts);
            //seeding for Ward
            var wards = new List<Ward>()
            {
                new Ward()
                {
                    WardId = 1,
                    WardName="Bach Khoa",
                    DistrictId=1
                },
                new Ward()
                {
                    WardId = 2,
                    WardName="Bach Mai",
                    DistrictId=1
                },
                new Ward()
                {
                    WardId = 3,
                    WardName="Quan Nhan",
                    DistrictId=3
                },
                 new Ward()
                {
                    WardId = 4,
                    WardName="Tuong Mai",
                    DistrictId=2
                },
                  new Ward()
                {
                    WardId = 5,
                    WardName="Giap Bat",
                    DistrictId=2
                }
            };
            modelBuilder.Entity<Ward>().HasData(wards);
            var roles = new List<UserRoles>()
            {
                new UserRoles()
                {
                    RoleId= 1,
                    RoleName="Admin"

                },
                new UserRoles()
                {
                    RoleId= 2,
                    RoleName="Student"

                },
                new UserRoles()
                {
                    RoleId= 3,
                    RoleName="Landlord"

                }
            };
            modelBuilder.Entity<UserRoles>().HasData(roles);

            //seeding for street
            var streets = new List<Street>()
            {
                new Street()
                {
                    StreetId = 1,
                    StreetName="Ta Quang Buu",
                    WardId=1,


                },
                new Street()
                {
                    StreetId = 2,
                    StreetName="Tran Dai Nghia",
                    WardId=1

                },
                new Street()
                {
                    StreetId = 3,
                    StreetName="Trai Ca",
                    WardId=2

                },
                 new Street()
                {
                    StreetId = 4,
                    StreetName="Hoang Ngan",
                    WardId=3

                },
                  new Street()
                {
                    StreetId = 5,
                    StreetName="Truong Dinh",
                    WardId=4

                },
                     new Street()
                {
                    StreetId = 6,
                    StreetName="Giap Nhi",
                    WardId=5

                },



            };
            modelBuilder.Entity<Street>().HasData(streets);

        }
    }
}
