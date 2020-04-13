using System;
using Berlin.BusinessLogic.MeasureMappers;
using Berlin.Infrastructure.Enums;
using Berlin.Infrastructure.Interfaces;

namespace Berlin.BusinessLogic
{
    public class MeasureMapperFactory
    {
        public static IMeasureMapper GetMeasureMapper(MeasureType type, IInquiry inquiry)
        {
            switch (type)
            {
                case MeasureType.KiloWatts:
                    return new KiloWattMapper(inquiry);
                case MeasureType.Months:
                    return new MonthMapper(inquiry);
                default:
                    return null;
            }
        }
    }
}
