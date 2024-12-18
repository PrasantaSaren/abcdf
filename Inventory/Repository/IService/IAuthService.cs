using Common_Helper.CommonHelper;
using Inventory.Models.Request;
using Inventory.Models.Response;

namespace Inventory.Repository.IService
{
    public interface IAuthService
    {
        Task<LoginResponse?> GetLoginDetails(LoginRequest user, AuditLogHelper _auditLogHelper);
        Task<bool> UpdateRefreshToken(TokenResponse tokenResponse, long? UserId, AuditLogHelper _auditLogHelper);
        Task<Guid?> GetValidToken(string? username, string? refreshToken, AuditLogHelper _auditLogHelper);
        Task<bool> RevokeToken(string? username, AuditLogHelper _auditLogHelper);
    }
}
