using HotelProject_BusinessLayer.Abstract;
using HotelProject_EntityLayer.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HotelProject_WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactController : ControllerBase
    {
        private readonly IContactService _contactservice;

        public ContactController(IContactService contactService)
        {
            _contactservice = contactService;
        }

        [HttpGet]
        public IActionResult ContactList()
        {
            var values = _contactservice.TGetList();
            return Ok(values);
        }

        [HttpPost]
        public IActionResult ContactAdd(Contact contact)
        {
            contact.Date = Convert.ToDateTime(DateTime.Now.ToString());
            _contactservice.TAdd(contact);
            return Ok();
        }

        [HttpDelete]
        public IActionResult ContactDelete(int id)
        {
            var values = _contactservice.TGetByID(id);
            _contactservice.TDelete(values);
            return Ok();
        }

        [HttpPut]
        public IActionResult ContactUpdate(Contact contact)
        {
            _contactservice.TUpdate(contact);
            return Ok();
        }

        [HttpGet("{id}")]
        public IActionResult GetIdRoom(int id)
        {
            var values = _contactservice.TGetByID(id);
            return Ok(values);
        }

    }
}
