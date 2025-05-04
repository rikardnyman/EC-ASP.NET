using EC_ASP.NET.Models;
using Microsoft.AspNetCore.Mvc;

namespace EC_ASP.NET.Controllers
{
    public class AdminController : Controller
    {
        public IActionResult Members()
        {
            return View();
        }






        public IActionResult SignUpSuccess()
        {
            return View();
        }
    }
}
