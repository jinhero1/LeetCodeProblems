namespace MaximumAverageSubarrayI
{
    public class Solution
    {
        public double FindMaxAverage(int[] nums, int k)
        {
            // compute sum of the first window [0..k-1]
            int windowSum = 0;
            for (int i = 0; i < k; i++) windowSum += nums[i];
            int best = windowSum;

            // slide the window: add nums[i], remove nums[i-k]
            for (int i = k; i < nums.Length; i++)
            {
                windowSum += nums[i] - nums[i - k];
                if (windowSum > best) best = windowSum;
            }

            // return maximum average with double precision
            return (double)best / k;
        }
    }
}
