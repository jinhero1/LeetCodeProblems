namespace AddDigits
{
    public class Solution
    {
        private const int ZERO = 0;
        private const int TEN = 10;

        private int sum, _remainder, _quotient;

        public int AddDigits(int num)
        {
            while (num >= TEN)
            {
                num = GetDigits(num);
            }

            return num;
        }

        private int GetDigits(int num)
        {
            sum = ZERO;
            _remainder = ZERO;
            _quotient = num;
            while (true)
            {
                _remainder = _quotient % TEN;
                sum += _remainder;

                _quotient /= TEN;
                if (_quotient == ZERO)
                {
                    break;
                }
            }

            return sum;
        }
    }
}