using HotelProject_EntityLayer.Concrete;
using HotelProject_WebUI.Dtos.RegisterDto;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace HotelProject_WebUI.Controllers
{
    public class RegisterController : Controller
    {
        private readonly UserManager<AppUser> _manager;

        public RegisterController(UserManager<AppUser> manager)
        {
            _manager = manager;
        }
        [HttpGet]
        public IActionResult RegisterIndex()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> RegisterIndex(CreateNewUserDto userDto)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            var appuser = new AppUser()
            {
                Name = userDto.Name,
                Email=userDto.Mail,
                Surname=userDto.Surname,
                UserName=userDto.Username

            };
            var result = await _manager.CreateAsync(appuser, userDto.Password);
            if (result.Succeeded)
            {
                return RedirectToAction("LoginIndex", "Login");
            }
            return View();
        }
    }
}
