using System;
using System.Diagnostics;
using System.Linq;
using CodingKata_Infinites;
using Xunit;
using Xunit.Abstractions;

namespace InfinitesTests
{
    public class InfiniteTests : IDisposable
    {
        private readonly Stopwatch _stopwatch;
        private readonly ITestOutputHelper _output;

        public InfiniteTests(ITestOutputHelper output)
        {
            _output = output;
            _stopwatch = Stopwatch.StartNew();
        }

        public void Dispose()
        {
            _output.WriteLine($"Elapsed: {_stopwatch.ElapsedMilliseconds}ms");
            Assert.True(_stopwatch.ElapsedMilliseconds < 30, "Timeout of 30ms exceeded. " + _stopwatch.ElapsedMilliseconds);
        }

        [Fact]
        public void CanGetFirst100Numbers()
        {
            var result = Infinite.All().Take(100).ToList();

            var answer = Enumerable.Range(1, 100).ToList();

            Assert.Equal(answer, result);
        }

        [Fact]
        public void CanGetBigNumbers()
        {
            var result = Infinite.All().Skip(10000).Take(100).ToList();

            var answer = Enumerable.Range(10001, 100).ToList();

            Assert.Equal(answer, result);
        }

        [Fact]
        public void CanGetOdds()
        {
            var result = Infinite.Odds().Take(100).ToList();

            var answer = Enumerable.Range(1, 200).Where(x => x % 2 != 0).ToList();

            Assert.Equal(answer, result);
        }

        [Fact]
        public void CanGetBigOdds()
        {
            var result = Infinite.Odds().Skip(10000).Take(100).ToList();

            var answer = Enumerable.Range(20001, 200).Where(x => x % 2 != 0).ToList();

            Assert.Equal(answer, result);
        }

        [Fact]
        public void CanGetEvens()
        {
            var result = Infinite.Evens().Take(100).ToList();

            var answer = Enumerable.Range(1, 200).Where(x => x % 2 == 0).ToList();

            Assert.Equal(answer, result);
        }

        [Fact]
        public void CanGetBigEvens()
        {
            var result = Infinite.Evens().Skip(10000).Take(100).ToList();

            var answer = Enumerable.Range(20001, 200).Where(x => x % 2 == 0).ToList();

            Assert.Equal(answer, result);
        }
    }
}
