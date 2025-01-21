using AutoMapper;
using HotelProject_BusinessLayer.Abstract;
using HotelProject_DtoLayer.Dtos.RoomDto;
using HotelProject_EntityLayer.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HotelProject_WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Room2Controller : ControllerBase
    {
        private readonly IRoomService _roomService;
        private readonly IMapper _mapper;

        public Room2Controller(IRoomService roomService,IMapper mapper)
        {
            _roomService = roomService;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult Room2Get()
        {
            var values=_roomService.TGetList();
            return Ok(values);
        }

        [HttpPost]
        public IActionResult Room2Post(RoomAddDto roomAddDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            var values=_mapper.Map<Room>(roomAddDto);
            _roomService.TAdd(values);
            return Ok();
        }

        [HttpPut]
        public IActionResult Room2Put(RoomUpdateDto roomUpdateDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            var values = _mapper.Map<Room>(roomUpdateDto);
            _roomService.TUpdate(values);
            return Ok("Başarıyla Güncellendi");
        }
    }
}
