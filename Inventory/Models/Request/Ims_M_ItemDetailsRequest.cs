// ReSharper disable All
namespace Inventory.Models.Request;

public class Ims_M_ItemDetailsRequest
{
    public long HiddenfildID          { get; set; }
    public long? ItemID               { get; set; }
    public string? Make               { get; set; }
    public string? Model              { get; set; }
    public string? Serial             { get; set; }
    public DateTime? PurchaseDate     { get; set; }
    public DateTime? InstallationDate { get; set; }
    public long CompanyID             { get; set; }
    public string? WarrantyTerm       { get; set; }
    public string? WarrantyDetail     { get; set; }
    public string? LogBookSerial      { get; set; }
    public long CreatedUID            { get; set; }

}