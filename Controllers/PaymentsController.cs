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
    }
}
