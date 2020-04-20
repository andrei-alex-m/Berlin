using System;
using System.Collections.Generic;
using System.Linq;
using Berlin.BusinessLogic;
using Berlin.Infrastructure.Enums;
using Berlin.Infrastructure.Interfaces;
using Berlin.Model;
using Moq;
using Xunit;
using Berlin.Controllers;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Berlin.Tests
{
    public class BusinessLogicTests
    {
        [Fact]
        public void Test1200()
        {
            var stubRepo = new Repo.Repo();
            var inq = new InquiryProcessor(stubRepo);
            var results = inq.Execute(1200, 12).ToList();
            Assert.Equal(324, results[0].Amount);
            Assert.Equal(800, results[1].Amount);
        }

        [Fact]
        public async Task Test1200ControllerAsync()
        {

            //same setup as repo object
            ProductComponent component1;
            ProductComponent component2;
            var products = new List<IProduct>();

            component1 = new ProductComponent() { Amount = 5, Type = MeasureType.Months, Unit = 1 };
            component2 = new ProductComponent() { Amount = 0.22m, Type = MeasureType.KiloWatts, Unit = 1 };

            products.Add(new Product() { Components = new List<ProductComponent>() { component1, component2 }, Name = "Basic Electricity Tariff" });

            component1 = new ProductComponent() { Amount = 800, Type = MeasureType.KiloWatts, Limits = new Limits() { Upper = 4000 }, Unit = 4000, };
            component2 = new ProductComponent() { Amount = 0.30m, Type = MeasureType.KiloWatts, Limits = new Limits() { Lower = 4000 }, Unit = 1, };

            products.Add(new Product() { Components = new List<ProductComponent>() { component1, component2 }, Name = "Basic Packaged Tariff" });

            var mockRepo = new Mock<IRepo>();
            mockRepo.Setup(x => x.Products).Returns(products);

            var mockInqProc = new InquiryProcessor(mockRepo.Object);
            var controller = new ProductCompareController(mockInqProc);

            var response = await controller.Get(1200, 12);

            var actionResult = Assert.IsType<OkObjectResult>(response.Result);
            var returnVal = Assert.IsAssignableFrom<IEnumerable<IProductCost>>(actionResult.Value);

            Assert.Equal(324, returnVal.First().Amount);
            Assert.Equal(800, returnVal.Skip(1).First().Amount);

        }
    }
}
