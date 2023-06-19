using RealEstate.API.FitnessTests.Fixtures;
using RealEstate.API.FitnessTests.TestHelpers;

namespace RealEstate.API.FitnessTests.Performance
{
    public class PerformanceSLATests : BaseRestFixture
    {
        public PerformanceSLATests(FitnessWebApplicationFactory<Program> factory) : base(factory) { }

        [Fact]
        internal void Categories_Get_Calls_Are_In_95_Percentile()
        {
            var performanceMeasure = Resolver.Resolve<IPerformanceMesaure>();
            var client = CreateWebClientForAuthenticatedUser();
            //95 percentile it is taling 10 or less mili seconds 
            var result = performanceMeasure.IsHttpCallWithinAcceptablePercentile(100, 0.95, 10, () => client.GetJsonAsync<List<Object>>("/category").Wait());
            Assert.True(result);
        }
    }
}
