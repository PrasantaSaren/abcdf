namespace Inventory.Extensions
{
    public interface ISmtpSettings
    {
        public string? Host { get; set; }
        public int Port { get; set; }
        public string? UserName { get; set; }
        public string? Password { get; set; }
        public bool EnableSsl { get; set; }
    }
    public sealed class SmtpSettings: ISmtpSettings
    {
        public string? Host { get; set; }
        public int Port { get; set; }
        public string? UserName { get; set; }
        public string? Password { get; set; }
        public bool EnableSsl { get; set; }
    }
}
