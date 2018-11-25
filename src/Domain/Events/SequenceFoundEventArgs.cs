namespace Domain.Events
{
    using System;

    public enum Direction
    {
        Horizontal,
        Vertical
    }

    public class SequenceFoundEventArgs : EventArgs
    {
        public int Row { get; set; }
        public int Column { get; set; }
        public int SequenceLength { get; set; }
        public Direction Direction { get; set; }
    }
}
