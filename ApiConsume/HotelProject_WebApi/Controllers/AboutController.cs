using HotelProject_BusinessLayer.Abstract;
using HotelProject_EntityLayer.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HotelProject_WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AboutController : ControllerBase
    {
        private readonly IAboutService _aboutService;

        public AboutController(IAboutService aboutService)
        {
            _aboutService = aboutService;
        }

        [HttpGet]
        public IActionResult AboutList()
        {
            var values=_aboutService.TGetList();
            return Ok(values);
        }

        [HttpPost]
        public IActionResult AboutAdd(About about)
        {
            _aboutService.TAdd(about);
            return Ok();
        }

        [HttpDelete]
        public IActionResult AboutDelete(int id)
        {
            var values=_aboutService.TGetByID(id);
            _aboutService.TDelete(values);
            return Ok();
        }

        [HttpPut]
        public IActionResult AboutUpdate(About about)
        {
            _aboutService.TUpdate(about);
            return Ok();
        }
        [HttpGet("{id}")]
        public IActionResult GetIdRoom(int id)
        {
            var values = _aboutService.TGetByID(id);
            return Ok(values);
        }
    }
}
