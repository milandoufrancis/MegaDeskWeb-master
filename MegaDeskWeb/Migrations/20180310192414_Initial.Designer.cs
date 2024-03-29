﻿// <auto-generated />
using MegaDeskWeb.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore.Storage.Internal;
using System;

namespace MegaDeskWeb.Migrations
{
    [DbContext(typeof(MegaDeskDBContext))]
    [Migration("20180310192414_Initial")]
    partial class Initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.0.1-rtm-125")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("MegaDeskWeb.Model.Desk", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("depth");

                    b.Property<int>("drawers");

                    b.Property<int>("width");

                    b.HasKey("ID");

                    b.ToTable("Desk");
                });

            modelBuilder.Entity("MegaDeskWeb.Model.DeskQuote", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("CustomerName");

                    b.Property<int>("DeskID");

                    b.Property<int>("RushID");

                    b.Property<DateTime>("date");

                    b.Property<double>("price");

                    b.HasKey("ID");

                    b.HasIndex("DeskID");

                    b.HasIndex("RushID");

                    b.ToTable("DeskQuote");
                });

            modelBuilder.Entity("MegaDeskWeb.Model.Material", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<double>("cost");

                    b.Property<string>("type");

                    b.HasKey("ID");

                    b.ToTable("Material");
                });

            modelBuilder.Entity("MegaDeskWeb.Model.Rush", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("days");

                    b.HasKey("ID");

                    b.ToTable("Rush");
                });

            modelBuilder.Entity("MegaDeskWeb.Model.DeskQuote", b =>
                {
                    b.HasOne("MegaDeskWeb.Model.Desk", "desk")
                        .WithMany()
                        .HasForeignKey("DeskID")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("MegaDeskWeb.Model.Rush", "rush")
                        .WithMany()
                        .HasForeignKey("RushID")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
