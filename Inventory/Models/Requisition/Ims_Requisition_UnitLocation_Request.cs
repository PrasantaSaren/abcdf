
namespace Inventory.Models.Requisition;
public class Ims_Requisition_UnitLocation_Request
{
    public long LocationId      { get; set; }
    public string? LocationName { get; set; }
    public long? AreaId         { get; set; }
    public long? UnitId         { get; set; }
    public long? CompanyId      { get; set; }
    public long? CreatedUid     { get; set; }
    public string? EntryPoint   { get; set; }
}
