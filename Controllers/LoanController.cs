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

    public class LoanController : Controller
    {
       private readonly NotadocoopContext _context;

       public LoanController(NotadocoopContext context)
       {
            _context = context;
       }

        public IActionResult Index()
        {
            var loan = _context.LoanDbs.ToList();
            return View(loan);
        }

         [HttpGet]
        public IActionResult Create()
        {
            var loan = new LoanDb(); // Create a new instance of ClientsInfoTb
            return View(loan);
        }


       
    }
}