using System;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
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
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Create(LoanDb loan)
    {
        if (ModelState.IsValid)
        {
            _context.Add(loan);
            await _context.SaveChangesAsync();
            GeneratePaymentSchedule(loan);
            return RedirectToAction(nameof(Index));
        }
        return View(loan);
    }

    private void GeneratePaymentSchedule(LoanDb loan)
    {
        var paymentSchedules = new List<PaymentsTb>();
        var dailyPayment = loan.Amount / 10;
        var startDate = loan.DateCreated;

        for (int i = 0; i < 10; i++)
        {
            paymentSchedules.Add(new PaymentsTb
            {
                LoanId = loan.Id,
                ClientId = 1, // Assuming a fixed clientId for simplicity
                Collectable = dailyPayment,
                Date = startDate.AddDays(i),
                Status = "Pending"
            });
        }

        _context.PaymentsTbs.AddRange(paymentSchedules);
        _context.SaveChanges();
    }

        // [HttpGet]
        // public IActionResult Create()
        // {
        //     var loan = new LoanDb(); // Create an instance of LoanDb
        //     return View(loan);   
        // }

        // [HttpPost]
        // public IActionResult Create(LoanDb createLoan)
        // {
        //       if (!ModelState.IsValid)
        //         return View(createLoan);

        //     _context.LoanDbs.Add(createLoan);
        //     _context.SaveChanges();


        //     return RedirectToAction("Index");
        // }

        [HttpGet]
        public IActionResult Update(int id)
        {
            var loan = _context.LoanDbs.FirstOrDefault(q => q.Id == id);
            if (loan == null)
            {
                return NotFound();
            }
            return View(loan);
        }

        [HttpPost]
        public IActionResult Update(LoanDb loan)
        {
            if (!ModelState.IsValid)
            {
                return View(loan);
            }

            _context.LoanDbs.Update(loan);
            _context.SaveChanges();

            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            var loan = _context.LoanDbs.FirstOrDefault(q => q.Id == id);
            if (loan == null)
            {
                return NotFound();
            }

            _context.LoanDbs.Remove(loan);
            _context.SaveChanges();

            return RedirectToAction("Index");
        }
    }

    internal class LoadDb
    {
        public LoadDb()
        {
        }
    }
}
