using System;
using System.Collections.Generic;

namespace PrelimCoop.Entities;

public partial class LoanDb
{
    public int Id { get; set; }

    public string Client { get; set; } = null!;

    public string Type { get; set; } = null!;

    public int Amount { get; set; }

    public string Interest { get; set; } = null!;

    public string NoOfPayment { get; set; } = null!;

    public int Deduction { get; set; }

    public string Status { get; set; } = null!;

    public DateOnly DateCreated { get; set; }

    public int RecievableAmount { get; set; }

    public int PayableAmount { get; set; }

    public DateOnly DueDate { get; set; }
}
