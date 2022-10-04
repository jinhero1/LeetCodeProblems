using System.Collections.Generic;

namespace MergeSimilarItems
{
    public class Solution
    {
        private const int WEIGHT_SIZE = 1001;
        private const int VALUE_INDEX = 0;
        private const int WEIGHT_INDEX = 1;

        private int[] weights;
        private List<int> values = new List<int>();

        public IList<IList<int>> MergeSimilarItems(int[][] items1, int[][] items2)
        {
            weights = new int[WEIGHT_SIZE];
            values.Clear();

            CountWeights(items1);
            CountWeights(items2);
            values.Sort();

            IList<IList<int>> ret = new List<IList<int>>();
            int _value;
            for (int i = 0; i < values.Count; i++)
            {
                _value = values[i];
                ret.Add(new List<int> { _value, weights[_value] });
            }

            return ret;
        }

        private void CountWeights(int[][] items)
        {
            int _value;
            int _weight;
            for (int i = 0; i < items.Length; i++)
            {
                _value = items[i][VALUE_INDEX];
                _weight = items[i][WEIGHT_INDEX];

                weights[_value] += _weight;

                if (!values.Contains(_value))
                {
                    values.Add(_value);
                }
            }
        }
    }
}