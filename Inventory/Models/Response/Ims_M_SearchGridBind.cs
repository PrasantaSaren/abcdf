using System;

namespace Inventory.Models.Response;

public class Ims_M_SearchGridBind
{
    public long ItemGroupID { get; set; }
    public long ItemSubGroupID { get; set; }
    public string? ItemName { get; set; }
    public long CompanyID { get; set; }
}
