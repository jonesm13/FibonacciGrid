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

            // create a sequence starting in 0,0 extending to 0,3
            theGrid.Click(0, 0);
            theGrid.Click(3, 1);
            theGrid.Click(5, 2);
            theGrid.Click(7, 3);

            // act
            // now complete the sequence
            theGrid.Click(9, 4);

            Assert.Single(raisedEvents);
        }
    }
}