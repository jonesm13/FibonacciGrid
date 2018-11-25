namespace Tests
{
    using System;
    using Domain.Extensions;
    using Xunit;

    public class EnumerableInt32ExtensionsTests
    {
        [Fact]
        public void GivenEmptyArray_ThenNoIncrementingSequenceFound()
        {
            int[] input = { };

            Assert.False(input.IsIncrementingSequence());
        }

        [Fact]
        public void GivenSingleMember_ThenNoIncrementingSequenceFound()
        {
            int[] input = { 10 };

            Assert.False(input.IsIncrementingSequence());
        }

        [Fact]
        public void GivenIncrementingArrayOfIntegers_ThenCanFindIncrementingSequence()
        {
            int[] input = { 5, 6, 7, 8, 9, 10 };

            Assert.True(input.IsIncrementingSequence());
        }

        [Fact]
        public void GivenNonIncrementingArrayOfIntegers_ThenNoIncrementingSequenceFound()
        {
            int[] input = { 4, 2, 1, 6, 10 };

            Assert.False(input.IsIncrementingSequence());
        }

        [Fact]
        public void GivenNullArray_ThenExceptionThrown()
        {
            int[] input = null;

            Assert.Throws<ArgumentNullException>(() =>
                input.IsIncrementingSequence());
        }
    }
}