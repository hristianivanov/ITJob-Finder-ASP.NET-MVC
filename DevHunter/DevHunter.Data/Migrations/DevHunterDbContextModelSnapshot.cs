﻿// <auto-generated />
using System;
using DevHunter.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace DevHunter.Data.Migrations
{
    [DbContext(typeof(DevHunterDbContext))]
    partial class DevHunterDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
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
                            Id = new Guid("d3d1e828-7dd0-4a50-a1ba-1bc0762be3c3"),
                            ImageUrl = "http://res.cloudinary.com/dlffxtrek/image/upload/v1709491632/DevHunter/technology/Go.png",
                            Name = "Go"
                        },
                        new
                        {
                            Id = new Guid("e9cfa32d-d49e-4f11-8508-81f1c01e5fd1"),
                            ImageUrl = "http://res.cloudinary.com/dlffxtrek/image/upload/v1709496382/DevHunter/technology/HTML5.png",
                            Name = "Html5"
                        },
                        new
                        {
                            Id = new Guid("b6176af4-69c7-46d4-8d88-54313e60fdad"),
                            ImageUrl = "http://res.cloudinary.com/dlffxtrek/image/upload/v1709495915/DevHunter/technology/Kubernetes.png",
                            Name = "Kubernetes"
                        },
                        new
                        {
                            Id = new Guid("6e2a190b-032c-493c-ba0b-5bf8979db8af"),
                            ImageUrl = "http://res.cloudinary.com/dlffxtrek/image/upload/v1709496039/DevHunter/technology/Apache.png",
                            Name = "Apache"
                        },
                        new
                        {
                            Id = new Guid("d73a5fe3-72f6-44b6-9770-3893a61eb341"),
                            ImageUrl = "http://res.cloudinary.com/dlffxtrek/image/upload/v1709496307/DevHunter/technology/Angular.png",
                            Name = "Angular"
                        },
                        new
                        {
                            Id = new Guid("27a27fd9-2823-4c58-8b31-bae732940f61"),
                            ImageUrl = "http://res.cloudinary.com/dlffxtrek/image/upload/v1709495970/DevHunter/technology/Javascript.png",
                            Name = "Javascript"
                        },
                        new
                        {
                            Id = new Guid("8bbaefc4-da12-43b0-aa8c-d0929c5317d8"),
                            ImageUrl = "http://res.cloudinary.com/dlffxtrek/image/upload/v1709491632/DevHunter/technology/Go.png",
                            Name = "Go"
                        },
                        new
                        {
                            Id = new Guid("eeb2eb5b-354f-4210-b26a-df1d8389b38d"),
                            ImageUrl = "http://res.cloudinary.com/dlffxtrek/image/upload/v1709496353/DevHunter/technology/Gitlab.jpg",
                            Name = "Gitlab"
                        },
                        new
                        {
                            Id = new Guid("e36dbbb8-6884-4446-b5ff-bacb1767ae9e"),
                            ImageUrl = "http://res.cloudinary.com/dlffxtrek/image/upload/v1709495888/DevHunter/technology/CSS.png",
                            Name = "CSS"
                        },
                        new
                        {
                            Id = new Guid("e7b98c94-aa79-417f-ba14-c6078e48220c"),
                            ImageUrl = "http://res.cloudinary.com/dlffxtrek/image/upload/v1709495873/DevHunter/technology/Bootstrap.png",
                            Name = "Bootstrap"
                        },
                        new
                        {
                            Id = new Guid("ad749c75-da8b-4d3c-8b1f-69ff97189c77"),
                            ImageUrl = "http://res.cloudinary.com/dlffxtrek/image/upload/v1709495988/DevHunter/technology/React.png",
                            Name = "React"
                        },
                        new
                        {
                            Id = new Guid("f760daac-2c09-43c7-81a0-15ff06951748"),
                            ImageUrl = "http://res.cloudinary.com/dlffxtrek/image/upload/v1709496410/DevHunter/technology/Python.png",
                            Name = "Python"
                        },
                        new
                        {
                            Id = new Guid("6a4a2dd8-1b9d-4247-bafc-32b4eb472ebd"),
                            ImageUrl = "http://res.cloudinary.com/dlffxtrek/image/upload/v1709495978/DevHunter/technology/Django.png",
                            Name = "Django"
                        },
                        new
                        {
                            Id = new Guid("e8404684-e4b9-4845-8c01-bcb9f1740f4d"),
                            ImageUrl = "http://res.cloudinary.com/dlffxtrek/image/upload/v1709496008/DevHunter/technology/MongoDb.png",
                            Name = "MongoDb"
                        },
                        new
                        {
                            Id = new Guid("2f74ac82-8e0d-4a37-8a35-a0104ada4409"),
                            ImageUrl = "http://res.cloudinary.com/dlffxtrek/image/upload/v1709496318/DevHunter/technology/Ansible.png",
                            Name = "Ansible"
                        },
                        new
                        {
                            Id = new Guid("db828c44-3b14-4f90-b37c-51a1e7799ec5"),
                            ImageUrl = "http://res.cloudinary.com/dlffxtrek/image/upload/v1709495978/DevHunter/technology/Django.png",
                            Name = "Django"
                        },
                        new
                        {
                            Id = new Guid("25ddbb09-f887-4af6-8964-41a60ab6f2ef"),
                            ImageUrl = "http://res.cloudinary.com/dlffxtrek/image/upload/v1709496362/DevHunter/technology/Flink.png",
                            Name = "Flink"
                        },
                        new
                        {
                            Id = new Guid("071f5d0b-f057-4cef-a3a3-ec1da0b1990e"),
                            ImageUrl = "http://res.cloudinary.com/dlffxtrek/image/upload/v1709496341/DevHunter/technology/Ecma.png",
                            Name = "Ecma"
                        },
                        new
                        {
                            Id = new Guid("42901f87-33d9-48a9-b4ab-db426aa2c0e1"),
                            ImageUrl = "http://res.cloudinary.com/dlffxtrek/image/upload/v1709495925/DevHunter/technology/Linux.png",
                            Name = "Linux"
                        },
                        new
                        {
                            Id = new Guid("cd142bb1-4e85-455a-8546-f819eb9745f5"),
                            ImageUrl = "http://res.cloudinary.com/dlffxtrek/image/upload/v1709496395/DevHunter/technology/Typescript.png",
                            Name = "Typescript"
                        },
                        new
                        {
                            Id = new Guid("94685d36-5c74-4900-9e5d-23e2253832f6"),
                            ImageUrl = "http://res.cloudinary.com/dlffxtrek/image/upload/v1709495940/DevHunter/technology/MariaDb.png",
                            Name = "MariaDb"
                        },
                        new
                        {
                            Id = new Guid("af0baf65-f1e1-4a81-a40d-27bcb8cba98e"),
                            ImageUrl = "http://res.cloudinary.com/dlffxtrek/image/upload/v1709495957/DevHunter/technology/Nodejs.png",
                            Name = "Nodejs"
                        },
                        new
                        {
                            Id = new Guid("a7d2e657-ecfd-4a21-bc39-31655ae81ccb"),
                            ImageUrl = "http://res.cloudinary.com/dlffxtrek/image/upload/v1709495897/DevHunter/technology/Docker.jpg",
                            Name = "Docker"
                        },
                        new
                        {
                            Id = new Guid("7aac0748-8702-44f0-abb2-50369f82a04d"),
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
