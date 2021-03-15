using System;
using Xunit;
using Xunit.Abstractions;

using AlgorithmsDataStructures;

namespace Queue.Tests
{
    public class UnitTest1
    {
        private readonly ITestOutputHelper output;

        public UnitTest1(ITestOutputHelper output)
        {
            this.output = output;
        }

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
        [Fact]
        public void Rotate()
        {
            var q = new Queue<int>();
            for (int i = 0; i < 5; i++)
            {
                q.Enqueue(i);
            }
            int[] target = { 2, 3, 4, 0, 1 };
            q.Rotate(2);
            Assert.Equal(target, q.ToArray());
            q.Rotate(5);
            Assert.Equal(target, q.ToArray());
        }
        [Fact]
        public void PrintQueue()
        {
            var q = new Queue<int>();
            for (int i = 0; i < 5; i++)
            {
                q.Enqueue(i);
            }
            output.WriteLine(q.ToString());
            q.Rotate(5);
            output.WriteLine(q.ToString());
            q.Rotate(3);
            output.WriteLine(q.ToString());
        }
    }
}
