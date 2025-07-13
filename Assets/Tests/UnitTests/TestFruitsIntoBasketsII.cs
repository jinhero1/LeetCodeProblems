using NUnit.Framework;
using FruitsIntoBasketsII;

public class TestFruitsIntoBasketsII
{
    [TestCase(new[] { 4 }, new[] { 4 }, ExpectedResult = 0)]
    [TestCase(new[] { 4, 2, 5 }, new[] { 3, 5, 4 }, ExpectedResult = 1)]
    [TestCase(new[] { 3, 6, 1 }, new[] { 6, 4, 7 }, ExpectedResult = 0)]
    public int Test_NumOfUnplacedFruits(int[] fruits, int[] baskets)
        => new Solution().NumOfUnplacedFruits(fruits, baskets);
}
