using Berlin.Infrastructure.Interfaces;

namespace Berlin.Infrastructure.Interfaces
{
    public interface IInquiry
    {
        decimal Amount { get; set; }
        ILimits MonthLimits { get; set; }
        ILimits KiloWattLimits { get; set; }
    }
}