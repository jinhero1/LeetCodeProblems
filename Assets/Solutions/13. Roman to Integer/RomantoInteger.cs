using System.Collections.Generic;
using System.Text;

namespace RomantoInteger
{
    // Runtime: 86 ms, faster than 83.15% of C# online submissions for Roman to Integer.
    // Memory Usage: 36.8 MB, less than 77.15% of C# online submissions for Roman to Integer.
    public class Solution
    {
        private readonly Dictionary<char, int> symbolValues = new Dictionary<char, int>
        {
            { 'I', 1 },
            { 'V', 5 },
            { 'X', 10 },
            { 'L', 50 },
            { 'C', 100 },
            { 'D', 500 },
            { 'M', 1000 },
        };

        private readonly Dictionary<string, int> subtractions = new Dictionary<string, int>
        {
            { "IV", 4 },
            { "IX", 9 },
            { "XL", 40 },
            { "XC", 90 },
            { "CD", 400 },
            { "CM", 900 },
        };

        private readonly StringBuilder stringBuilder = new StringBuilder();

        public int RomanToInt(string s)
        {
            int sum = 0;
            int _secondLastIndex = s.Length - 2;
            string _checkedSubtraction = null;
            for (int i = 0; i < s.Length; i++)
            {
                if (i <= _secondLastIndex)
                {
                    stringBuilder.Length = 0;
                    stringBuilder.Append(s[i]);
                    stringBuilder.Append(s[i + 1]);
                    _checkedSubtraction = stringBuilder.ToString();
                    if (subtractions.ContainsKey(_checkedSubtraction))
                    {
                        sum += subtractions[_checkedSubtraction];
                        i++;
                        continue;
                    }
                }

                sum += symbolValues[s[i]];
            }

            return sum;
        }
    }
}