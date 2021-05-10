using System.Collections.Generic;
using System;
using System.IO;

namespace AlgorithmsDataStructures
{
    public class BloomFilter
    {
        public int length;
        private uint[] filter;
        private List<Func<string, int>> hashes;

        private int CalcFilterSize(int length)
        {
            var boxes = length / sizeof(uint);
            if (length % sizeof(uint) != 0)
            {
                boxes += 1;
            }
            return boxes;
        }
        public BloomFilter(int length)
        {
            this.length = length;
            this.filter = new uint[CalcFilterSize(length)];
            this.hashes = new List<Func<string, int>>() { Hash1, Hash2 };
        }

        private void SetBit(int index)
        {
            var box = index / sizeof(uint);
            index = index % sizeof(uint);

            filter[box] |= 1u << index;
        }

        private bool ReadBit(int index)
        {
            var box = index / sizeof(uint);
            index = index % sizeof(uint);

            return (filter[box] & 1u << index) != 0;
        }
        public int Hash1(string element) => Hash(element, 17);
        public int Hash2(string element) => Hash(element, 223);
        private int Hash(string element, int seed)
        {
            var hash = 0;
            foreach (var ch in element)
            {
                hash = (hash * seed + (int)ch) % length;
            }
            return hash;
        }

        public void Add(string element)
        {
            hashes.ForEach((hash) => SetBit(hash(element)));
        }

        public bool IsValue(string element)
        {
            return hashes.TrueForAll((hash) => ReadBit(hash(element)));
        }
    }
}