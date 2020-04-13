using Berlin.Infrastructure.Interfaces;

namespace Berlin.BusinessLogic
{
    /// <summary>
    /// used as a mule for carrying results throughout component processing within a product
    /// </summary>
    public class Inquiry : IInquiry
    {
        public decimal Amount { get; set; }
        public ILimits MonthLimits { get; set; }
        public ILimits KiloWattLimits { get; set; }
    }
}
