namespace MaximumGap
{
    public class Solution
    {
        public int MaximumGap(int[] nums)
        {
            int n = nums.Length;
            if (n < 2) return 0;

            // 1) Find global minimum and maximum
            int minV = nums[0], maxV = nums[0];
            foreach (int x in nums)
            {
                if (x < minV) minV = x;
                if (x > maxV) maxV = x;
            }
            if (minV == maxV) return 0; // all numbers are identical

            // 2) Compute bucket size using ceil division
            int delta = maxV - minV;
            int bucketSize = (delta + (n - 2)) / (n - 1);  // ceil(delta / (n-1))
            int bucketCount = delta / bucketSize + 1;

            // 3) Initialize buckets
            int[] bucketMin = new int[bucketCount];
            int[] bucketMax = new int[bucketCount];
            bool[] used = new bool[bucketCount];
            for (int i = 0; i < bucketCount; i++)
            {
                bucketMin[i] = int.MaxValue;
                bucketMax[i] = int.MinValue;
            }

            // 4) Distribute numbers into buckets
            foreach (int x in nums)
            {
                int idx = (x - minV) / bucketSize;
                if (!used[idx])
                {
                    used[idx] = true;
                    bucketMin[idx] = x;
                    bucketMax[idx] = x;
                }
                else
                {
                    if (x < bucketMin[idx]) bucketMin[idx] = x;
                    if (x > bucketMax[idx]) bucketMax[idx] = x;
                }
            }

            // 5) Scan buckets to find maximum gap between successive non-empty buckets
            int maxGap = 0;
            int prevMax = minV;
            for (int i = 0; i < bucketCount; i++)
            {
                if (!used[i]) continue;
                // gap between this bucket's minimum and previous bucket's maximum
                int gap = bucketMin[i] - prevMax;
                if (gap > maxGap) maxGap = gap;
                prevMax = bucketMax[i];
            }

            return maxGap;
        }
    }
}
