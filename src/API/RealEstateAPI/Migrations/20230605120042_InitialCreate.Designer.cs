﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using RealEstate.Persistence;

#nullable disable

namespace RealEstateAPI.Migrations
{
    [DbContext(typeof(RealEstateDbContext))]
    [Migration("20230605120042_InitialCreate")]
    partial class InitialCreate
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("RealEstate.Domain.Entities.Bookmark", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("Created")
                        .HasColumnType("datetime2");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("LastModified")
                        .HasColumnType("datetime2");

                    b.Property<string>("LastModifiedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("PropertyId")
                        .HasColumnType("int");

                    b.Property<bool>("Status")
                        .HasColumnType("bit");

                    b.Property<int>("User_Id")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("PropertyId");

                    b.ToTable("Bookmarks");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Created = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            PropertyId = 1,
                            Status = true,
                            User_Id = 1
                        });
                });

            modelBuilder.Entity("RealEstate.Domain.Entities.Category", b =>
                {
                    b.Property<Guid>("CategoryId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("Created")
                        .HasColumnType("datetime2");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ImageUrl")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("LastModified")
                        .HasColumnType("datetime2");

                    b.Property<string>("LastModifiedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("CategoryId");

                    b.ToTable("Categories");

                    b.HasData(
                        new
                        {
                            CategoryId = new Guid("d9f9b9b0-5b9a-4b9c-9c9d-9b9b9b9b9b9b"),
                            Created = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            ImageUrl = "house.png",
                            Name = "House"
                        },
                        new
                        {
                            CategoryId = new Guid("d9f9b9b0-5b9a-4b9c-9c9d-9b9b9b9b9b9c"),
                            Created = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            ImageUrl = "hotel.png",
                            Name = "Hotel"
                        },
                        new
                        {
                            CategoryId = new Guid("d9f9b9b0-5b9a-4b9c-9c9d-9b9b9b9b9b9d"),
                            Created = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            ImageUrl = "apartment.png",
                            Name = "Apartment"
                        },
                        new
                        {
                            CategoryId = new Guid("d9f9b9b0-5b9a-4b9c-9c9d-9b9b9b9b9b9e"),
                            Created = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            ImageUrl = "penthouse.png",
                            Name = "Penthouse"
                        });
                });

            modelBuilder.Entity("RealEstate.Domain.Entities.Property", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("CategoryId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("Created")
                        .HasColumnType("datetime2");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Detail")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ImageUrl")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsTrending")
                        .HasColumnType("bit");

                    b.Property<DateTime?>("LastModified")
                        .HasColumnType("datetime2");

                    b.Property<string>("LastModifiedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("Price")
                        .HasColumnType("float");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.HasIndex("UserId");

                    b.ToTable("Properties");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Address = "Ciel Tower, Dubai Marina, Dubai",
                            CategoryId = new Guid("d9f9b9b0-5b9a-4b9c-9c9d-9b9b9b9b9b9b"),
                            Created = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Detail = "Allsopp Real Estate are pleased to offer this stunning one bedroom apartment in Emaar's 5242, Dubai Marina.Amazing full marina views, from all rooms, this one bedroom apartment is offered vacant and spread over 696 sq. ft. Perfect for short term holiday lets or as a first home.",
                            ImageUrl = "imagep1.jpg",
                            IsTrending = false,
                            Name = "Jumeirah Metro City",
                            Price = 800000.0,
                            UserId = 1
                        },
                        new
                        {
                            Id = 2,
                            Address = "Dorrabay, Dubai Marina, Dubai",
                            CategoryId = new Guid("d9f9b9b0-5b9a-4b9c-9c9d-9b9b9b9b9b9b"),
                            Created = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Detail = "Sky golobal Real Estate is pleased to offer this stunning house in Emaar's 5242, Dubai Marina.Amazing full marina views, from all rooms, this one bedroom apartment is offered vacant and spread over 696 sq. ft. Perfect for short term holiday lets or as a first home.",
                            ImageUrl = "imagep2.jpg",
                            IsTrending = true,
                            Name = "Stuning Marina",
                            Price = 700000.0,
                            UserId = 1
                        },
                        new
                        {
                            Id = 3,
                            Address = "Dorrabay, Dubai Marina, Dubai",
                            CategoryId = new Guid("d9f9b9b0-5b9a-4b9c-9c9d-9b9b9b9b9b9b"),
                            Created = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Detail = "Allsopp Real Estate are pleased to offer this stunning one bedroom apartment in Emaar's 5242, Dubai Marina.Amazing full marina views, from all rooms, this one bedroom apartment is offered vacant and spread over 696 sq. ft. Perfect for short term holiday lets or as a first home.",
                            ImageUrl = "imagep3.jpg",
                            IsTrending = false,
                            Name = "Distress Deal",
                            Price = 200000.0,
                            UserId = 1
                        },
                        new
                        {
                            Id = 4,
                            Address = "TFG Marina , Dubai Marina, Dubai",
                            CategoryId = new Guid("d9f9b9b0-5b9a-4b9c-9c9d-9b9b9b9b9b9c"),
                            Created = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Detail = "Jumeirah Real Estate is pleased to offer this stunning one bedroom apartment in Emaar's 5242, Dubai Marina.Amazing full marina views, from all rooms, this one bedroom apartment is offered vacant and spread over 696 sq. ft. Perfect for short term holiday lets or as a first home.",
                            ImageUrl = "imagep4.jpg",
                            IsTrending = false,
                            Name = "Panoramic Views",
                            Price = 900000.0,
                            UserId = 1
                        },
                        new
                        {
                            Id = 5,
                            Address = "The Palm Tower, Palm Jumeirah, Dubai",
                            CategoryId = new Guid("d9f9b9b0-5b9a-4b9c-9c9d-9b9b9b9b9b9c"),
                            Created = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Detail = "Allsopp Real Estate are pleased to offer this stunning one bedroom apartment in Emaar's 5242, Dubai Marina.Amazing full marina views, from all rooms, this one bedroom apartment is offered vacant and spread over 696 sq. ft. Perfect for short term holiday lets or as a first home.",
                            ImageUrl = "imagep5.jpg",
                            IsTrending = true,
                            Name = "Palm View",
                            Price = 750000.0,
                            UserId = 1
                        },
                        new
                        {
                            Id = 6,
                            Address = "Dorrabay, Dubai Marina, Dubai",
                            CategoryId = new Guid("d9f9b9b0-5b9a-4b9c-9c9d-9b9b9b9b9b9d"),
                            Created = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Detail = "Allsopp Real Estate are pleased to offer this stunning one bedroom apartment in Emaar's 5242, Dubai Marina.Amazing full marina views, from all rooms, this one bedroom apartment is offered vacant and spread over 696 sq. ft. Perfect for short term holiday lets or as a first home.",
                            ImageUrl = "imagep6.jpg",
                            IsTrending = false,
                            Name = "Full Marina View",
                            Price = 200000.0,
                            UserId = 1
                        },
                        new
                        {
                            Id = 7,
                            Address = "Attessa, Marina Promenade, Dubai Marina, Dubai",
                            CategoryId = new Guid("d9f9b9b0-5b9a-4b9c-9c9d-9b9b9b9b9b9d"),
                            Created = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Detail = "We are pleased to offer this stunning two bed apartment in Emaar's 5243, Dubai.Amazing full marina views, from all rooms, this two bedroom apartment is offered vacant and spread over 850 sq. ft. Perfect for short term holiday lets or as a first home.",
                            ImageUrl = "imagep7.jpg",
                            IsTrending = true,
                            Name = "Avant Tower",
                            Price = 300000.0,
                            UserId = 1
                        },
                        new
                        {
                            Id = 8,
                            Address = "Tower B1, Vida Hotel, The Hills, Dubai",
                            CategoryId = new Guid("d9f9b9b0-5b9a-4b9c-9c9d-9b9b9b9b9b9d"),
                            Created = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Detail = "Eithad Real Estate is pleased to offer this stunning one bedroom apartment in Emaar's 5242, Dubai Marina.Amazing full marina views, from all rooms, this one bedroom apartment is offered vacant and spread over 696 sq. ft. Perfect for short term holiday lets or as a first home.",
                            ImageUrl = "imagep8.jpg",
                            IsTrending = false,
                            Name = "Distress Deal",
                            Price = 400000.0,
                            UserId = 1
                        },
                        new
                        {
                            Id = 9,
                            Address = "Vida Residence 2, Vida Residence, Dubai",
                            CategoryId = new Guid("d9f9b9b0-5b9a-4b9c-9c9d-9b9b9b9b9b9d"),
                            Created = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Detail = "Kernizia Real Estate is pleased to offer this stunning one bedroom apartment in Emaar's 5242, Dubai Marina.Amazing full marina views, from all rooms, this one bedroom apartment is offered vacant and spread over 696 sq. ft. Perfect for short term holiday lets or as a first home.",
                            ImageUrl = "imagep9.jpg",
                            IsTrending = false,
                            Name = "Sea View",
                            Price = 880000.0,
                            UserId = 1
                        },
                        new
                        {
                            Id = 10,
                            Address = "Artesia C, Artesia, DAMAC Hills, Dubai",
                            CategoryId = new Guid("d9f9b9b0-5b9a-4b9c-9c9d-9b9b9b9b9b9e"),
                            Created = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Detail = "Astro Properties are delighted to present this Excellent investment opportunity to own a hotel room in the heart of Dubai Marina! Wyndham Dubai Marina is an upscale 4* hotel with breathtaking views of the Arabian Sea and Dubai Marina. The hotel is very popular through the guests and visitors and keeps high ranking on booking. com and similar booking portals through all time.",
                            ImageUrl = "imagep10.jpg",
                            IsTrending = false,
                            Name = "Jenkins Height",
                            Price = 5500000.0,
                            UserId = 1
                        },
                        new
                        {
                            Id = 11,
                            Address = "Damac Maison The Distinction, Downtown Dubai, Dubai",
                            CategoryId = new Guid("d9f9b9b0-5b9a-4b9c-9c9d-9b9b9b9b9b9e"),
                            Created = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Detail = "Allsopp Real Estate are pleased to offer this stunning one bedroom apartment in Emaar's 5242, Dubai Marina.Amazing full marina views, from all rooms, this one bedroom apartment is offered vacant and spread over 696 sq. ft. Perfect for short term holiday lets or as a first home.",
                            ImageUrl = "imagep11.jpg",
                            IsTrending = false,
                            Name = "Takishi Penhouse",
                            Price = 800000.0,
                            UserId = 1
                        },
                        new
                        {
                            Id = 12,
                            Address = "Dorrabay, Dubai Marina, Dubai",
                            CategoryId = new Guid("d9f9b9b0-5b9a-4b9c-9c9d-9b9b9b9b9b9e"),
                            Created = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Detail = "Elan Real Estate delighted to present Ciel Tower that means Sky in French, is in Dubai Marina one of the magnificent height of 360 meters and is a breathtaking building that will set a new global milestone as the world's tallest hotel upon completion. The architectural marvel is the newest landmark added to the world-famous skyline of the Marina. Designed by the award-winning London-based architect NORR, Ciel Tower features a stunning exterior, futuristic interiors and a spectacular glass observation deck that provides incredible 360-degree views of Dubai Marina, Palm Jumeirah and the Arab Gulf. ",
                            ImageUrl = "imagep12.jpg",
                            IsTrending = true,
                            Name = "Blue World",
                            Price = 650000.0,
                            UserId = 1
                        });
                });

            modelBuilder.Entity("RealEstate.Domain.Entities.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Users");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Email = "andrew@email.com",
                            Name = "Andrew",
                            Password = "And@1234",
                            Phone = "93524682"
                        },
                        new
                        {
                            Id = 2,
                            Email = "bob@email.com",
                            Name = "Bob",
                            Password = "Bb@1234",
                            Phone = "93925611"
                        },
                        new
                        {
                            Id = 3,
                            Email = "john@email.com",
                            Name = "John",
                            Password = "Jn@1234",
                            Phone = "93624627"
                        },
                        new
                        {
                            Id = 4,
                            Email = "chris@email.com",
                            Name = "Chris",
                            Password = "Crs@1234",
                            Phone = "93304682"
                        });
                });

            modelBuilder.Entity("RealEstate.Domain.Entities.Bookmark", b =>
                {
                    b.HasOne("RealEstate.Domain.Entities.Property", "Property")
                        .WithMany("Bookmarks")
                        .HasForeignKey("PropertyId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Property");
                });

            modelBuilder.Entity("RealEstate.Domain.Entities.Property", b =>
                {
                    b.HasOne("RealEstate.Domain.Entities.Category", "Category")
                        .WithMany("Properties")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("RealEstate.Domain.Entities.User", "User")
                        .WithMany("Properties")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Category");

                    b.Navigation("User");
                });

            modelBuilder.Entity("RealEstate.Domain.Entities.Category", b =>
                {
                    b.Navigation("Properties");
                });

            modelBuilder.Entity("RealEstate.Domain.Entities.Property", b =>
                {
                    b.Navigation("Bookmarks");
                });

            modelBuilder.Entity("RealEstate.Domain.Entities.User", b =>
                {
                    b.Navigation("Properties");
                });
#pragma warning restore 612, 618
        }
    }
}
