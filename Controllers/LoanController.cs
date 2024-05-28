using System;
using System.Linq;
using System.Collections.Generic;
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
            var loans = _context.LoanDbs.ToList();
            return View(loans);
        }

        [HttpGet]
        public IActionResult View(int id)
        {
            var loan = _context.PaymentsTbs.FirstOrDefault(q => q.Id == id);
            if (loan == null)
            {
                return NotFound();
            }
            return View(loan.Id);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(LoanDb loan)
        {
            if (ModelState.IsValid)
            {
                loan.DateCreated = DateOnly.FromDateTime(DateTime.Now);
                loan.DueDate = DateOnly.FromDateTime(loan.DueDate.ToDateTime(TimeOnly.MinValue)); 
                _context.LoanDbs.Add(loan);
                _context.SaveChanges();

                GeneratePaymentSchedule(loan);

                return RedirectToAction(nameof(Index));
            }
            return View(loan);
        }

        private void GeneratePaymentSchedule(LoanDb loan)
        {
            var paymentSchedules = new List<PaymentsTb>();
            var startDate = loan.DateCreated.ToDateTime(TimeOnly.MinValue); 
            var clientid = loan.ClientId;

            double interestRate;
            TimeSpan interval;
            switch (loan.Type)
            {
                case "Weekly":
                    interestRate = 0.03; 
                    interval = TimeSpan.FromDays(7);
                    break;
                case "Monthly":
                    interestRate = 0.05; 
                    interval = TimeSpan.FromDays(30); 
                    break;
                case "Daily":
                default:
                    interestRate = 0.01; 
                    interval = TimeSpan.FromDays(1);
                    break;
            }

            double totalInterest = loan.Amount * interestRate * loan.NoOfPayment;
            double totalAmountWithInterest = loan.Amount + totalInterest + loan.Deduction;
            double paymentAmountPerPeriod = totalAmountWithInterest / loan.NoOfPayment;

            for (int i = 0; i < loan.NoOfPayment; i++)
            {
                paymentSchedules.Add(new PaymentsTb
                {
                    LoanId = loan.Id,
                    ClientId = clientid,
                    Collectable = (decimal)paymentAmountPerPeriod,
                    Date = DateOnly.FromDateTime(startDate.AddDays(i * interval.TotalDays)), 
                    Status = "Pending",
                    Deduction = (decimal)loan.Deduction / loan.NoOfPayment 
                });
            }

            loan.PayableAmount = (decimal)totalAmountWithInterest; 
            _context.LoanDbs.Update(loan);
            _context.PaymentsTbs.AddRange(paymentSchedules);
            _context.SaveChanges();
        }

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
}
