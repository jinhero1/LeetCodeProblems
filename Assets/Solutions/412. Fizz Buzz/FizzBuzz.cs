using System.Collections.Generic;

namespace FizzBuzz
{
    // Runtime: 156 ms, faster than 89.92% of C# online submissions for Fizz Buzz.
    // Memory Usage: 46.8 MB, less than 93.40% of C# online submissions for Fizz Buzz.
    public class Solution
    {
        private const string FIZZ = "Fizz";
        private const string BUZZ = "Buzz";
        private const string FIZZ_BUZZ = "FizzBuzz";

        private readonly string[] queries = new string[]
        {
            null,
            null,
            FIZZ,
            null,
            BUZZ,
            FIZZ,
            null,
            null,
            FIZZ,
            BUZZ,
            null,
            FIZZ,
            null,
            null,
            FIZZ_BUZZ,
        };

        public IList<string> FizzBuzz(int n)
        {
            List<string> results = new List<string>();
            int queriesLength = queries.Length;
            int _queryIndex;
            string _queryString = null;
            for (int i = 1; i <= n; i++)
            {
                _queryIndex = (i - 1) % queriesLength;
                _queryString = queries[_queryIndex];

                if (_queryString == null)
                {
                    results.Add(i.ToString());
                    continue;
                }

                results.Add(_queryString);
            }

            return results;
        }
    }
}
