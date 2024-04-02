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
           var user = _context.Usertypedbs.ToList();
            return View(user);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        
        [HttpPost]
        public IActionResult Create(Usertypedb Insert_User)
        {

            if(!ModelState.IsValid)
                return View(Insert_User);
                
            _context.Usertypedbs.Add(Insert_User);
            _context.SaveChanges();
            
            return RedirectToAction("Index");

        }

       [HttpGet]
       public IActionResult Update(int Id)
       {
             var user = _context.Usertypedbs.Where( q => q.Id == Id).FirstOrDefault();
            return View(user);
       }

        [HttpPost]
        public IActionResult Update(Usertypedb b) {

            if(!ModelState.IsValid)
                return View(b);

            _context.Usertypedbs.Update(b);
            _context.SaveChanges();

            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Delete(int id) {
            var user = _context.Usertypedbs.Where( q => q.Id == id).FirstOrDefault();
            _context.Usertypedbs.Remove(user);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}