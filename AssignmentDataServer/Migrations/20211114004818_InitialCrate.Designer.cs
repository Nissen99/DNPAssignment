﻿// <auto-generated />
using System;
using AssignmentDataServer.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace AssignmentDataServer.Migrations
{
    [DbContext(typeof(DatabaseContext))]
    [Migration("20211114004818_InitialCrate")]
    partial class InitialCrate
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "5.0.12");

            modelBuilder.Entity("AssignmentDataServer.Data.Role", b =>
                {
                    b.Property<string>("RoleName")
                        .HasColumnType("TEXT");

                    b.Property<string>("Username")
                        .HasColumnType("TEXT");

                    b.HasKey("RoleName");

                    b.HasIndex("Username");

                    b.ToTable("Role");
                });

            modelBuilder.Entity("AssignmentDataServer.Data.User", b =>
                {
                    b.Property<string>("Username")
                        .HasColumnType("TEXT");

                    b.Property<string>("Password")
                        .HasColumnType("TEXT");

                    b.HasKey("Username");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("AssignmentDataServer.Models.Family", b =>
                {
                    b.Property<string>("StreetName")
                        .HasColumnType("TEXT");

                    b.Property<int>("HouseNumber")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT");

                    b.HasKey("StreetName", "HouseNumber");

                    b.ToTable("Families");
                });

            modelBuilder.Entity("AssignmentDataServer.Models.Interest", b =>
                {
                    b.Property<int>("InterestId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int?>("ChildId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Description")
                        .HasColumnType("TEXT");

                    b.Property<string>("Type")
                        .HasColumnType("TEXT");

                    b.HasKey("InterestId");

                    b.HasIndex("ChildId");

                    b.ToTable("Interests");
                });

            modelBuilder.Entity("AssignmentDataServer.Models.Job", b =>
                {
                    b.Property<int>("JobId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("JobTitle")
                        .HasColumnType("TEXT");

                    b.Property<int?>("Salary")
                        .HasColumnType("INTEGER");

                    b.HasKey("JobId");

                    b.ToTable("Jobs");
                });

            modelBuilder.Entity("AssignmentDataServer.Models.Person", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("Age")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Discriminator")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("EyeColor")
                        .HasColumnType("TEXT");

                    b.Property<string>("FirstName")
                        .HasColumnType("TEXT");

                    b.Property<string>("HairColor")
                        .HasColumnType("TEXT");

                    b.Property<int>("Height")
                        .HasColumnType("INTEGER");

                    b.Property<string>("LastName")
                        .HasColumnType("TEXT");

                    b.Property<string>("Sex")
                        .HasColumnType("TEXT");

                    b.Property<float>("Weight")
                        .HasColumnType("REAL");

                    b.HasKey("Id");

                    b.ToTable("Persons");

                    b.HasDiscriminator<string>("Discriminator").HasValue("Person");
                });

            modelBuilder.Entity("AssignmentDataServer.Models.Pet", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("Age")
                        .HasColumnType("INTEGER");

                    b.Property<int?>("ChildId")
                        .HasColumnType("INTEGER");

                    b.Property<int?>("FamilyHouseNumber")
                        .HasColumnType("INTEGER");

                    b.Property<string>("FamilyStreetName")
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT");

                    b.Property<string>("Species")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("ChildId");

                    b.HasIndex("FamilyStreetName", "FamilyHouseNumber");

                    b.ToTable("Pets");
                });

            modelBuilder.Entity("AssignmentDataServer.Models.Adult", b =>
                {
                    b.HasBaseType("AssignmentDataServer.Models.Person");

                    b.Property<int?>("FamilyHouseNumber")
                        .HasColumnType("INTEGER")
                        .HasColumnName("Adult_FamilyHouseNumber");

                    b.Property<string>("FamilyStreetName")
                        .HasColumnType("TEXT")
                        .HasColumnName("Adult_FamilyStreetName");

                    b.Property<int?>("JobId")
                        .HasColumnType("INTEGER");

                    b.HasIndex("JobId");

                    b.HasIndex("FamilyStreetName", "FamilyHouseNumber");

                    b.HasDiscriminator().HasValue("Adult");
                });

            modelBuilder.Entity("AssignmentDataServer.Models.Child", b =>
                {
                    b.HasBaseType("AssignmentDataServer.Models.Person");

                    b.Property<int?>("FamilyHouseNumber")
                        .HasColumnType("INTEGER");

                    b.Property<string>("FamilyStreetName")
                        .HasColumnType("TEXT");

                    b.HasIndex("FamilyStreetName", "FamilyHouseNumber");

                    b.HasDiscriminator().HasValue("Child");
                });

            modelBuilder.Entity("AssignmentDataServer.Data.Role", b =>
                {
                    b.HasOne("AssignmentDataServer.Data.User", null)
                        .WithMany("Roles")
                        .HasForeignKey("Username");
                });

            modelBuilder.Entity("AssignmentDataServer.Models.Interest", b =>
                {
                    b.HasOne("AssignmentDataServer.Models.Child", null)
                        .WithMany("Interests")
                        .HasForeignKey("ChildId");
                });

            modelBuilder.Entity("AssignmentDataServer.Models.Pet", b =>
                {
                    b.HasOne("AssignmentDataServer.Models.Child", null)
                        .WithMany("Pets")
                        .HasForeignKey("ChildId");

                    b.HasOne("AssignmentDataServer.Models.Family", null)
                        .WithMany("Pets")
                        .HasForeignKey("FamilyStreetName", "FamilyHouseNumber");
                });

            modelBuilder.Entity("AssignmentDataServer.Models.Adult", b =>
                {
                    b.HasOne("AssignmentDataServer.Models.Job", "Job")
                        .WithMany()
                        .HasForeignKey("JobId");

                    b.HasOne("AssignmentDataServer.Models.Family", null)
                        .WithMany("Adults")
                        .HasForeignKey("FamilyStreetName", "FamilyHouseNumber");

                    b.Navigation("Job");
                });

            modelBuilder.Entity("AssignmentDataServer.Models.Child", b =>
                {
                    b.HasOne("AssignmentDataServer.Models.Family", null)
                        .WithMany("Children")
                        .HasForeignKey("FamilyStreetName", "FamilyHouseNumber");
                });

            modelBuilder.Entity("AssignmentDataServer.Data.User", b =>
                {
                    b.Navigation("Roles");
                });

            modelBuilder.Entity("AssignmentDataServer.Models.Family", b =>
                {
                    b.Navigation("Adults");

                    b.Navigation("Children");

                    b.Navigation("Pets");
                });

            modelBuilder.Entity("AssignmentDataServer.Models.Child", b =>
                {
                    b.Navigation("Interests");

                    b.Navigation("Pets");
                });
#pragma warning restore 612, 618
        }
    }
}