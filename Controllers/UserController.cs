using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using PrelimCoop.Entities;

namespace PrelimCoop.Controllers
{

    public class UserController : Controller
    {
        private readonly NotadocoopContext _context;

        public UserController(NotadocoopContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
           var user = _context.UserTypeDbs.ToList();
            return View(user);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
       
    }
}