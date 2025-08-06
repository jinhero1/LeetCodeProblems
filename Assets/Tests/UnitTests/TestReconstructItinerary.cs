using NUnit.Framework;
using System.Collections;
using System.Collections.Generic;
using ReconstructItinerary;

public class TestReconstructItinerary
{
    private static IEnumerable TestCases
    {
        get
        {
            // Example 1
            yield return new TestCaseData(
                (object)new List<IList<string>> {
                    new List<string> { "MUC", "LHR" },
                    new List<string> { "JFK", "MUC" },
                    new List<string> { "SFO", "SJC" },
                    new List<string> { "LHR", "SFO" }
                },
                (object)new List<string> { "JFK", "MUC", "LHR", "SFO", "SJC" }
            );

            // Example 2
            yield return new TestCaseData(
                (object)new List<IList<string>> {
                    new List<string> { "JFK", "SFO" },
                    new List<string> { "JFK", "ATL" },
                    new List<string> { "SFO", "ATL" },
                    new List<string> { "ATL", "JFK" },
                    new List<string> { "ATL", "SFO" }
                },
                (object)new List<string> { "JFK", "ATL", "JFK", "SFO", "ATL", "SFO" }
            );
        }
    }

    [TestCaseSource(nameof(TestCases))]
    public void Test_FindItinerary(IList<IList<string>> tickets, IList<string> expected)
    {
        var result = new Solution().FindItinerary(tickets);
        CollectionAssert.AreEqual(expected, result);
    }
}
