namespace Inventory.Models.Response;

public class Ims_M_UOM
{
    public long?      UOMID      { get; set; }
    public char?      UOMtype    { get; set; }
    public string?    UOMname    { get; set; }
    public long?      CompanyID  { get; set; }
    public long?      CreatedUID { get; set; }
}