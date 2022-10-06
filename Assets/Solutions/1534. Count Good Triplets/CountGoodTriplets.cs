using System;

namespace CountGoodTriplets
{
    public class Solution
    {
        private const int TWO = 2;
        private const int ONE = 1;

        public int CountGoodTriplets(int[] arr, int a, int b, int c)
        {
            int numberOfGoodTriplets = 0;
            bool _good;
            for (int i = 0; i < arr.Length - TWO; i++)
            {
                for (int j = i + ONE; j < arr.Length - ONE; j++)
                {
                    for (int k = j + ONE; k < arr.Length; k++)
                    {
                        _good = Math.Abs(arr[i] - arr[k]) <= c;
                        if (!_good) continue;

                        _good = Math.Abs(arr[j] - arr[k]) <= b;
                        if (!_good) continue;

                        _good = Math.Abs(arr[i] - arr[j]) <= a;
                        if (_good)
                        {
                            numberOfGoodTriplets++;
                        }
                    }
                }
            }

            return numberOfGoodTriplets;
        }
    }
}