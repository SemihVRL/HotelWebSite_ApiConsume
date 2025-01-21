using HotelProject_BusinessLayer.Abstract;
using HotelProject_EntityLayer.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HotelProject_WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SendMessageController : ControllerBase
    {
        private readonly ISendMessageService _messsageService;
        public SendMessageController(ISendMessageService messsageService)
        {
            _messsageService = messsageService;
        }

        [HttpGet]
        public IActionResult SendMessageList()
        {
            var values = _messsageService.TGetList();
            return Ok(values);
        }

        [HttpPost]
        public IActionResult SendMessageAdd(SendMessage message)
        {
            _messsageService.TAdd(message);
            return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult SendMessageDelete(int id)
        {
            var values = _messsageService.TGetByID(id);
            _messsageService.TDelete(values);
            return Ok();
        }

        [HttpPut]
        public IActionResult SendMessageUpdate(SendMessage message)
        {
            _messsageService.TUpdate(message);
            return Ok();
        }

        [HttpGet("{id}")]
        public IActionResult GetIdSendMessage(int id)
        {
            var values = _messsageService.TGetByID(id);
            return Ok(values);
        }
    }
}
