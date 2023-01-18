﻿// <auto-generated />
using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using Tema.Models;

#nullable disable

namespace Tema.Migrations
{
    [DbContext(typeof(MyAppContext))]
    partial class MyAppContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("Tema.Models.Companies.Company", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<Guid>("CreatorId")
                        .HasColumnType("uuid");

                    b.Property<DateTime?>("DateCreated")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Location")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Logo")
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("Name")
                        .IsUnique();

                    b.ToTable("Companies");
                });

            modelBuilder.Entity("Tema.Models.Jobs.Job", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("Category")
                        .HasColumnType("text");

                    b.Property<DateTime?>("DateCreated")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Location")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<long>("PostId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("PostId"));

                    b.Property<string>("Salary")
                        .HasColumnType("text");

                    b.Property<Guid>("SeekerId")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasIndex("SeekerId");

                    b.ToTable("Jobs");
                });

            modelBuilder.Entity("Tema.Models.ManyToMany.Applicant", b =>
                {
                    b.Property<Guid>("FinderId")
                        .HasColumnType("uuid");

                    b.Property<Guid>("JobId")
                        .HasColumnType("uuid");

                    b.Property<bool>("Accepted")
                        .HasColumnType("boolean");

                    b.Property<DateTime?>("DateAnswered")
                        .HasColumnType("timestamp without time zone");

                    b.Property<DateTime>("DateApplied")
                        .HasColumnType("timestamp without time zone");

                    b.HasKey("FinderId", "JobId");

                    b.HasIndex("JobId");

                    b.ToTable("Applicants");
                });

            modelBuilder.Entity("Tema.Models.Users.Finder.Finder", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("About")
                        .HasColumnType("text");

                    b.Property<DateTime?>("DateCreated")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("PasswordHash")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("ProfilePicture")
                        .HasColumnType("text");

                    b.Property<string>("Resume")
                        .HasColumnType("text");

                    b.Property<int>("Role")
                        .HasColumnType("integer");

                    b.Property<List<string>>("Skills")
                        .IsRequired()
                        .HasColumnType("text[]");

                    b.HasKey("Id");

                    b.HasIndex("Email")
                        .IsUnique();

                    b.ToTable("Finders");
                });

            modelBuilder.Entity("Tema.Models.Users.Seeker.Seeker", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<Guid>("CompanyId")
                        .HasColumnType("uuid");

                    b.Property<DateTime?>("DateCreated")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<bool>("IsCreator")
                        .HasColumnType("boolean");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("PasswordHash")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("ProfilePicture")
                        .HasColumnType("text");

                    b.Property<int>("Role")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("CompanyId");

                    b.HasIndex("Email")
                        .IsUnique();

                    b.ToTable("Seekers");
                });

            modelBuilder.Entity("Tema.Models.Jobs.Job", b =>
                {
                    b.HasOne("Tema.Models.Users.Seeker.Seeker", "Seeker")
                        .WithMany("ListedJobs")
                        .HasForeignKey("SeekerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Seeker");
                });

            modelBuilder.Entity("Tema.Models.ManyToMany.Applicant", b =>
                {
                    b.HasOne("Tema.Models.Users.Finder.Finder", "Finder")
                        .WithMany("JobApplications")
                        .HasForeignKey("FinderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Tema.Models.Jobs.Job", "Job")
                        .WithMany("Applicants")
                        .HasForeignKey("JobId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Finder");

                    b.Navigation("Job");
                });

            modelBuilder.Entity("Tema.Models.Users.Seeker.Seeker", b =>
                {
                    b.HasOne("Tema.Models.Companies.Company", "Company")
                        .WithMany("Employees")
                        .HasForeignKey("CompanyId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Company");
                });

            modelBuilder.Entity("Tema.Models.Companies.Company", b =>
                {
                    b.Navigation("Employees");
                });

            modelBuilder.Entity("Tema.Models.Jobs.Job", b =>
                {
                    b.Navigation("Applicants");
                });

            modelBuilder.Entity("Tema.Models.Users.Finder.Finder", b =>
                {
                    b.Navigation("JobApplications");
                });

            modelBuilder.Entity("Tema.Models.Users.Seeker.Seeker", b =>
                {
                    b.Navigation("ListedJobs");
                });
#pragma warning restore 612, 618
        }
    }
}
