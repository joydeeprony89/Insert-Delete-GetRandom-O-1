using System;
using System.Collections.Generic;

namespace Insert_Delete_GetRandom_O_1_
{
    class Program
    {
        static void Main(string[] args)
        {
            // https://leetcode.com/problems/insert-delete-getrandom-o1/
        }
    }

    public class RandomizedSet
    {
        Dictionary<int, int> hash;
        List<int> items;
        int Length => items.Count;
        /** Initialize your data structure here. */
        public RandomizedSet()
        {
            hash = new Dictionary<int, int>();
            items = new List<int>();
        }

        /** Inserts a value to the set. Returns true if the set did not already contain the specified element. */
        public bool Insert(int val)
        {
            if (hash.ContainsKey(val)) return false;
            items.Add(val);
            hash.Add(val, Length - 1);
            return true;
        }

        /** Removes a value from the set. Returns true if the set contained the specified element. */
        public bool Remove(int val)
        {
            if (!hash.ContainsKey(val)) return false;
            var location = hash[val];
            if(location < Length)
            {
                int lastVal = items[Length - 1];
                items[location] = lastVal;
                hash[lastVal] = location;
            }
            items.RemoveAt(Length - 1);
            hash.Remove(val);
            return true;
        }

        /** Get a random element from the set. */
        public int GetRandom()
        {
            var random = new Random().Next(0, Length);
            return items[random];
        }
    }
}
