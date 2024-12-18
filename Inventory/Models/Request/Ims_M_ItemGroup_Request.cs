namespace Inventory.Models.Request;
public class Ims_M_ItemGroup_Request
{
    public long ItemGroupId      { get; set; }
    public string? ItemGroupName { get; set; }
    public string? SetGroupName  { get; set; }
    public long?  CompanyId      { get; set; }
    public long? CreatedUId      { get; set; }
}
