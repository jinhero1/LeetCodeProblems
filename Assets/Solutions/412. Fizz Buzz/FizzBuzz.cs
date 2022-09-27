using System.Collections.Generic;
using UnityEngine;

namespace FizzBuzz
{
    internal class Solution
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


    public class FizzBuzz : MonoBehaviour
    {
        void Start()
        {
            Solution solution = new Solution();
            IList<string> output = solution.FizzBuzz(30);
            DebugUtility.Log(output);
        }
    }
}
