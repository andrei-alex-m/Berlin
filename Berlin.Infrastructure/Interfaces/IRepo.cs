using System.Collections.Generic;

namespace Berlin.Infrastructure.Interfaces
{
    public interface IRepo
    {
        IEnumerable<IProduct> Products { get; set; }
    }
}