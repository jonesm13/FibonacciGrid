namespace Tests
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Domain.Aggregates;
    using Domain.Events;
    using Xunit;

    public class GridClickTests
    {
        readonly List<SquareChangedEventArgs> raisedEvents;
        readonly Grid subject;

        public GridClickTests()
        {
            raisedEvents = new List<SquareChangedEventArgs>();

            subject = new Grid(Guid.NewGuid().ToString());

            subject.SquareChanged += (sender, args) =>
            {
                raisedEvents.Add(args);
            };
        }

        [Fact]
        public void GivenEmptyGrid_WhenSquareClicked_ThenRowAndColumnChanged()
        {
            // act
            subject.Click(2, 2);

            // assert
            Assert.Equal(
                99,
                raisedEvents.Count);

            Assert.Equal(
                50,
                raisedEvents.Count(x => x.Row == 2));

            Assert.Equal(
                50,
                raisedEvents.Count(x => x.Column == 2));

            Assert.True(
                raisedEvents.All(x => x.NewValue == 1));
        }

        [Fact]
        public void GivenGridWithSingleIncrement_WhenSquareClicked_ThenExistingNonEmptySquaresAreIncremented()
        {
            // act
            subject.Click(2, 2);
            subject.Click(44, 44);

            // assert
            Assert.True(
                raisedEvents
                    .Any(x => x.Row == 2 & x.Column == 44 & x.NewValue == 2));

            Assert.True(
                raisedEvents
                    .Any(x => x.Row == 44 & x.Column == 2 & x.NewValue == 2));
        }
    }
}
