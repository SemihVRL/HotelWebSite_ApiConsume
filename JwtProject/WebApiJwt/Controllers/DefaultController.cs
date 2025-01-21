using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authorization.Infrastructure;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApiJwt.Models;

namespace WebApiJwt.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DefaultController : ControllerBase
    {
        [HttpGet("[action]")]
        public IActionResult TokenTest()
        {
            return Ok(new CreateToken().TokenCreate());
        }

        [Authorize(AuthenticationSchemes = "Bearer")]
        [HttpGet("[action]")]
        public IActionResult Test2()
        {
            return Ok("Hoşgeldiniz");
        }


        [HttpGet("[action]")]
        public IActionResult TokenAdminTest()
        {
            return Ok(new CreateToken().TokenCreateAdmin());
        }

        [Authorize(AuthenticationSchemes = "Bearer",Roles ="Admin,Visitor")]
        [HttpGet("[action]")]
        public IActionResult Test4()
        {
            return Ok("Token başarılı bir şekilde giriş yaptı");
        }
    }
}
