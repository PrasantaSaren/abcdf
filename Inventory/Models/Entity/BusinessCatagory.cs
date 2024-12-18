using System;
using System.Collections.Generic;

namespace Inventory.Models.Entity;

public partial class BusinessCatagory
{
    public int BusinessCatId { get; set; }

    public string? CatagoryName { get; set; }

    public Guid? CreatedBy { get; set; }

    public Guid? UpdatedBy { get; set; }

    public DateTime? CreatedDate { get; set; }

    public DateTime? UpdatedDate { get; set; }

    public int StatusId { get; set; }
}
