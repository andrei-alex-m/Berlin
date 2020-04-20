using System;
using System.Linq;
using Berlin.BusinessLogic;
using Xunit;

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
    }
}
