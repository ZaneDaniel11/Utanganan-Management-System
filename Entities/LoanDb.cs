using System;
using System.Collections.Generic;

namespace PrelimCoop.Entities;

public partial class LoanDb
{
     public int Id { get; set; }
        public string ClientId { get; set; } = null!;
        public string Type { get; set; } = null!;
        public decimal Amount { get; set; } // Updated from int to decimal
        public decimal Interest { get; set; }
        public int Term { get; set; } // New property for loan term
        public DateTime StartDate { get; set; } // New property for loan start date
        public decimal InterestRate { get; set; } // New property for interest rate
    
        public string NoOfPayment { get; set; }  = null!;
        public decimal Deduction { get; set; }
        public string Status { get; set; }  = null!;
        public DateTime DateCreated { get; set; } // Changed from DateOnly to DateTime
        public decimal ReceivableAmount { get; set; } // Corrected property name
        public decimal PayableAmount { get; set; } // Corrected property name
        public DateTime DueDate { get; set; } // Changed from DateOnly to DateTime

        public virtual ICollection<PaymentsTb> Payments { get; set; } = null!; // Navigation property for payments
    
    // public int Id { get; set; }

    // public string ClientId { get; set; } = null!;

    // public string Type { get; set; } = null!;

    // public int Amount { get; set; }

    // public decimal Interest { get; set; }

    // public string NoOfPayment { get; set; } = null!;

    // public decimal Deduction { get; set; }

    // public string Status { get; set; } = null!;

    // public DateOnly DateCreated { get; set; }

    // public decimal RecievableAmount { get; set; }

    // public decimal PayableAmount { get; set; }

    // public DateOnly DueDate { get; set; }
}
