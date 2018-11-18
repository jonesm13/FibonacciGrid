namespace Domain.Entities
{
    using Utilities;

    public struct SquareIndex
    {
        public int Row { get; }
        public int Column { get; }

        public SquareIndex(int row, int column)
        {
            Ensure.IsInRange(row, 0, Constants.GridDimension - 1, nameof(row));
            Ensure.IsInRange(column, 0, Constants.GridDimension - 1, nameof(column));

            Row = row;
            Column = column;
        }
    }
}