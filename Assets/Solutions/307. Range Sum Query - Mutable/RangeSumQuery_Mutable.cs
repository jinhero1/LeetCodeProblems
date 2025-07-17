namespace RangeSumQuery_Mutable
{
    public class NumArray
    {
        private int[] _nums;
        private int _left;
        private int _right;
        private int _sum;
        private int _originalVal;

        public NumArray(int[] nums)
        {
            _nums = nums;
            _left = 0;
            _right = nums.Length - 1;
            for (int i = _left; i <= _right; i++)
            {
                _sum += _nums[i];
            }
        }

        public void Update(int index, int val)
        {
            if (index >= _left && index <= _right)
            {
                _originalVal = _nums[index];
                if (_originalVal > val)
                {
                    _sum -= _originalVal - val;
                }
                else if (val > _originalVal)
                {
                    _sum += val - _originalVal;
                }
            }            
            _nums[index] = val;
        }

        public int SumRange(int left, int right)
        {
            if (left == right)
            {
                return _nums[left];
            }

            if (left > _left)
            {
                for (int i = _left; i < left; i++)
                {
                    _sum -= _nums[i];
                }
            }
            else if (left < _left)
            {
                for (int i = left; i < _left; i++)
                {
                    _sum += _nums[i];
                }
            }

            if (right > _right)
            {
                for (int i = _right + 1; i <= right; i++)
                {
                    _sum += _nums[i];
                }
            }
            else if (right < _right)
            {
                for (int i = right + 1; i <= _right; i++)
                {
                    _sum -= _nums[i];
                }
            }

            _left = left;
            _right = right;
            return _sum;
        }
    }
}
