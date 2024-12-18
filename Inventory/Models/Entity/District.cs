using System;
using System.Collections.Generic;

namespace Inventory.Models.Entity;

public partial class District
{
    public long DistrictId { get; set; }

    public long StateId { get; set; }

    public string DistrictName { get; set; } = null!;

    public long CompanyId { get; set; }

    public long CreatedUid { get; set; }

    public DateTime CreateDate { get; set; }
}
