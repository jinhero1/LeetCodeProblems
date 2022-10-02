using System.Collections.Generic;

namespace ContainsDuplicateII
{
    public class Solution
    {
        private Dictionary<int, int> previousIndexes = new Dictionary<int, int>();

        public bool ContainsNearbyDuplicate(int[] nums, int k)
        {
            previousIndexes.Clear();

            int _value;
            for (int i = 0; i < nums.Length; i++)
            {
                _value = nums[i];
                if (previousIndexes.ContainsKey(_value))
                {
                    if (i - previousIndexes[_value] <= k)
                    {
                        return true;
                    }                    
                }

                previousIndexes[_value] = i;
            }

            return false;
        }
    }
}