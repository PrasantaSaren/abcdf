using System.ComponentModel;

namespace Inventory.Models.Request
{
    public class LoginRequest
    {
        [DefaultValue("bgupta@technoindiagroup.in")]
        public string? UserName { get; set; }
        //[DefaultValue("123")]
        //public string? Password { get; set; }
    }
}
