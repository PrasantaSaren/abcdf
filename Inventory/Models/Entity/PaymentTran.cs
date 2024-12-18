using System;
using System.Collections.Generic;

namespace Inventory.Models.Entity;

public partial class PaymentTran
{
    public long PayTransId { get; set; }

    public long PaymentId { get; set; }

    public long? PobillId { get; set; }

    public decimal? BillAmount { get; set; }

    public decimal? PayAmount { get; set; }

    public long CompanyId { get; set; }
}
