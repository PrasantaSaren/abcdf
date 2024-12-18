using System;
using System.Collections.Generic;

namespace Inventory.Models.Entity;

public partial class UserWorkApproval
{
    public long Uaid { get; set; }

    public long? UserId { get; set; }

    public long? UserWorkFlowId { get; set; }

    public long? CompanyId { get; set; }

    public long? CreatedUid { get; set; }

    public DateTime CreateDate { get; set; }
}
