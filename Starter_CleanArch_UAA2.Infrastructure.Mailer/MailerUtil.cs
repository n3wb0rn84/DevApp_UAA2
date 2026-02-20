using Starter_CleanArch_UAA2.ApplicationCore.Interfaces.Utils;
using Starter_CleanArch_UAA2.Domain.Models;

namespace Starter_CleanArch_UAA2.Infrastructure.Mailer;

public class MailerUtil : IMailerUtil
{

    private string _Host { get; set; }
    private int _Port { get; set; }
    private string _Username { get; set; }
    private string _Password { get; set; }
    private string _AppEmail { get; set; }
    private string _AppName { get; set; }
    public MailerUtil(string host, int port, string username, string password, string appEmail, string appName)
    {
        _Host = host;
        _Port = port;
        _Username = username;
        _Password = password;
        _AppEmail = appEmail;
        _AppName = appName;
    }

    public void SendEmail(NewsletterSignUp newsletterSignUp)
    {
        throw new NotImplementedException();
    }
}
