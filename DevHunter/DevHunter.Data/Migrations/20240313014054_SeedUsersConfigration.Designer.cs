﻿// <auto-generated />
using System;
using DevHunter.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace DevHunter.Data.Migrations
{
    [DbContext(typeof(DevHunterDbContext))]
    [Migration("20240313014054_SeedUsersConfigration")]
    partial class SeedUsersConfigration
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.25")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("DevHunter.Data.Models.ApplicationUser", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers", (string)null);

                    b.HasData(
                        new
                        {
                            Id = new Guid("8a5edc49-7490-493f-2f01-08db8a416485"),
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "fe4d861b-aa29-45b6-be62-5203e744fe42",
                            Email = "admin@gmail.com",
                            EmailConfirmed = false,
                            LockoutEnabled = false,
                            NormalizedEmail = "ADMIN@GMAIL.COM",
                            NormalizedUserName = "ADMIN@GMAIL.COM",
                            PasswordHash = "AQAAAAEAACcQAAAAEKixlLbYWabPTbj/HGNxO1pkVE3rBuuKThr0zcKMxQVgtno0MbfLodPiYSpzSMxRbQ==",
                            PhoneNumberConfirmed = false,
                            TwoFactorEnabled = false,
                            UserName = "admin@gmail.com"
                        },
                        new
                        {
                            Id = new Guid("f06d4765-779a-4766-eb64-08db8a42133c"),
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "71c0c430-fce0-4483-8cf4-aa80b1b95c4a",
                            Email = "defi@gmail.com",
                            EmailConfirmed = false,
                            LockoutEnabled = false,
                            NormalizedEmail = "DEFI@GMAIL.COM",
                            NormalizedUserName = "DEFI@GMAIL.COM",
                            PasswordHash = "AQAAAAEAACcQAAAAEPFfnmmNot3ipvM6PfHtfcwT28HAIOx/ofbQRo19v54OwJxDU3BKFiWPMM1xwzfKLA==",
                            PhoneNumberConfirmed = false,
                            TwoFactorEnabled = false,
                            UserName = "defi@gmail.com"
                        },
                        new
                        {
                            Id = new Guid("f2525385-0162-4b42-8fa5-08db8a43496a"),
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "f9b1c52f-ce5c-43e1-b51b-4588d06a5d97",
                            Email = "pesho_petrov@yahoo.com",
                            EmailConfirmed = false,
                            LockoutEnabled = false,
                            NormalizedEmail = "PESHO_PETROV@YAHOO.COM",
                            NormalizedUserName = "PESHO_PETROV@YAHOO.COM",
                            PasswordHash = "AQAAAAEAACcQAAAAEIKHpdv/ceOVjOl09eM9XR4aSY/4dvSJGXT10VZgaJSe1TGd5/dnmOmGPhfTjNn6xg==",
                            PhoneNumberConfirmed = false,
                            TwoFactorEnabled = false,
                            UserName = "pesho_petrov@yahoo.com"
                        });
                });

            modelBuilder.Entity("DevHunter.Data.Models.Company", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Activity")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("CreatorId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int?>("EmployeeCount")
                        .HasColumnType("int");

                    b.Property<DateTime?>("FoundedYear")
                        .HasColumnType("datetime2");

                    b.Property<string>("ImageUrl")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Location")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Sector")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("WebsiteUrl")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("WorkingHoursPerDay")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CreatorId");

                    b.ToTable("Companies");
                });

            modelBuilder.Entity("DevHunter.Data.Models.CompanyTechnologies", b =>
                {
                    b.Property<Guid>("CompanyId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("TechnologyId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("CompanyId", "TechnologyId");

                    b.HasIndex("TechnologyId");

                    b.ToTable("CompanyTechnologies");
                });

            modelBuilder.Entity("DevHunter.Data.Models.Development", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("ImageUrl")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Developments");
                });

            modelBuilder.Entity("DevHunter.Data.Models.JobOffer", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("CompanyId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreatedOn")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(2147483647)
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("JobPosition")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal?>("MaxSalary")
                        .HasPrecision(18, 2)
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal?>("MinSalary")
                        .HasPrecision(18, 2)
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("PlaceToWork")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("Seniority")
                        .HasColumnType("int");

                    b.Property<string>("WorkingExperience")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("WorkingHours")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CompanyId");

                    b.ToTable("JobOffers");
                });

            modelBuilder.Entity("DevHunter.Data.Models.SavedJobOffer", b =>
                {
                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("JobOfferId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.HasKey("UserId", "JobOfferId");

                    b.HasIndex("JobOfferId");

                    b.ToTable("SavedJobOffers");
                });

            modelBuilder.Entity("DevHunter.Data.Models.Technology", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("ImageUrl")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Technologies");

                    b.HasData(
                        new
                        {
                            Id = new Guid("8ebcb369-1519-4f31-b996-170bd8fbb45d"),
                            ImageUrl = "http://res.cloudinary.com/dlffxtrek/image/upload/v1709491632/DevHunter/technology/Go.png",
                            Name = "Go"
                        },
                        new
                        {
                            Id = new Guid("c0243c0e-9237-4e05-ba19-c8850e353434"),
                            ImageUrl = "http://res.cloudinary.com/dlffxtrek/image/upload/v1709496382/DevHunter/technology/HTML5.png",
                            Name = "Html5"
                        },
                        new
                        {
                            Id = new Guid("2f938bc9-ac5e-4dee-9393-6b759a4dc048"),
                            ImageUrl = "http://res.cloudinary.com/dlffxtrek/image/upload/v1709495915/DevHunter/technology/Kubernetes.png",
                            Name = "Kubernetes"
                        },
                        new
                        {
                            Id = new Guid("dfda9dff-ba4f-48b9-943f-f1011f8777a6"),
                            ImageUrl = "http://res.cloudinary.com/dlffxtrek/image/upload/v1709496039/DevHunter/technology/Apache.png",
                            Name = "Apache"
                        },
                        new
                        {
                            Id = new Guid("7c3ab177-16f4-4fef-b1da-81be79a75a63"),
                            ImageUrl = "http://res.cloudinary.com/dlffxtrek/image/upload/v1709496307/DevHunter/technology/Angular.png",
                            Name = "Angular"
                        },
                        new
                        {
                            Id = new Guid("e144e9a4-4da4-4dfb-a8b8-1cb630102d8f"),
                            ImageUrl = "http://res.cloudinary.com/dlffxtrek/image/upload/v1709495970/DevHunter/technology/Javascript.png",
                            Name = "Javascript"
                        },
                        new
                        {
                            Id = new Guid("a69ae21a-42f1-4ab7-bd6a-de0ac18d5596"),
                            ImageUrl = "http://res.cloudinary.com/dlffxtrek/image/upload/v1709491632/DevHunter/technology/Go.png",
                            Name = "Go"
                        },
                        new
                        {
                            Id = new Guid("1a54e033-bef5-47c0-80c7-1cf01d463be9"),
                            ImageUrl = "http://res.cloudinary.com/dlffxtrek/image/upload/v1709496353/DevHunter/technology/Gitlab.jpg",
                            Name = "Gitlab"
                        },
                        new
                        {
                            Id = new Guid("7dc12f1a-d3db-43cf-adff-374212722a5d"),
                            ImageUrl = "http://res.cloudinary.com/dlffxtrek/image/upload/v1709495888/DevHunter/technology/CSS.png",
                            Name = "CSS"
                        },
                        new
                        {
                            Id = new Guid("0c5da6a9-4336-4dad-902c-e90582e6a9a5"),
                            ImageUrl = "http://res.cloudinary.com/dlffxtrek/image/upload/v1709495873/DevHunter/technology/Bootstrap.png",
                            Name = "Bootstrap"
                        },
                        new
                        {
                            Id = new Guid("682c55d1-7674-432e-882b-715f89ee55df"),
                            ImageUrl = "http://res.cloudinary.com/dlffxtrek/image/upload/v1709495988/DevHunter/technology/React.png",
                            Name = "React"
                        },
                        new
                        {
                            Id = new Guid("c53dc983-d355-4e33-af97-14b782185906"),
                            ImageUrl = "http://res.cloudinary.com/dlffxtrek/image/upload/v1709496410/DevHunter/technology/Python.png",
                            Name = "Python"
                        },
                        new
                        {
                            Id = new Guid("de192ea4-9464-4f44-bfa2-82b4e278c1bb"),
                            ImageUrl = "http://res.cloudinary.com/dlffxtrek/image/upload/v1709495978/DevHunter/technology/Django.png",
                            Name = "Django"
                        },
                        new
                        {
                            Id = new Guid("03f00a4d-5946-4bfc-9bf8-d986e13f2763"),
                            ImageUrl = "http://res.cloudinary.com/dlffxtrek/image/upload/v1709496008/DevHunter/technology/MongoDb.png",
                            Name = "MongoDb"
                        },
                        new
                        {
                            Id = new Guid("a007d83f-75ff-49b6-885e-adb4e8197c22"),
                            ImageUrl = "http://res.cloudinary.com/dlffxtrek/image/upload/v1709496318/DevHunter/technology/Ansible.png",
                            Name = "Ansible"
                        },
                        new
                        {
                            Id = new Guid("63b3d599-8bce-4f77-95b1-ee835e7cfcdf"),
                            ImageUrl = "http://res.cloudinary.com/dlffxtrek/image/upload/v1709495978/DevHunter/technology/Django.png",
                            Name = "Django"
                        },
                        new
                        {
                            Id = new Guid("804926af-71c1-4b96-b255-7e0796224468"),
                            ImageUrl = "http://res.cloudinary.com/dlffxtrek/image/upload/v1709496362/DevHunter/technology/Flink.png",
                            Name = "Flink"
                        },
                        new
                        {
                            Id = new Guid("acb2f9f7-d0e9-4079-9ba0-b9b4a4149035"),
                            ImageUrl = "http://res.cloudinary.com/dlffxtrek/image/upload/v1709496341/DevHunter/technology/Ecma.png",
                            Name = "Ecma"
                        },
                        new
                        {
                            Id = new Guid("551d3877-bc1b-4734-8845-fc001b120bc5"),
                            ImageUrl = "http://res.cloudinary.com/dlffxtrek/image/upload/v1709495925/DevHunter/technology/Linux.png",
                            Name = "Linux"
                        },
                        new
                        {
                            Id = new Guid("e2fbe483-b20b-4caa-bf47-da78b1df950d"),
                            ImageUrl = "http://res.cloudinary.com/dlffxtrek/image/upload/v1709496395/DevHunter/technology/Typescript.png",
                            Name = "Typescript"
                        },
                        new
                        {
                            Id = new Guid("40753a55-7ba3-4c53-b742-b9ba9cd11170"),
                            ImageUrl = "http://res.cloudinary.com/dlffxtrek/image/upload/v1709495940/DevHunter/technology/MariaDb.png",
                            Name = "MariaDb"
                        },
                        new
                        {
                            Id = new Guid("b4df498b-e900-44ff-b6c9-9c4b4af09e82"),
                            ImageUrl = "http://res.cloudinary.com/dlffxtrek/image/upload/v1709495957/DevHunter/technology/Nodejs.png",
                            Name = "Nodejs"
                        },
                        new
                        {
                            Id = new Guid("06fb55df-500a-4bf3-a64c-579034ceb0ad"),
                            ImageUrl = "http://res.cloudinary.com/dlffxtrek/image/upload/v1709495897/DevHunter/technology/Docker.jpg",
                            Name = "Docker"
                        },
                        new
                        {
                            Id = new Guid("bd168209-fa3b-42dc-b613-6327d23036fd"),
                            ImageUrl = "http://res.cloudinary.com/dlffxtrek/image/upload/v1709496838/DevHunter/technology/Vue.png",
                            Name = "Vue"
                        });
                });

            modelBuilder.Entity("DevHunter.Data.Models.TechnologyDevelopments", b =>
                {
                    b.Property<Guid>("TechnologyId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("DevelopmentId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("TechnologyId", "DevelopmentId");

                    b.HasIndex("DevelopmentId");

                    b.ToTable("TechnologiesDevelopments");
                });

            modelBuilder.Entity("DevHunter.Data.Models.TechnologyJobOffers", b =>
                {
                    b.Property<Guid>("JobOfferId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("TechnologyId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("JobOfferId", "TechnologyId");

                    b.HasIndex("TechnologyId");

                    b.ToTable("TechnologyJobOffers");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole<System.Guid>", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<System.Guid>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("RoleId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<System.Guid>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<System.Guid>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("ProviderKey")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<System.Guid>", b =>
                {
                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("RoleId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<System.Guid>", b =>
                {
                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("LoginProvider")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("Name")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens", (string)null);
                });

            modelBuilder.Entity("DevHunter.Data.Models.Company", b =>
                {
                    b.HasOne("DevHunter.Data.Models.ApplicationUser", "Creator")
                        .WithMany("Companies")
                        .HasForeignKey("CreatorId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Creator");
                });

            modelBuilder.Entity("DevHunter.Data.Models.CompanyTechnologies", b =>
                {
                    b.HasOne("DevHunter.Data.Models.Company", "Company")
                        .WithMany("UsedTechnologies")
                        .HasForeignKey("CompanyId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DevHunter.Data.Models.Technology", "Technology")
                        .WithMany("CompanyTechnologies")
                        .HasForeignKey("TechnologyId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Company");

                    b.Navigation("Technology");
                });

            modelBuilder.Entity("DevHunter.Data.Models.JobOffer", b =>
                {
                    b.HasOne("DevHunter.Data.Models.Company", "Company")
                        .WithMany()
                        .HasForeignKey("CompanyId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Company");
                });

            modelBuilder.Entity("DevHunter.Data.Models.SavedJobOffer", b =>
                {
                    b.HasOne("DevHunter.Data.Models.JobOffer", "JobOffer")
                        .WithMany("SavedJobOffers")
                        .HasForeignKey("JobOfferId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DevHunter.Data.Models.ApplicationUser", "User")
                        .WithMany("SavedJobOffers")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("JobOffer");

                    b.Navigation("User");
                });

            modelBuilder.Entity("DevHunter.Data.Models.TechnologyDevelopments", b =>
                {
                    b.HasOne("DevHunter.Data.Models.Development", "Development")
                        .WithMany("TechnologyDevelopments")
                        .HasForeignKey("DevelopmentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DevHunter.Data.Models.Technology", "Technology")
                        .WithMany("TechnologyDevelopments")
                        .HasForeignKey("TechnologyId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Development");

                    b.Navigation("Technology");
                });

            modelBuilder.Entity("DevHunter.Data.Models.TechnologyJobOffers", b =>
                {
                    b.HasOne("DevHunter.Data.Models.JobOffer", "JobOffer")
                        .WithMany("TechnologyJobOffers")
                        .HasForeignKey("JobOfferId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DevHunter.Data.Models.Technology", "Technology")
                        .WithMany("TechnologyJobOffers")
                        .HasForeignKey("TechnologyId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("JobOffer");

                    b.Navigation("Technology");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<System.Guid>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole<System.Guid>", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<System.Guid>", b =>
                {
                    b.HasOne("DevHunter.Data.Models.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<System.Guid>", b =>
                {
                    b.HasOne("DevHunter.Data.Models.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<System.Guid>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole<System.Guid>", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DevHunter.Data.Models.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<System.Guid>", b =>
                {
                    b.HasOne("DevHunter.Data.Models.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("DevHunter.Data.Models.ApplicationUser", b =>
                {
                    b.Navigation("Companies");

                    b.Navigation("SavedJobOffers");
                });

            modelBuilder.Entity("DevHunter.Data.Models.Company", b =>
                {
                    b.Navigation("UsedTechnologies");
                });

            modelBuilder.Entity("DevHunter.Data.Models.Development", b =>
                {
                    b.Navigation("TechnologyDevelopments");
                });

            modelBuilder.Entity("DevHunter.Data.Models.JobOffer", b =>
                {
                    b.Navigation("SavedJobOffers");

                    b.Navigation("TechnologyJobOffers");
                });

            modelBuilder.Entity("DevHunter.Data.Models.Technology", b =>
                {
                    b.Navigation("CompanyTechnologies");

                    b.Navigation("TechnologyDevelopments");

                    b.Navigation("TechnologyJobOffers");
                });
#pragma warning restore 612, 618
        }
    }
}