
namespace Inventory.Models.Requisition;
public class Ims_Requisition_AreaRequest
{
    public long AreaId        { get; set; }
    public string? AreaName   { get; set; }
    public long? CompanyId    { get; set; }
    public string? EntryPoint { get; set; }
    public long? UnitId       { get; set; }
    public long? CreatedUid   { get; set; }
}
