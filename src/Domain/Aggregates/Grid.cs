namespace Domain.Aggregates
{
    using System.Linq;
    using Entities;
    using Events;
    using Extensions;

    public class Grid
    {
        public string Name { get; }

        readonly int[,] state;
        readonly int[,] fibonacciIndex;

        public Grid(string name)
        {
            Name = name;
            state = new int[Constants.GridDimension, Constants.GridDimension];
            fibonacciIndex = new int[Constants.GridDimension, Constants.GridDimension];
        }

        public void Click(SquareIndex index)
        {
            ClickSquare(index.Row, index.Column);

            foreach (int row in Enumerable
                .Range(0, Constants.GridDimension)
                .Except(new[] { index.Row }))
            {
                ClickSquare(row, index.Column);
            }

            foreach (int column in Enumerable
                .Range(0, Constants.GridDimension)
                .Except(new[] { index.Column }))
            {
                ClickSquare(index.Row, column);
            }
        }

        void ClickSquare(int row, int column)
        {
            state[row, column]++;
            fibonacciIndex[row, column] = state[row, column].FibonacciIndex();

            DomainEvents.Raise(new SquareChanged
            {
                GridName = Name,
                Row = row,
                Column = column,
                NewValue = state[row, column]
            });
        }
    }
}
