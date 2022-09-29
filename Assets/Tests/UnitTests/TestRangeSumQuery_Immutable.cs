using System.Collections.Generic;
using NUnit.Framework;
using RangeSumQuery_Immutable;

public class TestRangeSumQuery_Immutable
{
    private static IEnumerable<TestCaseData> TestCases
    {
        get
        {
            yield return new TestCaseData(new string[] { "NumArray", "sumRange", "sumRange", "sumRange" },
                new int[][] { new int[] { -2, 0, 3, -5, 2, -1 }, new int[] { 0, 2 }, new int[] { 2, 5 }, new int[] { 0, 5 } },
                new object[] { null, 1, -1, -3 })
                .SetName("Example 1");

            yield return new TestCaseData(new string[] { "NumArray", "sumRange" },
                new int[][] { new int[] { -4, -5 }, new int[] { 0, 0 } },
                new object[] { null, -4 })
                .SetName("Example 2");

            yield return new TestCaseData(new string[] { "NumArray", "sumRange", "sumRange" },
                new int[][] { new int[] { 1, 4, -6 }, new int[] { 0, 2 }, new int[] { 0, 1 } },
                new object[] { null, -1, 5 })
                .SetName("Example 3");
        }
    }

    [Test]
    [TestCaseSource(nameof(TestCases))]
    public void Calculate_RangeSumQuery_Immutable(string[] methods, int[][] allParameters, object[] result)
    {
        NumArray numArray = null;
        int[] _parameters = null;
        object[] output = new object[result.Length];
        for (int i = 0; i < methods.Length; i++)
        {
            _parameters = allParameters[i];

            switch (methods[i])
            {
                case "NumArray":                                        
                    numArray = new NumArray(_parameters);
                    output[i] = null;
                    break;
                case "sumRange":
                    output[i] = numArray.SumRange(_parameters[0], _parameters[1]);
                    break;
            }
        }

        CollectionAssert.AreEqual(result, output);
    }
}
