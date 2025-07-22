using System;
using System.Collections.Generic;

namespace InsertDeleteGetRandomO1
{
    // You must implement the functions of the class such that each function works in average O(1) time complexity.
    public class RandomizedSet
    {
        private Dictionary<int, int> idx;
        private List<int> nums;
        Random rand;
        int _lastIndex;
        int _lastVal;
        int _index;

        public RandomizedSet()
        {
            idx = new Dictionary<int, int>();
            nums = new List<int>();
            rand = new Random();
        }

        public bool Insert(int val)
        {
            if (idx.ContainsKey(val))
            {
                return false; // Value already exists
            }
            idx[val] = nums.Count; // Store the index of the new value
            nums.Add(val); // Add the value to the list
            return true;
        }

        public bool Remove(int val)
        {
            if (!idx.TryGetValue(val, out int _index))
            {
                return false; // Value does not exist
            }
            _lastIndex = nums.Count - 1;
            _lastVal = nums[_lastIndex];
            // move last into i’s spot
            nums[_index] = _lastVal;
            idx[_lastVal] = _index;
            // pop and remove from map
            nums.RemoveAt(_lastIndex);
            idx.Remove(val);
            return true;
        }

        public int GetRandom()
        {
            return nums[rand.Next(nums.Count)];
        }
    }
}
