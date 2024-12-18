namespace Inventory.Models.Response
{
    public class TokenResponse
    {
        public string? Token { get; set; }
        public string? RefreshToken { get; set; }
        public long?  UserId { get; set; }
        public string? Role { get; set; }
        public string? UserName { get; set; }
        public string? UserMail { get; set; }
        public string? Otp { get; set; }
        public long ExpiryTime { get; set; }
        
    }
}
