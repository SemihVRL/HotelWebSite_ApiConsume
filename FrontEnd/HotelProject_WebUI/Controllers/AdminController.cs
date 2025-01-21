using Microsoft.AspNetCore.Mvc;

namespace HotelProject_WebUI.Controllers
{
    public class AdminController : Controller
    {
        public IActionResult AdminLayout()
        {
            return View();
        }
    }
}
