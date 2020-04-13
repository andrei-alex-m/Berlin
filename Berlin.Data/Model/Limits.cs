using System;
using Berlin.Infrastructure.Interfaces;

namespace Berlin.Model
{
    /// <summary>
    /// Kilowatts or Months
    /// </summary>
    public class Limits : ILimits
    {
        public Limits(long lower = long.MinValue, long upper = long.MaxValue)
        {
            Lower = lower;
            Upper = upper;
        }

        public long Lower { get; set; }
        public long Upper { get; set; }
    }
}
