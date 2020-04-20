using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Berlin.Dto;
using Berlin.Infrastructure.Interfaces;
using Berlin.Model;

namespace Berlin.BusinessLogic
{
    public class InquiryProcessor : IInquiryProcessor
    {
        private IRepo _repo;

        public InquiryProcessor(IRepo repo)
        {
            _repo = repo;
        }

        public IEnumerable<IProductCost> Execute(long kilowatts, long months)
        {
            var result = new List<ProductCost>();

            foreach (var product in _repo.Products)
            {
                var processors = new List<ComponentProcessor>();

                var inquiry = new Inquiry() { KiloWattLimits = new Limits(upper: kilowatts), MonthLimits = new Limits(upper: months) };

                foreach (var component in product.Components.OrderBy(x => x.Limits.Lower))
                {
                    processors.Add(new ComponentProcessor(component, MeasureMapperFactory.GetMeasureMapper(component.Type, inquiry)));
                }

                foreach (var processor in processors)
                {
                    processor.Execute();
                }

                result.Add(new ProductCost() { Name = product.Name, Amount = inquiry.Amount });
            }

            return result;
        }

    }
}
