using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using student_testing.Models;
using student_testing.Models.Group;
using System.Security.Claims;
using BLL.DTO;
using BLL.Interfaces;
using DAL.Domain;
using DAL.Interfaces;
using Serilog;

namespace student_testing.Controllers
{
    public class GroupController : Controller
    {
        private IGroupService groupService;
        private IUnitOfWork unitOfWork;

        public GroupController(IGroupService service, IUnitOfWork uof)
        {
            this.groupService = service;
            this.unitOfWork = uof;
        }

        [HttpGet]
        [Authorize]
        public IActionResult Index() // returns all user groups
        {
            return View(new List<GroupViewModel>());
        }

        [HttpPost]
        [Authorize(Roles = "Student")]
        public async Task<IActionResult> Create(CreateGroupViewModel model) //create new group
        {
            if (this.ModelState.IsValid)
            {
                User user = await unitOfWork.UserManager.FindByEmailAsync(User.FindFirstValue(ClaimTypes.Email));
                GroupDto groupDto = new GroupDto
                {
                    DateCreation = DateTime.Now,
                    Name = model.Name,
                    Description = model.Description,
                    CreatorId = user.Id,
                };
                await groupService.CreateGroup(groupDto);
                Log.Logger.Verbose("Create group: {@groupDto}  ", groupDto);
                return View();
            }
            return View();
        }

        [HttpGet]
        [Authorize(Roles = "Student")]
        public IActionResult Create() //create new group
        {
            return View();
        }

        [HttpPut]
        [Authorize(Roles = "Teacher")]
        public IActionResult Update(UpdateGroupViewModel model) //update existed group
        {
            return View();
        }

        [HttpGet]
        [Authorize(Roles = "Teacher")]
        public IActionResult Update() //update existed group
        {
            return View();
        }

        [HttpPost]
        [Authorize(Roles = "Teacher")]
        public IActionResult AddStudent(AddStudentToGroupViewModel model) //add student to group
        {
            return View();
        }

        [HttpGet]
        [Authorize(Roles = "Teacher")]
        public IActionResult AddStudent() //add student to group
        {
            return View();
        }

        [HttpDelete]
        [Authorize(Roles = "Teacher")]
        public IActionResult Delete(int id) //delete student from group
        {
            return View();
        }

        [HttpGet]
        [Authorize(Roles = "Teacher")]
        public IActionResult Delete() //delete student from group
        {
            return View();
        }
    }
}
