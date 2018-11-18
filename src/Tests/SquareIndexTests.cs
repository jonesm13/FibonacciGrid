namespace Tests
{
    using System;
    using Domain.Entities;
    using Xunit;

    public class SquareIndexTests
    {
        [Fact]
        public void CanCreateSquareIndex()
        {
            // ReSharper disable once UnusedVariable
            SquareIndex subject = new SquareIndex(15, 15);
        }

        [Fact]
        public void CannotCreateOutOfRangeIndex_Row_Low()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() =>
                new SquareIndex(-1, 4));
        }

        [Fact]
        public void CannotCreateOutOfRangeIndex_Column_Low()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() =>
                new SquareIndex(4, -1));
        }

        [Fact]
        public void CannotCreateOutOfRangeIndex_Row_High()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() =>
                new SquareIndex(50, 4));
        }

        [Fact]
        public void CannotCreateOutOfRangeIndex_Column_High()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() =>
                new SquareIndex(4, 50));
        }
    }
}