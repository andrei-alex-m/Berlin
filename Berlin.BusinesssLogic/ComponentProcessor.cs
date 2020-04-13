using System;
using Berlin.Infrastructure.Interfaces;

namespace Berlin.BusinessLogic
{
    public class ComponentProcessor
    {
        private IProductComponent _component;
        private IMeasureMapper _measureMapper;

        public ComponentProcessor(IProductComponent component, IMeasureMapper measureMapper)
        {
            _component = component;
            _measureMapper = measureMapper;
        }

        public void Execute()
        {

            //intersection
            var lowerLimit = Math.Max(_measureMapper.Measure.Lower, _component.Limits.Lower);
            var upperLimit = Math.Min(_measureMapper.Measure.Upper, _component.Limits.Upper);

            //we dont know, maybe
            if (lowerLimit > upperLimit)
                return;

            //price is per unit in component
            var units = (decimal)(upperLimit - lowerLimit) / (decimal)_component.Unit;

            if (!_component.Proportional)
            {
                units = Math.Ceiling(units);
            }

            //adding amount to the inquiry
            _measureMapper.Amount += units * _component.Amount;

            //setting new lower limit to the inquiry for the next component to pick up;
            _measureMapper.Measure.Lower = upperLimit;
        }

    }
}
