namespace Inventory.Models.Request;

public class Ims_M_ItemMaintain_Request
{
    public long? ItemDetailID { get; set; }
    public long? ItemID { get; set; }
    public long? AmcProviderID { get; set; }
    public char? AmcType { get; set; }
    public long? AmcValue { get; set; }
    public DateTime? AmcStartDate { get; set; }
    public DateTime? AmcRenewDate { get; set; }
    public char? Status { get; set; }
    public long? SupplierID { get; set; }
    public string? SupplierContactNo { get; set; }
}
