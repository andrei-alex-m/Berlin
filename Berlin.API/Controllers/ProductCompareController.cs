using System;
using System.Collections.Generic;
using Berlin.Dto;
using Berlin.Infrastructure.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Berlin.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductCompareController : ControllerBase
    {
        private IInquiryProcessor _processor;
        public ProductCompareController(IInquiryProcessor processor)
        {
            _processor = processor;
        }

        // GET: api/ProductCompare/5
        [HttpGet(Name = "Get")]
        public ActionResult<IEnumerable<IProductCost>> Get([FromQuery]long kilowatts,[FromQuery]long months)
        {
            try
            {
                return StatusCode(200, _processor.Execute( kilowatts, months ));
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Internal Server Error");
            }
        }
    }
}
