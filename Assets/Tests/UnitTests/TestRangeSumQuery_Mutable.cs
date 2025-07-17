using NUnit.Framework;
using System.Collections;
using RangeSumQuery_Mutable;

public class TestRangeSumQuery_Mutable
{
    private static IEnumerable TestCases
    {
        get
        {

            yield return new TestCaseData(
                (object)new string[] { "NumArray", "sumRange", "sumRange", "sumRange", "update", "update", "update", "sumRange", "update", "sumRange", "update" },
                (object)new object[] {
                    new object[] { new int[] { 0, 9, 5, 7, 3 } },
                    new object[] { 4, 4 },
                    new object[] { 2, 4 },
                    new object[] { 3, 3 },
                    new object[] { 4, 5 },
                    new object[] { 1, 7 },
                    new object[] { 0, 8 },
                    new object[] { 1, 2 },
                    new object[] { 1, 9 },
                    new object[] { 4, 4 },
                    new object[] { 3, 4 }
                },
                (object)new object[] { null, 3, 15, 7, null, null, null, 12, null, 5, null }
            );
            yield return new TestCaseData(
                (object)new string[] { "NumArray", "update", "sumRange", "sumRange", "update", "sumRange" },
                (object)new object[] {
                    new object[] { new int[] { 9, -8 } },
                    new object[] { 0, 3 },
                    new object[] { 1, 1 },
                    new object[] { 0, 1 },
                    new object[] { 1, -3 },
                    new object[] { 0, 1 }
                },
                (object)new object[] { null, null, -8, -5, null, 0 }
            );
            yield return new TestCaseData(
                (object)new string[] { "NumArray", "sumRange", "update", "sumRange" },
                (object)new object[] {
                    new object[] { new int[] { -1 } },
                    new object[] { 0, 0 },
                    new object[] { 0, 1 },
                    new object[] { 0, 0 }
                },
                (object)new object[] { null, -1, null, 1 }
            );
            yield return new TestCaseData(
                (object)new string[] { "NumArray", "sumRange", "update", "sumRange" },
                (object)new object[] {
                    new object[] { new int[] { 1, 3, 5 } },
                    new object[] { 0, 2 },
                    new object[] { 1, 2 },
                    new object[] { 0, 2 }
                },
                (object)new object[] { null, 9, null, 8 }
            );
        }
    }

    [TestCaseSource(nameof(TestCases))]
    public void Test_NumArrayCommands(string[] cmds, object[] argsList, object[] expected)
    {
        var results = new object[cmds.Length];
        NumArray numArray = null;

        for (int i = 0; i < cmds.Length; i++)
        {
            var args = (object[])argsList[i];
            switch (cmds[i])
            {
                case "NumArray":
                    numArray = new NumArray((int[])args[0]);
                    results[i] = null;
                    break;
                case "sumRange":
                    results[i] = numArray.SumRange((int)args[0], (int)args[1]);
                    break;
                case "update":
                    numArray.Update((int)args[0], (int)args[1]);
                    results[i] = null;
                    break;
                default:
                    Assert.Fail($"Unknown command: {cmds[i]}");
                    break;
            }
        }

        CollectionAssert.AreEqual(expected, results);
    }
}
