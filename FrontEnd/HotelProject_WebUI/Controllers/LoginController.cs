using HotelProject_EntityLayer.Concrete;
using HotelProject_WebUI.Dtos.LoginDto;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace HotelProject_WebUI.Controllers
{
    public class LoginController : Controller
    {
        private readonly SignInManager<AppUser> _manager;

        public LoginController(SignInManager<AppUser> manager)
        {
            _manager = manager;
        }
        [HttpGet]
        public IActionResult LoginIndex()
        {
            return View();
        }

        [HttpPost]
        public async Task< IActionResult> LoginIndex(LoginUserDto logindto)
        {
            
            if (ModelState.IsValid)
            {
                var result = await _manager.PasswordSignInAsync(logindto.UserName, logindto.Password, true, true);
                if (result.Succeeded)
                {
                    return RedirectToAction("StaffIndex","Staff");
                }

                else
                {
                    ModelState.AddModelError(string.Empty, "Hatalı Kullanıcı Adı veya Şifre");
                }

            }
            return View();
        }
    }
}
