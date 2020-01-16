using System.Threading.Tasks;
using delivery_app_back.Models;
using delivery_app_back.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Internal;

namespace delivery_app_back.Controllers
{
    [Route("api/couriers")]
    [ApiController]
    public class CourierController : ControllerBase
    {
        private readonly ICourierService _courierService;

        public CourierController(ICourierService courierService)
        {
            _courierService = courierService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var couriers = await _courierService.Get();

            if (!couriers.Any()) return NoContent();

            return Ok(couriers);
        }

        [HttpGet("{userId}")]
        public IActionResult Get(int userId)
        {
            var courier = _courierService.Get(userId);
            if (courier != null) return Ok(courier);
            return NotFound();
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CourierForCreationDto courierData)
        {
            if (courierData == null) return BadRequest();
            var courierDetail = await _courierService.Create(courierData);
            return CreatedAtRoute("CreateCourier", new { id = courierDetail.UserId.ToString()}, courierDetail);
        }
    }
}