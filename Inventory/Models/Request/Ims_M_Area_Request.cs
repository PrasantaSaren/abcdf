using System;

namespace Inventory.Models.Request;

public class Ims_M_Area_Request
{
    public long? AreaID { get; set; }
    public string? AreaName { get; set; }
    public string? AreaCode { get; set; }
    public long? UnitID { get; set; }
    public long? CompanyID { get; set; }
    public long? CreatedUID { get; set; }
}
