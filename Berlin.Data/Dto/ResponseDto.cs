using Berlin.Infrastructure.Interfaces;

namespace Berlin.Dto
{
    /// <summary>
    /// to be returned as a list
    /// </summary>
    public class ProductCost : IProductCost
    {
        public string Name { get; set; }
        public decimal Amount { get; set; }
    }
}
