using System;
using Xunit;

namespace AlgorithmsDataStructures.Tests
{
    public class UnitTest1
    {
        /*
        // Test for inner functions
        [Fact]
        public void BitwiseOperations()
        {
            var filter = new BloomFilter(34);
            filter.SetBit(17);
            filter.SetBit(34);
            Assert.True(filter.ReadBit(17));
            Assert.True(filter.ReadBit(34));
            Assert.False(filter.ReadBit(18));
            Assert.False(filter.ReadBit(0));
        } */

        [Fact]
        public void AddAndCheck()
        {
            var filter = new BloomFilter(32);
            string[] test_data = { "0123456789", "1234567890", "2345678901", "3456789012", "4567890123", "5678901234", "6789012345" };
            foreach (var word in test_data)
            {
                filter.Add(word);
                Assert.True(filter.IsValue(word));
            }
            Assert.True(filter.IsValue("0123456789"));
        }
    }
}
