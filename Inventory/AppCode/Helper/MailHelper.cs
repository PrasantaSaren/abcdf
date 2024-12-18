using System.Net.Mail;
using System.Net;
using Inventory.Extensions;
using Microsoft.Extensions.Options;
using Azure.Communication.Email;
using Azure.Identity;
using Azure;

namespace Inventory.AppCode.Helper
{
    public interface IMailHelper
    {
        Task<bool> SendEmailSMTPAsync(List<string> toList, List<string> ccList, List<string> bccList, string from, string subject, string body, string template, bool isHtml);
        Task<bool> SendEmailAzureAsync(List<string> toList, List<string> ccList, List<string> bccList, string subject, string body, string template, bool isHtml);
    }
    public class MailHelper: IMailHelper
    {
        private readonly SmtpSettings _smtpSettings;
        public MailHelper(IOptions<SmtpSettings> smtpSettings)
        {
            _smtpSettings = smtpSettings.Value;
        }
        public async Task<bool> SendEmailSMTPAsync(List<string> toList, List<string> ccList, List<string> bccList, string from, string subject, string body, string template, bool isHtml)
        {
            bool result = true;
            MailMessage? mailMessage = null;
            if (isHtml)
            {
                mailMessage = new MailMessage
                {
                    From = new MailAddress(from),
                    Subject = subject,
                    Body = AddHtmlTemplte(body, subject, template),
                    IsBodyHtml = isHtml
                };
            }
            else
            {
                mailMessage = new MailMessage
                {
                    From = new MailAddress(from),
                    Subject = subject,
                    Body = body,
                    IsBodyHtml = isHtml
                };
            }
            if (toList != null)
            {
                foreach (var to in toList)
                {
                    mailMessage.To.Add(to);
                }
            }
            if (ccList != null)
            {
                foreach (var cc in ccList)
                {
                    mailMessage.CC.Add(cc);
                }
            }
            if (bccList != null)
            {
                foreach (var bcc in bccList)
                {
                    mailMessage.Bcc.Add(bcc);
                }
            }
            using (var smtpClient = new SmtpClient(_smtpSettings.Host, _smtpSettings.Port))
            {
                try
                {
                    smtpClient.UseDefaultCredentials = false;
                    smtpClient.Credentials = new NetworkCredential(_smtpSettings.UserName, _smtpSettings.Password);
                    smtpClient.EnableSsl = _smtpSettings.EnableSsl;
                    await smtpClient.SendMailAsync(mailMessage);
                }
                catch (Exception ex)
                {
                    result = false;
                    throw new ApplicationException($"Failed to send email: {ex.Message}");
                }
            }
            return result;
        }
        public async Task<bool> SendEmailAzureAsync(List<string> toList, List<string> ccList, List<string> bccList, string subject, string body, string template, bool isHtml)
        {
            bool result = true;
            //string resourceEndpoint = "<ACS_RESOURCE_ENDPOINT>";
            //EmailClient emailClient = new EmailClient(new Uri(resourceEndpoint), new DefaultAzureCredential());
            string? connectionString = Environment.GetEnvironmentVariable("COMMUNICATION_SERVICES_CONNECTION_STRING");
            EmailClient emailClient = new EmailClient(connectionString);
            var toRecipients = new List<EmailAddress>();
            var ccRecipients = new List<EmailAddress>();
            var bccRecipients = new List<EmailAddress>();
            var emailContent = new EmailContent(subject);
            if (isHtml)
            {
                emailContent.Html = AddHtmlTemplte(body, subject, template);
            }
            else
            {
                emailContent.PlainText = body;
            }
            if (toList != null)
            {
                foreach (var to in toList)
                {
                    toRecipients.Add(new EmailAddress(to));
                }
            }
            if (ccList != null)
            {
                foreach (var cc in ccList)
                {
                    ccRecipients.Add(new EmailAddress(cc));
                }
            }
            if (bccList != null)
            {
                foreach (var bcc in bccList)
                {
                    bccRecipients.Add(new EmailAddress(bcc));
                }
            }
            try
            {
                var emailRecipients = new EmailRecipients(toRecipients, ccRecipients, bccRecipients);
                var emailMessage = new EmailMessage("no-reply@example.com", emailRecipients, emailContent);
                var emailSendOperation = await emailClient.SendAsync(WaitUntil.Completed, emailMessage);

                var operationId = emailSendOperation.Id;
                Console.WriteLine($"Email Sent. Status = {emailSendOperation.Value.Status}");
                Console.WriteLine($"Email operation id = {operationId}");
            }
            catch (RequestFailedException ex)
            {
                result = false;
                Console.WriteLine($"Email send operation failed with error code: {ex.ErrorCode}, message: {ex.Message}");
            }
            return result;
        }
        public static string AddHtmlTemplte(string body, string subject, string template)
        {
            string htmlTemplate = GethtmlTemplate(template);
            string modifiedHtml = ReplacePlaceholders(htmlTemplate, new
            {
                Title = subject,
                Name = "",
                Content = body
            });
            return modifiedHtml;
        }
        private static string ReplacePlaceholders(string template, object replacements)
        {
            // Use reflection to replace placeholders in the template
            foreach (var property in replacements.GetType().GetProperties())
            {
                string placeholder = $"{{{{{property.Name}}}}}";
                string replacement = property.GetValue(replacements)?.ToString() ?? string.Empty;
                template = template.Replace(placeholder, replacement);
            }
            return template;
        }
        private static string GethtmlTemplate(string template)
        {
            string result="";
            string filePath= "AppCode/Helper/mailTemplate/";
            switch (template)
            {
                case "welcome":
                    filePath += "WelcomeTemplate.html";
                    result = File.ReadAllText(filePath);
                    break;
                case "registration":
                    filePath += "";
                    result = File.ReadAllText(filePath);
                    break;
                case "Submission":
                    filePath += "";
                    result = File.ReadAllText(filePath);
                    break;
                default:
                    filePath += "";
                    result = File.ReadAllText(filePath);
                    break;
            }

            return result;
        }
    }
}
