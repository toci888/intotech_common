namespace Intotech.Common.Bll.Interfaces;

public class EmailContent
{
    //public string EmailFrom { get; set; }
    public List<string> EmailTo { get; set; }
    public string From { get; set; }
    public string Subject { get; set; }
    public string Body { get; set; }
}