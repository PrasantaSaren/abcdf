using System;

namespace Inventory.Models.Request;

public class Ims_M_Location_Request
{
    public long LocationID { get; set; }
    public long AreaID { get; set; }
    public string? LocationName { get; set; }
    public string? LocationCode { get; set; }
    public long? UnitID { get; set; }
    public long CompanyID { get; set; }
    public long CreatedUID { get; set; }
}
