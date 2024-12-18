using System;
using System.Collections.Generic;

namespace Inventory.Models.Entity;

public partial class Bank
{
    public long BankId { get; set; }

    public string BankName { get; set; } = null!;

    public string? BaranchName { get; set; }

    public string? Address { get; set; }

    public string? IfscCode { get; set; }
}
