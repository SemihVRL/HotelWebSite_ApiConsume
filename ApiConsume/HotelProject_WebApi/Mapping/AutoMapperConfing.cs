using AutoMapper;
using HotelProject_DtoLayer.Dtos.RoomDto;
using HotelProject_EntityLayer.Concrete;

namespace HotelProject_WebApi.Mapping
{
    public class AutoMapperConfing : Profile
    {
        //auto mapper sayesinde
        //dto sınıfında yazdığımız proplar entity de yazılan proplar ile eşleşmiş oluyor

        public AutoMapperConfing()
        {
            CreateMap<RoomAddDto, Room>();
            CreateMap<Room, RoomAddDto>();
            //reverse mapsiz hali

            CreateMap<RoomUpdateDto, Room>().ReverseMap();

            //Revervemap dememizin sebebi iki taraflı eşleşme yapılması için

           
        }
    }
}
