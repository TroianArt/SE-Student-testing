using DAL.Domain;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using student_testing.Models.Admin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BLL.Interfaces;
using DAL.Interfaces;

namespace student_testing.Controllers
{
   
    public class AdminController : Controller
    {
        private IUserService userService;
        private IUnitOfWork unitOfWork;
        public AdminController(IUserService service, IUnitOfWork uof)
        {
            this.userService = service;
            this.unitOfWork = uof;
        }

        Dictionary<string, string> d = new Dictionary<string, string> { { "test@gmail.com", "Student" }, { "teacher@gmail.com", "Teacher" } };
        [HttpGet]
        //[Authorize(Roles = "Admin")]
        public IActionResult Index()
        {
            AdminPageModel am = new AdminPageModel { Users = d };
            return View(am);
        }

        [HttpPost]
        //[Authorize(Roles = "Admin")]
        public async Task<IActionResult> Index(string email)
        {
            //User user = await unitOfWork.UserManager.FindByEmailAsync(email);
            //if (user.)
            return View();
        }
    }
}
