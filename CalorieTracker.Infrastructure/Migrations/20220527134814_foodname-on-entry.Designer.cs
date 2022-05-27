﻿// <auto-generated />
using System;
using CalorieTracker.Infrastructure.DBContexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace CalorieTracker.Infrastructure.Migrations
{
    [DbContext(typeof(TrackerContext))]
    [Migration("20220527134814_foodname-on-entry")]
    partial class foodnameonentry
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "6.0.5");

            modelBuilder.Entity("CalorieTracker.Domain.CalorieEntries.CalorieEntry", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("CreatedOn")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("Date")
                        .HasColumnType("TEXT");

                    b.Property<DateTime?>("DeletedOn")
                        .HasColumnType("TEXT");

                    b.Property<int>("FoodTypeId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("FoodTypeName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<double>("Quantity")
                        .HasColumnType("REAL");

                    b.HasKey("Id");

                    b.ToTable("CalorieEntry");
                });

            modelBuilder.Entity("CalorieTracker.Domain.FoodTypes.FoodType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<double>("CaloriesPerUnit")
                        .HasColumnType("REAL");

                    b.Property<DateTime>("CreatedOn")
                        .HasColumnType("TEXT");

                    b.Property<DateTime?>("DeletedOn")
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("Units")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.ToTable("FoodType");
                });
#pragma warning restore 612, 618
        }
    }
}
