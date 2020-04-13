using System.Collections.Generic;

namespace Berlin.Infrastructure.Interfaces
{
    public interface IProduct
    {
        string Name { get; set; }
        IEnumerable<IProductComponent> Components { get; set; }
    }
}