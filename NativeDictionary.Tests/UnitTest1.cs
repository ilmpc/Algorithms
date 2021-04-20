using System;
using Xunit;

using AlgorithmsDataStructures;

namespace NativeDictionary.Tests
{
    public class UnitTest1
    {
        [Fact]
        public void Test1()
        {
            var dict = new NativeDictionary<int>(size: 10);
            dict.Put("q", 12);
            dict.Put("2", 1);
            dict.Put("3", 17);
            Assert.Equal(12, dict.Get("q"));
            Assert.Equal(1, dict.Get("2"));
            Assert.Equal(17, dict.Get("3"));
            dict.Put("q", 11);
            Assert.Equal(11, dict.Get("q"));
            Assert.True(dict.IsKey("2"));
            Assert.False(dict.IsKey("1"));
            Assert.Equal(0, dict.Get("qwe"));
        }
    }
}
