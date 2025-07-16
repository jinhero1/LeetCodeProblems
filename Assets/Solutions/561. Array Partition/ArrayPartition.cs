namespace ArrayPartition
{
    public class Solution
    {
        private const int OFFSET = 10000;

        public int ArrayPairSum(int[] nums)
        {
            nums = CountingSort(nums, OFFSET);
            
            int sum = 0;
            for (int i = 0; i < nums.Length; i += 2)
            {
                sum += nums[i];
            }
            return sum;
        }

        private int[] CountingSort(int[] nums, int offset)
        {
            int size = offset + offset + 1;
            int[] count = new int[size];

            foreach (var v in nums)
                count[v + offset]++;
                
            int[] sorted = new int[nums.Length];
            int idx = 0;
            for (int bucket = 0; bucket < size; bucket++)
            {
                while (count[bucket]-- > 0)
                    sorted[idx++] = bucket - offset;
            }
            return sorted;
        }
    }
}
