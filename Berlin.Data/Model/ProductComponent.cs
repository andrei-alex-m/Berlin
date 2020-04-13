using System;
using Berlin.Infrastructure.Interfaces;
using Berlin.Infrastructure.Enums;

namespace Berlin.Model
{
    public class ProductComponent : IProductComponent
    {

        public ProductComponent()
        {
            Limits = new Limits();
        }

        public MeasureType Type { get; set; }

        public decimal Amount { get; set; }

        public long Unit { get; set; }

        public ILimits Limits { get; set; }

        public bool Proportional { get; set; }
    }
}
