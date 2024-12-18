using System;
using System.Collections.Generic;

namespace Inventory.Models.Entity;

public partial class BillInstallAmt
{
    public long Id { get; set; }

    public long? PobillId { get; set; }

    public decimal? InstallmentAmt { get; set; }
}
