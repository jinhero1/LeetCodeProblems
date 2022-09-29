namespace LongestPalindrome
{
    // Memory Usage: 34.6 MB, less than 93.29% of C# online submissions for Longest Palindrome.
    public class Solution
    {
        private const int ONE = 1;
        private const int TWO = 2;
        private const char UPPER_CASE_A = 'A';

        public int LongestPalindrome(string s)
        {
            int[] letterCounts = new int[58];

            for (int i = 0; i < s.Length; i++)
            {
                letterCounts[s[i] - UPPER_CASE_A]++;
            }

            int lengthCount = 0;
            int _charCount = 0;
            bool _hasOddChecked = false;
            for (int i = 0; i < letterCounts.Length; i++)
            {
                _charCount = letterCounts[i];
                if (_charCount == 0) continue;

                if (_charCount % TWO == 0)
                {
                    lengthCount += _charCount;
                }
                // count odd as the even 
                else
                {
                    lengthCount += _charCount - ONE;
                    _hasOddChecked = true;
                }
            }

            if (_hasOddChecked) lengthCount++;

            return lengthCount;
        }
    }
}