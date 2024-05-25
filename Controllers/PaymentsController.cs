using System.Linq;
using Microsoft.AspNetCore.Mvc;
using PrelimCoop.Entities;

namespace PrelimCoop.Controllers
{
    public class PaymentsController : Controller
    {
        private readonly NotadocoopContext _context;

        public PaymentsController(NotadocoopContext context)
        {
            _context = context;
        }

        [HttpGet]
        [Route("payments/viewpayments/{clientId}")]
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
    public IActionResult Pay(int id)
    {
        var payment = _context.PaymentsTbs.FirstOrDefault(p => p.Id == id);
        if (payment == null || payment.Status != "Pending")
        {
            return NotFound();
        }

        return View(payment);
    }

    [HttpPost]
        public IActionResult ProcessPayment(int paymentId, decimal amount)
        {
            var payment = _context.PaymentsTbs.FirstOrDefault(p => p.Id == paymentId);
            if (payment == null || payment.Status != "Pending")
            {
                return NotFound();
            }

            // Update payment status
            payment.Status = "Paid";

            // Update loan's PayableAmount
            var loan = _context.LoanDbs.FirstOrDefault(l => l.Id == payment.LoanId);
            if (loan != null)
            {
                loan.PayableAmount -= amount;
            }

            _context.SaveChanges();

            return RedirectToAction(nameof(Index)); // Redirect to payments list or another appropriate page
        }
    }

}
