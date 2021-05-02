using System;
using System.Collections.Generic;

namespace AlgorithmsDataStructures
{

    public class PowerSet<T> where T : IEquatable<T>
    {
        private int size;
        private int capacity;
        private int step;
        private T[] slots;

        private PowerSet(PowerSet<T> other)
        {
            this.size = other.size;
            this.capacity = other.capacity;
            this.step = other.step;
            this.slots = (T[])other.slots.Clone();

        }
        public PowerSet(int capacity = 20000, int step = 32)
        {
            this.size = 0;
            this.capacity = capacity;
            this.step = step;
            this.slots = new T[capacity];
            for (var i = 0; i < capacity; i++)
            {
                slots[i] = default(T);
            }
        }

        public int Size()
        {
            return size;
        }
        private int HashFun(string value)
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
            return Math.Abs((int)(hash % capacity));
        }

        private int HashFun(T value)
        {
            if (value == null) { return 0; }

            var hash = value.GetHashCode();
            return Math.Abs(hash % capacity);
        }

        public void Put(T value)
        {
            if (capacity == 0 || size == capacity || value == null) { return; }

            var hash = HashFun(value);
            var potential = hash;
            do
            {
                var exists = EqualityComparer<T>.Default.Equals(value, slots[potential]);
                var empty = EqualityComparer<T>.Default.Equals(default(T), slots[potential]);
                if (exists) { return; }
                if (empty)
                {
                    slots[potential] = value;
                    size += 1;
                    return;
                }
                potential = (potential + step) % capacity;
            } while (potential != hash);
        }

        public bool Get(T value)
        {
            if (capacity == 0) { return false; }
            if (value == null) { return true; }

            var hash = HashFun(value);
            var potential = hash;
            do
            {
                var exists = EqualityComparer<T>.Default.Equals(value, slots[potential]);
                if (exists) { return true; }
                potential = (potential + step) % capacity;
            } while (potential != hash);
            return false;
        }

        public bool Remove(T value)
        {
            if (capacity == 0 || value == null) { return false; }
            
            var hash = HashFun(value);
            var potential = hash;
            do
            {
                var exists = EqualityComparer<T>.Default.Equals(value, slots[potential]);
                if (exists)
                {
                    slots[potential] = default(T);
                    size -= 1;
                    return true;
                }
                potential = (potential + step) % capacity;
            } while (potential != hash);
            return false;
        }

        public PowerSet<T> Intersection(PowerSet<T> other)
        {
            var intersection = new PowerSet<T>();
            if (size == 0 || other.size == 0) { return intersection; }

            foreach (var item in slots)
            {
                if (other.Get(item))
                {
                    intersection.Put(item);
                }
            }
            return intersection;
        }

        public PowerSet<T> Union(PowerSet<T> other)
        {
            if (size == 0) { return new PowerSet<T>(other); }
            if (other.size == 0) { return new PowerSet<T>(this); }

            var union = new PowerSet<T>();

            Action<T> put = (item) => union.Put(item);
            Array.ForEach(slots, put);
            Array.ForEach(other.slots, put);

            return union;
        }

        public PowerSet<T> Difference(PowerSet<T> other)
        {
            if (size == 0) { return new PowerSet<T>(); }
            if (other.size == 0) { return new PowerSet<T>(this); }

            var difference = new PowerSet<T>();

            foreach (var item in slots)
            {
                if (!other.Get(item))
                {
                    difference.Put(item);
                }
            }

            return difference;
        }

        public bool IsSubset(PowerSet<T> other)
        {
            foreach (var item in other.slots)
            {
                if (!this.Get(item))
                {
                    return false;
                }
            }
            return true;
        }
    }
}