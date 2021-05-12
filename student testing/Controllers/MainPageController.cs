using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace student_testing.Controllers
{
    public class MainPageController : Controller
    {

        [Authorize]
        [HttpGet]
        public IActionResult Main()
        {
            return this.View();
        }
    }
}
