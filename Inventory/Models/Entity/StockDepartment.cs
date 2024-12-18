using System;
using System.Collections.Generic;

namespace Inventory.Models.Entity;

public partial class StockDepartment
{
    public long StockDepartmentId { get; set; }

    public int? UnitId { get; set; }

    public string? StockDepartmentName { get; set; }

    public string? SdDescription { get; set; }

    public int? CompanyId { get; set; }

    public long? CreatedUid { get; set; }

    public DateTime? CreateDate { get; set; }

    public bool? IsActive { get; set; }
}
