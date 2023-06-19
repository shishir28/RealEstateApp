using RealEstate.Domain.Entities;
using RealEstate.Persistence;

namespace RealEstate.API.IntegrationTests
{
    // as of now it had duplicate data as RealEstateDBContextSeed but over period of time RealEstateDBContextSeed could have more realistic data and hence wants to keep these two class separate
    internal static class GenesisDataState
    {
        private static readonly Guid houseGuid = new("d9f9b9b0-5b9a-4b9c-9c9d-9b9b9b9b9b9b");
        private static readonly Guid hotelGuid = new("d9f9b9b0-5b9a-4b9c-9c9d-9b9b9b9b9b9c");
        private static readonly Guid apartmentGuid = new("d9f9b9b0-5b9a-4b9c-9c9d-9b9b9b9b9b9d");
        private static readonly Guid penthouseGuid = new("d9f9b9b0-5b9a-4b9c-9c9d-9b9b9b9b9b9e");
        private static readonly Guid firstUserId = new("8399c62e-d0b4-49bc-a8c6-0a7a0446c159");
        private static readonly Guid secondUserId = new("8399c62e-d0b4-49bc-a8c6-0a7a0446c259");
        private static readonly Guid thirdUserId = new("8399c62e-d0b4-49bc-a8c6-0a7a0446c359");
        private static readonly Guid fourthUserId = new("8399c62e-d0b4-49bc-a8c6-0a7a0446c459");

        internal static async Task ResetDatabaseState(RealEstateDbContext context)
        {
            context.Database.EnsureDeleted();
            context.Database.EnsureCreated();
            await context.Categories.AddRangeAsync(GetCategories());
            await context.Users.AddRangeAsync(GetUsers());
            await context.Properties.AddRangeAsync(GetProperties());
            await context.Bookmarks.AddRangeAsync(GetBookmarks());
            await context.SaveChangesAsync();
        }

        internal static IEnumerable<Category> GetCategories() => new Category[]
            {
                new Category { CategoryId = houseGuid, Name = "House", ImageUrl = "house.png" },
                new Category { CategoryId = hotelGuid, Name = "Hotel", ImageUrl = "hotel.png" },
                new Category { CategoryId = apartmentGuid, Name = "Apartment", ImageUrl = "apartment.png" },
                new Category { CategoryId = penthouseGuid, Name = "Penthouse", ImageUrl = "penthouse.png" }
            };
        internal static IEnumerable<User> GetUsers() => new User[]
            {
                new User { UserId = firstUserId, Name = "Andrew", Email = "andrew@email.com", Password = "And@1234", Phone = "93524682" },
                new User { UserId = secondUserId, Name = "Bob", Email = "bob@email.com", Password = "Bb@1234", Phone = "93925611" },
                new User { UserId = thirdUserId, Name = "John", Email = "john@email.com", Password = "Jn@1234", Phone = "93624627" },
                new User { UserId = fourthUserId, Name = "Chris", Email = "chris@email.com", Password = "Crs@1234", Phone ="93304682" }
            };

        internal static IEnumerable<Property> GetProperties() =>
                 new Property[] {
                  new Property {
                    PropertyId = new("d9f9b9b0-5b9a-4b9c-9c9d-9b9b9b9b9b9f"),
                    Name = "Parramatta Metro City", ImageUrl = "imagep1.jpg", Price = 800000,
                    IsTrending = false, CategoryId = houseGuid, UserId = firstUserId,
                    Detail =
                        "We are delighted to present this exquisite one-bedroom apartment located in Parramatta CBD, brought to you by Allsopp Real Estate. Boasting breathtaking panoramic views of the marina from every room, this vacant apartment spans across 696 sq. ft. It is an ideal choice for short-term holiday rentals or as a comfortable first home.",
                    Address = "109 George Street, Parramatta, NSW 2150"
                  },
                  new Property {
                    PropertyId = new("d9f9b9b0-5b9a-4b9c-9c9d-9b9b9b9b9b10"),
                    Name = "Stuning Drift Street", ImageUrl = "imagep2.jpg", Price = 700000,
                    IsTrending = true, CategoryId = houseGuid, UserId = firstUserId,
                    Detail =
                        "Immaculately presented and meticulously kept, this well designed and quality built home is situated on a quiet street in a convenient location which is walking distance away from The Ponds High & Riverbank Primary school, Stanhope Village Centre & The Ponds Shopping Centre, transport options and parklands.",
                    Address = "Drift Street, The Ponds, NSW 2769"
                  },
                  new Property {
                    PropertyId = new("d9f9b9b0-5b9a-4b9c-9c9d-9b9b9b9b9b11"),
                    Name = "Distress Deal", ImageUrl = "imagep3.jpg", Price = 200000,
                    IsTrending = false, CategoryId = houseGuid, UserId = firstUserId,
                    Detail =
                        "A sprawling waterfront estate of Tuscan inspired grandeur, this full brick home awaits refurbishment to reclaim its title as a Middle Harbour view masterpiece. It's tucked away on a north-west facing 752sqm parcel in a quiet cul-de-sac, close to Mosman Village.",
                    Address = "Shellbank Avenue, Mosman, NSW 2088"
                  },
                  new Property {
                    PropertyId = new("d9f9b9b0-5b9a-4b9c-9c9d-9b9b9b9b9b12"),
                    Name = "Panoramic Views", ImageUrl = "imagep4.jpg", Price = 900000,
                    IsTrending = false, CategoryId = hotelGuid, UserId = firstUserId,
                    Detail =
                        "Brave, bespoke and brilliant. This distinctive east facing 4 bedroom harbour front sanctuary, created by acclaimed architect Bruce Stafford, enjoys a gloriously private and abundant ambience offering an unparalleled living experience.",
                    Address = "Baden Road, Kurraba Point, NSW 2089"
                  },
                  new Property {
                    PropertyId = new("d9f9b9b0-5b9a-4b9c-9c9d-9b9b9b9b9b13"),
                    Name = "Family-Friendly Lowset Geared for Entertaining", ImageUrl = "imagep5.jpg", Price = 750000,
                    IsTrending = true, CategoryId = hotelGuid, UserId = firstUserId,
                    Detail =
                        "Strolling distance to leafy parks, city-bound buses, the local zoned primary and high schools, and both Runcorn Plaza and Warrigal Rd Shopping Centre, this four-bedroom home must be one of the best positioned on the southside for family convenience",
                    Address = "Trevi Close, Eight Mile Plains, Qld 4113"
                  },
                  new Property {
                    PropertyId = new("d9f9b9b0-5b9a-4b9c-9c9d-9b9b9b9b9b14"),
                    Name = "Full North Lakes View", ImageUrl = "imagep6.jpg", Price = 200000,
                    IsTrending = false, CategoryId = apartmentGuid, UserId = firstUserId,
                    Detail =
                        "We are proud to present to the market for the very first time this beautiful double storey family Home. An absolute oasis from life perched on a 450m2 block, you will simply love every part of this home. The home features a combination of multiple living areas and open plan living - whether you have an extended family or love entertaining, this home has all that you need.",
                    Address = " Pademelon Circuit, North Lakes, Qld 4509"
                  },
                  new Property {
                    PropertyId = new("d9f9b9b0-5b9a-4b9c-9c9d-9b9b9b9b9b15"),
                    Name = "Derwent  Palace", ImageUrl = "imagep7.jpg", Price = 300000,
                    IsTrending = true, CategoryId = apartmentGuid, UserId = firstUserId,
                    Detail =
                        "Don't miss out on this incredible opportunity! We present to you a well-presented four-bedroom brick veneer home with a near-new rare three-bedroom granny flat. Nestled in the highly sought-after area of Blacktown, this property offers comfortable living and fantastic Investment potential.",
                    Address = "Derwent Parade, Blacktown, NSW 2148"
                  },
                  new Property {
                    PropertyId =
                        new("d9f9b9b0-5b9a-4b9c-9c9d-9b9b9b9b9b16"),
                    Name = "Distress Deal", ImageUrl = "imagep8.jpg",
                    Price = 400000, IsTrending = false, CategoryId = apartmentGuid,
                    UserId = firstUserId,
                    Detail =
                        "This DOUBLE BRICK, Torrens Title Cherrybrook home on 450msq with high ceilings offers a comfortable four bedrooms, standout location and important updates to key rooms. Recent neutral tone painting, new carpets upstairs and low-fuss polished porcelain tile floors to the downstairs living areas ensure this property is not only very practical but also very appealing to a range of different buyers such as down-sizers, first home buyers and investors.",
                    Address = "Wisteria Crescent, Cherrybrook, NSW 2126"
                  },
                  new Property {
                    PropertyId =
                        new("d9f9b9b0-5b9a-4b9c-9c9d-9b9b9b9b9b17"),
                    Name = "Sea View", ImageUrl = "imagep9.jpg",
                    Price = 880000, IsTrending = false, CategoryId = apartmentGuid,
                    UserId = firstUserId,
                    Detail =
                        "If ever there was a definition of relaxation, this is it. A hilltop haven overlooking Pittwater with sweeping views of Careel Bay and beyond, enveloped in privacy within a serene natural setting. This stunning dual level 5-bedroom home has been crafted with character, and built to harmonise with its elevated bushland environment on a peaceful cul de sac.",
                    Address = "Crane Lodge Place, Palm Beach, NSW 2108"
                  },
                  new Property { PropertyId = new("d9f9b9b0-5b9a-4b9c-9c9d-9b9b9b9b9b18"),
                                 Name = "Quebec Height", ImageUrl = "imagep10.jpg",
                                 Price = 5500000, IsTrending = false, CategoryId = penthouseGuid, UserId = firstUserId, 
                      Detail = "This family home, in the most sought after \"HIGHLANDS\" Estate catering to young families, providing an amazing lifestyle and offering you convenience, comfort, luxury and space.",
                                 Address = "Quebec Avenue, Craigieburn, Vic 3064" },
                  new Property {
                    PropertyId = new("d9f9b9b0-5b9a-4b9c-9c9d-9b9b9b9b9b19"),
                    Name = " Luxury Living, Great View", ImageUrl = "imagep11.jpg", Price = 800000,
                    IsTrending = false, CategoryId = penthouseGuid, UserId = firstUserId,
                    Detail =
                        "Lighthouse is perfectly situated in the heart of CBD, providing easy access to a wide range of iconic landmarks and amenities such as Melbourne Central, QV, Queens Victoria Market, Emporium, Myer, and David Jones. Additionally, renowned educational institutions like RMIT and Melbourne University and a fine selection of great local restaurants and cafes are just a short stroll away. With a tram stop conveniently located at your doorstep, you can effortlessly explore the CBD, Carlton, Spring Street, Flinders Street Station, Federation Square, and beyond.",
                    Address = "Elizabeth Street, Melbourne, Vic 3000"
                  },
                  new Property {
                    PropertyId = new("d9f9b9b0-5b9a-4b9c-9c9d-9b9b9b9b9b20"),
                    Name = "Victoria World", ImageUrl = "imagep12.jpg", Price = 650000,
                    IsTrending = true, CategoryId = penthouseGuid, UserId = firstUserId,
                    Detail =
                        "t would be hard to find a better lifestyle location than that enjoyed by this double-storey terrace which dishes up welcoming character-filled interiors along with just the right amount of potential to really get you excited. ",
                    Address = "Victoria Street, Windsor, Vic 3181"
                  }
     };
        internal static IEnumerable<Bookmark> GetBookmarks() => new Bookmark[]
            {
                new Bookmark { BookmarkId = new System.Guid("a46ab603-903e-4460-9ba7-da5f3f0f9e92"), Status = true, UserId = firstUserId, PropertyId = new System.Guid("d9f9b9b0-5b9a-4b9c-9c9d-9b9b9b9b9b9f") }
            };
    }
}
