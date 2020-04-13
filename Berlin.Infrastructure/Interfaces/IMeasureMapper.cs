using System;
namespace Berlin.Infrastructure.Interfaces
{
    public interface IMeasureMapper
    {
        public decimal Amount { get; set; }
        public ILimits Measure { get; set; }
    }
}
