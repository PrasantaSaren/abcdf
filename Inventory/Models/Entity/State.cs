using System;
using System.Collections.Generic;

namespace Inventory.Models.Entity;

public partial class State
{
    public int StateId { get; set; }

    public string StateName { get; set; } = null!;

    public long CompanyId { get; set; }

    public long CreatedUid { get; set; }

    public DateTime CreateDate { get; set; }
}
