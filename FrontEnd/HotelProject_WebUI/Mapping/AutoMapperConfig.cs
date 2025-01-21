using AutoMapper;
using HotelProject_EntityLayer.Concrete;
using HotelProject_WebUI.Dtos.AboutDto;
using HotelProject_WebUI.Dtos.BookingDto;
using HotelProject_WebUI.Dtos.LoginDto;
using HotelProject_WebUI.Dtos.RegisterDto;
using HotelProject_WebUI.Dtos.ServiceDto;
using HotelProject_WebUI.Dtos.SubscribeDto;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.Blazor;
using System.Runtime.CompilerServices;

namespace HotelProject_WebUI.Mapping
{
    public class AutoMapperConfig:Profile
    {
        public AutoMapperConfig()
        {
            CreateMap<ListServiceDto, Service>().ReverseMap();
            CreateMap<AddServiceDto, Service>().ReverseMap();
            CreateMap<UpdateServiceDto, Service>().ReverseMap();

            CreateMap<CreateNewUserDto,AppUser>().ReverseMap();
            CreateMap<LoginUserDto,AppUser>().ReverseMap();

            CreateMap<ResultAboutDto,About>().ReverseMap();
            CreateMap<UpdateAboutDto,About>().ReverseMap();


            CreateMap<ResultSubsDto,Subscribe>().ReverseMap();
            CreateMap<ResultBookingDto,Booking>().ReverseMap();



            
        }
    }
}
