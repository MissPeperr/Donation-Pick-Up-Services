﻿// <auto-generated />
using System;
using DonationPickUpServices.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace DonationPickUpServices.Data.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.4-rtm-31024")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("DonationPickUpServices.Models.Donation", b =>
                {
                    b.Property<int>("DonationId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime?>("DateCompleted");

                    b.Property<DateTime>("DateCreated")
                        .ValueGeneratedOnAddOrUpdate()
                        .HasDefaultValueSql("GETDATE()");

                    b.Property<int>("StatusId");

                    b.HasKey("DonationId");

                    b.HasIndex("StatusId");

                    b.ToTable("Donations");

                    b.HasData(
                        new { DonationId = 1, DateCreated = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), StatusId = 2 },
                        new { DonationId = 2, DateCreated = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), StatusId = 1 },
                        new { DonationId = 3, DateCreated = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), StatusId = 1 }
                    );
                });

            modelBuilder.Entity("DonationPickUpServices.Models.Item", b =>
                {
                    b.Property<int>("ItemId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ApplicationUserId")
                        .IsRequired();

                    b.Property<string>("Description")
                        .IsRequired();

                    b.Property<int>("DonationId");

                    b.Property<int>("ItemTypeId");

                    b.Property<int>("Quantity");

                    b.Property<string>("Title")
                        .IsRequired();

                    b.Property<int>("Weight");

                    b.HasKey("ItemId");

                    b.HasIndex("ApplicationUserId");

                    b.HasIndex("DonationId");

                    b.HasIndex("ItemTypeId");

                    b.ToTable("Items");

                    b.HasData(
                        new { ItemId = 1, ApplicationUserId = "720a80ca-6217-4759-924a-58c8036bd0c2", Description = "Size 7.5, never worn, brown leather booties", DonationId = 1, ItemTypeId = 3, Quantity = 1, Title = "Brown Booties", Weight = 1 },
                        new { ItemId = 2, ApplicationUserId = "cb60afa5-d6b7-4773-8f49-b9d31f55a454", Description = "A 30\" Samsung TV, black, flat screen", DonationId = 2, ItemTypeId = 1, Quantity = 1, Title = "30\" Samsung TV", Weight = 20 },
                        new { ItemId = 3, ApplicationUserId = "720a80ca-6217-4759-924a-58c8036bd0c2", Description = "A brown dresser with 4 drawers", DonationId = 3, ItemTypeId = 2, Quantity = 1, Title = "Dresser", Weight = 60 }
                    );
                });

            modelBuilder.Entity("DonationPickUpServices.Models.ItemType", b =>
                {
                    b.Property<int>("ItemTypeId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Title")
                        .IsRequired();

                    b.HasKey("ItemTypeId");

                    b.ToTable("ItemTypes");

                    b.HasData(
                        new { ItemTypeId = 1, Title = "Electronics" },
                        new { ItemTypeId = 2, Title = "Furniture" },
                        new { ItemTypeId = 3, Title = "Clothing" }
                    );
                });

            modelBuilder.Entity("DonationPickUpServices.Models.Status", b =>
                {
                    b.Property<int>("StatusId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Title")
                        .IsRequired();

                    b.HasKey("StatusId");

                    b.ToTable("Statuses");

                    b.HasData(
                        new { StatusId = 1, Title = "Pending Pick Up" },
                        new { StatusId = 2, Title = "Picked Up" },
                        new { StatusId = 3, Title = "Delivered" },
                        new { StatusId = 4, Title = "Canceled" }
                    );
                });

            modelBuilder.Entity("DonationPickUpServices.Models.UserType", b =>
                {
                    b.Property<int>("UserTypeId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Title")
                        .IsRequired();

                    b.HasKey("UserTypeId");

                    b.ToTable("UserTypes");

                    b.HasData(
                        new { UserTypeId = 1, Title = "Admin" },
                        new { UserTypeId = 2, Title = "Employee" },
                        new { UserTypeId = 3, Title = "Driver" },
                        new { UserTypeId = 4, Title = "Customer" }
                    );
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Name")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("RoleId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUser", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("AccessFailedCount");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Discriminator")
                        .IsRequired();

                    b.Property<string>("Email")
                        .HasMaxLength(256);

                    b.Property<bool>("EmailConfirmed");

                    b.Property<bool>("LockoutEnabled");

                    b.Property<DateTimeOffset?>("LockoutEnd");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256);

                    b.Property<string>("PasswordHash");

                    b.Property<string>("PhoneNumber");

                    b.Property<bool>("PhoneNumberConfirmed");

                    b.Property<string>("SecurityStamp");

                    b.Property<bool>("TwoFactorEnabled");

                    b.Property<string>("UserName")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers");

                    b.HasDiscriminator<string>("Discriminator").HasValue("IdentityUser");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasMaxLength(128);

                    b.Property<string>("ProviderKey")
                        .HasMaxLength(128);

                    b.Property<string>("ProviderDisplayName");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("RoleId");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("LoginProvider")
                        .HasMaxLength(128);

                    b.Property<string>("Name")
                        .HasMaxLength(128);

                    b.Property<string>("Value");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens");
                });

            modelBuilder.Entity("DonationPickUpServices.Models.ApplicationUser", b =>
                {
                    b.HasBaseType("Microsoft.AspNetCore.Identity.IdentityUser");

                    b.Property<string>("Address")
                        .IsRequired();

                    b.Property<string>("City")
                        .IsRequired();

                    b.Property<string>("FirstName")
                        .IsRequired();

                    b.Property<string>("LastName")
                        .IsRequired();

                    b.Property<string>("State")
                        .IsRequired();

                    b.Property<string>("UserPhoneNumber")
                        .IsRequired();

                    b.Property<int>("UserTypeId");

                    b.Property<string>("ZipCode")
                        .IsRequired();

                    b.HasIndex("UserTypeId");

                    b.ToTable("ApplicationUser");

                    b.HasDiscriminator().HasValue("ApplicationUser");

                    b.HasData(
                        new { Id = "452830a2-a348-4e1b-94b7-8f3b3f8330c0", AccessFailedCount = 0, ConcurrencyStamp = "cc0ca400-37d7-4662-9a59-673a550945bb", Email = "madisonpeper@gmail.com", EmailConfirmed = false, LockoutEnabled = false, PasswordHash = "AQAAAAEAACcQAAAAEO1yM8HMWc0OKegIUzqGIyQtJy0867s+7D/V2ThbFOTryVciE35AHbxwnDHuql24Qg==", PhoneNumberConfirmed = false, TwoFactorEnabled = false, Address = "1000 Nunya Business Dr", City = "Nashville", FirstName = "Madison", LastName = "Peper", State = "Tennessee", UserPhoneNumber = "6158122717", UserTypeId = 2, ZipCode = "37209" },
                        new { Id = "cb60afa5-d6b7-4773-8f49-b9d31f55a454", AccessFailedCount = 0, ConcurrencyStamp = "e5dfca2c-3cdc-4f2d-8429-20449861b5a5", Email = "russell@nanney.com", EmailConfirmed = false, LockoutEnabled = false, PasswordHash = "AQAAAAEAACcQAAAAENyMPhJ6urPK6kYN3Pg169k2pZ+dDXtPBnURU5YC9RHBQDrstxu3z3WuTwZ0F1I6fQ==", PhoneNumberConfirmed = false, TwoFactorEnabled = false, Address = "2020 Nowhere Circle", City = "Nashville", FirstName = "Russell", LastName = "Nanney", State = "Tennessee", UserPhoneNumber = "6152098318", UserTypeId = 4, ZipCode = "37209" },
                        new { Id = "720a80ca-6217-4759-924a-58c8036bd0c2", AccessFailedCount = 0, ConcurrencyStamp = "2fd368e1-7a0a-46a2-8c4f-50e4642bbf76", Email = "stephanie@risch.com", EmailConfirmed = false, LockoutEnabled = false, PasswordHash = "AQAAAAEAACcQAAAAED/dCDhRnAmpNk/88DetVRN0m/NfeDh85/8ks1+R1QbMqzGIOfUklKKBw4VzSH/YNQ==", PhoneNumberConfirmed = false, TwoFactorEnabled = false, Address = "1060 OuttaMy Way", City = "Nashville", FirstName = "Stephanie", LastName = "Risch", State = "Tennessee", UserPhoneNumber = "6151234567", UserTypeId = 4, ZipCode = "37221" },
                        new { Id = "a14ec0d0-c55d-42f8-b607-81a8dcb71ffb", AccessFailedCount = 0, ConcurrencyStamp = "11a4703e-d865-4f30-b3b2-4b146c867cab", Email = "parker@kelley.com", EmailConfirmed = false, LockoutEnabled = false, PasswordHash = "AQAAAAEAACcQAAAAEKHgNuZWi5P5MxGR4y1+LvdN+rYM6SSZHxtVlanr3a1J8tX3CuNphUhWNW7m8wmX+w==", PhoneNumberConfirmed = false, TwoFactorEnabled = false, Address = "1509 Rainbow St", City = "Nashville", FirstName = "Parker", LastName = "Kelley", State = "Tennessee", UserPhoneNumber = "6150987654", UserTypeId = 2, ZipCode = "37212" }
                    );
                });

            modelBuilder.Entity("DonationPickUpServices.Models.Donation", b =>
                {
                    b.HasOne("DonationPickUpServices.Models.Status", "Status")
                        .WithMany()
                        .HasForeignKey("StatusId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("DonationPickUpServices.Models.Item", b =>
                {
                    b.HasOne("DonationPickUpServices.Models.ApplicationUser", "ApplicationUser")
                        .WithMany("Items")
                        .HasForeignKey("ApplicationUserId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("DonationPickUpServices.Models.Donation", "Donation")
                        .WithMany("Items")
                        .HasForeignKey("DonationId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("DonationPickUpServices.Models.ItemType", "ItemType")
                        .WithMany("Items")
                        .HasForeignKey("ItemTypeId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("DonationPickUpServices.Models.ApplicationUser", b =>
                {
                    b.HasOne("DonationPickUpServices.Models.UserType", "UserType")
                        .WithMany()
                        .HasForeignKey("UserTypeId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
