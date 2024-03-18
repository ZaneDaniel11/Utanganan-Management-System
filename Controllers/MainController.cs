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
   
    public class MainController : Controller
    {
        
        private readonly NotadocoopContext _context;
        public MainController(NotadocoopContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var client = _context.ClientsInfoTbs.ToList();
            return View(client);
        }

        
    }
}