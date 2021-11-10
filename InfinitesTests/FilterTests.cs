using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CodingKata_Infinites;
using Xunit;

namespace InfinitesTests
{
    public class FilterTests
    {
        private static List<int> _oneToOneHundred;

        public FilterTests()
        {
            _oneToOneHundred = Enumerable.Range(1, 100).ToList();
        }

        [Theory]
        [InlineData(new[]{ 1,2,3,4,5,6 }, new []{ 2,4,6 })]
        [InlineData(new[]{ 10,11,12,13,15,16 }, new []{ 10,12,16 })]
        [InlineData(new[]{ 101,102 }, new []{ 102 })]
        public void CanFilterLists(IEnumerable<int> input, IEnumerable<int> output)
        {
            var result = Infinite.Filter(input, x => x % 2 == 0);

            Assert.Equal(output, result);
        }
    }
}
