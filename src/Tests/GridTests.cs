namespace Tests
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Domain.Aggregates;
    using Domain.Entities;
    using Domain.Events;
    using Xunit;

    public class GridTests
    {
        List<IDomainEvent> raisedEvents = new List<IDomainEvent>();

        public GridTests()
        {
            DomainEvents.Register<SquareChanged>(e =>
            {
                raisedEvents.Add(e);
            });
        }

        [Fact]
        public void GivenEmptyGrid_WhenSquareClicked_ThenRowAndColumnChanged()
        {
            // arrange
            string gridName = DateTime.UtcNow.Ticks.ToString();

            Grid subject = new Grid(gridName);

            // act
            subject.Click(new SquareIndex(2, 2));

            // assert
            IEnumerable<SquareChanged> squareChangedEvents = raisedEvents
                .OfType<SquareChanged>()
                .Where(x=>x.GridName == gridName)
                .ToList();

            Assert.Equal(
                99,
                squareChangedEvents.Count());

            Assert.Equal(
                50,
                squareChangedEvents.Count(x => x.Row == 2));

            Assert.Equal(
                50,
                squareChangedEvents.Count(x => x.Column == 2));

            Assert.True(
                squareChangedEvents.All(x => x.NewValue == 1));
        }

        [Fact]
        public void GivenGridWithSingleIncrement_WhenSquareClicked_ExistingNonEmptySquaresAreIncremented()
        {
            // arrange
            string gridName = DateTime.UtcNow.Ticks.ToString();

            Grid subject = new Grid(gridName);

            // act
            subject.Click(new SquareIndex(2, 2));

            subject.Click(new SquareIndex(44, 44));

            // assert
            IEnumerable<SquareChanged> squareChangedEvents = raisedEvents
                .OfType<SquareChanged>()
                .Where(x => x.GridName == gridName)
                .ToList();

            Assert.True(
                squareChangedEvents
                    .Any(x => x.Row == 2 & x.Column == 44 & x.NewValue == 2));

            Assert.True(
                squareChangedEvents
                    .Any(x => x.Row == 44 & x.Column == 2 & x.NewValue == 2));
        }
    }
}
