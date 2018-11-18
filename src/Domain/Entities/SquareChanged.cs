namespace Domain.Entities
{
    using Events;

    public class SquareChanged : IDomainEvent
    {
        public string GridName { get; set; }
        public int Row { get; set; }
        public int Column { get; set; }
        public int NewValue { get; set; }
    }
}
