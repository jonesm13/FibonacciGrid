namespace Tests
{
    using Domain.Extensions;
    using Xunit;

    public class FibonacciTests
    {
        [Theory]
        [InlineData(1, 0)]
        [InlineData(2, 1)]
        [InlineData(3, 2)]
        [InlineData(5, 3)]
        [InlineData(8, 4)]
        [InlineData(13, 5)]
        [InlineData(21, 6)]
        [InlineData(34, 7)]
        [InlineData(144, 10)]
        public void GivenNumberInFibonacciSequence_MethodReturnsExpectedIndex(
            int input,
            int expected)
        {
            Assert.Equal(expected, input.GetFibonacciIndex());
        }

        [Theory]
        [InlineData(new[] { 0, 4, 6, 7 })]
        public void GivenNumberNotInFibonacciSequence_MethodReturnsNotFound(
            int[] input)
        {
            foreach(int i in input)
            {
                Assert.Equal(-1, i.GetFibonacciIndex());
            }
        }
    }
}
