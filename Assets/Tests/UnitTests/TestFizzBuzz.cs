using NUnit.Framework;
using FizzBuzz;
using System.Collections.Generic;

public class TestFizzBuzz
{
    private static IEnumerable<TestCaseData> TestCases
    {
        get
        {
            yield return new TestCaseData(3, new List<string> { "1", "2", "Fizz" });

            yield return new TestCaseData(5, new List<string> { "1", "2", "Fizz", "4", "Buzz" });

            yield return new TestCaseData(15, new List<string> { "1", "2", "Fizz", "4", "Buzz", "Fizz", "7", "8", "Fizz", "Buzz", "11", "Fizz", "13", "14", "FizzBuzz" });

            yield return new TestCaseData(30, new List<string> { "1", "2", "Fizz", "4", "Buzz", "Fizz", "7", "8", "Fizz", "Buzz", "11", "Fizz", "13", "14", "FizzBuzz", "16", "17", "Fizz", "19", "Buzz", "Fizz", "22", "23", "Fizz", "Buzz", "26", "Fizz", "28", "29", "FizzBuzz" });
        }
    }

    [Test]
    [TestCaseSource(nameof(TestCases))]
    public void Calculate_FizzBuzz(int n, IList<string> result)
    {
        Solution solution = new Solution();
        IList<string> output = solution.FizzBuzz(n);

        CollectionAssert.AreEqual(result, output);
    }
}
