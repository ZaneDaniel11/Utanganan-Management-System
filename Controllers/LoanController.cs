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
            var loan = _context.LoanDbs.ToList();
            return View(loan);
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
        loan.DueDate = DateOnly.FromDateTime(loan.DueDate.ToDateTime(TimeOnly.MinValue)); // Ensure DueDate is properly converted if needed
        _context.LoanDbs.Add(loan);
        _context.SaveChanges();

        // Generate payment schedule
        GeneratePaymentSchedule(loan);

        return RedirectToAction(nameof(Index));
    }
    return View(loan);
}


      private void GeneratePaymentSchedule(LoanDb loan)
{
    var paymentSchedules = new List<PaymentsTb>();
    var startDate = loan.DateCreated.ToDateTime(TimeOnly.MinValue); // Convert DateOnly to DateTime
    var clientid = loan.ClientId;

    int totalPayments = loan.NoOfPayment; // Assuming 10 payments for simplicity
    int PayableAmount = loan.Amount / totalPayments;
    
    TimeSpan interval;
    switch (loan.Type)
    {
        case "Weekly":
            interval = TimeSpan.FromDays(7);
            break;
        case "Monthly":
            interval = TimeSpan.FromDays(30); // Simplified month duration
            break;
        case "Daily":
        default:
            interval = TimeSpan.FromDays(1);
            break;
    }

    for (int i = 0; i < totalPayments; i++)
    {
        paymentSchedules.Add(new PaymentsTb
        {
            LoanId = loan.Id,
            ClientId = clientid,
            Collectable = PayableAmount,
            Date = DateOnly.FromDateTime(startDate.AddDays(i * interval.TotalDays)), // Convert DateTime to DateOnly
            Status = "Pending"
        });
    }

    _context.PaymentsTbs.AddRange(paymentSchedules);
    _context.SaveChanges();
}

    [HttpGet]
    public IActionResult ViewPayments(int clientId)
    {
        var payments = _context.PaymentsTbs.Where(p => p.ClientId == clientId).ToList();
        if (payments == null || payments.Count == 0)
        {
            return NotFound();
        }
        return View(payments);
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


    internal class LoadDb
    {
        public LoadDb()
        {
        }
    }
}
