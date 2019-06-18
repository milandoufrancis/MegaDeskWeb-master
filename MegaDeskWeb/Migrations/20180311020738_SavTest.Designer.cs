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
    [Migration("20180311020738_SavTest")]
    partial class SavTest
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

                    b.Property<int>("materialID");

                    b.Property<int>("width");

                    b.HasKey("ID");

                    b.HasIndex("materialID");

                    b.ToTable("Desk");
                });

            modelBuilder.Entity("MegaDeskWeb.Model.DeskQuote", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("CustomerName");

                    b.Property<DateTime>("Date");

                    b.Property<int>("DeskID");

                    b.Property<int>("RushID");

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

                    b.Property<int>("priceLarge");

                    b.Property<int>("priceMedium");

                    b.Property<int>("priceSmall");

                    b.HasKey("ID");

                    b.ToTable("Rush");
                });

            modelBuilder.Entity("MegaDeskWeb.Model.Desk", b =>
                {
                    b.HasOne("MegaDeskWeb.Model.Material", "Material")
                        .WithMany("Desks")
                        .HasForeignKey("materialID")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("MegaDeskWeb.Model.DeskQuote", b =>
                {
                    b.HasOne("MegaDeskWeb.Model.Desk", "Desk")
                        .WithMany("Quotes")
                        .HasForeignKey("DeskID")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("MegaDeskWeb.Model.Rush", "Rush")
                        .WithMany("Quotes")
                        .HasForeignKey("RushID")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
