using AutoMapper;
using HotelProject.BusinessLayer.Abstrack;
using HotelProject.DtoLayer.Dtos.AboutDto;
using HotelProject.DtoLayer.Dtos.RoomDto;
using HotelProject.EntityLayer.Concerate;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HotelProject.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AboutController : ControllerBase
    {
        //Abstrack methodlar buralarda çalıştırlıyor.
        private readonly IAboutService _aboutService;

        private readonly IMapper _mapper;

        public AboutController(IAboutService aboutService, IMapper mapper)
        {
            _aboutService = aboutService;
            _mapper = mapper;
        }

        //Abstrack methodlar buralarda çalıştırlıyor.
        [HttpGet]
        public IActionResult AboutList()
        {
            return Ok(_aboutService.TGetList());
        }

        [HttpPost]
        public IActionResult AddAbout(AboutAddDto aboutAddDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var values = _mapper.Map<About>(aboutAddDto); //Entitiy ile Dto kıyaslaması yapılıyor.
            _aboutService.TInsert(values);// Ekleme işlemini yapıyor .
            return Ok("İşlem Başarılı.");
        }

        [HttpDelete]
        public IActionResult DeleteAbout(int id)
        {
            var values = _aboutService.TGetByID(id);
            _aboutService.TDelete(values);

            return Ok();
        }

        [HttpPut]
        public IActionResult UpdateAbout(About About)
        {
            _aboutService.TUpdate(About);
            return Ok();
        }

        [HttpGet("{id}")]
        public IActionResult GetByID(int id)
        {
            var values = _aboutService.TGetByID(id);
            return Ok(values);
        }
    }
}