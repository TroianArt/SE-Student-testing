using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using student_testing.Models.Test;
using DAL.Domain;
using BLL.Interfaces;
using DAL.Interfaces;
using BLL.DTO;
using Serilog;

namespace student_testing.Controllers
{
    public class TestController : Controller
    {
        private ITestService testService;
        private long groupId;


        public TestController(ITestService service)
        {
            this.testService = service;

        }
        [HttpGet]
        [Authorize]
        public IActionResult Index()//get user tests
        {
            return View(new List<TestViewModel>());//IEnumerable<Test>
        }

        [HttpPost]
        [Authorize(Roles = "Student")]
        public async Task<IActionResult> Create(CreateTestViewModel model)//create test
        {
            if (this.ModelState.IsValid)
            {
                TestDto testDto = new TestDto
                {
                    DateCreation = DateTime.Now,
                    Name= model.Name,
                    Description=model.Description, 
                    DateStart=model.DateStart,
                    DateValid=model.DateValid,
                    Duration=model.Duration,
                    GroupId= model.GroupId

                };
                await testService.CreateTest(testDto);
                Log.Logger.Verbose("Create test: {@groupDto}  ", testDto);
                return View();
            }
            return View();
        }

        [HttpGet]
        [Authorize(Roles = "Student")]
        public IActionResult Create(long groupid)//create test
        {
            groupId = groupid;
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

        [HttpGet]
        [Authorize]
        public IActionResult Take(int id)//get user tests
        {
            Dictionary<string, List<string>> q = new Dictionary<string, List<string>>();
            if (id == 1)
            {
                q.Add("Question", new List<string> { "a", "b", "c" });
                q.Add("Question1", new List<string> { "a", "b", "c" });
                q.Add("Question2", new List<string> { "a", "b", "c" });
                q.Add("Question3", new List<string> { "a", "b", "c" });
                q.Add("Question4", new List<string> { "a", "b", "c" });
            }
            ViewBag.Questions = q;
            ViewBag.TestId = id;
            return View();
        }

        [HttpPost]
        [Authorize]
        public IActionResult Submit(int id)//get user tests
        {
            int b = id;
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
