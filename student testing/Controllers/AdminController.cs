using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace student_testing.Controllers
{
    public class AdminController : Controller
    {
        [HttpGet]
        [Authorize(Roles = "Admin")]
        public IActionResult Index()
        {
            return View();
        }

        //[HttpPost]
        //[Authorize(Roles = "Admin")]
        //public IActionResult Index()
        //{
        //    return View();
        //}
    }
}
