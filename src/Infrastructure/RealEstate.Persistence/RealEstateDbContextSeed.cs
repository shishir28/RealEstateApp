using Microsoft.EntityFrameworkCore;
using RealEstate.Domain.Entities;

namespace RealEstate.Persistence
{
    public static class RealEstateDbContextSeed
    {
        public static void SeedData(ModelBuilder modelBuilder)
        {
            var houseGuid = new System.Guid("d9f9b9b0-5b9a-4b9c-9c9d-9b9b9b9b9b9b");
            var hotelGuid = new System.Guid("d9f9b9b0-5b9a-4b9c-9c9d-9b9b9b9b9b9c");
            var apartmentGuid = new System.Guid("d9f9b9b0-5b9a-4b9c-9c9d-9b9b9b9b9b9d");
            var penthouseGuid = new System.Guid("d9f9b9b0-5b9a-4b9c-9c9d-9b9b9b9b9b9e");

            modelBuilder.Entity<Category>().HasData(
                new Category { CategoryId = houseGuid, Name = "House", ImageUrl = "house.png" },
                new Category { CategoryId = hotelGuid, Name = "Hotel", ImageUrl = "hotel.png" },
                new Category { CategoryId = apartmentGuid, Name = "Apartment", ImageUrl = "apartment.png" },
                new Category { CategoryId = penthouseGuid, Name = "Penthouse", ImageUrl = "penthouse.png" });

            modelBuilder.Entity<User>().HasData(
              new User { Id = 1, Name = "Andrew", Email = "andrew@email.com", Password = "And@1234", Phone = "93524682" },
              new User { Id = 2, Name = "Bob", Email = "bob@email.com", Password = "Bb@1234", Phone = "93925611" },
              new User { Id = 3, Name = "John", Email = "john@email.com", Password = "Jn@1234", Phone = "93624627" },
              new User { Id = 4, Name = "Chris", Email = "chris@email.com", Password = "Crs@1234", Phone = "93304682" });


            modelBuilder.Entity<Property>().HasData(
            new Property { Id = 1, Name = "Jumeirah Metro City", ImageUrl = "imagep1.jpg", Price = 800000, IsTrending = false, CategoryId = houseGuid, UserId = 1, Detail = "Allsopp Real Estate are pleased to offer this stunning one bedroom apartment in Emaar's 5242, Dubai Marina.Amazing full marina views, from all rooms, this one bedroom apartment is offered vacant and spread over 696 sq. ft. Perfect for short term holiday lets or as a first home.", Address = "Ciel Tower, Dubai Marina, Dubai" },
            new Property { Id = 2, Name = "Stuning Marina", ImageUrl = "imagep2.jpg", Price = 700000, IsTrending = true, CategoryId = houseGuid, UserId = 1, Detail = "Sky golobal Real Estate is pleased to offer this stunning house in Emaar's 5242, Dubai Marina.Amazing full marina views, from all rooms, this one bedroom apartment is offered vacant and spread over 696 sq. ft. Perfect for short term holiday lets or as a first home.", Address = "Dorrabay, Dubai Marina, Dubai" },
            new Property { Id = 3, Name = "Distress Deal", ImageUrl = "imagep3.jpg", Price = 200000, IsTrending = false, CategoryId = houseGuid, UserId = 1, Detail = "Allsopp Real Estate are pleased to offer this stunning one bedroom apartment in Emaar's 5242, Dubai Marina.Amazing full marina views, from all rooms, this one bedroom apartment is offered vacant and spread over 696 sq. ft. Perfect for short term holiday lets or as a first home.", Address = "Dorrabay, Dubai Marina, Dubai" },
            new Property { Id = 4, Name = "Panoramic Views", ImageUrl = "imagep4.jpg", Price = 900000, IsTrending = false, CategoryId = hotelGuid, UserId = 1, Detail = "Jumeirah Real Estate is pleased to offer this stunning one bedroom apartment in Emaar's 5242, Dubai Marina.Amazing full marina views, from all rooms, this one bedroom apartment is offered vacant and spread over 696 sq. ft. Perfect for short term holiday lets or as a first home.", Address = "TFG Marina , Dubai Marina, Dubai" },
            new Property { Id = 5, Name = "Palm View", ImageUrl = "imagep5.jpg", Price = 750000, IsTrending = true, CategoryId = hotelGuid, UserId = 1, Detail = "Allsopp Real Estate are pleased to offer this stunning one bedroom apartment in Emaar's 5242, Dubai Marina.Amazing full marina views, from all rooms, this one bedroom apartment is offered vacant and spread over 696 sq. ft. Perfect for short term holiday lets or as a first home.", Address = "The Palm Tower, Palm Jumeirah, Dubai" },
            new Property { Id = 6, Name = "Full Marina View", ImageUrl = "imagep6.jpg", Price = 200000, IsTrending = false, CategoryId = apartmentGuid, UserId = 1, Detail = "Allsopp Real Estate are pleased to offer this stunning one bedroom apartment in Emaar's 5242, Dubai Marina.Amazing full marina views, from all rooms, this one bedroom apartment is offered vacant and spread over 696 sq. ft. Perfect for short term holiday lets or as a first home.", Address = "Dorrabay, Dubai Marina, Dubai" },
            new Property { Id = 7, Name = "Avant Tower", ImageUrl = "imagep7.jpg", Price = 300000, IsTrending = true, CategoryId = apartmentGuid, UserId = 1, Detail = "We are pleased to offer this stunning two bed apartment in Emaar's 5243, Dubai.Amazing full marina views, from all rooms, this two bedroom apartment is offered vacant and spread over 850 sq. ft. Perfect for short term holiday lets or as a first home.", Address = "Attessa, Marina Promenade, Dubai Marina, Dubai" },
            new Property { Id = 8, Name = "Distress Deal", ImageUrl = "imagep8.jpg", Price = 400000, IsTrending = false, CategoryId = apartmentGuid, UserId = 1, Detail = "Eithad Real Estate is pleased to offer this stunning one bedroom apartment in Emaar's 5242, Dubai Marina.Amazing full marina views, from all rooms, this one bedroom apartment is offered vacant and spread over 696 sq. ft. Perfect for short term holiday lets or as a first home.", Address = "Tower B1, Vida Hotel, The Hills, Dubai" },
            new Property { Id = 9, Name = "Sea View", ImageUrl = "imagep9.jpg", Price = 880000, IsTrending = false, CategoryId = apartmentGuid, UserId = 1, Detail = "Kernizia Real Estate is pleased to offer this stunning one bedroom apartment in Emaar's 5242, Dubai Marina.Amazing full marina views, from all rooms, this one bedroom apartment is offered vacant and spread over 696 sq. ft. Perfect for short term holiday lets or as a first home.", Address = "Vida Residence 2, Vida Residence, Dubai" },
            new Property { Id = 10, Name = "Jenkins Height", ImageUrl = "imagep10.jpg", Price = 5500000, IsTrending = false, CategoryId = penthouseGuid, UserId = 1, Detail = "Astro Properties are delighted to present this Excellent investment opportunity to own a hotel room in the heart of Dubai Marina! Wyndham Dubai Marina is an upscale 4* hotel with breathtaking views of the Arabian Sea and Dubai Marina. The hotel is very popular through the guests and visitors and keeps high ranking on booking. com and similar booking portals through all time.", Address = "Artesia C, Artesia, DAMAC Hills, Dubai" },
            new Property { Id = 11, Name = "Takishi Penhouse", ImageUrl = "imagep11.jpg", Price = 800000, IsTrending = false, CategoryId = penthouseGuid, UserId = 1, Detail = "Allsopp Real Estate are pleased to offer this stunning one bedroom apartment in Emaar's 5242, Dubai Marina.Amazing full marina views, from all rooms, this one bedroom apartment is offered vacant and spread over 696 sq. ft. Perfect for short term holiday lets or as a first home.", Address = "Damac Maison The Distinction, Downtown Dubai, Dubai" },
            new Property { Id = 12, Name = "Blue World", ImageUrl = "imagep12.jpg", Price = 650000, IsTrending = true, CategoryId = penthouseGuid, UserId = 1, Detail = "Elan Real Estate delighted to present Ciel Tower that means Sky in French, is in Dubai Marina one of the magnificent height of 360 meters and is a breathtaking building that will set a new global milestone as the world's tallest hotel upon completion. The architectural marvel is the newest landmark added to the world-famous skyline of the Marina. Designed by the award-winning London-based architect NORR, Ciel Tower features a stunning exterior, futuristic interiors and a spectacular glass observation deck that provides incredible 360-degree views of Dubai Marina, Palm Jumeirah and the Arab Gulf. ", Address = "Dorrabay, Dubai Marina, Dubai" });

            modelBuilder.Entity<Bookmark>().HasData(
               new Bookmark { Id = 1, Status = true, User_Id = 1, PropertyId = 1 });
        }

    }
}
