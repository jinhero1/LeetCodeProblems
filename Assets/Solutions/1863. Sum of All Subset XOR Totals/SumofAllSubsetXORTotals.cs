namespace SumofAllSubsetXORTotals
{
    public class Solution
    {
        private const int ZERO = 0;
        private const int ONE = 1;

        private int[] nums;
        private int numsLength;

        public int SubsetXORSum(int[] nums)
        {
            this.nums = nums;
            numsLength = nums.Length;

            return GetSubsetSum(ZERO, ZERO);
        }

        // Backtracking approach
        private int GetSubsetSum(int index, int xorTotal)
        {
            // Final XOR total for subset
            if (index == numsLength) return xorTotal;

            // Include current element's sum
            int withElement = GetSubsetSum(index + ONE, xorTotal ^ nums[index]);

            // Exclude current element's sum
            int withoutElement = GetSubsetSum(index + ONE, xorTotal);

            // XOR sum of the bottom subtree
            return withElement + withoutElement;
        }
    }
}
