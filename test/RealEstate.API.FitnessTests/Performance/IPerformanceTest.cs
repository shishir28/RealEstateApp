namespace RealEstate.API.FitnessTests.Performance
{
    internal interface IPerformanceTest
    {
        bool IsHttpCallWithinAcceptablePercentile(int loopCount, double percentileLimit, int expectedReposnse, Action action);
    }
}
