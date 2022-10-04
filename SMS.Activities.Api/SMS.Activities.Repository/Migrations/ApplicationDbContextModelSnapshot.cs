﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SMS.Activities.Repository.Context;

#nullable disable

namespace SMS.Activities.Repository.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "6.0.9");

            modelBuilder.Entity("SMS.Activities.Domain.Models.Activity", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Content")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("CreatedDate")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT")
                        .HasDefaultValue(new DateTime(2022, 10, 3, 22, 18, 20, 553, DateTimeKind.Local).AddTicks(4821));

                    b.Property<DateTime>("DeadLine")
                        .HasColumnType("TEXT");

                    b.Property<long>("TeacherId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.ToTable("Activity");
                });
#pragma warning restore 612, 618
        }
    }
}
