namespace Domain.Events
{
    using System;

    public class SquareChangedEventArgs : EventArgs
    {
        public int Row { get; set; }
        public int Column { get; set; }
        public int NewValue { get; set; }
    }
}