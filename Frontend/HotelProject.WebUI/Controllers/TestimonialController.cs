using HotelProject.WebUI.Models.Testimonial;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;

namespace HotelProject.WebUI.Controllers
{
    public class TestimonialController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public TestimonialController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IActionResult> Index()
        {
            var client = _httpClientFactory.CreateClient();// Http istemci oluşturuluyor.
            var responseMessage = await client.GetAsync("http://localhost:5203/api/Testimonial");// İstek gönderiyoruz

            if (responseMessage.IsSuccessStatusCode) // Success true ise
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync(); // istekten gelen datayı json şeklinde alır.
                var response = JsonConvert.DeserializeObject<List<TestimonialViewModel>>(jsonData); // İstekten gelen data ile modeli karşılaştırıyoruz dönen verilerin aynı olması gerek.
                return View(response);
            }
            return View();
        }

        [HttpGet]
        public IActionResult AddTestimonial()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> AddTestimonial(TestimonialViewModel addTestimonialWiewModel)
        {
            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(addTestimonialWiewModel);
            StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var responseMessage = await client.PostAsync("http://localhost:5203/api/Testimonial", stringContent);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View();
        }

        public async Task<IActionResult> DeleteTestimonial(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessega = await client.DeleteAsync($"http://localhost:5203/api/Testimonial/{id}");
            if (responseMessega.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View();
        }
        [HttpGet]
        public async Task<IActionResult> UpdateTestimonial(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessega = await client.GetAsync($"http://localhost:5203/api/Testimonial/{id}");
            if (responseMessega.IsSuccessStatusCode)
            {
                var jsonData = await responseMessega.Content.ReadAsStringAsync(); // istekten gelen datayı json şeklinde alır.
                var values = JsonConvert.DeserializeObject<TestimonialViewModel>(jsonData);
                return View(values);
            }
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> UpdateTestimonial(TestimonialViewModel updateTestimonialViewModel)
        {
            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(updateTestimonialViewModel);
            StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var responseMessega = await client.PutAsync("http://localhost:5203/api/Testimonial/", stringContent);
            if (responseMessega.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View();
        }
    }
}
