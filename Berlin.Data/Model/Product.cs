using System;
using System.Collections.Generic;
using Berlin.Infrastructure.Interfaces;

namespace Berlin.Model
{
    public class Product : IProduct
    {
        public Product()
        {
            Components = new List<ProductComponent>();
        }

        public Product(string name) : this()
        {
            Name = name;
        }

        public string Name { get; set; }
        public IEnumerable<IProductComponent> Components { get; set; }
    }
}
