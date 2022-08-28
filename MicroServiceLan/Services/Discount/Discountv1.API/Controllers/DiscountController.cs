using Discountv1.API.Entities;
using Discountv1.API.Repository;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace Discountv1.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DiscountController : ControllerBase
    {
        private readonly IDiscountRepository _repository;
        public DiscountController(IDiscountRepository repository)
        {
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
        }
        [HttpGet("{productName}", Name = "GetDiscount")]
        [ProducesResponseType(typeof(Couponcs), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<Couponcs>> GetDiscount(string productName)
        {
            var coupon = await _repository.GetDiscount(productName);
            return Ok(coupon);
        }

        [HttpPost]
        [ProducesResponseType(typeof(Couponcs), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<Couponcs>> CreateDiscount([FromBody] Couponcs coupon)
        {
            await _repository.CreateDiscount(coupon);
            return CreatedAtRoute("GetDiscount", new { productName = coupon.ProductName }, coupon);
        }

        [HttpPut]
        [ProducesResponseType(typeof(Couponcs), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<Couponcs>> UpdateDiscount([FromBody] Couponcs coupon)
        {
            return Ok(await _repository.UpdateDiscount(coupon));
        }

        [HttpDelete("{productName}", Name = "DeleteDiscount")]
        [ProducesResponseType(typeof(void), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<bool>> DeleteDiscount(string productName)
        {
            return Ok(await _repository.DeleteDiscount(productName));
        }
    }
}
