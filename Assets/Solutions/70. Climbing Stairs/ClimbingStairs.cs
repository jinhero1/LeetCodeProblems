using System;

namespace ClimbingStairs
{
    // Runtime: 19 ms, faster than 97.43% of C# online submissions for Climb Stairs.
    public class Solution
    {
        // F(n) = F(n-1) + F(n-2)
        // Fibonacci Sequence Formula
        // https://youtu.be/whbjsLicdwM
        private const double SQRT_FIVE = 2.23606797749979;
        private const double RECIPROCAL_SQRT_FIVE = 0.447213595499958;

        public int ClimbStairs(int n)
        {
            int nextN = n + 1;

            double[] tables = new double[2];
            tables[0] = Math.Pow((1 + SQRT_FIVE) * 0.5, nextN);
            tables[1] = Math.Pow((1 - SQRT_FIVE) * 0.5, nextN);

            return (int)(RECIPROCAL_SQRT_FIVE * (tables[0] - tables[1]));
        }
    }
}