using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using student_testing.Models;
using student_testing.Models.Group;

namespace student_testing.Controllers
{
    public class GroupController : Controller
    {
        [HttpGet]
        [Authorize]
        public IActionResult Index() // returns all user groups
        {
            return View(new List<GroupViewModel>());
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public IActionResult Create(CreateGroupViewModel model) //create new group
        {
            return View();
        }

        [HttpGet]
        [Authorize(Roles = "Admin")]
        public IActionResult Create() //create new group
        {
            return View();
        }

        [HttpPut]
        [Authorize(Roles = "Admin")]
        public IActionResult Update(UpdateGroupViewModel model) //update existed group
        {
            return View();
        }

        [HttpGet]
        [Authorize(Roles = "Admin")]
        public IActionResult Update() //update existed group
        {
            return View();
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public IActionResult AddStudent(AddStudentToGroupViewModel model) //add student to group
        {
            return View();
        }

        [HttpGet]
        [Authorize(Roles = "Admin")]
        public IActionResult AddStudent() //add student to group
        {
            return View();
        }

        [HttpDelete]
        [Authorize(Roles = "Admin")]
        public IActionResult Delete(int id) //delete student from group
        {
            return View();
        }

        [HttpGet]
        [Authorize(Roles = "Admin")]
        public IActionResult Delete() //delete student from group
        {
            return View();
        }
    }
}
