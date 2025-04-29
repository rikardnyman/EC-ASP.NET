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



        [HttpPost]
        public IActionResult SignUp(ClientEntity client, bool terms)
        {
            if (ModelState.IsValid)
            {

                if (!terms)
                {
                    ModelState.AddModelError("Terms", "You must accept the terms and conditions.");
                    return View();
                }




                return RedirectToAction("SignUpSuccess");
            }


            return View(client);
        }


        public IActionResult SignUpSuccess()
        {
            return View();
        }
    }
}
