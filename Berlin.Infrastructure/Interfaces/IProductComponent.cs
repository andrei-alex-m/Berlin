using Berlin.Infrastructure.Enums;

namespace Berlin.Infrastructure.Interfaces
{
    public interface IProductComponent
    {
        MeasureType Type { get; set; }
        decimal Amount { get; set; }
        long Unit { get; set; }
        ILimits Limits { get; set; }
        bool Proportional { get; set; }
    }
}