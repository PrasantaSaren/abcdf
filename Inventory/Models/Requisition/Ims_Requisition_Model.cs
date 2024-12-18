
namespace Inventory.Models.Requisition;
public class Ims_Requisition_Model
{
    public Int64? ReqID { get; set; }
    public string? RefReqNo { get; set; }
    public string? ReqANMType { get; set; }
    public string? ReqNo { get; set; }
    public DateTime? ReqDate { get; set; }
    public string? ReqType { get; set; }
    public string? Type { get; set; }
    public string? IsRateContract { get; set; }
    public string? WorkStatus { get; set; }
    public Int64? UnitID { get; set; }
    public Int64? LocationID { get; set; }
    public Int64? AreaID { get; set; }
    public string? Description { get; set; }
    public string? Remarks { get; set; }
    public string? Experiment { get; set; }
    public string? RejectRemarks { get; set; }
    public string? Justification { get; set; }
    public string? ContactNo { get; set; }
    public string? InitBy { get; set; }
    public Int64? CompanyID { get; set; }
    public Int64? CreatedUID { get; set; }
    public Int64? ApprovedBy { get; set; }
    public string? ApprovalStatus { get; set; }
    public string? FrdStatus { get; set; }
    public int? ApprovedLevel { get; set; }
    public string? SuppDocName1 { get; set; }
    public byte[] SuppDoc1 { get; set; }
    public string? SuppDocName2 { get; set; }
    public byte[] SuppDoc2 { get; set; }
    public string? SuppDocName3 { get; set; }
    public byte[] SuppDoc3 { get; set; }
    public DateTime? ApproveDate { get; set; }
    public List<RequisitionItemJob> ReqItemJob { get; set; } = new List<RequisitionItemJob>();
}

public class RequisitionItemJob
{
    
    public long slno { get; set; }
    public long ItemID { get; set; }
    public string ItemName { get; set; }
    public string Description { get; set; }
    public string uomn { get; set; }
    public long uom { get; set; }
    public string assetn { get; set; }
    public long asset { get; set; }
    public decimal Qty { get; set; }
    public decimal Rate { get; set; }
    public decimal GrossAmount { get; set; }
}


