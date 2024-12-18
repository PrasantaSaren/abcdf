using System;
using System.Collections.Generic;

namespace Inventory.Models.Entity;

public partial class VwBank
{
    public long BankId { get; set; }

    public string? BankName { get; set; }

    public string? Address { get; set; }

    public string? IfscCode { get; set; }
}
