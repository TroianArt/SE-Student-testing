using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using student_testing.Models.Settings;

namespace student_testing.Controllers
{
    public class SettingsController : Controller
    {
        [Authorize]
        [HttpGet]
        public IActionResult Account()
        {
            return View();
        }

        [Authorize]
        [HttpPost]
        public IActionResult Account(SettingsModel model)
        {
            return this.Redirect("/Home/Index");
        }
    }
}
