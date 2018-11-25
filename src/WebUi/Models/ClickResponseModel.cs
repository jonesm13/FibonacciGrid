namespace WebUi.Models
{
    using System.Collections.Generic;
    using Domain.Events;

    public class ClickResponseModel
    {
        public IEnumerable<SquareChangedEventArgs> ChangedSquares { get; set; }
        public IEnumerable<SequenceFoundEventArgs> SequencesFound { get; set; }
    }
}