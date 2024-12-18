using Inventory.Models.Requisition;
using Inventory.Repository.IService;
using Inventory.Repository.Service;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;

namespace Inventory.Controllers
{
    [Route(V)]
    [ApiController]
    public class RequisitionController : ControllerBase
    {
        private const string V = "api/[controller]";
        private readonly IRequisitionRepository? _repo;
        private readonly IConfiguration _config;
        public RequisitionController(IRequisitionRepository repo, IConfiguration config)
        {
            _repo = repo;
            _config = config;
        }

        
        [HttpGet]
        [Route("GetRequisitionUnitDetails")]
        public IActionResult GetRequisitionUnitDetails(string type, long userID)
        {
            var result = _repo!.GetRequisitionUnitDetails(type, userID);
            if ((result.UnitDetailsList!.Count == 0))
            {
                return NotFound("No data found for the provided UnitID and CompanyID.");
            }
            return Ok(result);
        }

        [HttpGet]
        [Route("GetRequisitionUnitAreaDetails")]
        public IActionResult GetRequisitionUnitAreaDetails(long unitId, long companyId)
        {
            var result = _repo!.GetRequisitionUnitAreaDetails(unitId, companyId);
            if ((result.Areas!.Count == 0) && (result.UnitInfo == null))
            {
                return NotFound("No data found for the provided UnitID and CompanyID.");
            }
            return Ok(result);
        }


        [HttpGet]
        [Route("GetRequisitionUnitAreaLocationDetails")]
        public async Task<IActionResult> GetRequisitionUnitAreaLocationDetails(long unitId = 0, long areaId = 0)
        {
            var result = await _repo!.GetRequisitionUnitAreaLocationDetails(unitId, areaId);
            if (result.Tables[0].Rows.Count <= 0)
            {
                return Ok(new { message = "No records found.", data = new List<Dictionary<string, object>>() });
            }
            var output = GeneralUtilityService.ConvertDataTableToDictionaryList(result.Tables[0]);
            return Ok(output);
        }

        [HttpPost("InsertRequisitionDetails")]
        public async Task<IActionResult> InsertRequisitionDetails([FromBody] Ims_Requisition_Model _bodyParams)
        {
            try
            {
                var result = await _repo!.InsertRequisitionDetails(_bodyParams);
                if (result > 0)
                {
                    return Ok(new { Id = result, Message = "Requisition Details saved successfully." });
                }
                else
                {
                    return StatusCode(500, "An error occurred while saving the Requisition Details.");
                }
            }
            catch (SqlException sqlEx)
            {
                return StatusCode(500, new { message = "A database error occurred.", error = sqlEx.Message });
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpPost]
        [Route("GetRequisitionListData")]
        public async Task<IActionResult> GetRequisitionSearchList(Ims_Requisition_ReqSearchList_Reponse _params)
        {
            try
            {
                var result = await _repo!.GetRequisitionSearchList(_params);
                if (result.Tables[0].Rows.Count <= 0)
                {
                    return Ok(new { message = "No records found.", data = new List<Dictionary<string, object>>() });
                }
                var output = GeneralUtilityService.ConvertDataTableToDictionaryList(result.Tables[0]);
                return Ok(output);
            }
            catch (SqlException sqlEx)
            {
                return StatusCode(500, new { message = "A database error occurred.", error = sqlEx.Message });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "An unexpected error occurred.", error = ex.Message });
            }
        }










        [HttpPost("InsertOrUpdateArea")]
        public IActionResult InsertOrUpdateArea([FromBody] Ims_Requisition_AreaRequest _bodyParams)
        {
            try
            {
                var result = _repo!.InsertUpdateArea(_bodyParams);
                if (result == -7)
                {
                    return BadRequest("An area with the same name already exists.");
                }
                else if (result > 0)
                {
                    return Ok(new { AreaID = result, Message = "Area saved successfully." });
                }
                else
                {
                    return StatusCode(500, "An error occurred while saving the area.");
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }
        
        [HttpGet]
        [Route("GetRemarks")]
        public async Task<IActionResult> GetRemarks(long reqId = 0)
        {
            var result = await _repo!.GetRemarks(reqId);
            if (result.Tables[0].Rows.Count <= 0)
            {
                return Ok(new { message = "No records found.", data = new List<Dictionary<string, object>>() });
            }
            var output = GeneralUtilityService.ConvertDataTableToDictionaryList(result.Tables[0]);
            return Ok(output);
        }
        
        
        [HttpPost("InsertOrUpdateUnitLocation")]
        public async Task<IActionResult> InsertOrUpdateUnitLocation([FromBody] Ims_Requisition_UnitLocation_Request _bodyParams)
        {
            try
            {
                var result = await _repo!.InsertOrUpdateUnitLOcation(_bodyParams);
                if (result == -7)
                {
                    return BadRequest("A location with the same name already exists.");
                }
                else if (result > 0)
                {
                    return Ok(new { LocationId = result, Message = "Unit location saved successfully." });
                }
                else
                {
                    return StatusCode(500, "An error occurred while saving the unit location.");
                }
            }
            catch (SqlException sqlEx)
            {
                return StatusCode(500, new { message = "A database error occurred.", error = sqlEx.Message });
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }
        #region  Requisition List
        [HttpGet("GetRequisitionAllItem")]
        public async Task<IActionResult> GetRequisitionAllItem(long reqId)
        {
            try
            {
                var result = await _repo!.GetRequisitionAllItem(reqId);
                if (result.Tables[0].Rows.Count <= 0)
                {
                    return Ok(new { message = "No records found.", data = new List<Dictionary<string, object>>() });
                }
                var output = GeneralUtilityService.ConvertDataTableToDictionaryList(result.Tables[0]);
                return Ok(output);
            }
            catch (SqlException sqlEx)
            {
                return StatusCode(500, new { message = "A database error occurred.", error = sqlEx.Message });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "An unexpected error occurred.", error = ex.Message });
            }
        }
        [HttpPost("InsertOrUpdateRequisitionApproval")]
        public async Task<IActionResult> InsertOrUpdateRequisitionApproval([FromBody] Ims_Requisition_ReqApproval _bodyParams)
        {
            try
            {
                var result = await _repo!.InsertOrUpdateRequisitionApproval(_bodyParams);
                if (result == -7)
                {
                    return BadRequest("A location with the same name already exists.");
                }
                else if (result > 0)
                {
                    return Ok(new { Id = result, Message = "Requisition Approval saved successfully." });
                }
                else
                {
                    return StatusCode(500, "An error occurred while saving the Requisition Approval.");
                }
            }
            catch (SqlException sqlEx)
            {
                return StatusCode(500, new { message = "A database error occurred.", error = sqlEx.Message });
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }
        #endregion

        

        [HttpPost("UpdateRequisitionDetails")]
        public async Task<IActionResult> UpdateRequisitionDetails([FromBody] Ims_Requisition_Model _bodyParams)
        {
            try
            {
                var result = await _repo!.UpdateRequisitionDetails(_bodyParams);
                if (result > 0)
                {
                    return Ok(new { Id = result, Message = "Requisition details updated successfully." });
                }
                else
                {
                    return StatusCode(500, "An error occurred while updating the Requisition Details.");
                }
            }
            catch (SqlException sqlEx)
            {
                return StatusCode(500, new { message = "A database error occurred.", error = sqlEx.Message });
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }
    }
}
