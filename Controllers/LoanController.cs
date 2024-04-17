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
            var loan = new LoanDb(); 
            return View(loan);
        }

        [HttpPost]
        public IActionResult Create(LoanDb CreateLoan)
        {

            if (!ModelState.IsValid)
                return View(CreateLoan);

            _context.LoanDbs.Add(CreateLoan);

            _context.SaveChanges();

            return RedirectToAction("Index");
            
        }


       
        [HttpGet]
        public IActionResult Update(int Id)
        {
            
            var client = _context.LoanDbs.Where(q => q.Id == Id).FirstOrDefault();
            return View(client);
        }
        [HttpPost]
        public IActionResult Update(LoanDb b)
        {

            if (!ModelState.IsValid)
                return View(b);

            _context.LoanDbs.Update(b);
            _context.SaveChanges();

            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            var client = _context.ClientsInfoTbs.Where(q => q.Id == id).FirstOrDefault();
            _context.ClientsInfoTbs.Remove(client);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }

}
