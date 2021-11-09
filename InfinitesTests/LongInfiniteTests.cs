using System;
using System.Diagnostics;
using System.Linq;
using CodingKata_Infinites;
using Xunit;
using Xunit.Abstractions;

namespace InfinitesTests
{
    public class LongInfiniteTests : IDisposable
    {
        readonly Stopwatch _stopwatch;
        private readonly ITestOutputHelper _output;

        public LongInfiniteTests(ITestOutputHelper output)
        {
            _output = output;
            _stopwatch = Stopwatch.StartNew();
        }

        public void Dispose()
        {
            _output.WriteLine($"Elapsed: {_stopwatch.ElapsedMilliseconds}ms");
        }

        [Fact]
        public void StopsWhenIntMaxValueHit()
        {
            var result = Infinite.All().Skip(int.MaxValue - 5).Take(10).ToList();

            var answer = Enumerable.Range(int.MaxValue - 4, 5).ToList();

            Assert.Equal(answer, result);
        }
    }
}
