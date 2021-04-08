using BLL.DTO;
using DAL.Domain;
using Microsoft.AspNetCore.Mvc;
using student_testing.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BLL.Interfaces;
using BLL.Services;

namespace student_testing.Controllers
{
    public class AuthController : Controller
    {
        private IUserService userService;

        public AuthController(IUserService service)
        {
            userService = service;
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public async Task<ActionResult> Login(LoginModel model)
        {
            if (ModelState.IsValid)
            {
                UserDto user = new UserDto { Email = model.Email };
                var result = await userService.SignInAsync(user, model.Password, true);
                if (result != null && result.Succeeded)
                {
                    return Redirect("/Home/Privacy");
                }
                return Redirect("/Home/Index");
            }
            return View();
        }

        [HttpGet]
        public IActionResult SignUp()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> SignUp(SignUpModel model)
        {
            if (ModelState.IsValid)
            {
                UserDto user = new UserDto { UserName = model.UserName, Email = model.Email };
                var result = await userService.SignUpAsync(user, model.Password);
                if (result.Succeeded)
                {
                    //result = await userService.AddRole(user, "Student");
                    if (result.Succeeded)
                    {
                        return Redirect("/Auth/Login");
                    }
                }
                return Redirect("/Home/Index");
            }
            return View();
        }
    }
}
