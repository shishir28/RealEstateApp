using RealEstate.Application.Contracts.Persistence;
using RealEstate.Domain.Entities;
using Moq;

namespace RealEstate.Application.UnitTests.Mocks;

public class MockPropertyRepository
{
    public static IPropertyRepository GetPropertyRepository()
    {
        var newPropertyId = new Guid("d9f9b9b0-5b9a-4b9c-9c9d-9b9b9b9b9b21");
        var houseGuid = new Guid("d9f9b9b0-5b9a-4b9c-9c9d-9b9b9b9b9b9b");
        var hotelGuid = new Guid("d9f9b9b0-5b9a-4b9c-9c9d-9b9b9b9b9b9c");
        var apartmentGuid = new Guid("d9f9b9b0-5b9a-4b9c-9c9d-9b9b9b9b9b9d");
        var penthouseGuid = new Guid("d9f9b9b0-5b9a-4b9c-9c9d-9b9b9b9b9b9e");
        var firstUserId = new Guid("8399c62e-d0b4-49bc-a8c6-0a7a0446c159");
        var secondUserId = new Guid("8399c62e-d0b4-49bc-a8c6-0a7a0446c259");
        var thirdUserId = new Guid("8399c62e-d0b4-49bc-a8c6-0a7a0446c359");
        var fourthUserId = new Guid("8399c62e-d0b4-49bc-a8c6-0a7a0446c459");

        var properties = new List<Property>
        {
           new Property { PropertyId = new Guid("d9f9b9b0-5b9a-4b9c-9c9d-9b9b9b9b9b9f"), Name = "Jumeirah Metro City", ImageUrl = "imagep1.jpg", Price = 800000, IsTrending = false, CategoryId = houseGuid, UserId = firstUserId, Detail = "Allsopp Real Estate are pleased to offer this stunning one bedroom apartment in Emaar's 5242, Dubai Marina.Amazing full marina views, from all rooms, this one bedroom apartment is offered vacant and spread over 696 sq. ft. Perfect for short term holiday lets or as a first home.", Address = "Ciel Tower, Dubai Marina, Dubai" },
           new Property { PropertyId = new Guid("d9f9b9b0-5b9a-4b9c-9c9d-9b9b9b9b9b10"), Name = "Stuning Marina", ImageUrl = "imagep2.jpg", Price = 700000, IsTrending = true, CategoryId = houseGuid, UserId = firstUserId, Detail = "Sky golobal Real Estate is pleased to offer this stunning house in Emaar's 5242, Dubai Marina.Amazing full marina views, from all rooms, this one bedroom apartment is offered vacant and spread over 696 sq. ft. Perfect for short term holiday lets or as a first home.", Address = "Dorrabay, Dubai Marina, Dubai" },
           new Property { PropertyId = new Guid("d9f9b9b0-5b9a-4b9c-9c9d-9b9b9b9b9b11"), Name = "Distress Deal", ImageUrl = "imagep3.jpg", Price = 200000, IsTrending = false, CategoryId = houseGuid, UserId = firstUserId, Detail = "Allsopp Real Estate are pleased to offer this stunning one bedroom apartment in Emaar's 5242, Dubai Marina.Amazing full marina views, from all rooms, this one bedroom apartment is offered vacant and spread over 696 sq. ft. Perfect for short term holiday lets or as a first home.", Address = "Dorrabay, Dubai Marina, Dubai" },
           new Property { PropertyId = new Guid("d9f9b9b0-5b9a-4b9c-9c9d-9b9b9b9b9b12"), Name = "Panoramic Views", ImageUrl = "imagep4.jpg", Price = 900000, IsTrending = false, CategoryId = hotelGuid, UserId =firstUserId, Detail = "Jumeirah Real Estate is pleased to offer this stunning one bedroom apartment in Emaar's 5242, Dubai Marina.Amazing full marina views, from all rooms, this one bedroom apartment is offered vacant and spread over 696 sq. ft. Perfect for short term holiday lets or as a first home.", Address = "TFG Marina , Dubai Marina, Dubai" },
           new Property { PropertyId = new Guid("d9f9b9b0-5b9a-4b9c-9c9d-9b9b9b9b9b13"), Name = "Palm View", ImageUrl = "imagep5.jpg", Price = 750000, IsTrending = true, CategoryId = hotelGuid, UserId = firstUserId, Detail = "Allsopp Real Estate are pleased to offer this stunning one bedroom apartment in Emaar's 5242, Dubai Marina.Amazing full marina views, from all rooms, this one bedroom apartment is offered vacant and spread over 696 sq. ft. Perfect for short term holiday lets or as a first home.", Address = "The Palm Tower, Palm Jumeirah, Dubai" },
           new Property { PropertyId = new Guid("d9f9b9b0-5b9a-4b9c-9c9d-9b9b9b9b9b14"), Name = "Full Marina View", ImageUrl = "imagep6.jpg", Price = 200000, IsTrending = false, CategoryId = apartmentGuid, UserId = firstUserId, Detail = "Allsopp Real Estate are pleased to offer this stunning one bedroom apartment in Emaar's 5242, Dubai Marina.Amazing full marina views, from all rooms, this one bedroom apartment is offered vacant and spread over 696 sq. ft. Perfect for short term holiday lets or as a first home.", Address = "Dorrabay, Dubai Marina, Dubai" },
           new Property { PropertyId = new Guid("d9f9b9b0-5b9a-4b9c-9c9d-9b9b9b9b9b15"), Name = "Avant Tower", ImageUrl = "imagep7.jpg", Price = 300000, IsTrending = true, CategoryId = apartmentGuid, UserId = firstUserId, Detail = "We are pleased to offer this stunning two bed apartment in Emaar's 5243, Dubai.Amazing full marina views, from all rooms, this two bedroom apartment is offered vacant and spread over 850 sq. ft. Perfect for short term holiday lets or as a first home.", Address = "Attessa, Marina Promenade, Dubai Marina, Dubai" },
           new Property { PropertyId = new Guid("d9f9b9b0-5b9a-4b9c-9c9d-9b9b9b9b9b16"), Name = "Distress Deal", ImageUrl = "imagep8.jpg", Price = 400000, IsTrending = false, CategoryId = apartmentGuid, UserId = firstUserId, Detail = "Eithad Real Estate is pleased to offer this stunning one bedroom apartment in Emaar's 5242, Dubai Marina.Amazing full marina views, from all rooms, this one bedroom apartment is offered vacant and spread over 696 sq. ft. Perfect for short term holiday lets or as a first home.", Address = "Tower B1, Vida Hotel, The Hills, Dubai" },
           new Property { PropertyId = new Guid("d9f9b9b0-5b9a-4b9c-9c9d-9b9b9b9b9b17"), Name = "Sea View", ImageUrl = "imagep9.jpg", Price = 880000, IsTrending = false, CategoryId = apartmentGuid, UserId = firstUserId, Detail = "Kernizia Real Estate is pleased to offer this stunning one bedroom apartment in Emaar's 5242, Dubai Marina.Amazing full marina views, from all rooms, this one bedroom apartment is offered vacant and spread over 696 sq. ft. Perfect for short term holiday lets or as a first home.", Address = "Vida Residence 2, Vida Residence, Dubai" },
           new Property { PropertyId = new Guid("d9f9b9b0-5b9a-4b9c-9c9d-9b9b9b9b9b18"), Name = "Jenkins Height", ImageUrl = "imagep10.jpg", Price = 5500000, IsTrending = false, CategoryId = penthouseGuid, UserId = firstUserId, Detail = "Astro Properties are delighted to present this Excellent investment opportunity to own a hotel room in the heart of Dubai Marina! Wyndham Dubai Marina is an upscale 4* hotel with breathtaking views of the Arabian Sea and Dubai Marina. The hotel is very popular through the guests and visitors and keeps high ranking on booking. com and similar booking portals through all time.", Address = "Artesia C, Artesia, DAMAC Hills, Dubai" },
           new Property { PropertyId = new Guid("d9f9b9b0-5b9a-4b9c-9c9d-9b9b9b9b9b19"), Name = "Takishi Penhouse", ImageUrl = "imagep11.jpg", Price = 800000, IsTrending = false, CategoryId = penthouseGuid, UserId = firstUserId, Detail = "Allsopp Real Estate are pleased to offer this stunning one bedroom apartment in Emaar's 5242, Dubai Marina.Amazing full marina views, from all rooms, this one bedroom apartment is offered vacant and spread over 696 sq. ft. Perfect for short term holiday lets or as a first home.", Address = "Damac Maison The Distinction, Downtown Dubai, Dubai" },
           new Property { PropertyId = new Guid("d9f9b9b0-5b9a-4b9c-9c9d-9b9b9b9b9b20"), Name = "Blue World", ImageUrl = "imagep12.jpg", Price = 650000, IsTrending = true, CategoryId = penthouseGuid, UserId = firstUserId, Detail = "Elan Real Estate delighted to present Ciel Tower that means Sky in French, is in Dubai Marina one of the magnificent height of 360 meters and is a breathtaking building that will set a new global milestone as the world's tallest hotel upon completion. The architectural marvel is the newest landmark added to the world-famous skyline of the Marina. Designed by the award-winning London-based architect NORR, Ciel Tower features a stunning exterior, futuristic interiors and a spectacular glass observation deck that provides incredible 360-degree views of Dubai Marina, Palm Jumeirah and the Arab Gulf. ", Address = "Dorrabay, Dubai Marina, Dubai" }
        };

        var mockPropertyRepository = new Mock<IPropertyRepository>();
        mockPropertyRepository.Setup(repo => repo.GetTrendingProperties()).ReturnsAsync(properties);
        mockPropertyRepository.Setup(repo => repo.GetAllAsync()).ReturnsAsync(properties);
        //GetPropertiesByCategoryId(Guid categoryId)
        mockPropertyRepository.Setup(repo => repo.GetPropertiesByCategoryId(It.IsAny<Guid>())).ReturnsAsync(
            (Guid categoryId) =>
            {
                return properties.Where(x => x.CategoryId == categoryId).ToList();
            });
        mockPropertyRepository.Setup(repo => repo.GetPropertiesForAddress(It.IsAny<string>())).ReturnsAsync(
       (string address) =>
       {
           return properties.Where(x => x.Address.Contains(address)).ToList();
       });

        mockPropertyRepository.Setup(repo => repo.AddAsync(It.IsAny<Property>()))
       .ReturnsAsync((Property property) =>
       {
           property.PropertyId = newPropertyId;
           return property;
       });
        mockPropertyRepository.Setup(repo => repo.GetByIdAsync(It.IsAny<Guid>())).ReturnsAsync(
        (Guid Id) =>
        {
            return properties.Where(x => x.PropertyId == Id).FirstOrDefault();
        });

        return mockPropertyRepository.Object;
    }
}
