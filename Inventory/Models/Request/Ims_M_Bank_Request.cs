namespace Inventory.Models.Request;
public class Ims_M_Bank_Request
{
    public long BankId             { get; set; }
    public string? BankName        { get; set; }
    public string? BranchName      { get; set; } 
    public string? Address         { get; set; }
    public string? IFSCCode        { get; set; }
}
