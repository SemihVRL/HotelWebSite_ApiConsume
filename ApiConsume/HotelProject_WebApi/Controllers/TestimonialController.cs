using HotelProject_BusinessLayer.Abstract;
using HotelProject_EntityLayer.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HotelProject_WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestimonialController : ControllerBase
    {
        private readonly ITestimonialService _testimonialService;

        public TestimonialController(ITestimonialService testimonialService)
        {
            _testimonialService = testimonialService;
        }

        [HttpGet]
        public IActionResult TestimonialList()
        {
            var values = _testimonialService.TGetList();
            return Ok(values);
        }

        [HttpPost]
        public IActionResult TestimonialAdd(Testimonial testimonial)
        {
            _testimonialService.TAdd(testimonial);
            return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult TestimonialDelete(int id)
        {
            var values = _testimonialService.TGetByID(id);
            _testimonialService.TDelete(values);
            return Ok();
        }

        [HttpPut]
        public IActionResult TestimonialUpdate(Testimonial testimonial)
        {
            _testimonialService.TUpdate(testimonial);
            return Ok();
        }

        [HttpGet("{id}")]
        public IActionResult GetIdTestimonial(int id)
        {
            var values = _testimonialService.TGetByID(id);
            return Ok(values);
        }

       
    }
}
