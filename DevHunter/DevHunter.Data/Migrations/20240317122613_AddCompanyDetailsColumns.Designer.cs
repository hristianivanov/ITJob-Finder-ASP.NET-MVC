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
    [Migration("20240317122613_AddCompanyDetailsColumns")]
    partial class AddCompanyDetailsColumns
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

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

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

                    b.Property<int?>("PaidVacationDays")
                        .HasColumnType("int");

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
                            Id = new Guid("f5c594f4-ed75-438d-9ab4-fd1c5ac1bdcb"),
                            ImageUrl = "http://res.cloudinary.com/dlffxtrek/image/upload/v1709491632/DevHunter/technology/Go.png",
                            Name = "Go"
                        },
                        new
                        {
                            Id = new Guid("7881243e-9142-4551-8828-00827abd53b8"),
                            ImageUrl = "http://res.cloudinary.com/dlffxtrek/image/upload/v1709496382/DevHunter/technology/HTML5.png",
                            Name = "Html5"
                        },
                        new
                        {
                            Id = new Guid("68c37025-c5cc-4e09-8878-92a6ee2607d2"),
                            ImageUrl = "http://res.cloudinary.com/dlffxtrek/image/upload/v1709495915/DevHunter/technology/Kubernetes.png",
                            Name = "Kubernetes"
                        },
                        new
                        {
                            Id = new Guid("4f02416f-01e1-4837-8aa4-60a7ead0bc66"),
                            ImageUrl = "http://res.cloudinary.com/dlffxtrek/image/upload/v1709496039/DevHunter/technology/Apache.png",
                            Name = "Apache"
                        },
                        new
                        {
                            Id = new Guid("79394630-ff56-47a5-b18e-3f4f3accdd0b"),
                            ImageUrl = "http://res.cloudinary.com/dlffxtrek/image/upload/v1709496307/DevHunter/technology/Angular.png",
                            Name = "Angular"
                        },
                        new
                        {
                            Id = new Guid("8c8d6277-6d50-4eea-93fb-3e78cf77f85d"),
                            ImageUrl = "http://res.cloudinary.com/dlffxtrek/image/upload/v1709495970/DevHunter/technology/Javascript.png",
                            Name = "Javascript"
                        },
                        new
                        {
                            Id = new Guid("373eca56-9862-43c7-9815-f6a83bb01107"),
                            ImageUrl = "http://res.cloudinary.com/dlffxtrek/image/upload/v1709491632/DevHunter/technology/Go.png",
                            Name = "Go"
                        },
                        new
                        {
                            Id = new Guid("93962e69-bb1d-4743-b4ca-90c0e6018efa"),
                            ImageUrl = "http://res.cloudinary.com/dlffxtrek/image/upload/v1709496353/DevHunter/technology/Gitlab.jpg",
                            Name = "Gitlab"
                        },
                        new
                        {
                            Id = new Guid("a2503f53-dac6-4f1c-8792-ca0801db32b6"),
                            ImageUrl = "http://res.cloudinary.com/dlffxtrek/image/upload/v1709495888/DevHunter/technology/CSS.png",
                            Name = "CSS"
                        },
                        new
                        {
                            Id = new Guid("5d3e2cb7-10f8-453a-8f0a-07a8feb260de"),
                            ImageUrl = "http://res.cloudinary.com/dlffxtrek/image/upload/v1709495873/DevHunter/technology/Bootstrap.png",
                            Name = "Bootstrap"
                        },
                        new
                        {
                            Id = new Guid("3e601a45-8257-4677-b4af-eff4da158b8f"),
                            ImageUrl = "http://res.cloudinary.com/dlffxtrek/image/upload/v1709495988/DevHunter/technology/React.png",
                            Name = "React"
                        },
                        new
                        {
                            Id = new Guid("94f8b926-378d-40ec-983b-c8fa3d5475aa"),
                            ImageUrl = "http://res.cloudinary.com/dlffxtrek/image/upload/v1709496410/DevHunter/technology/Python.png",
                            Name = "Python"
                        },
                        new
                        {
                            Id = new Guid("e7c8c758-6384-4765-a48c-8e0eb13f5ba3"),
                            ImageUrl = "http://res.cloudinary.com/dlffxtrek/image/upload/v1709495978/DevHunter/technology/Django.png",
                            Name = "Django"
                        },
                        new
                        {
                            Id = new Guid("65ebb9b7-f19a-4d4b-8fbe-4c802ce2ab82"),
                            ImageUrl = "http://res.cloudinary.com/dlffxtrek/image/upload/v1709496008/DevHunter/technology/MongoDb.png",
                            Name = "MongoDb"
                        },
                        new
                        {
                            Id = new Guid("bbabc9b1-ae0f-4667-af08-d49875e50c68"),
                            ImageUrl = "http://res.cloudinary.com/dlffxtrek/image/upload/v1709496318/DevHunter/technology/Ansible.png",
                            Name = "Ansible"
                        },
                        new
                        {
                            Id = new Guid("9c585fee-13a0-4dce-857f-1d3551e0d27a"),
                            ImageUrl = "http://res.cloudinary.com/dlffxtrek/image/upload/v1709495978/DevHunter/technology/Django.png",
                            Name = "Django"
                        },
                        new
                        {
                            Id = new Guid("32a46de8-8031-4423-b480-f9eaed02b42f"),
                            ImageUrl = "http://res.cloudinary.com/dlffxtrek/image/upload/v1709496362/DevHunter/technology/Flink.png",
                            Name = "Flink"
                        },
                        new
                        {
                            Id = new Guid("903ee453-b7a4-449e-bbf6-8ffc66ec9c1d"),
                            ImageUrl = "http://res.cloudinary.com/dlffxtrek/image/upload/v1709496341/DevHunter/technology/Ecma.png",
                            Name = "Ecma"
                        },
                        new
                        {
                            Id = new Guid("68861b7d-9baa-4694-bc64-72d95755f39d"),
                            ImageUrl = "http://res.cloudinary.com/dlffxtrek/image/upload/v1709495925/DevHunter/technology/Linux.png",
                            Name = "Linux"
                        },
                        new
                        {
                            Id = new Guid("5379dc42-996b-48b7-96ab-5faf91b4b3e7"),
                            ImageUrl = "http://res.cloudinary.com/dlffxtrek/image/upload/v1709496395/DevHunter/technology/Typescript.png",
                            Name = "Typescript"
                        },
                        new
                        {
                            Id = new Guid("ab21fe6f-cf43-4bcf-ae26-844fa4089705"),
                            ImageUrl = "http://res.cloudinary.com/dlffxtrek/image/upload/v1709495940/DevHunter/technology/MariaDb.png",
                            Name = "MariaDb"
                        },
                        new
                        {
                            Id = new Guid("a9b2e8a9-40a0-4d7b-91b0-f290f222c957"),
                            ImageUrl = "http://res.cloudinary.com/dlffxtrek/image/upload/v1709495957/DevHunter/technology/Nodejs.png",
                            Name = "Nodejs"
                        },
                        new
                        {
                            Id = new Guid("5b1503b0-77c4-4dd2-b944-fc711f2be42f"),
                            ImageUrl = "http://res.cloudinary.com/dlffxtrek/image/upload/v1709495897/DevHunter/technology/Docker.jpg",
                            Name = "Docker"
                        },
                        new
                        {
                            Id = new Guid("208168a0-b7c1-4d02-b23e-dc6f8190ee3e"),
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
                        .WithMany("JobOffers")
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
                    b.Navigation("JobOffers");

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
