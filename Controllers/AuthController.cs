using EC_ASP.NET.Models;
using Microsoft.AspNetCore.Mvc;

namespace EC_ASP.NET.Controllers
{
    public class AuthController : Controller
    {



        [HttpGet]
        public IActionResult SignUp()
        {
            return View();
        }


        [HttpPost]
        public IActionResult SignUp(User user, string confirmPassword, bool terms)
        {
            if (ModelState.IsValid)
            {

                if (user.Password != confirmPassword)
                {
                    ModelState.AddModelError("Password", "Password and confirmation do not match.");
                    return View();
                }




                return RedirectToAction("SignUpSuccess");
            }

            return View();
        }


        public IActionResult SignUpSuccess()
        {
            return View();

        }


        public IActionResult SignIn()
        {
            return View();
        }
    }
}

