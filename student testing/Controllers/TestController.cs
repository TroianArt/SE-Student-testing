using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using student_testing.Models.Test;

namespace student_testing.Controllers
{
    public class TestController : Controller
    {
        [HttpGet]
        [Authorize]
        public IActionResult Index()//get user tests
        {
            return View(new List<TestViewModel>());//IEnumerable<Test>
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public IActionResult Create(CreateTestViewModel model)//create test
        {
            return View();
        }

        [HttpGet]
        [Authorize(Roles = "Admin")]
        public IActionResult Create()//create test
        {
            return View();
        }

        [HttpPut]
        [Authorize(Roles = "Admin")]
        public IActionResult Update(UpdateTestViewModel model)//get user tests
        {
            return View();
        }

        [HttpGet]
        [Authorize(Roles = "Admin")]
        public IActionResult Update()//get user tests
        {
            return View();
        }

        [HttpPost]
        [Authorize]
        public IActionResult Start(int id)//get user tests
        {
            return View();
        }

        [HttpPost]
        [Authorize]
        public IActionResult Complete(int id)//get user tests
        {
            return View();
        }

        [HttpGet]
        [Authorize]
        public IActionResult Details(int id)//get user tests
        {
            return View();
        }
    }
}
