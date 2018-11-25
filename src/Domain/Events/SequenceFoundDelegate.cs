namespace Domain.Events
{
    public delegate void SequenceFoundDelegate(
        object sender,
        SequenceFoundEventArgs args);
}