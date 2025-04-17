using Microsoft.AspNetCore.Mvc;

namespace EC_ASP.NET.Controllers
{
    public class AuthController : Controller
    {
        public IActionResult SignUp()
        {
            return View();
        }
    }
}
