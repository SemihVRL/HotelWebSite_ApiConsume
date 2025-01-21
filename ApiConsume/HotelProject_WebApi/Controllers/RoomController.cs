using HotelProject_BusinessLayer.Abstract;
using HotelProject_BusinessLayer.Concrete;
using HotelProject_EntityLayer.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HotelProject_WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoomController : ControllerBase
    {
        private readonly IRoomService _roomService;
        public RoomController(IRoomService roomService)
        {
            _roomService = roomService;
        }

        [HttpGet]
        public IActionResult RoomList()
        {
            var values = _roomService.TGetList();
            return Ok(values);
        }

        [HttpPost]
        public IActionResult RoomAdd(Room room)
        {
            _roomService.TAdd(room);
            return Ok();
        }

        [HttpDelete]
        public IActionResult RoomDelete(int id)
        {
            var values = _roomService.TGetByID(id);
            _roomService.TDelete(values);
            return Ok();
        }

        [HttpPut]
        public IActionResult RoomUpdate(Room room)
        {
            _roomService.TUpdate(room);
            return Ok();
        }

        [HttpGet("{id}")]
        public IActionResult GetIdRoom(int id)
        {
           var values=_roomService.TGetByID(id);
            return Ok(values);
        }
    }
}
