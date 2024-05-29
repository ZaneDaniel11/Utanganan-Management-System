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
            var loan = _context.LoanDbs.FirstOrDefault(q => q.Id == id);
            if (loan == null)
            {
                return NotFound();
            }
            return View(loan);
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
            var clientId = loan.ClientId;

            double interestRate;
            TimeSpan interval;
            switch (loan.Type)
            {
                case "Weekly":
                    interestRate = 0.03; // 3% weekly
                    interval = TimeSpan.FromDays(7);
                    break;
                case "Monthly":
                    interestRate = 0.05; // 5% monthly
                    interval = TimeSpan.FromDays(30); // Simplified month duration
                    break;
                case "Daily":
                default:
                    interestRate = 0.01; // 1% daily
                    interval = TimeSpan.FromDays(1);
                    break;
            }

            double totalAmountWithInterest = loan.Amount * Math.Pow(1 + interestRate, loan.NoOfPayment);
            double paymentAmountPerPeriod = Math.Round(totalAmountWithInterest / loan.NoOfPayment, 2);
            double totalScheduledPayments = paymentAmountPerPeriod * loan.NoOfPayment;
            double difference = totalScheduledPayments - totalAmountWithInterest;

            if (difference > 0)
            {
                paymentAmountPerPeriod -= Math.Round(difference / loan.NoOfPayment, 2);
            }

            for (int i = 0; i < loan.NoOfPayment; i++)
            {
                double collectable = (i == loan.NoOfPayment - 1) ? totalAmountWithInterest - (paymentAmountPerPeriod * (loan.NoOfPayment - 1)) : paymentAmountPerPeriod;
                paymentSchedules.Add(new PaymentsTb
                {
                    LoanId = loan.Id,
                    ClientId = clientId,
                    Collectable = (decimal)collectable,
                    Date = DateOnly.FromDateTime(startDate.AddDays(i * interval.TotalDays)),
                    Status = "Pending",
                    Deduction = (decimal)(collectable - loan.Amount / loan.NoOfPayment) // Assuming Deduction is the interest part
                });
            }

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