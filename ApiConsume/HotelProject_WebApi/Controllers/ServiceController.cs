using HotelProject_BusinessLayer.Abstract;
using HotelProject_EntityLayer.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HotelProject_WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ServiceController : ControllerBase
    {
        private readonly IServiceService _serviceService;

        public ServiceController(IServiceService serviceService)
        {
            _serviceService = serviceService;
        }

        [HttpGet]
        public IActionResult ServiceList()
        {
            var values = _serviceService.TGetList();
            return Ok(values);
        }

        [HttpPost]
        public IActionResult ServiceAdd(Service service)
        {
            _serviceService.TAdd(service);
            return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult ServiceDelete(int id)
        {
            var values = _serviceService.TGetByID(id);
            _serviceService.TDelete(values);
            return Ok();
        }

        [HttpPut]
        public IActionResult ServiceUpdate(Service service)
        {
            _serviceService.TUpdate(service);
            return Ok();
        }

        [HttpGet("{id}")]
        public IActionResult GetIdService(int id)
        {
            var values = _serviceService.TGetByID(id);
            return Ok(values);
        }
    }
}
