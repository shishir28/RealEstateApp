using System.Diagnostics;

namespace RealEstate.API.FitnessTests.Performance
{
    internal class PerformanceTest : IPerformanceTest
    {
        public bool IsHttpCallWithinAcceptablePercentile(int loopCount, double percentileLimit, int expectedReposnse, Action action)
        {
           var stopWatch = new Stopwatch();
           var responseTimes =  new long[loopCount];

            for (int idx = 0; idx < loopCount; idx++)
            {
                stopWatch.Start();
                action();
                stopWatch.Stop();
                responseTimes[idx] = stopWatch.ElapsedMilliseconds;
                stopWatch.Reset();
            }
            Array.Sort(responseTimes);

            var percentileIndex = (int)Math.Ceiling(percentileLimit *responseTimes.Length) -1;
            var percentileTime = responseTimes[percentileIndex];
            return percentileTime > expectedReposnse;
        }
    }
}
