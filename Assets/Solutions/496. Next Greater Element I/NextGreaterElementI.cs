namespace NextGreaterElementI
{
    public class Solution
    {
        private const int NUMS_SIZE = 10001;
        private const int NOT_FOUND = -1;
        private const int ONE = 1;

        private int num2Length;
        private int _startIndex;
        private int _num;

        public int[] NextGreaterElement(int[] nums1, int[] nums2)
        {
            int[] greaterNums = new int[NUMS_SIZE];

            num2Length = nums2.Length;
            int _num;
            int _greaterIndex;
            for (int j = 0; j < num2Length; j++)
            {
                _num = nums2[j];

                _greaterIndex = FindGreaterIndex(nums2, j);
                if (_greaterIndex < 0)
                {
                    greaterNums[_num] = NOT_FOUND;
                    continue;
                }

                greaterNums[_num] = nums2[_greaterIndex];
            }

            int nums1Length = nums1.Length;
            int[] ans = new int[nums1Length];
            for (int i = 0; i < nums1Length; i++)
            {
                ans[i] = greaterNums[nums1[i]];
            }

            return ans;
        }

        private int FindGreaterIndex(int[] nums2, int index)
        {
            _startIndex = index + ONE;
            if (_startIndex >= num2Length)
            {
                return NOT_FOUND;
            }

            _num = nums2[index];
            for (int j = _startIndex; j < num2Length; j++)
            {
                if (nums2[j] > _num)
                {
                    return j;
                }
            }

            return NOT_FOUND;
        }
    }
}