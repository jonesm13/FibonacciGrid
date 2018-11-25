namespace Tests
{
    using System;
    using System.Collections.Generic;
    using Domain.Aggregates;
    using Domain.Events;
    using Xunit;

    public class GridFibonacciTests
    {
        [Fact]
        public void GivenGridWithAlmostCompleteSequence_WhenSquareIsClicked_ThenSequenceFoundEventRaised()
        {
            // arrange
            List<SequenceFoundEventArgs> raisedEvents = new List<SequenceFoundEventArgs>();

            Grid theGrid = new Grid(Guid.NewGuid().ToString());
            theGrid.SequenceFound += (sender, args) =>
            {
                raisedEvents.Add(args);
            };

            // create a sequence
            ClickTimes(theGrid, 0, 0, 1);
            ClickTimes(theGrid, 1, 1, 1);
            ClickTimes(theGrid, 3, 2, 2);
            ClickTimes(theGrid, 5, 3, 4);

            // act
            // now complete the sequence
            ClickTimes(theGrid, 7, 4, 7);

            Assert.Single(raisedEvents);
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