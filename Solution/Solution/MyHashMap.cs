using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solution
{
    public class MyHashMap
    {
        public List<Pair<int, int>>[] Hash;
        int maxCnt = 9997;
        /** Initialize your data structure here. */
        public MyHashMap()
        {
            Hash = new List<Pair<int, int>>[maxCnt];
        }

        /** value will always be non-negative. */
        public void Put(int key, int value)
        {
            if (Hash[key % maxCnt] == null)
            {
                Hash[key % maxCnt] = new List<Pair<int, int>>();
            }
            foreach (var p in Hash[key % maxCnt])
            {
                if (p.Key == key)
                {
                    p.Value = value;
                    return;
                }
            }
            Hash[key % maxCnt].Add(new Pair<int, int>(key, value));
        }

        /** Returns the value to which the specified key is mapped, or -1 if this map contains no mapping for the key */
        public int Get(int key)
        {
            if (Hash[key % maxCnt] == null)
            {
                return -1;
            }
            foreach (var p in Hash[key % maxCnt])
            {
                if (p.Key == key)
                    return p.Value;
            }
            return -1;
        }

        /** Removes the mapping of the specified value key if this map contains a mapping for the key */
        public void Remove(int key)
        {
            if (Hash[key % maxCnt] == null)
            {
                return;
            }
            for (int i = 0; i < Hash[key % maxCnt].Count; i++)
            {
                var p = Hash[key % maxCnt][i];
                if (p.Key == key)
                {
                    Hash[key % maxCnt].RemoveAt(i);
                    return;
                }
            }
        }
    }
}
