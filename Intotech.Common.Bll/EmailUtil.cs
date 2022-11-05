using Intotech.Common.Bll.Interfaces;
using MailKit.Net.Smtp;
using MailKit.Security;
using MimeKit;

namespace Intotech.Common.Bll;

public class EmailUtil : IEmailUtil
{
    protected EmailSettings Settings;

    public EmailUtil(EmailSettings settings)
    {
        Settings = settings;
    }

    public virtual bool SendEmail(EmailContent content)
    {
        BodyBuilder bodyBuilder = new BodyBuilder();

        bodyBuilder.HtmlBody = content.Body;

        foreach (string emailTo in content.EmailTo)
        {
            MimeMessage message = new MimeMessage();
            message.From.Add(new MailboxAddress(content.From, Settings.AdminLoginAddress)); //content.EmailFrom
            message.To.Add(MailboxAddress.Parse(emailTo));
            message.Subject = content.Subject;

            message.Body = bodyBuilder.ToMessageBody();

            SmtpClient client = new SmtpClient();
            try
            {
                client.Connect(Settings.SmtpAddress, Settings.Port, SecureSocketOptions.StartTls);
                //authenticate client
                client.Authenticate(Settings.AdminLoginAddress, Settings.AdminPassword);
                client.Send(message);
            }
            catch (Exception ex)
            {
                return false;
            }
            finally
            {
                client.Disconnect(true);
                client.Dispose();
            }
        }

        return true;
    }
}