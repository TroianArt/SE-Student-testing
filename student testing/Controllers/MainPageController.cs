using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using student_testing.Models.MainPage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace student_testing.Controllers
{
    public class MainPageController : Controller
    {
        List<DAL.Domain.Group> l = new List<DAL.Domain.Group> ();

        [Authorize]
        [HttpGet]
        public IActionResult Main()
        {
            DAL.Domain.Group ng = new DAL.Domain.Group { CreatorId = "1", Name = "test", DateCreation =DateTime.Now, Description = "Loh"};
            l.Add(ng);
            MainModel mm = new MainModel { Classes = l};
            return this.View(mm);
        }
    }
}
