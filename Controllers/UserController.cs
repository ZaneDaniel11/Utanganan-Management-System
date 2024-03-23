using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace PrelimCoop.Controllers
{

    public class UserController : Controller
    {
        private readonly ILogger<UserController> _logger;

   
        public IActionResult Index()
        {
            return View();
        }

     
    }
}