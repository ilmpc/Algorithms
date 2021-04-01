using System;
using System.Collections.Generic;
using Xunit;

using AlgorithmsDataStructures;

namespace OrderedList.Tests
{
    public class UnitTest1
    {
        [Fact]
        public void Test1()
        {
            var list = new OrderedList<int>(true);
            var values = new List<int>{1, -10, 2};
            values.ForEach(list.Add);
            values.Sort();

            var i = 0;
            list.ForEach((val) => Assert.Equal(values[i++], val));
            list.ForEach
        }
    }
}
