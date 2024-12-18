namespace Inventory.Models.Response
{
    public class LoginResponse
    {
        public long UserId   { get; set; } = 0;
        public string Email    { get; set; } = "";
        public long  RoleId    { get; set; } = 0;
        public string ?Role     { get; set; } = "";
        public string? Otp      { get; set; } = "";
        public long ExpiryTime  { get; set; }
        public string? UserName { get; set; } = "";
    }
}
