namespace Persistence.Model
{
    public enum OrderStatus
    {
        InQueue,
        InProgress,
        Halted,
        Completed,
        Canceled,
        Inactive,
        Error
    }
}