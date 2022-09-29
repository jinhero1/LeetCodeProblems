namespace RangeSumQuery_Immutable
{
    // Runtime: 147 ms, faster than 97.17% of C# online submissions for Range Sum Query - Immutable.
    public class NumArray
    {
        private int[] sumQueries;
        private int _sum;
        private const int ZERO = 0;
        private const int ONE = 1;

        public NumArray(int[] nums)
        {
            sumQueries = new int[nums.Length];

            for (int i = 0; i < nums.Length; i++)
            {
                if (i == ZERO)
                {
                    sumQueries[i] = nums[i];
                }
                else
                {
                    sumQueries[i] = sumQueries[i - ONE] + nums[i];
                }
            }
        }

        public int SumRange(int left, int right)
        {
            _sum = 0;

            if (left == 0)
            {
                _sum = sumQueries[right];
            }
            else
            {
                // If rang is (2, 5), the reuslt will be (0, 5) - (0, 1)
                _sum = sumQueries[right] - sumQueries[left - ONE];
            }

            return _sum;
        }
    }
}
