using System;
using Berlin.Infrastructure.Interfaces;

namespace Berlin.BusinessLogic.MeasureMappers
{
    public abstract class BaseMeasureMapper : IMeasureMapper
    {
        protected IInquiry _inquiry;
        public BaseMeasureMapper(IInquiry inquiry)
        {
            _inquiry = inquiry;
        }

        public decimal Amount
        {
            get => _inquiry.Amount;
            set { _inquiry.Amount = value; }
        }

        public abstract ILimits Measure { get; set; }
    }

    public class MonthMapper : BaseMeasureMapper
    {

        public MonthMapper(IInquiry inquiry):base(inquiry)
        {
        }

        public override ILimits Measure
        {
            get => _inquiry.MonthLimits;
            set { _inquiry.MonthLimits = value; }
        }
    }

    public class KiloWattMapper : BaseMeasureMapper
    {
        public KiloWattMapper(IInquiry inquiry):base(inquiry)
        {
        }

        public override ILimits Measure
        {
            get => _inquiry.KiloWattLimits;
            set { _inquiry.KiloWattLimits = value; }
        }
    }

}
