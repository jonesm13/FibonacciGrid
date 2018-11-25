namespace Tests
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Domain.Aggregates;
    using Domain.Events;
    using Xunit;

    public class GridFibonacciTests
    {
        [Fact]
        public void GivenGridWithAlmostCompleteHorizontalSequence_WhenSquareIsClicked_ThenSequenceFoundEventRaised()
        {
            // arrange
            List<SequenceFoundEventArgs> raisedEvents = new List<SequenceFoundEventArgs>();

            Grid subject = new Grid(Guid.NewGuid().ToString());
            subject.SequenceFound += (sender, args) =>
            {
                raisedEvents.Add(args);
            };

            // create a nearly-complete sequence in row 0
            ClickTimes(subject, 0, 0, 1);
            ClickTimes(subject, 1, 1, 1);
            ClickTimes(subject, 3, 2, 2);
            ClickTimes(subject, 5, 3, 4);
            ClickTimes(subject, 7, 4, 6);

            raisedEvents.Clear();

            // act
            // now complete the sequence
            ClickTimes(subject, 7, 4, 1);

            // assert
            SequenceFoundEventArgs theEvent = raisedEvents.Single();

            Assert.Equal(Direction.Horizontal, theEvent.Direction);
            Assert.Equal(0, theEvent.Row);
            Assert.Equal(0, theEvent.Column);
            Assert.Equal(5, theEvent.SequenceLength);
        }

        [Fact]
        public void GivenGridWithAlmostCompleteVerticalSequence_WhenSquareIsClicked_ThenSequenceFoundEventRaised()
        {
            // arrange
            List<SequenceFoundEventArgs> raisedEvents = new List<SequenceFoundEventArgs>();

            Grid subject = new Grid(Guid.NewGuid().ToString());
            subject.SequenceFound += (sender, args) =>
            {
                raisedEvents.Add(args);
            };

            // create a nearly-complete sequence in col 10
            ClickTimes(subject, 10, 10, 1);
            ClickTimes(subject, 11, 11, 1);
            ClickTimes(subject, 12, 13, 2);
            ClickTimes(subject, 13, 15, 4);
            ClickTimes(subject, 14, 17, 6);

            raisedEvents.Clear();

            // act
            // now complete the sequence
            ClickTimes(subject, 14, 17, 1);

            // assert
            SequenceFoundEventArgs theEvent = raisedEvents.Single();

            Assert.Equal(Direction.Vertical, theEvent.Direction);
            Assert.Equal(10, theEvent.Row);
            Assert.Equal(10, theEvent.Column);
            Assert.Equal(5, theEvent.SequenceLength);
        }

        static void ClickTimes(Grid grid, int row, int column, int times)
        {
            for(int i = 0; i < times; i++)
            {
                grid.Click(row, column);
            }
        }
    }
}