using System;
using System.ComponentModel.DataAnnotations;

namespace PrelimCoop.Entities
{
    public partial class LoanDb
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "ClientId is required")]
        public required string ClientId { get; set; }

        [Required(ErrorMessage = "Status is required")]
        public required string Status { get; set; }

        public decimal Amount { get; set; }

        public int NoOfPayment { get; set; }
        
        public decimal Interest { get; set; }

        public decimal Deduction { get; set; }

        [Required(ErrorMessage = "Type is required")]
        public string Type { get; set; }

        public DateTime DateCreated { get; set; } = DateTime.Now;

        public decimal RecievableAmount { get; set; }

        public decimal PayableAmount { get; set; }

        public DateTime DueDate { get; set; }
    }
}
