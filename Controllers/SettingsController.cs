using Microsoft.AspNetCore.Mvc;

namespace EC_ASP.NET.Controllers
{
    public class SettingsController : Controller
    {
        public IActionResult Settings()
        {
            return View();
        }
        public IActionResult ProfileSettings()
        {
            return View();
        }
    }
}
