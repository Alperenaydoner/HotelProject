using HotelProject.BusinessLayer.Abstrack;
using HotelProject.EntityLayer.Concerate;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HotelProject.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoomController : ControllerBase
    {
        //Abstrack methodlar buralarda çalıştırlıyor.
        private readonly IRoomService _roomService;

        public RoomController(IRoomService roomService)
        {
            _roomService = roomService;
        }

        //Abstrack methodlar buralarda çalıştırlıyor.
        [HttpGet]
        public IActionResult RoomList()
        {
            return Ok(_roomService.TGetList());
        }

        [HttpPost]
        public IActionResult AddRoom(Room Room)
        {
            _roomService.TInsert(Room);
            return Ok();
        }

        [HttpDelete]
        public IActionResult DeleteRoom(int id)
        {
            var values = _roomService.TGetByID(id);
            _roomService.TDelete(values);

            return Ok();
        }

        [HttpPut]
        public IActionResult UpdateRoom(Room room)
        {
            _roomService.TUpdate(room);
            return Ok();
        }

        [HttpGet("{id}")]
        public IActionResult GetByID(int id)
        {
            var values = _roomService.TGetByID(id);
            return Ok(values);
        }
    }
}
