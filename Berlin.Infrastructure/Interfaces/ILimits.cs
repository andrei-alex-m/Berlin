namespace Berlin.Infrastructure.Interfaces

{
    public interface ILimits
    {
        long Lower { get; set; }
        long Upper { get; set; }
    }
}