using System;
using System.Collections.Generic;

namespace Inventory.Models.Entity;

public partial class Business
{
    public Guid? BusinessId { get; set; }

    public Guid? UserId { get; set; }

    public int? BusinessCatagoryId { get; set; }

    public string? BusinessName { get; set; }

    public Guid? CreatedBy { get; set; }

    public Guid? UpdatedBy { get; set; }

    public DateTime? CreatedDate { get; set; }

    public DateTime? UpdatedDate { get; set; }

    public int? StatusId { get; set; }
}
