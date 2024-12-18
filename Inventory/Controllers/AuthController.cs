using Common_Helper.CommonHelper;
using Inventory.AppCode;
using Inventory.Models.Request;
using Inventory.Models.Response;
using Inventory.Repository.IService;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Inventory.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(GlobalGenericRequest<>))]
    public class AuthController : ControllerBase
    {
        #region Declaration
        private readonly IAuthService _service;
        private readonly ITokenService _tokenService;
        private readonly ISessionHelper _sessionHelper;
        AuditLogHelper _auditLogHelper = new AuditLogHelper();
        AuditLog.BeLogLevel _errorlevel = AuditLog.BeLogLevel.Information;
        AuditLog.BeLogType _errortype = AuditLog.BeLogType.Success;
        string? METHODNAME = "";
        string? TableID = "";
        bool result = true;
        new GlobalGenericResponse<object> Response = new GlobalGenericResponse<object>();
        public AuthController(IAuthService service, ITokenService tokenService, ISessionHelper sessionHelper)
        {
            _service = service ?? throw new ArgumentNullException(nameof(service));
            _tokenService = tokenService ?? throw new ArgumentNullException(nameof(tokenService));
            _sessionHelper = sessionHelper ?? throw new ArgumentNullException(nameof(sessionHelper));
        }
        private void InitialCall()
        {
            _sessionHelper.GetSessionClaim();
            _auditLogHelper.ClientIpAddress = HttpContext.Connection.RemoteIpAddress?.ToString();
            _auditLogHelper.ClientEmail = _sessionHelper.Email;
        }
        #endregion
        

        [HttpPost]
        [Route("GetLogin")]
        public async Task<ActionResult> GetLogin(LoginRequest user)
        {
            if (user.UserName == "") return BadRequest("Please Enter User Name");
            METHODNAME = "GetLogin";
            TableID = user.UserName;
            Response.ErrorDescription = "Successful To Get Login Details";
            var tokenResponse = new TokenResponse();
            try
            {
                _auditLogHelper.ClientIpAddress = HttpContext.Connection.RemoteIpAddress?.ToString();
                _auditLogHelper.ClientEmail = user.UserName;
                var loginResponse = await _service.GetLoginDetails(user, _auditLogHelper);
                if (loginResponse != null)
                {
                    var UserId = (loginResponse.UserId);
                    #region Claim
                    var claims = new List<Claim>
                    {
                        new Claim(ClaimTypes.NameIdentifier, loginResponse.UserId.ToString()),
                        new Claim(ClaimTypes.Email, loginResponse.Email == null ? "": loginResponse.Email),
                        new Claim(ClaimTypes.Name,  loginResponse.Email == null ? "" : loginResponse.Email),
                        new Claim(ClaimTypes.Role,  loginResponse.Role ?? "")
                    };
                    #endregion
                    tokenResponse.Token = _tokenService.GenerateAccessToken(claims);
                    tokenResponse.RefreshToken = _tokenService.GenerateRefreshToken();
                    tokenResponse.UserName = loginResponse.UserName;
                    tokenResponse.UserMail = loginResponse.Email;
                    tokenResponse.UserId = loginResponse.UserId;
                    tokenResponse.Role = loginResponse.Role;
                    tokenResponse.Otp = loginResponse.Otp;
                    tokenResponse.ExpiryTime = loginResponse.ExpiryTime;
                    _ = await _service.UpdateRefreshToken(tokenResponse, UserId, _auditLogHelper);
                    Response.Response = tokenResponse;
                }
                else
                {
                    Response.IsError = true;
                    Response.ErrorDescription = "Wrong User Id Or Password ...!";
                    _errorlevel = AuditLog.BeLogLevel.Error;
                    _errortype = AuditLog.BeLogType.SQL;
                }
            }
            catch (Exception ex)
            {
                result = false;
                Response.ErrorDescription = "Failed To Get Login Details : - " + ex.Message;
            }
            //Audit Helper
            AuditLog.CallLog(_auditLogHelper, _errorlevel, _errortype, METHODNAME, TableID, Response.ErrorDescription);
            if (result)
            {
                return Ok(Response);
            }
            else
            {
                return StatusCode(StatusCodes.Status500InternalServerError, Response.ErrorDescription);
            }
        }

        [HttpPost]
        [Route("refresh")]
        public async Task<ActionResult> RefreshToken(RefreshTokenRequest tokenApiModel)
        {
            if (tokenApiModel is null)return BadRequest("Invalid client request");
            
            var tokenResponse = new TokenResponse();
            METHODNAME = "RefreshToken";
            TableID = "Refresh Token";
            Response.ErrorDescription = "Successful To Get Refresh Token";
            try
            {
                var principal = _tokenService.GetPrincipalFromExpiredToken(tokenApiModel.AccessToken);
                var username = principal.Identity?.Name; //this is mapped to the Name claim by default
                _auditLogHelper.ClientIpAddress = HttpContext.Connection.RemoteIpAddress?.ToString();
                _auditLogHelper.ClientEmail = username;
                dynamic? UserId = await _service.GetValidToken(username, tokenApiModel.RefreshToken, _auditLogHelper);
                if (UserId == null) return BadRequest("Invalid client request");
                tokenResponse.Token = _tokenService.GenerateAccessToken(principal.Claims);
                tokenResponse.RefreshToken = _tokenService.GenerateRefreshToken();
                _ = await _service.UpdateRefreshToken(tokenResponse, UserId, _auditLogHelper);
                Response.Response = tokenResponse;
            }
            catch (Exception ex)
            {
                result = false;
                Response.ErrorDescription = "Failed To Get Refresh Token : - " + ex.Message;
                _errorlevel = AuditLog.BeLogLevel.Error;
                _errortype = AuditLog.BeLogType.SQL;
            }
            //Audit Helper
            AuditLog.CallLog(_auditLogHelper, _errorlevel, _errortype, METHODNAME, TableID, Response.ErrorDescription);
            if (result)
            {
                return Ok(Response);
            }
            else
            {
                return StatusCode(StatusCodes.Status500InternalServerError, Response.ErrorDescription);
            }
        }

        [HttpPost, Authorize]
        [Route("revoke")]
        public async Task<ActionResult> RevokeToken()
        {
            InitialCall();
            var username = User.Identity?.Name;
            METHODNAME = "RevokeToken";
            TableID = "Revoke Token";
            Response.ErrorDescription = "Successfull To Revoke Token";
            try
            {
                var result = await _service.RevokeToken(username, _auditLogHelper);
                if (result == false)
                {
                    Response.IsError = true;
                    Response.ErrorDescription = "Faild To Revoke Token";
                }
            }
            catch (Exception ex)
            {
                result = false;
                Response.ErrorDescription = "Faild To Revoke Token : - " + ex.Message;
                _errorlevel = AuditLog.BeLogLevel.Error;
                _errortype = AuditLog.BeLogType.SQL;
            }
            //Audit Helper
            AuditLog.CallLog(_auditLogHelper, _errorlevel, _errortype, METHODNAME, TableID, Response.ErrorDescription);
            if (result)
            {
                return Ok(Response);
            }
            else
            {
                return StatusCode(StatusCodes.Status500InternalServerError, Response.ErrorDescription);
            }
        }
       
    }
}
