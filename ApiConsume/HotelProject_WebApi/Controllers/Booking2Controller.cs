using HotelProject_BusinessLayer.Abstract;
using HotelProject_EntityLayer.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HotelProject_WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Booking2Controller : ControllerBase
    {
        private readonly IBookingService _bookingService;

        public Booking2Controller(IBookingService bookingService)
        {
            _bookingService = bookingService;
        }

        [HttpGet]
        public IActionResult BookingList()
        {
            var values = _bookingService.TGetList();
            return Ok(values);
        }
        [HttpPost]
        public IActionResult BookingAdd(Booking booking)
        {
            _bookingService.TAdd(booking);
            return Ok();
        }

        [HttpDelete]
        public IActionResult BookingDelete(int id)
        {
            var values = _bookingService.TGetByID(id);
            _bookingService.TDelete(values);
            return Ok();
        }
        [HttpPut]
        public IActionResult BookingUpdate(Booking booking)
        {
            _bookingService.TUpdate(booking);
            return Ok();

        }

        [HttpGet("{id}")]
        public IActionResult BookingGetID(int id)
        {
            var values=_bookingService.TGetByID(id);
            return Ok(values);
        }
    
    }
}
