using Microsoft.AspNetCore.Mvc;

namespace HotelProject.WebUI.Controllers
{
    public class defaultController : Controller
    {

        public IActionResult Index()
        {
            return View();
        }
    }
}
