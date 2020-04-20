using System.Collections.Generic;
using Berlin.Infrastructure.Enums;
using Berlin.Infrastructure.Interfaces;
using Berlin.Model;

namespace Berlin.Repo
{
    public class Repo : IRepo
    {
        public Repo()
        {
            ProductComponent component1;
            ProductComponent component2;

            var products = new List<IProduct>();

            component1 = new ProductComponent() { Amount = 5, Type = MeasureType.Months, Unit = 1 };
            component2 = new ProductComponent() { Amount = 0.22m, Type = MeasureType.KiloWatts, Unit = 1 };

            products.Add(new Product() { Components = new List<ProductComponent>() { component1, component2 }, Name = "Basic Electricity Tariff" });

            component1 = new ProductComponent() { Amount = 800, Type=MeasureType.KiloWatts, Limits = new Limits() { Upper = 4000 }, Unit = 4000, };
            component2 = new ProductComponent() { Amount = 0.30m, Type=MeasureType.KiloWatts, Limits = new Limits() { Lower = 4000 }, Unit = 1, };

            products.Add(new Product() { Components = new List<ProductComponent>() { component1, component2 }, Name = "Basic Packaged Tariff" });

            Products = products;

        }

        public IEnumerable<IProduct> Products { get; set; }


    }
}
