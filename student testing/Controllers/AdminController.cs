using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using student_testing.Models.Admin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace student_testing.Controllers
{
   
    public class AdminController : Controller
    {
        Dictionary<string, string> d = new Dictionary<string, string> { { "test@gmail.com", "Student" }, { "teacher@gmail.com", "Teacher" } };
        [HttpGet]
        //[Authorize(Roles = "Admin")]
        public IActionResult Index()
        {
            AdminPageModel am = new AdminPageModel { Users = d };
            return View(am);
        }

        //[HttpPost]
        //[Authorize(Roles = "Admin")]
        //public IActionResult Index()
        //{
        //    return View();
        //}
    }
}
