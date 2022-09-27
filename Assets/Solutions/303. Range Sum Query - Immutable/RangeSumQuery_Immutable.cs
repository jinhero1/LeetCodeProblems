using UnityEngine;

namespace RangeSumQuery_Immutable
{
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

    public class RangeSumQuery_Immutable : MonoBehaviour
    {
        void Start()
        {
            NumArray numArray = new NumArray(new int[] { -2, 0, 3, -5, 2, -1 });
            int output = numArray.SumRange(0, 2);
            Debug.Log($"Output: {output}");
            output = numArray.SumRange(2, 5);
            Debug.Log($"Output: {output}");
            output = numArray.SumRange(0, 5);
            Debug.Log($"Output: {output}");
            /*
            NumArray numArray = new NumArray(new int[] { -4, -5 });
            int output = numArray.SumRange(0, 0);
            */
            /*
            NumArray numArray = new NumArray(new int[] { 1, 4, -6 });
            int output = numArray.SumRange(0, 2);
            Debug.Log($"Output: {output}");
            output = numArray.SumRange(0, 1);
            Debug.Log($"Output: {output}");
            */
        }
    }
}
