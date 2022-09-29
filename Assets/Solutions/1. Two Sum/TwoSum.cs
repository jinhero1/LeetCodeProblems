using System.Collections.Generic;

namespace TwoSum
{
    public class Solution
    {
        #region MemoryMinimization
        // Memory Usage: 42.5 MB, less than 91.82% of C# online submissions for Two Sum.
        /*
        public int[] TwoSum(int[] nums, int target)
        {
            int[] indexes = null;
            for (int i = 0; i < nums.Length; i++)
            {
                indexes = FindIndexes(nums, target, i);
                if (indexes != null)
                {
                    break;
                }
            }

            return indexes;
        }

        private int[] FindIndexes(int[] nums, int target, int start)
        {
            for (int i = start + 1; i < nums.Length; i++)
            {
                if (nums[start] + nums[i] == target)
                {
                    return new int[] { start, i };
                }
            }

            return null;
        }
        */
        #endregion
        #region RuntimeFastest
        // Runtime: 163 ms, faster than 92.78% of C# online submissions for Two Sum.
        public int[] TwoSum(int[] nums, int target)
        {
            Dictionary<int, int> pairs = new Dictionary<int, int>();
            for (int i = 0; i < nums.Length; i++)
            {
                int diff = target - nums[i];
                if (pairs.ContainsKey(diff))
                {
                    return new int[] { pairs[diff], i };
                }

                pairs[nums[i]] = i;
            }

            return null;
        }
        #endregion
    }
}