using NUnit.Framework;
using System.Collections;
using EvaluateDivision;

public class TestEvaluateDivision
{
    private static IEnumerable TestCases
    {
        get
        {
            yield return new TestCaseData(
                (object)new string[][] {
                new string[] { "x1", "x2" },
                new string[] { "x2", "x3" },
                new string[] { "x3", "x4" },
                new string[] { "x4", "x5" }
                },
                (object)new double[] { 3.0, 4.0, 5.0, 6.0 },
                (object)new string[][] {
                new string[] { "x1", "x5" },
                new string[] { "x5", "x2" },
                new string[] { "x2", "x4" },
                new string[] { "x2", "x2" },
                new string[] { "x2", "x9" },
                new string[] { "x9", "x9" }
                },
                (object)new double[] { 360.00000, 0.00833, 20.00000, 1.00000, -1.00000, -1.00000 }
            );

            yield return new TestCaseData(
                (object)new string[][] {
                    new string[] { "a", "e" },
                    new string[] { "b", "e" }
                },
                (object)new double[] { 4.0, 3.0 },
                (object)new string[][] {
                    new string[] { "a", "b" },
                    new string[] { "e", "e" },
                    new string[] { "x", "x" }
                },
                (object)new double[] { 1.33333, 1.0, -1.0 }
            );

            // Example 1
            yield return new TestCaseData(
                (object)new string[][] {
                    new string[] { "a", "b" },
                    new string[] { "b", "c" }
                },
                (object)new double[] { 2.0, 3.0 },
                (object)new string[][] {
                    new string[] { "a", "c" },
                    new string[] { "b", "a" },
                    new string[] { "a", "e" },
                    new string[] { "a", "a" },
                    new string[] { "x", "x" }
                },
                (object)new double[] { 6.0, 0.5, -1.0, 1.0, -1.0 }
            );

            // Example 2
            yield return new TestCaseData(
                (object)new string[][] {
                    new string[] { "a", "b" },
                    new string[] { "b", "c" },
                    new string[] { "bc", "cd" }
                },
                (object)new double[] { 1.5, 2.5, 5.0 },
                (object)new string[][] {
                    new string[] { "a", "c" },
                    new string[] { "c", "b" },
                    new string[] { "bc", "cd" },
                    new string[] { "cd", "bc" }
                },
                (object)new double[] { 3.75, 0.4, 5.0, 0.2 }
            );

            // Example 3
            yield return new TestCaseData(
                (object)new string[][] {
                    new string[] { "a", "b" }
                },
                (object)new double[] { 0.5 },
                (object)new string[][] {
                    new string[] { "a", "b" },
                    new string[] { "b", "a" },
                    new string[] { "a", "c" },
                    new string[] { "x", "y" }
                },
                (object)new double[] { 0.5, 2.0, -1.0, -1.0 }
            );
        }
    }

    [TestCaseSource(nameof(TestCases))]
    public void Test_EvaluateDivision(
        string[][] equations,
        double[] values,
        string[][] queries,
        double[] expected)
    {
        var result = new Solution().CalcEquation(equations, values, queries);
        Assert.That(result, Is.EqualTo(expected).Within(1e-5));
    }
}
