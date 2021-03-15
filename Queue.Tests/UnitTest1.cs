using System;
using Xunit;

using AlgorithmsDataStructures;

namespace Queue.Tests
{
    public class UnitTest1
    {
        [Fact]
        public void Empty()
        {
            var q = new Queue<int>();
            Assert.Equal(0, q.Size());
            q.Enqueue(5);
            Assert.Equal(5, q.Dequeue());
            Assert.Equal(0, q.Size());
            Assert.Equal(default(int), q.Dequeue());
        }
        [Fact]
        public void EnqueueThenDequeueOrder()
        {
            var q = new Queue<int>();
            for (int i = 0; i < 10; i++)
            {
                q.Enqueue(i);
            }
            Assert.Equal(10, q.Size());
            for (int i = 0; i < 10; i++)
            {
                Assert.Equal(i, q.Dequeue());
            }
        }
    }
}
