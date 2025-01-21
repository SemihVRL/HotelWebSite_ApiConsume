using HotelProject_BusinessLayer.Abstract;
using HotelProject_BusinessLayer.Concrete;
using HotelProject_DataAccessLayer.Entity_Framework;
using HotelProject_EntityLayer.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HotelProject_WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StaffController : ControllerBase
    {
        private readonly IStaffService _staffService;
        public StaffController(IStaffService staffService)
        {
            _staffService = staffService;
        }

        [HttpGet]
        public IActionResult StaffList()
        {
            var values = _staffService.TGetList();
            return Ok(values);
        }

        [HttpPost]
        public IActionResult StaffAdd(Staff staff)
        {
            _staffService.TAdd(staff);
            return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult StaffDelete(int id)
        {
           var values=_staffService.TGetByID(id);
            _staffService.TDelete(values);
            return Ok();
        }

        [HttpPut]
        public IActionResult StaffUpdate(Staff staff)
        {
            _staffService.TUpdate(staff);
            return Ok();
        }

        [HttpGet("{id}")]
        public IActionResult GetIdStaff(int id)
        {
            var values = _staffService.TGetByID(id);
            return Ok(values);
        }
    }

    
}
