using System.Collections.Generic;

namespace Berlin.Infrastructure.Interfaces
{
    public interface IInquiryProcessor
    {
        IEnumerable<IProductCost> Execute(long kilowatts, long months);
    }
}