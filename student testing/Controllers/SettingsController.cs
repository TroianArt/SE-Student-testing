using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using BLL.Interfaces;
using student_testing.Models.Settings;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace student_testing.Controllers
{
    public class SettingsController : Controller
    {
        private IUserService userService;

        public SettingsController(IUserService service)
        {
            this.userService = service;
        }

        [Authorize]
        [HttpGet]
        public IActionResult Account()
        {
            string userEmail = User.FindFirst(ClaimTypes.Email).Value;
            ViewBag.email = userEmail;
            return View();
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> Account(SettingsModel model)
        {
            if (this.ModelState.IsValid)
            {
                string userEmail = User.FindFirst(ClaimTypes.Email).Value;
                IdentityResult result = await userService.ChangePasswordAsync(userEmail, model.oldPassword, model.newPassword);
                if (result.Succeeded)
                {
                    await this.userService.SignOutAsync();
                    return this.Redirect("/Home/Index");
                }
            }
            return this.View();
        }
    }
}
