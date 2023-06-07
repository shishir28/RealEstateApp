using Microsoft.EntityFrameworkCore;
using RealEstate.Domain.Entities;

namespace RealEstate.Persistence
{
    public static class RealEstateDbContextSeed
    {
        private static Guid houseGuid = new("d9f9b9b0-5b9a-4b9c-9c9d-9b9b9b9b9b9b");
        private static Guid hotelGuid = new("d9f9b9b0-5b9a-4b9c-9c9d-9b9b9b9b9b9c");
        private static Guid apartmentGuid = new("d9f9b9b0-5b9a-4b9c-9c9d-9b9b9b9b9b9d");
        private static Guid penthouseGuid = new("d9f9b9b0-5b9a-4b9c-9c9d-9b9b9b9b9b9e");
        private static Guid firstUserId = new("8399c62e-d0b4-49bc-a8c6-0a7a0446c159");
        private static Guid secondUserId = new("8399c62e-d0b4-49bc-a8c6-0a7a0446c259");
        private static Guid thirdUserId = new("8399c62e-d0b4-49bc-a8c6-0a7a0446c359");
        private static Guid fourthUserId = new("8399c62e-d0b4-49bc-a8c6-0a7a0446c459");

        public static void SeedData(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>().HasData(
                new Category { CategoryId = houseGuid, Name = "House", ImageUrl = "house.png" },
                new Category { CategoryId = hotelGuid, Name = "Hotel", ImageUrl = "hotel.png" },
                new Category { CategoryId = apartmentGuid, Name = "Apartment", ImageUrl = "apartment.png" },
                new Category { CategoryId = penthouseGuid, Name = "Penthouse", ImageUrl = "penthouse.png" });

            modelBuilder.Entity<User>().HasData(
              new User { UserId = firstUserId, Name = "Andrew", Email = "andrew@email.com", Password = "And@1234", Phone = "93524682" },
              new User { UserId = secondUserId, Name = "Bob", Email = "bob@email.com", Password = "Bb@1234", Phone = "93925611" },
              new User { UserId = thirdUserId, Name = "John", Email = "john@email.com", Password = "Jn@1234", Phone = "93624627" },
              new User { UserId = fourthUserId, Name = "Chris", Email = "chris@email.com", Password = "Crs@1234", Phone = "93304682" });

            SeedProperties(modelBuilder);

            modelBuilder.Entity<Bookmark>().HasData(
               new Bookmark { BookmarkId = new System.Guid("a46ab603-903e-4460-9ba7-da5f3f0f9e92"), Status = true, User_Id = 1, PropertyId = new System.Guid("d9f9b9b0-5b9a-4b9c-9c9d-9b9b9b9b9b9f") });
        }

        private static void SeedProperties(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Property>().HasData(
           new Property { PropertyId = new("d9f9b9b0-5b9a-4b9c-9c9d-9b9b9b9b9b9f"), Name = "Jumeirah Metro City", ImageUrl = "imagep1.jpg", Price = 800000, IsTrending = false, CategoryId = houseGuid, UserId = firstUserId, Detail = "Allsopp Real Estate are pleased to offer this stunning one bedroom apartment in Emaar's 5242, Dubai Marina.Amazing full marina views, from all rooms, this one bedroom apartment is offered vacant and spread over 696 sq. ft. Perfect for short term holiday lets or as a first home.", Address = "Ciel Tower, Dubai Marina, Dubai" },
           new Property { PropertyId = new("d9f9b9b0-5b9a-4b9c-9c9d-9b9b9b9b9b10"), Name = "Stuning Marina", ImageUrl = "imagep2.jpg", Price = 700000, IsTrending = true, CategoryId = houseGuid, UserId = firstUserId, Detail = "Sky golobal Real Estate is pleased to offer this stunning house in Emaar's 5242, Dubai Marina.Amazing full marina views, from all rooms, this one bedroom apartment is offered vacant and spread over 696 sq. ft. Perfect for short term holiday lets or as a first home.", Address = "Dorrabay, Dubai Marina, Dubai" },
           new Property { PropertyId = new("d9f9b9b0-5b9a-4b9c-9c9d-9b9b9b9b9b11"), Name = "Distress Deal", ImageUrl = "imagep3.jpg", Price = 200000, IsTrending = false, CategoryId = houseGuid, UserId = firstUserId, Detail = "Allsopp Real Estate are pleased to offer this stunning one bedroom apartment in Emaar's 5242, Dubai Marina.Amazing full marina views, from all rooms, this one bedroom apartment is offered vacant and spread over 696 sq. ft. Perfect for short term holiday lets or as a first home.", Address = "Dorrabay, Dubai Marina, Dubai" },
           new Property { PropertyId = new("d9f9b9b0-5b9a-4b9c-9c9d-9b9b9b9b9b12"), Name = "Panoramic Views", ImageUrl = "imagep4.jpg", Price = 900000, IsTrending = false, CategoryId = hotelGuid, UserId = firstUserId, Detail = "Jumeirah Real Estate is pleased to offer this stunning one bedroom apartment in Emaar's 5242, Dubai Marina.Amazing full marina views, from all rooms, this one bedroom apartment is offered vacant and spread over 696 sq. ft. Perfect for short term holiday lets or as a first home.", Address = "TFG Marina , Dubai Marina, Dubai" },
           new Property { PropertyId = new("d9f9b9b0-5b9a-4b9c-9c9d-9b9b9b9b9b13"), Name = "Palm View", ImageUrl = "imagep5.jpg", Price = 750000, IsTrending = true, CategoryId = hotelGuid, UserId = firstUserId, Detail = "Allsopp Real Estate are pleased to offer this stunning one bedroom apartment in Emaar's 5242, Dubai Marina.Amazing full marina views, from all rooms, this one bedroom apartment is offered vacant and spread over 696 sq. ft. Perfect for short term holiday lets or as a first home.", Address = "The Palm Tower, Palm Jumeirah, Dubai" },
           new Property { PropertyId = new("d9f9b9b0-5b9a-4b9c-9c9d-9b9b9b9b9b14"), Name = "Full Marina View", ImageUrl = "imagep6.jpg", Price = 200000, IsTrending = false, CategoryId = apartmentGuid, UserId = firstUserId, Detail = "Allsopp Real Estate are pleased to offer this stunning one bedroom apartment in Emaar's 5242, Dubai Marina.Amazing full marina views, from all rooms, this one bedroom apartment is offered vacant and spread over 696 sq. ft. Perfect for short term holiday lets or as a first home.", Address = "Dorrabay, Dubai Marina, Dubai" },
           new Property { PropertyId = new("d9f9b9b0-5b9a-4b9c-9c9d-9b9b9b9b9b15"), Name = "Avant Tower", ImageUrl = "imagep7.jpg", Price = 300000, IsTrending = true, CategoryId = apartmentGuid, UserId = firstUserId, Detail = "We are pleased to offer this stunning two bed apartment in Emaar's 5243, Dubai.Amazing full marina views, from all rooms, this two bedroom apartment is offered vacant and spread over 850 sq. ft. Perfect for short term holiday lets or as a first home.", Address = "Attessa, Marina Promenade, Dubai Marina, Dubai" },
           new Property { PropertyId = new("d9f9b9b0-5b9a-4b9c-9c9d-9b9b9b9b9b16"), Name = "Distress Deal", ImageUrl = "imagep8.jpg", Price = 400000, IsTrending = false, CategoryId = apartmentGuid, UserId = firstUserId, Detail = "Eithad Real Estate is pleased to offer this stunning one bedroom apartment in Emaar's 5242, Dubai Marina.Amazing full marina views, from all rooms, this one bedroom apartment is offered vacant and spread over 696 sq. ft. Perfect for short term holiday lets or as a first home.", Address = "Tower B1, Vida Hotel, The Hills, Dubai" },
           new Property { PropertyId = new("d9f9b9b0-5b9a-4b9c-9c9d-9b9b9b9b9b17"), Name = "Sea View", ImageUrl = "imagep9.jpg", Price = 880000, IsTrending = false, CategoryId = apartmentGuid, UserId = firstUserId, Detail = "Kernizia Real Estate is pleased to offer this stunning one bedroom apartment in Emaar's 5242, Dubai Marina.Amazing full marina views, from all rooms, this one bedroom apartment is offered vacant and spread over 696 sq. ft. Perfect for short term holiday lets or as a first home.", Address = "Vida Residence 2, Vida Residence, Dubai" },
           new Property { PropertyId = new("d9f9b9b0-5b9a-4b9c-9c9d-9b9b9b9b9b18"), Name = "Jenkins Height", ImageUrl = "imagep10.jpg", Price = 5500000, IsTrending = false, CategoryId = penthouseGuid, UserId = firstUserId, Detail = "Astro Properties are delighted to present this Excellent investment opportunity to own a hotel room in the heart of Dubai Marina! Wyndham Dubai Marina is an upscale 4* hotel with breathtaking views of the Arabian Sea and Dubai Marina. The hotel is very popular through the guests and visitors and keeps high ranking on booking. com and similar booking portals through all time.", Address = "Artesia C, Artesia, DAMAC Hills, Dubai" },
           new Property { PropertyId = new("d9f9b9b0-5b9a-4b9c-9c9d-9b9b9b9b9b19"), Name = "Takishi Penhouse", ImageUrl = "imagep11.jpg", Price = 800000, IsTrending = false, CategoryId = penthouseGuid, UserId = firstUserId, Detail = "Allsopp Real Estate are pleased to offer this stunning one bedroom apartment in Emaar's 5242, Dubai Marina.Amazing full marina views, from all rooms, this one bedroom apartment is offered vacant and spread over 696 sq. ft. Perfect for short term holiday lets or as a first home.", Address = "Damac Maison The Distinction, Downtown Dubai, Dubai" },
           new Property { PropertyId = new("d9f9b9b0-5b9a-4b9c-9c9d-9b9b9b9b9b20"), Name = "Blue World", ImageUrl = "imagep12.jpg", Price = 650000, IsTrending = true, CategoryId = penthouseGuid, UserId = firstUserId, Detail = "Elan Real Estate delighted to present Ciel Tower that means Sky in French, is in Dubai Marina one of the magnificent height of 360 meters and is a breathtaking building that will set a new global milestone as the world's tallest hotel upon completion. The architectural marvel is the newest landmark added to the world-famous skyline of the Marina. Designed by the award-winning London-based architect NORR, Ciel Tower features a stunning exterior, futuristic interiors and a spectacular glass observation deck that provides incredible 360-degree views of Dubai Marina, Palm Jumeirah and the Arab Gulf. ", Address = "Dorrabay, Dubai Marina, Dubai" });
        }

    }
}
