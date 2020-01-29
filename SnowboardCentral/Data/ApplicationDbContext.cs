using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using SnowboardCentral.Models;

namespace SnowboardCentral.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<ApplicationUser> ApplicationUsers { get; set; }
        public DbSet<Shop> Shops { get; set; }
        public DbSet<Resort> Resorts { get; set; }
        public DbSet<ShopReview> ShopReviews { get; set; }
        public DbSet<ResortReview> ResortReviews { get; set; }
        public DbSet<ExperienceLevel> ExperienceLevels { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            //Create User
            ApplicationUser user = new ApplicationUser
            {
                UserName = "admin@admin.com",
                NormalizedUserName = "ADMIN@ADMIN.COM",
                Email = "admin@admin.com",
                NormalizedEmail = "ADMIN@ADMIN.COM",
                EmailConfirmed = true,
                LockoutEnabled = false,
                SecurityStamp = "7f434309-a4d9-48e9-9ebb-8803db794577",
                Id = "00000000-ffff-ffff-ffff-ffffffffffff",
                FirstName = "Kelli",
                LastName = "Evans",
                Age = 29,
                Height = 69,
                Weight = 130,
                ExperienceLevelId = 1
            };

            var passwordHash = new PasswordHasher<ApplicationUser>();
            user.PasswordHash = passwordHash.HashPassword(user, "Admin123!");
            modelBuilder.Entity<ApplicationUser>().HasData(user);


            //Create three shops
            modelBuilder.Entity<Shop>().HasData(
                new Shop()
                {
                    Id = 1,
                    Name = "Aspen Ski and Board",
                    Address= "1170 E Powell Rd Lewis Center, OH 43035",
                    PhoneNumber = "614-848-6600",
                    WeekdayHours = "11am - 8:30pm",
                    WeekendHours = "10am - 6pm",
                    Description = "We offer over 65 of the top brands of jackets, pants, base layers, skis, snowboards, boots, bindings, tuning equipment, helmets, goggles and more!",
                    RentEquipment = true,
                    Url = "https://www.aspenskiandboard.com/",
                    UrlImage = null,
                    DailyRentalCost = 50.00
                },

                new Shop()
                {
                    Id = 2,
                    Name = "Colorado Mountain Sports",
                    Address = "4445 Cemetery Rd, Hilliard, OH 43026",
                    PhoneNumber = "614-459-6666",
                    WeekdayHours = "11am - 8pm",
                    WeekendHours = "10am - 6pm",
                    Description = "This is a description",
                    RentEquipment = true,
                    Url = "https://coloradomtnsports.com/",
                    UrlImage = null,
                    DailyRentalCost = 75.00
                },

                new Shop()
                {
                    Id = 3,
                    Name = "Zumiez",
                    Address = "5043 Tuttle Crossing Blvd #162, Dublin, OH 43016",
                    PhoneNumber = "614-798-2018",
                    WeekdayHours = "10am - 9pm",
                    WeekendHours = "11am - 6pm",
                    Description = "This is a description",
                    RentEquipment = true,
                    Url = "https://www.zumiez.com/",
                    UrlImage = null,
                    DailyRentalCost = 60.00
                }
            );

            //Create three resorts
            modelBuilder.Entity<Resort>().HasData(
                new Resort()
                {
                    Id = 1,
                    Name = "Mad River Mountain",
                    Address = "1000 Snow Valley Rd Zanesville, OH 43360",
                    PhoneNumber = "800-231-7669",
                    WeekdayHours = "10am - 9:30pm",
                    WeekendHours = "9am - 9:30pm",
                    Description = "Amenities: Lodging, restaurants, shuttle services, vehicle charging stations, chapel, and much more!",
                    Lodging = true,
                    RentEquipment = true,
                    Url = "https://www.skimadriver.com/",
                    UrlImage = null,
                    DailyCost = 40.00
                },

                new Resort()
                {
                    Id = 2,
                    Name = "Snow Trails",
                    Address = "3100 Possum Run Rd, Mansfield, OH 44903",
                    PhoneNumber = "419-774-9818",
                    WeekdayHours = "10am - 9pm",
                    WeekendHours = "9am - 9pm",
                    Description = "Opened in 1961, this family-owned resort with a lodge features winter skiing, snowboarding & tubing.",
                    Lodging = true,
                    RentEquipment = true,
                    Url = "https://www.snowtrails.com/",
                    UrlImage = null,
                    DailyCost = 50.00
                },

                new Resort()
                {
                    Id = 3,
                    Name = "Alpine Valley",
                    Address = "10620 Mayfield Rd, Chesterland, OH 44026",
                    PhoneNumber = "440-285-2211",
                    WeekdayHours = "3:30pm - 9pm",
                    WeekendHours = "9am - 9pm",
                    Description = "Alpine Valley Ski Area is a ski resort located in Munson Township, Geauga County, in the U.S. state of Ohio, east of Chesterland. It was built in 1965 under the direction of Thomas D. Apthorp, who then continued to operate and manage the resort until 2007.",
                    Lodging = true,
                    RentEquipment = true,
                    Url = "http://www.alpinevalleyohio.com/",
                    UrlImage = null,
                    DailyCost = 45.00
                }
            );

            //Create three shop reviews
            modelBuilder.Entity<ShopReview>().HasData(
                new ShopReview()
                {
                    Id = 1,
                    ShopId = 1,
                    Rating = 5,
                    UserId = "00000000-ffff-ffff-ffff-ffffffffffff",
                    DetailReview = "This place is fucking awesome"
                },

                new ShopReview()
                {
                    Id = 2,
                    ShopId = 2,
                    Rating = 3,
                    UserId = "00000000-ffff-ffff-ffff-ffffffffffff",
                    DetailReview = "This place is alright"
                },

                new ShopReview()
                {
                    Id = 3,
                    ShopId = 3,
                    Rating = 4,
                    UserId = "00000000-ffff-ffff-ffff-ffffffffffff",
                    DetailReview = "The name of this place is kinda entertaining"
                }
            );

            //Create three resort reviews
            modelBuilder.Entity<ResortReview>().HasData(
                new ResortReview()
                {
                    Id = 1,
                    ResortId = 1,
                    Rating = 5,
                    UserId = "00000000-ffff-ffff-ffff-ffffffffffff",
                    DetailReview = "Love the selection of slopes here!"
                },

                new ResortReview()
                {
                    Id = 2,
                    ResortId = 2,
                    Rating = 5,
                    UserId = "00000000-ffff-ffff-ffff-ffffffffffff",
                    DetailReview = "Pretty sweet place to board"
                },

                new ResortReview()
                {
                    Id = 3,
                    ResortId = 3,
                    Rating = 3,
                    UserId = "00000000-ffff-ffff-ffff-ffffffffffff",
                    DetailReview = "Not as many slopes to choose from but it was fun"
                }
            );

            //Create four experience levels
            modelBuilder.Entity<ExperienceLevel>().HasData(
                new ExperienceLevel()
                {
                    Id = 1,
                    Level = "Beginner"
                },

                new ExperienceLevel()
                {
                    Id = 2,
                    Level = "Intermediate"
                },

                new ExperienceLevel()
                {
                    Id = 3,
                    Level = "Advanced"
                },

                new ExperienceLevel()
                {
                    Id = 4,
                    Level = "Expert"
                }
            );
        }
    }
}
