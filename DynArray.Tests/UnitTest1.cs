using System;
using Xunit;
using AlgorithmsDataStructures;

namespace DynArray.Tests
{
    public class UnitTest1
    {
        [Fact]
        public void Empty()
        {
            var arr = new DynArray<int>();
            Assert.Equal(0, arr.count);
            Assert.Equal(16, arr.capacity);
            Assert.Equal(16, arr.array.Length);
        }
        [Fact]
        public void AddRemoveEmpty()
        {
            var arr = new DynArray<int>();
            arr.Append(1);
            Assert.Equal(1, arr.count);
            Assert.Equal(16, arr.capacity);
            Assert.Equal(16, arr.array.Length);
            Assert.Equal(1, arr.GetItem(0));

            arr.Remove(0);
            Assert.Equal(0, arr.count);
            Assert.Equal(16, arr.capacity);
        }
        [Fact]
        public void Add2InTail()
        {
            var arr = new DynArray<int>();
            arr.Append(1);
            arr.Append(1);
            Assert.Equal(2, arr.count);
            Assert.Equal(16, arr.capacity);
            Assert.Equal(16, arr.array.Length);
            Assert.Equal(1, arr.GetItem(0));
            Assert.Equal(1, arr.GetItem(1));
        }
        [Fact]
        public void InsertRemoveEmpty()
        {
            var arr = new DynArray<int>();
            arr.Insert(1, 0);
            Assert.Equal(1, arr.count);
            Assert.Equal(16, arr.capacity);
            Assert.Equal(16, arr.array.Length);
            Assert.Equal(1, arr.GetItem(0));

            arr.Remove(0);
            Assert.Equal(0, arr.count);
            Assert.Equal(16, arr.capacity);
        }
        [Fact]
        public void Insert2InHead()
        {
            var arr = new DynArray<int>();
            arr.Insert(1, 0);
            arr.Insert(1, 0);
            Assert.Equal(2, arr.count);
            Assert.Equal(16, arr.capacity);
            Assert.Equal(16, arr.array.Length);
            Assert.Equal(1, arr.GetItem(0));
            Assert.Equal(1, arr.GetItem(1));
        }
        [Fact]
        public void InsertInTail()
        {
            var arr = new DynArray<int>();
            arr.Insert(1, arr.count);
            Assert.Equal(1, arr.count);
            Assert.Equal(16, arr.capacity);
            Assert.Equal(16, arr.array.Length);
            Assert.Equal(1, arr.GetItem(0));
        }
        [Fact]
        public void AppendBeyondCapacity()
        {
            var arr = new DynArray<int>();
            for (int i = 0; i < 16; i++)
            {
                arr.Append(1);
            }
            Assert.Equal(16, arr.count);
            Assert.Equal(16, arr.capacity);
            Assert.Equal(16, arr.array.Length);
            Assert.Equal(1, arr.GetItem(0));
            Assert.Equal(1, arr.GetItem(15));

            arr.Append(1);
            Assert.Equal(17, arr.count);
            Assert.Equal(32, arr.capacity);
            Assert.Equal(32, arr.array.Length);
            Assert.Equal(1, arr.GetItem(0));
            Assert.Equal(1, arr.GetItem(16));
        }
        [Fact]
        public void InsertIncorrect()
        {
            var arr = new DynArray<int>();
            Assert.Throws<IndexOutOfRangeException>(() => arr.Insert(1, 1));
        }
        [Fact]
        public void RemoveIncorrect()
        {
            var arr = new DynArray<int>();
            Assert.Throws<IndexOutOfRangeException>(() => arr.Remove(1));
        }
        [Fact]
        public void RemoveWithSqueze()
        {
            var arr = new DynArray<int>();
            for (int i = 0; i < 17; i++)
            {
                arr.Append(1);
            }
            arr.Remove(5);
            arr.Remove(0);
            Assert.Equal(15, arr.count);
            Assert.Equal(21, arr.capacity);
            Assert.Equal(21, arr.array.Length);
            for (int i = 0; i < 6; i++)
            {
                arr.Remove(arr.count - 1);
            }
            Assert.Equal(9, arr.count);
            Assert.Equal(0, arr.array[9]);
            Assert.Equal(16, arr.capacity);
            Assert.Equal(16, arr.array.Length);
        }
    }
}
