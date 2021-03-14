using System;
using System.Collections.Generic;

namespace AlgorithmsDataStructures
{

    public class DynArray<T>
    {
        private const int MULTIPLIER = 2;
        private const double DIVIDER = 1.5;
        private const int MIN_CAPACITY = 16;
        public T[] array;
        public int count;
        public int capacity;

        public DynArray()
        {
            count = 0;
            MakeArray(16);
        }

        private void ExpandIfNeeded()
        {
            if (count == capacity)
            {
                MakeArray(capacity * MULTIPLIER);
            }
        }

        private void CheckBoundaries(int index)
        {
            if (index >= count)
            {
                throw new IndexOutOfRangeException();
            }
        }
        // Array.Resize
        public void MakeArray(int new_capacity)
        {
            if (new_capacity == capacity) { return; }
            var prev_array = array;
            array = new T[new_capacity];
            if (prev_array != null || count != 0)
            {
                Array.Copy(prev_array, array, count);
            }
            capacity = new_capacity;
        }

        public T GetItem(int index)
        {
            CheckBoundaries(index);
            return array[index];
        }

        public void Append(T item)
        {
            ExpandIfNeeded();
            array[count] = item;
            count += 1;
        }

        // O(n)
        public void Insert(T item, int index)
        {
            if (index == count)
            {
                this.Append(item);
                return;
            }
            CheckBoundaries(index);
            ExpandIfNeeded();
            Array.Copy(array, index, array, index + 1, count - index + 1);
            array[index] = item;
            count += 1;
        }

        // O(n)
        public void Remove(int index)
        {
            CheckBoundaries(index);
            if (count - 1 < capacity / 2 && capacity > 16)
            {
                // trim
                var prev_array = array;
                int new_capacity = (int)(capacity / DIVIDER);
                if (new_capacity < 16) { new_capacity = 16; }
                capacity = new_capacity;
                array = new T[new_capacity];
                Array.Copy(prev_array, array, index);
                Array.Copy(prev_array, index + 1, array, index, count - index - 1);
            }
            else
            {
                Array.Copy(array, index + 1, array, index, count - index - 1);
            }
            count -= 1;
        }

    }
}