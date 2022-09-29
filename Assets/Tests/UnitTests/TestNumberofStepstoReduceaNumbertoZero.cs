using NUnit.Framework;
using NumberofStepstoReduceaNumbertoZero;

public class TestNumberofStepstoReduceaNumbertoZero
{
    [Test]
    [TestCase(14, 6)]
    [TestCase(8, 4)]
    [TestCase(123, 12)]
    public void Calculate_NumberofStepstoReduceaNumbertoZero(int num, int result)
    {
        Solution solution = new Solution();
        int output = solution.NumberOfSteps(num);

        Assert.AreEqual(result, output);
    }
}
