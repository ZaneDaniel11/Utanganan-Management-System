using System;
using System.Collections.Generic;

namespace PrelimCoop.Entities;

public partial class LoanDb
{
    public int Id { get; set; }

    public int ClientId { get; set; }

    public string Type { get; set; } = null!;

    public int Amount { get; set; }

    public decimal Interest { get; set; }

    public string NoOfPayment { get; set; } = null!;

    public decimal Deduction { get; set; }

    public string Status { get; set; } = null!;

    public DateOnly DateCreated { get; set; }

    public decimal RecievableAmount { get; set; }

    public decimal PayableAmount { get; set; }

    public DateOnly DueDate { get; set; }

    public int Term { get; set; }
}
