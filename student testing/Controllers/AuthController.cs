using System.Diagnostics.Eventing.Reader;
using BLL.DTO;
using BLL.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Serilog;
using student_testing.Models;
using System.Threading.Tasks;
using student_testing.Models.Auth;

namespace student_testing.Controllers
{
    public class AuthController : Controller
    {
        private IUserService userService;

        public AuthController(IUserService service)
        {
            this.userService = service;
        }

        [HttpGet]
        public IActionResult Login()
        {
            return this.View();
        }

        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public async Task<ActionResult> Login(LoginModel model)
        {
            if (this.ModelState.IsValid)
            {
                UserDto user = new UserDto { Email = model.Email };
                var result = await this.userService.SignInAsync(user, model.Password, true);
                if (result?.Succeeded == true)
                {
                    Log.Logger.Verbose("Logged in user {@userdto} ", user);
                    return this.Redirect("/Home/Privacy");
                }
                else
                {
                    Log.Logger.Warning("Did not log in user {@userdto} ", user);
                }

                return this.Redirect("/Home/Index");
            }

            return this.View();
        }

        [HttpGet]
        public IActionResult SignUp()
        {
            return this.View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> SignUp(SignUpModel model)
        {
            if (this.ModelState.IsValid)
            {
                UserDto user = new UserDto { UserName = model.UserName, Email = model.Email };
                var result = await this.userService.SignUpAsync(user, model.Password);
                if (result.Succeeded)
                {
                    result = await this.userService.AddRole(user, "Student");

                    if (result.Succeeded)
                    {
                        Log.Logger.Verbose("Registered user {@userdto} ", user);
                        return this.Redirect("/Auth/Login");
                    }

                    return await Login(new LoginModel {Email = model.Email, Password = model.Password});


                }
                else
                {
                    Log.Logger.Warning("Did not register user {@userdto} ", user);
                }

                return this.Redirect("/Home/Index");
            }

            return this.View();
        }
    }
}
