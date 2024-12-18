using Dapper;
using Inventory.Extensions;
using Inventory.Models.Entity;
using Inventory.Models.Response;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using System.Data;
using System.Security.Claims;

namespace Inventory.AppCode
{
    public interface ISessionHelper
    {
        public string? UserId { get; set; }
        public string? UserName { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? MiddleName { get; set; }
        public string? Email { get; set; }
        public Guid? BusinessId { get; set; }
        public string? ClientIpAddress { get; set; }

        bool GetSessionClaim();
    }
    public class SessionHelper: ISessionHelper
    {
        public string? UserId { get; set; }
        public string? UserName { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? MiddleName { get; set; }
        public string? Email { get; set; }
        public Guid? BusinessId { get; set; }
        public string? ClientIpAddress { get; set; }
        private readonly IDbConnection _dbConnection;
        public SessionHelper(IConfiguration Configuration)
        {
            ConnectionHelper connectionHelper = new ConnectionHelper(Configuration);
            _dbConnection = connectionHelper.GetDbConnection();
        }
        public bool GetSessionClaim()
        {
            HttpContextAccessor _httpContextAccessor = new HttpContextAccessor();
            bool result = false;
            var identity = _httpContextAccessor.HttpContext?.User.Identity as ClaimsIdentity;
            if (identity != null)
            {
                IEnumerable<Claim> claims = identity.Claims;
                GetusernameFromClaim(claims);
            }
            UserId = _httpContextAccessor.HttpContext?.User.FindFirstValue(ClaimTypes.NameIdentifier);
            Email = _httpContextAccessor.HttpContext?.User.FindFirstValue(ClaimTypes.Email);
            ClientIpAddress = _httpContextAccessor.HttpContext?.Connection.RemoteIpAddress?.ToString();
            GetUserDetails(UserId);
            result = true;
            return result;
        }
        private void GetusernameFromClaim(IEnumerable<Claim> claims)
        {
            for (int i = 0; i < claims.ToList().Count; i++)
            {
                //if (claims.ToList()[i].Type.EndsWith("givenname"))
                //{
                //    FirstName = claims.ToList()[i].Value;
                //}
            }
        }
        private void GetUserDetails(string? UserId)
        {
            try
            {
                string SqlQuery = UserDetailsSql();
                var parameters = new { UserId = UserId };
                var QResult = _dbConnection.QuerySingleOrDefaultAsync(SqlQuery, parameters);
                if (QResult != null)
                {
                    UserName = QResult.Result?.UserName;
                    BusinessId = QResult.Result?.BusinessId;
                }
            }
            catch (Exception)
            {

            }
        }
        private static string UserDetailsSql()
        {
            string query = "";
            query = " SELECT (FirstName + ' ' + LastName) As UserName, BusinessId From [User] Where UserId = @UserId ";
            return query;
        }
        public class Session
        {
            public string? UserId { get; set; }
            public string? UserName { get; set; }
        }
    }
}
