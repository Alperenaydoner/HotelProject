using HotelProject.WebUI.Models.Staff;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
namespace HotelProject.WebUI.Controllers
{
    public class StaffController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public StaffController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task <IActionResult> Index()
        {
            var client= _httpClientFactory.CreateClient();// Http istemci oluşturuluyor.
            var responseMessage = await client.GetAsync("http://localhost:5203/api/Staff");// İstek gönderiyoruz

            if (responseMessage.IsSuccessStatusCode) // Success true ise
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync(); // istekten gelen datayı json şeklinde alır.
                var response = JsonConvert.DeserializeObject<List<StaffViewModel>>(jsonData); // İstekten gelen data ile modeli karşılaştırıyoruz dönen verilerin aynı olması gerek.
                return View(response);
            }
            return View();
        }

        [HttpGet]
        public IActionResult AddStaff() 
        { 
            return View(); 
        }
        [HttpPost]
        public async Task<IActionResult> AddStaff(AddStaffWiewModel addStaffWiewModel)
        {
            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(addStaffWiewModel);
            StringContent stringContent = new StringContent(jsonData,Encoding.UTF8,"application/json");
            var responseMessage = await client.PostAsync("http://localhost:5203/api/Staff", stringContent);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View();
        }
        
        public async Task<IActionResult> DeleteStaff(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessega = await client.DeleteAsync($"http://localhost:5203/api/Staff/{id}");
            if (responseMessega.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View();
        }
        [HttpGet]
        public async Task<IActionResult> UpdateStaff(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessega = await client.GetAsync($"http://localhost:5203/api/Staff/{id}");
            if (responseMessega.IsSuccessStatusCode)
            {
                var jsonData = await responseMessega.Content.ReadAsStringAsync(); // istekten gelen datayı json şeklinde alır.
                var values = JsonConvert.DeserializeObject<UpdateStaffViewModel>(jsonData);
                return View(values);
            }
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> UpdateStaff(UpdateStaffViewModel updateStaffViewModel) 
        {
            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(updateStaffViewModel);
            StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var responseMessega = await client.PutAsync("http://localhost:5203/api/Staff/",stringContent);
            if (responseMessega.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View();
        }
    }
}
