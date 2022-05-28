﻿// <auto-generated />
using System;
using BlazorRpg.Server.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace BlazorRpg.Server.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20220524142311_characterAttributes")]
    partial class characterAttributes
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("BlazorRpg.Shared.Models.Character", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("Agi")
                        .HasColumnType("int");

                    b.Property<int>("Att")
                        .HasColumnType("int");

                    b.Property<int>("Class")
                        .HasColumnType("int");

                    b.Property<int>("Def")
                        .HasColumnType("int");

                    b.Property<long>("Exp")
                        .HasColumnType("bigint");

                    b.Property<long>("HP")
                        .HasColumnType("bigint");

                    b.Property<int>("Int")
                        .HasColumnType("int");

                    b.Property<int>("Level")
                        .HasColumnType("int");

                    b.Property<int>("Luck")
                        .HasColumnType("int");

                    b.Property<long>("MP")
                        .HasColumnType("bigint");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Str")
                        .HasColumnType("int");

                    b.Property<int>("Vit")
                        .HasColumnType("int");

                    b.Property<int>("Wis")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Characters");
                });

            modelBuilder.Entity("BlazorRpg.Shared.Models.SecondTestModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("SecondTestModels");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "N1"
                        },
                        new
                        {
                            Id = 2,
                            Name = "N2"
                        });
                });

            modelBuilder.Entity("BlazorRpg.Shared.Models.TestModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("SecondTestModelId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("SecondTestModelId");

                    b.ToTable("TestModels");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "T1",
                            SecondTestModelId = 1
                        },
                        new
                        {
                            Id = 2,
                            Name = "T2",
                            SecondTestModelId = 2
                        });
                });

            modelBuilder.Entity("BlazorRpg.Shared.Models.TestModel", b =>
                {
                    b.HasOne("BlazorRpg.Shared.Models.SecondTestModel", "SecondTestModel")
                        .WithMany()
                        .HasForeignKey("SecondTestModelId")
                        .OnDelete(DeleteBehavior.SetNull);

                    b.Navigation("SecondTestModel");
                });
#pragma warning restore 612, 618
        }
    }
}
