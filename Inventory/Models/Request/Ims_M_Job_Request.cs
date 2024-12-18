using System;

namespace Inventory.Models.Request;

public class Ims_M_Job_Request
{
    public long JobId { get; set; }
    public string? JobName { get; set; }
    public long JobTypeId { get; set; }
    public string? JobNameDesc { get; set; }
    public long CompanyId { get; set; }
    public long CreatedUID { get; set; }
}
