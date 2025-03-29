//using ASC.WEB.Configuration;
//using Microsoft.Extensions.Options;
//using MimeKit;
//using MailKit.Net.Smtp;
//using Microsoft.AspNetCore.Identity.UI.Services;
//using System.Threading.Tasks;

//namespace ASC.WEB.Services

//{
//    public class AuthMessgageSender : IEmailSender, ISmsSender
//    {
//        private IOptions<ApplicationSettings> _settings;
//        public AuthMessgageSender(IOptions<ApplicationSettings> settings)
//        {
//            _settings = settings;
//        }

//        public async Task SendEmailAsync(string email, string subject, string message)
//        {
//            var emailMessage = new MimeMessage();
//            emailMessage.From.Add(new MailboxAddress("admin", _settings.Value.SMTPAccount));
//            emailMessage.To.Add(new MailboxAddress("user", email));
//            emailMessage.Subject = subject;
//            emailMessage.Body = new TextPart("plain") { Text = message };
//            using (var client = new SmtpClient())
//            {
//                await client.ConnectAsync(_settings.Value.SMTPServer, _settings.Value.SMTPPort, false);
//                await client.AuthenticateAsync(_settings.Value.SMTPAccount, _settings.Value.SMTPPassword);
//                await client.SendAsync(emailMessage);
//                await client.DisconnectAsync(true);
//            }
//        }
//        public Task SendSmsAsync(string number, string message)
//        {
//            return Task.FromResult(0);
//        }
//    }
//}




using Microsoft.AspNetCore.Identity.UI.Services; // ✅ Đảm bảo dùng đúng namespace
using Microsoft.Extensions.Options;
using MimeKit;
using MailKit.Net.Smtp;
using System.Threading.Tasks;
using ASC.WEB.Configuration;

namespace ASC.WEB.Services
{
    public class AuthMessgageSender : IEmailSender
    {
        private readonly ApplicationSettings _settings;

        public AuthMessgageSender(IOptions<ApplicationSettings> settings)
        {
            _settings = settings.Value;
        }

        public async Task SendEmailAsync(string email, string subject, string message)
        {
            var emailMessage = new MimeMessage();
            emailMessage.From.Add(new MailboxAddress("Admin", _settings.SMTPAccount));
            emailMessage.To.Add(new MailboxAddress(email, email));
            emailMessage.Subject = subject;
            emailMessage.Body = new TextPart("html") { Text = message };

            using (var client = new SmtpClient())
            {
                await client.ConnectAsync(_settings.SMTPServer, _settings.SMTPPort, MailKit.Security.SecureSocketOptions.StartTls);
                await client.AuthenticateAsync(_settings.SMTPAccount, _settings.SMTPPassword);
                await client.SendAsync(emailMessage);
                await client.DisconnectAsync(true);
            }
        }
    }
}

