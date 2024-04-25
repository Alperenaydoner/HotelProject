using AutoMapper;
using HotelProject.BusinessLayer.Abstrack;
using HotelProject.DtoLayer.Dtos.RoomDto;
using HotelProject.EntityLayer.Concerate;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HotelProject.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    // DTO KULLANARAK AUTOMAPPER İLE VALIDETION KONTROLU YAPILMASI İÇİN ÖRNEK BİR CONTROLLER DOSYASI//
    public class Room2Controller : ControllerBase
    {
        //Abstrack methodlar buralarda çalıştırlıyor.
        private readonly IRoomService _roomService;
        private readonly IMapper _mapper;
        public Room2Controller(IRoomService roomService, IMapper mapper)
        {
            _roomService = roomService;
            _mapper = mapper;
        }

        //Abstrack methodlar buralarda çalıştırlıyor.
        [HttpGet]
        public IActionResult RoomList()
        {
            return Ok(_roomService.TGetList());
        }

        [HttpPost]
        public IActionResult AddRoom(RoomAddDto roomAddDto)
        {
            if(!ModelState.IsValid) 
            {
                return BadRequest(ModelState);
            }
            var values = _mapper.Map<Room>(roomAddDto); //Entitiy ile Dto kıyaslaması yapılıyor.
            _roomService.TInsert(values);// Ekleme işlemini yapıyor .
            return Ok("İşlem Başarılı.");

        }

        [HttpDelete]
        public IActionResult DeleteRoom(int id)
        {
            var values = _roomService.TGetByID(id);
            _roomService.TDelete(values);

            return Ok();
        }

        [HttpPut]
        public IActionResult UpdateRoom(UpdateRoomDto updateRoomDto)
        {
            if(!ModelState.IsValid) 
            {
                return BadRequest(ModelState);
            }
            var values = _mapper.Map<Room>(updateRoomDto);
            _roomService.TUpdate(values);
            return Ok("İşlem Başarılı.");
        }

        [HttpGet("{id}")]
        public IActionResult GetByID(int id)
        {
            var values = _roomService.TGetByID(id);
            return Ok(values);
        }
    }
}
