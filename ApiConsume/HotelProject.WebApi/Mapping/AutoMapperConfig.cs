using AutoMapper;
using HotelProject.DtoLayer.Dtos.AboutDto;
using HotelProject.DtoLayer.Dtos.RoomDto;
using HotelProject.EntityLayer.Concerate;

namespace HotelProject.WebApi.Mapping
{
    public class AutoMapperConfig: Profile
    {
        public AutoMapperConfig() 
        { 
            CreateMap<RoomAddDto, Room>();
            CreateMap<Room, RoomAddDto>();

            CreateMap<UpdateRoomDto, Room>().ReverseMap();

            CreateMap<AboutAddDto, About>().ReverseMap();

        }
    }
}
