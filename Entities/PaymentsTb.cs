using System;
using System.Collections.Generic;

namespace PrelimCoop.Entities;

     public partial class PaymentsTb
    {
        public int Id { get; set; }
        public int LoanId { get; set; }
        public int ClientId { get; set; }
        public decimal Collectable { get; set; }
        public DateTime Date { get; set; }
        public string Status { get; set; } = null!;

        public virtual LoanDb loan { get; set; } = null!;
    }
