using RealEstate.API.FitnessTests.Fixtures;
using RealEstate.API.FitnessTests.Models;
using RealEstate.API.FitnessTests.TestHelpers;

namespace RealEstate.API.FitnessTests.Performance.PerformanceTests
{
    /// <summary>
    ///  We can break down this class into multiple classes if it becomes very big
    /// </summary>
    public class PerformanceSLATests : BaseRestFixture
    {
        private HttpClient _httpClient;
        public PerformanceSLATests(FitnessWebApplicationFactory<Program> factory) : base(factory) =>
            _httpClient = CreateWebClientForAuthenticatedUser();

        [Fact]
        public void Category_Get_Calls_Are_In_95_Percentile()
        {
            //Arrange
            var performanceMeasure = Resolver.Resolve<IPerformanceMesaure>();
            //Act
            var result = performanceMeasure.IsHttpCallWithinAcceptablePercentile(loopCount: 100,
                percentileLimit: 0.95,
                expectedReposnse: 10,
                action: () => _httpClient.GetJsonAsync<List<object>>("/category").Wait());
            //Assert
            Assert.True(result);
        }

        #region Properties APIs
        [Fact]
        public void Property_TrendingProperties_Calls_Are_In_95_Percentile()
        {
            //Arrange
            var performanceMeasure = Resolver.Resolve<IPerformanceMesaure>();
            //Act
            var result = performanceMeasure.IsHttpCallWithinAcceptablePercentile(loopCount: 100,
                percentileLimit: 0.95,
                expectedReposnse: 10,
                action: () => _httpClient.GetJsonAsync<List<object>>("/property/trendingproperties").Wait());
            //Assert
            Assert.True(result);
        }

        [Fact]
        public void Property_ByCategory_Calls_Are_In_95_Percentile()
        {
            //Arrange
            var performanceMeasure = Resolver.Resolve<IPerformanceMesaure>();
            var penthouseCategory = GenesisDataState.GetCategories().FirstOrDefault(x => x.Name == "Penthouse");
            //Act
            var result = performanceMeasure.IsHttpCallWithinAcceptablePercentile(loopCount: 100,
                percentileLimit: 0.95,
                expectedReposnse: 10,
                action: () => _httpClient.GetJsonAsync<List<object>>($"/property/propertyList?categoryId={penthouseCategory!.CategoryId}").Wait());
            //Assert
            Assert.True(result);
        }

        [Fact]
        public void Property_BySearch_Calls_Are_In_95_Percentile()
        {
            //Arrange
            var performanceMeasure = Resolver.Resolve<IPerformanceMesaure>();
            var address = "Trevi Close";

            //Act
            var result = performanceMeasure.IsHttpCallWithinAcceptablePercentile(loopCount: 100,
                percentileLimit: 0.99,
                expectedReposnse: 10,
                action: () => _httpClient.GetJsonAsync<List<object>>($"/property/searchProperties?address={address}").Wait());
            //Assert
            Assert.True(result);
        }

        [Fact]
        public void Property_ById_Calls_Are_In_95_Percentile()
        {
            //Arrange
            var expectedProperty = GenesisDataState.GetProperties().FirstOrDefault(x => x.Name == "Stuning Drift Street");
            var performanceMeasure = Resolver.Resolve<IPerformanceMesaure>();

            //Act
            var result = performanceMeasure.IsHttpCallWithinAcceptablePercentile(loopCount: 100,
                percentileLimit: 0.99,
                expectedReposnse: 20,
                action: () => _httpClient.GetJsonAsync<object>($"/property/{expectedProperty!.PropertyId}").Wait());
            //Assert
            Assert.True(result);
        }

        [Fact]
        public void Property_Add_Calls_Are_In_95_Percentile()
        {
            //Arrange
            var expectedProperty = GenesisDataState.GetProperties().FirstOrDefault(x => x.Name == "Stuning Drift Street");
            var performanceMeasure = Resolver.Resolve<IPerformanceMesaure>();
            var hotelCategory = GenesisDataState.GetCategories().FirstOrDefault(x => x.Name == "Hotel");

            //Act
            var result = performanceMeasure.IsHttpCallWithinAcceptablePercentile(loopCount: 100,
                percentileLimit: 0.99,
            expectedReposnse: 10,
                action: () => _httpClient.PostJsonAsync($"/property", new AddProperty
                {
                    Name = $"Stuning Spring-{Guid.NewGuid}",
                    ImageUrl = "imagep20.jpg",
                    Price = 500000,
                    Address = $"The Springs-{Guid.NewGuid}, Sydney",
                    Detail = $"Lorem ipsum dolor sit amet--{Guid.NewGuid}",
                    CategoryId = hotelCategory!.CategoryId.ToString()
                }).Wait());
            //Assert
            Assert.True(result);
        }
        #endregion Properties APIs

        #region Bookmark APIs
        [Fact]
        public void Bookmark_Get_Calls_Are_In_95_Percentile()
        {
            //Arrange
            var performanceMeasure = Resolver.Resolve<IPerformanceMesaure>();
            //Act
            var result = performanceMeasure.IsHttpCallWithinAcceptablePercentile(loopCount: 100,
                percentileLimit: 0.95,
                expectedReposnse: 10,
                action: () => _httpClient.GetJsonAsync<List<object>>("/bookmark").Wait());
            //Assert
            Assert.True(result);
        }

        // To Do Add Bookmark and Delete Book

        #endregion Bookmark APIs
    }
}
