using System;
using System.Collections.Generic;
using System.Text;
using DonationPickUpServices.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace DonationPickUpServices.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<UserType> UserTypes { get; set; }
        public DbSet<ItemType> ItemTypes { get; set; }
        public DbSet<Status> Statuses { get; set; }
        public DbSet<ApplicationUser> ApplicationUsers { get; set; }
        public DbSet<Item> Items { get; set; }
        public DbSet<Donation> Donations { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            // this is ensuring that the Donation that was created when the DB was built, gets the current Date
            modelBuilder.Entity<Donation>()
                .Property(b => b.DateCreated)
                .HasDefaultValueSql("GETDATE()");

            modelBuilder.Entity<UserType>().HasData(
                new UserType()
                {
                    UserTypeId = 1,
                    Title = "Admin"
                },
                new UserType()
                {
                    UserTypeId = 2,
                    Title = "Employee"
                },
                new UserType()
                {
                    UserTypeId = 3,
                    Title = "Driver"
                },
                new UserType()
                {
                    UserTypeId = 4,
                    Title = "Customer"
                }
            );

            modelBuilder.Entity<ItemType>().HasData(
                new ItemType()
                {
                    ItemTypeId = 1,
                    Title = "Electronics"
                },
                new ItemType()
                {
                    ItemTypeId = 2,
                    Title = "Furniture"
                },
                new ItemType()
                {
                    ItemTypeId = 3,
                    Title = "Clothing"
                }
            );

            modelBuilder.Entity<Status>().HasData(
                new Status()
                {
                    StatusId = 1,
                    Title = "Pending Pick Up"
                },
                new Status()
                {
                    StatusId = 2,
                    Title = "Picked Up"
                },
                new Status()
                {
                    StatusId = 3,
                    Title = "Delivered"
                },
                new Status()
                {
                    StatusId = 4,
                    Title = "Canceled"
                }
            );

            ApplicationUser user1 = new ApplicationUser
            {
                FirstName = "Madison",
                LastName = "Peper",
                Address = "1000 Nunya Business Dr",
                City = "Nashville",
                State = "Tennessee",
                ZipCode = "37209",
                UserName = "madisonpeper@gmail.com",
                NormalizedUserName = "MADISONPEPER@GMAIL.COM",
                Email = "madisonpeper@gmail.com",
                NormalizedEmail = "MADISONPEPER@GMAIL.COM",
                UserPhoneNumber = "6158122717",
                UserTypeId = 2,
                EmailConfirmed = true,
                LockoutEnabled = false,
                SecurityStamp = Guid.NewGuid().ToString("D")
            };
            var passwordHash1 = new PasswordHasher<ApplicationUser>();
            user1.PasswordHash = passwordHash1.HashPassword(user1, "Password!1");
            modelBuilder.Entity<ApplicationUser>().HasData(user1);

            ApplicationUser user2 = new ApplicationUser
            {
                FirstName = "Russell",
                LastName = "Nanney",
                Address = "2020 Nowhere Circle",
                City = "Nashville",
                State = "Tennessee",
                ZipCode = "37209",
                UserName = "russell@nanney.com",
                NormalizedUserName = "RUSSELL@NANNEY.COM",
                Email = "russell@nanney.com",
                NormalizedEmail = "RUSSELL@NANNEY.COM",
                UserPhoneNumber = "6152098318",
                UserTypeId = 4,
                EmailConfirmed = true,
                LockoutEnabled = false,
                SecurityStamp = Guid.NewGuid().ToString("D")
            };
            var passwordHash2 = new PasswordHasher<ApplicationUser>();
            user2.PasswordHash = passwordHash2.HashPassword(user2, "Password!1");
            modelBuilder.Entity<ApplicationUser>().HasData(user2);

            ApplicationUser user3 = new ApplicationUser
            {
                FirstName = "Stephanie",
                LastName = "Risch",
                Address = "1060 OuttaMy Way",
                City = "Nashville",
                State = "Tennessee",
                ZipCode = "37221",
                UserName = "stephanie@risch.com",
                NormalizedUserName = "STEPHANIE@RISCH.COM",
                Email = "stephanie@risch.com",
                NormalizedEmail = "STEPHANIE@RISCH.COM",
                UserPhoneNumber = "6151234567",
                UserTypeId = 4,
                EmailConfirmed = true,
                LockoutEnabled = false,
                SecurityStamp = Guid.NewGuid().ToString("D")
            };
            var passwordHash3 = new PasswordHasher<ApplicationUser>();
            user3.PasswordHash = passwordHash3.HashPassword(user3, "Password!1");
            modelBuilder.Entity<ApplicationUser>().HasData(user3);

            ApplicationUser user4 = new ApplicationUser
            {
                FirstName = "Parker",
                LastName = "Kelley",
                Address = "1509 Rainbow St",
                City = "Nashville",
                State = "Tennessee",
                ZipCode = "37212",
                UserName = "parker@kelley.com",
                NormalizedUserName = "PARKER@KELLEY.COM",
                Email = "parker@kelley.com",
                NormalizedEmail = "PARKER@KELLEY.COM",
                UserPhoneNumber = "6150987654",
                UserTypeId = 2,
                EmailConfirmed = true,
                LockoutEnabled = false,
                SecurityStamp = Guid.NewGuid().ToString("D")
            };
            var passwordHash4 = new PasswordHasher<ApplicationUser>();
            user4.PasswordHash = passwordHash4.HashPassword(user4, "Password!1");
            modelBuilder.Entity<ApplicationUser>().HasData(user4);

            modelBuilder.Entity<Donation>().HasData(
                new Donation()
                {
                    DonationId = 1,
                    DateCompleted = null,
                    StatusId = 2,
                    ApplicationUserId = user3.Id
                },
                new Donation()
                {
                    DonationId = 2,
                    DateCompleted = null,
                    StatusId = 1,
                    ApplicationUserId = user2.Id
                },
                new Donation()
                {
                    DonationId = 3,
                    DateCompleted = null,
                    StatusId = 1,
                    ApplicationUserId = user3.Id
                }
            );

            modelBuilder.Entity<Item>().HasData(
                new Item()
                {
                    ItemId = 1,
                    Title = "Brown Booties",
                    Description = "Size 7.5, never worn, brown leather booties",
                    Weight = 1,
                    Quantity = 1,
                    ApplicationUserId = user3.Id,
                    ItemTypeId = 3,
                    DonationId = 1
                },
                new Item()
                {
                    ItemId = 2,
                    Title ="30\" Samsung TV",
                    Description = "A 30\" Samsung TV, black, flat screen",
                    Weight = 20,
                    Quantity = 1,
                    ApplicationUserId = user2.Id,
                    ItemTypeId = 1,
                    DonationId = 2
                },
                new Item()
                {
                    ItemId = 3,
                    Title = "Dresser",
                    Description = "A brown dresser with 4 drawers",
                    Weight = 60,
                    Quantity = 1,
                    ApplicationUserId = user3.Id,
                    ItemTypeId = 2,
                    DonationId = 3
                }
            );


        }
    }
}
