using System;
using System.Collections.Generic;

namespace Inventory.Models.Entity;

public partial class Menu
{
    public long MenuId { get; set; }

    public string MenuName { get; set; } = null!;

    public long? ParentMenuId { get; set; }

    public string? MenuUrl { get; set; }

    public bool? Inactive { get; set; }

    public long? CompanyId { get; set; }

    public long? CreatedUid { get; set; }

    public DateTime? CreateDate { get; set; }
}
