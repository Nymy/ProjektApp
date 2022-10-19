﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ProjektApp.Persistence;

#nullable disable

namespace ProjektApp.Migrations
{
    [DbContext(typeof(AuctionDbContext))]
    partial class AuctionDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("ProjektApp.Persistence.AuctionDb", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<DateTime>("CloseDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<int>("LowestPrice")
                        .HasColumnType("int");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("AuctionDbs");

                    b.HasData(
                        new
                        {
                            Id = -1,
                            CloseDate = new DateTime(2022, 10, 17, 23, 59, 59, 0, DateTimeKind.Unspecified),
                            CreatedDate = new DateTime(2022, 10, 17, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Description = "Alot of orchids, very nice",
                            LowestPrice = 100,
                            Title = "Auction for orchids",
                            UserName = "nonnoo@kth.se"
                        });
                });

            modelBuilder.Entity("ProjektApp.Persistence.BidDb", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("AuctionId")
                        .HasColumnType("int");

                    b.Property<int>("BidAmount")
                        .HasColumnType("int");

                    b.Property<DateTime>("BiddedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("Id");

                    b.HasIndex("AuctionId");

                    b.ToTable("BidsDbs");

                    b.HasData(
                        new
                        {
                            Id = -1,
                            AuctionId = -1,
                            BidAmount = 100,
                            BiddedAt = new DateTime(2022, 10, 17, 13, 20, 0, 0, DateTimeKind.Unspecified),
                            Name = "Viktor"
                        },
                        new
                        {
                            Id = -2,
                            AuctionId = -1,
                            BidAmount = 101,
                            BiddedAt = new DateTime(2022, 10, 17, 13, 21, 0, 0, DateTimeKind.Unspecified),
                            Name = "Nonno"
                        });
                });

            modelBuilder.Entity("ProjektApp.Persistence.BidDb", b =>
                {
                    b.HasOne("ProjektApp.Persistence.AuctionDb", "auctionDb")
                        .WithMany("BidDbs")
                        .HasForeignKey("AuctionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("auctionDb");
                });

            modelBuilder.Entity("ProjektApp.Persistence.AuctionDb", b =>
                {
                    b.Navigation("BidDbs");
                });
#pragma warning restore 612, 618
        }
    }
}
