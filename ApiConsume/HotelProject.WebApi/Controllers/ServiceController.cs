using HotelProject.BusinessLayer.Abstrack;
using HotelProject.EntityLayer.Concerate;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HotelProject.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ServiceController : ControllerBase
    {
        private readonly IServiceService _ServiceService;

        public ServiceController(IServiceService serviceService)
        {
            _ServiceService = serviceService;
        }

        //Abstrack methodlar buralarda çalıştırlıyor.
        [HttpGet]
        public IActionResult ServiceList()
        {
            return Ok(_ServiceService.TGetList());
        }

        [HttpPost]
        public IActionResult AddService(Service service)
        {
            _ServiceService.TInsert(service);
            return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteService(int id)
        {
            var values = _ServiceService.TGetByID(id);
            _ServiceService.TDelete(values);

            return Ok();
        }

        [HttpPut]
        public IActionResult UpdateService(Service service)
        {
            _ServiceService.TUpdate(service);
            return Ok();
        }

        [HttpGet("{id}")]
        public IActionResult GetByID(int id)
        {
            var values = _ServiceService.TGetByID(id);
            return Ok(values);
        }
    }
}
