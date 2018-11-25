namespace Domain.Events
{
    using System;

    public class SequenceFoundEventArgs : EventArgs
    {
        public int Row { get; set; }
        public int Column { get; set; }
        public bool Direction { get; set; }
    }
}