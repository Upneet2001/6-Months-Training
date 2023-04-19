﻿// <auto-generated />
using BackEnd.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace BackEnd.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20230418071706_Initial")]
    partial class Initial
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "7.0.5");

            modelBuilder.Entity("BackEnd.Models.Attendee", b =>
                {
                    b.Property<int>("Attendee_id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("Attendee_contact")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Attendee_email")
                        .HasColumnType("TEXT");

                    b.Property<string>("Attendee_name")
                        .HasMaxLength(200)
                        .HasColumnType("TEXT");

                    b.Property<string>("Facebook_id")
                        .HasMaxLength(4000)
                        .HasColumnType("TEXT");

                    b.Property<string>("Linkedin_id")
                        .HasColumnType("TEXT");

                    b.Property<string>("git")
                        .HasColumnType("TEXT");

                    b.HasKey("Attendee_id");

                    b.ToTable("Attendee");
                });

            modelBuilder.Entity("BackEnd.Models.Session", b =>
                {
                    b.Property<int>("Session_id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Description")
                        .HasMaxLength(4000)
                        .HasColumnType("TEXT");

                    b.Property<string>("Location")
                        .HasColumnType("TEXT");

                    b.Property<int>("Session_date")
                        .HasColumnType("INTEGER");

                    b.Property<int>("Speaker_id")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Topic")
                        .HasMaxLength(200)
                        .HasColumnType("TEXT");

                    b.HasKey("Session_id");

                    b.ToTable("Session");
                });

            modelBuilder.Entity("BackEnd.Models.Speaker", b =>
                {
                    b.Property<int>("Speaker_id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("About_Experience")
                        .HasColumnType("TEXT");

                    b.Property<string>("Facebook_id")
                        .HasMaxLength(4000)
                        .HasColumnType("TEXT");

                    b.Property<string>("Interest")
                        .HasColumnType("TEXT");

                    b.Property<string>("Linkedin_id")
                        .HasColumnType("TEXT");

                    b.Property<string>("Speaker_name")
                        .HasMaxLength(200)
                        .HasColumnType("TEXT");

                    b.Property<string>("WebSite")
                        .HasMaxLength(1000)
                        .HasColumnType("TEXT");

                    b.Property<string>("bio")
                        .HasColumnType("TEXT");

                    b.Property<string>("git")
                        .HasColumnType("TEXT");

                    b.Property<string>("twitter")
                        .HasColumnType("TEXT");

                    b.HasKey("Speaker_id");

                    b.ToTable("Speakers");
                });
#pragma warning restore 612, 618
        }
    }
}
