namespace Intotech.Common.Bll.Interfaces;

public interface IEmailUtil
{
    bool SendEmail(EmailContent content);
}