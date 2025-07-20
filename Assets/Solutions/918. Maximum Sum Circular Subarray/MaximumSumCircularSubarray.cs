using System;

namespace MaximumSumCircularSubarray
{
    public class Solution
    {
        public int MaxSubarraySumCircular(int[] nums)
        {
            int n = nums.Length;

            // initialize sums with first element
            int total = nums[0];
            int maxEnding = nums[0], maxSoFar = nums[0];
            int minEnding = nums[0], minSoFar = nums[0];

            // process the rest of the array
            for (int i = 1; i < n; i++)
            {
                int x = nums[i];

                // standard Kadane for max subarray
                maxEnding = Math.Max(x, maxEnding + x);
                maxSoFar = Math.Max(maxSoFar, maxEnding);

                // Kadane for min subarray
                minEnding = Math.Min(x, minEnding + x);
                minSoFar = Math.Min(minSoFar, minEnding);

                // accumulate total sum
                total += x;
            }

            // if all values are negative, maxSoFar is the answer
            if (maxSoFar < 0)
                return maxSoFar;

            // otherwise, max of non-wrap and wrap cases
            int maxWrap = total - minSoFar;
            return Math.Max(maxSoFar, maxWrap);
        }
    }
}
