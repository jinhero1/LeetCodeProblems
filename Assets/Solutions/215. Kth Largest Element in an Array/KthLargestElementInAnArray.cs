using System;

namespace KthLargestElementInAnArray
{
    public class Solution
    {
        public int FindKthLargest(int[] nums, int k)
        {
            // Counting sort is used here to efficiently find the k-th largest element
            const int OFFSET = 10000;          // shift negative values into 0..20000
            const int SIZE = 2 * OFFSET + 1;   // buckets for -10000..10000
            var count = new int[SIZE];

            // 1) count frequencies
            foreach (var v in nums)
                count[v + OFFSET]++;

            // 2) scan from largest value down,
            //    subtracting counts until we find the k-th largest
            for (int i = SIZE - 1; i >= 0; i--)
            {
                k -= count[i];
                if (k <= 0)
                    return i - OFFSET;
            }

            // unreachable under valid input
            throw new InvalidOperationException();
        }
    }
}
