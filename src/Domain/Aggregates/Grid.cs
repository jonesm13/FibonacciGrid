namespace Domain.Aggregates
{
    using System;
    using System.Linq;
    using Entities;
    using Events;
    using Extensions;

    public class Grid
    {
        public event SquareChangedDelegate SquareChanged;
        public event SequenceFoundDelegate SequenceFound;

        public string Name { get; }

        readonly int[,] state;
        readonly int[,] fibonacciIndex;

        public Grid(string name)
        {
            Name = name;

            state = ArrayBuilder.BuildSquareArray(Constants.GridDimension, 0);
            fibonacciIndex = ArrayBuilder.BuildSquareArray(Constants.GridDimension, -1);
        }

        public void Click(int row, int column)
        {
            Click(new SquareIndex(row, column));
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

            FindSequences();
        }

        void FindSequences()
        {
            for(int row = 0;
                row < Constants.GridDimension - Constants.SequenceLength;
                row++)
            {
                for(int col = 0;
                    col < Constants.GridDimension - Constants.SequenceLength;
                    col++)
                {
                    foreach(Direction direction in Enum.GetValues(typeof(Direction)))
                    {
                        if (GetSequenceCandidate(
                                row,
                                col,
                                direction)
                            .IsIncrementingSequence())
                        {
                            OnSequenceFound(new SequenceFoundEventArgs
                            {
                                Row = row,
                                Column = col,
                                SequenceLength = Constants.SequenceLength,
                                Direction = direction
                            });
                        }
                    }
                }
            }
        }

        int[] GetSequenceCandidate(int row, int column, Direction direction)
        {
            int[] result = new int[Constants.SequenceLength];
            for(int i = 0; i < Constants.SequenceLength; i++)
            {
                if(direction == Direction.Horizontal)
                {
                    result[i] = fibonacciIndex[row, column + i];
                }
                else
                {
                    result[i] = fibonacciIndex[row + i, column];
                }
            }

            return result;
        }

        void ClickSquare(int row, int column)
        {
            state[row, column]++;
            fibonacciIndex[row, column] = state[row, column].GetFibonacciIndex();

            OnSquareChanged(new SquareChangedEventArgs
            {
                Row = row,
                Column = column,
                NewValue = state[row, column]
            });
        }

        protected virtual void OnSquareChanged(SquareChangedEventArgs args)
        {
            SquareChanged?.Invoke(this, args);
        }

        protected virtual void OnSequenceFound(SequenceFoundEventArgs args)
        {
            for (int c = 0; c < Constants.SequenceLength; c++)
            {
                state[args.Row, c + args.Column] = 0;
                fibonacciIndex[args.Row, c + args.Column] = -1;
            }

            SequenceFound?.Invoke(this, args);
        }
    }
}
