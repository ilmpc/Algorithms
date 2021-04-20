using System;

namespace AlgorithmsDataStructures
{

    public class NativeDictionary<T>
    {
        private int step;
        public int size;
        public string[] slots;
        public T[] values;

        public NativeDictionary(int size)
        {
            step = 1;
            this.size = size;
            slots = new string[size];
            values = new T[size];
        }

        public int HashFun(string value)
        {
            if (value == null) { return 0; }
            // Should be any prime number roughly equal to the number of different characters use
            int p = 31;
            int m = (int)(1e9 + 9);
            long power_of_p = 1;
            long hash = 0;

            // Using Polynomial rolling 
            foreach (char ch in value)
            {
                hash = (hash + Math.Abs(ch - 'a' + 1) * power_of_p) % m;
                power_of_p = (power_of_p * p) % m;
            }
            return (int)(hash % size);
        }

        private int Find(string value, bool returnEmpty = false)
        {
            if (size == 0) { return -1; }

            var hash = HashFun(value);
            var potential = hash;
            do
            {
                var empty = slots[potential] == null && returnEmpty;
                var exactKey = slots[potential] == value;
                if (empty || exactKey) { return potential; }
                potential = (potential + step) % size;
            } while (potential != hash);
            return -1;
        }

        public bool IsKey(string key)
        {
            return Find(key) != -1;
        }

        public void Put(string key, T value)
        {
            var index = Find(key, returnEmpty: true);
            slots[index] = key;
            values[index] = value;
        }

        public T Get(string key)
        {
            var index = Find(key);
            if (index != -1) { return values[index]; }
            return default(T);
        }
    }
}
