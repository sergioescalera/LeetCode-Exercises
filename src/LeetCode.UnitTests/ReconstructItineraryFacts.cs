using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LeetCode.UnitTests
{
    [TestClass]
    [TestCategory("0332. Reconstruct Itinerary")]
    public class ReconstructItineraryFacts
    {
        [TestMethod]
        public void Example1()
        {
            var sol = new ReconstructItinerary();

            var output = sol.FindItinerary(new[]
            {
                new [] { "MUC", "LHR" },
                new [] { "JFK", "MUC" },
                new [] { "SFO", "SJC" },
                new [] { "LHR", "SFO" }
            });

            Assert.IsNotNull(output);
            Assert.AreEqual("JFK,MUC,LHR,SFO,SJC", string.Join(",", output));
        }

        [TestMethod]
        public void Example2()
        {
            var sol = new ReconstructItinerary();

            var output = sol.FindItinerary(new[]
            {
                new [] { "JFK", "SFO" },
                new [] { "JFK", "ATL" },
                new [] { "SFO", "ATL" },
                new [] { "ATL", "JFK" },
                new [] { "ATL", "SFO" }
            });

            Assert.IsNotNull(output);
            Assert.AreEqual("JFK,ATL,JFK,SFO,ATL,SFO", string.Join(",", output));
        }
    }
}
