using Data.Dtos;
using Data.Services;
using EC_ASP.NET.Models;
using Microsoft.AspNetCore.Mvc;

namespace EC_ASP.NET.Controllers
{
    public class AuthController(IAuthService authService) : Controller
    {
        private readonly IAuthService _authService = authService;

        public IActionResult SignUp()
        {
            
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> SignUp(SignUpViewModel model)
        {
            ViewBag.ErrorMessage = null;

            if (!ModelState.IsValid)
                return View(model);

            var signUpFormData = new SignUpFormData
            {
                Email = model.Email,
                Password = model.Password,
                FullName = model.FullName
            };

            var result = await _authService.SignUpAsync(signUpFormData);
          
            if (result.Succeeded)
            {
                return RedirectToAction("SignIn", "Auth");

            }
            ViewBag.ErrorMessage = result.Error;
            return View(model);
        }



        public IActionResult SignIn(string returnUrl = "~/")
        {
            ViewBag.ReturnUrl = returnUrl;
            return View();
        }



        [HttpPost]
        public async Task<IActionResult> SignIn(SignInViewModel model, string returnUrl = "~/")
        {
            ViewBag.ErrorMessage = null;
            ViewBag.ReturnUrl = returnUrl;


            if (!ModelState.IsValid)
                return View(model);

            var signInFormData = new SignInFormData
            {
                Email = model.Email,
                Password = model.Password,
                
            };

            var result = await _authService.SignInAsync(signInFormData);

            if (result.Succeeded)
            {
                return LocalRedirect(returnUrl);

            }
            ViewBag.ErrorMessage = result.Error;
            return View(model);
        }
    }
}

