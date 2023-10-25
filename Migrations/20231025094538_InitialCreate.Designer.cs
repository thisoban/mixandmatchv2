﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using mixandmatchv2;

#nullable disable

namespace mixandmatchv2.Migrations
{
    [DbContext(typeof(MMContext))]
    [Migration("20231025094538_InitialCreate")]
    partial class InitialCreate
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.13")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("mixandmatchv2.Job", b =>
                {
                    b.Property<Guid>("jobid")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<string>("jobdescription")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("jobname")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("jobtype")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("jobid");

                    b.ToTable("Jobs");
                });
#pragma warning restore 612, 618
        }
    }
}
