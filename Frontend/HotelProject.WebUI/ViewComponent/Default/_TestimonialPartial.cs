﻿using Microsoft.AspNetCore.Mvc;

namespace HotelProject.WebUI.ViewComponent.Default
{
    public class _TestimonialPartial : Microsoft.AspNetCore.Mvc.ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
