// ReSharper disable IdentifierTypo
namespace Inventory.Models.Response.ItemMaster;

public class Ims_M_Item
{
    public Int64 ItemGroupID { get; set; }
    public string? ItemGroupName { get; set; }
    public Int64 ItemSubGroupID { get; set; }
    public Int64 UnitID { get; set; }
    public Int64 LocationID { get; set; }
    public Int64 AreaID { get; set; }
    public Int64 UOMID { get; set; }
    public Int64 SOH { get; set; }
    public Int64 StoreUOMID { get; set; }
    public string? ItemType { get; set; }
    public string? ROL { get; set; }
    public Int64 CompanyID { get; set; }
    public Int64 CreatedUID { get; set; }
    public string? RQTY { get; set; }
    public string? AssetTypeID { get; set; }
    public string? Exprement { get; set; }
    public string? ItemName { get; set; }
    public string? ItemDescHTML { get; set; }
    public decimal VAT { get; set; }
    public decimal Rate { get; set; }
    public Int64 ItemID { get; set; }
    public string? Make { get; set; }
    public string? Model { get; set; }
    public string? Serial { get; set; }
    public DateTime PurchaseDate { get; set; }
    public DateTime InstallationDate { get; set; }
    public string? WarrantyTerm { get; set; }
    public string? WarrantyDetail { get; set; }
    public string? LogBookSerial { get; set; }

    public Int64 AmcProviderID { get; set; }
    public decimal AmcValue { get; set; }

    public string? AmcType { get; set; }

    public string? Status { get; set; }

    public DateTime AmcStartDate { get; set; }
    public DateTime AmcRenewDate { get; set; }

    public Int64 SupplierID { get; set; }

    public string? SupplierContactNo { get; set; }
    public Int64 itemdetilsID { get; set; }
    public Int64 HiddenfildID { get; set; }
    public string? ItemSubGroupName { get; set; }
    public string? setsubgroupname { get; set; }
    public string? setgroupname { get; set; }
}
