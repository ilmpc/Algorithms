using System;
using System.Linq;
using Xunit;

using AlgorithmsDataStructures;

namespace PowerSet.Tests
{
    public class UnitTest1
    {
        private static Random random = new Random();
        public static string RandomString(int length)
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            return new string(Enumerable.Range(1, length).Select(_ => chars[random.Next(chars.Length)]).ToArray());
        }

        [Fact]
        public void PutTwice()
        {
            var data = "Hi!";
            var set = new PowerSet<string>();
            set.Put(data);
            Assert.Equal(1, set.Size());
            set.Put(data);
            Assert.Equal(1, set.Size());
        }

        [Fact]
        public void RemoveSomething()
        {
            var data = "Hi!";
            var set = new PowerSet<string>();
            set.Put(data);
            Assert.True(set.Get(data));
            set.Remove(data);
            Assert.Equal(0, set.Size());
            Assert.False(set.Get(data));
        }

        [Fact]
        public void Intersection()
        {
            var set1 = new PowerSet<string>();
            var set2 = new PowerSet<string>();
            set1.Put("data");
            set2.Put("Hi!");
            Assert.Equal(0, set1.Intersection(set2).Size());
            set1.Put("Hi!");
            var setInt = set1.Intersection(set2);
            Assert.Equal(1, setInt.Size());
            Assert.True(setInt.Get("Hi!"));
        }
        [Fact]
        public void Union()
        {
            var set1 = new PowerSet<string>();
            var set2 = new PowerSet<string>();
            set1.Put("data");
            Assert.Equal(1, set1.Union(set2).Size());
            set2.Put("some");
            Assert.Equal(2, set1.Union(set2).Size());
        }
        [Fact]
        public void Difference()
        {
            var set1 = new PowerSet<string>();
            var set2 = new PowerSet<string>();
            set1.Put("data");
            set2.Put("data");
            Assert.Equal(0, set1.Difference(set2).Size());
            set1.Put("new");
            Assert.Equal(1, set1.Difference(set2).Size());
            set2.Put("any");
            Assert.Equal(1, set1.Difference(set2).Size());
        }

        [Fact]
        public void IsSubset()
        {
            var set1 = new PowerSet<string>();
            var set2 = new PowerSet<string>();
            set1.Put("data");
            set2.Put("data");
            Assert.True(set1.IsSubset(set2));
            set1.Put("more");
            Assert.True(set1.IsSubset(set2));
            set2.Put("diffore");
            Assert.False(set1.IsSubset(set2));
        }

        [Fact]
        public void Performance()
        {
            var set1 = new PowerSet<string>();
            var set2 = new PowerSet<string>();
            for (int i = 0; i < 5000; i++)
            {
                var data = RandomString(10);
                set1.Put(data);
                set2.Put(data);
            }
            for (int i = 0; i < 10000; i++)
            {
                var data = RandomString(12);
                set1.Put(data);
                data = RandomString(12);
                set2.Put(data);
            }
            Measure((n) => set1.Difference(set2));
            Measure((n) => set1.Union(set2));
            Measure((n) => set1.IsSubset(set2));
            Measure((n) => set1.Intersection(set2));
        }

        private void Measure(Action<int> measurable)
        {
            var watch = System.Diagnostics.Stopwatch.StartNew();
            measurable(0);
            watch.Stop();
            Assert.True(watch.ElapsedMilliseconds < 1000);
        }
    }
}
