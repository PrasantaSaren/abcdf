namespace Inventory.Models.Request;
public class Ims_M_ItemSubGroup_Request
{
    public long ItemGroupId         { get; set; }
    public long? ItemSubGroupId     { get; set; }
    public string? ItemSubGroupName { get; set; }
    public string? SetSubGroupName  { get; set; }
    public long? CompanyId          { get; set; }
    public long? CreatedUId         { get; set; }
}
