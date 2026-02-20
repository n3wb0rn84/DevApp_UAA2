using MailKit.Net.Smtp;
using MimeKit;
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

    private void SendMail(MimeMessage message)
    {
        using SmtpClient smtpClient = new SmtpClient();
        try
        {
            // - Connexion au serveur Smtp
            smtpClient.Connect(_Host, _Port, false);

            // - Authentification
            smtpClient.Authenticate(_Username, _Password);

            // - Envoi du mail 
            smtpClient.Send(message);
        }
        finally
        {
            smtpClient.Disconnect(true);
        }
    }
    public void SendNewsEmail(NewsletterSignUp newsletterSignUp)
    {
        MimeMessage message = new MimeMessage();

        // Config du message mail
        message.Subject = "Bienvenue sur Agenda Event !";
        message.From.Add(new MailboxAddress(_AppName, _AppEmail));
        message.To.Add(new MailboxAddress(null, newsletterSignUp.Email));

        // Définition du body du mail
        BodyBuilder bodyBuilder = new BodyBuilder();
        string isNews = newsletterSignUp.IsNews ? "oui recevoir des news classique" : "ne pas recevoir de news classique";
        string isMonthly = newsletterSignUp.IsMonthly ? "oui recevoir des news mensuelle" : "ne pas recevoir de news mensuelle";
        string isDayFact = newsletterSignUp.IsDayFact ? "oui recevoir les faits du jour" : "ne pas recevoir les faits du jour";

        bodyBuilder.TextBody = "Bienvenue.";
        bodyBuilder.HtmlBody = @$"
    <div>
        <h1 style='color:deeppink;'>Bonjour {newsletterSignUp.Email}</h1>
        <p>Merci de vous être enregistré sur notre newsletter</p>
        <p>Pour la newsletter classique vous avez sélectionné {isNews}</p>
        <p>Pour la newsletter classique vous avez sélectionné {isMonthly}</p>
        <p>Pour la newsletter classique vous avez sélectionné {isDayFact}</p>
        <p>Sur votre adresse {newsletterSignUp.Email}</p>
</div>";

        message.Body = bodyBuilder.ToMessageBody();

        // Envoi du mail
        SendMail(message);
    }

    public void SendResignEmail(NewsletterSignUp newsletterSignUp)
    {
        MimeMessage message = new MimeMessage();

        // Config du message mail
        message.Subject = "Bienvenue sur Agenda Event !";
        message.From.Add(new MailboxAddress(_AppName, _AppEmail));
        message.To.Add(new MailboxAddress(null, newsletterSignUp.Email));

        // Définition du body du mail
        BodyBuilder bodyBuilder = new BodyBuilder();

        bodyBuilder.TextBody = "Bienvenue.";
        bodyBuilder.HtmlBody = @$"
    <div>
        <h1 style='color:deeppink;'>Bonjour {newsletterSignUp.Email}</h1>
        <p>Désolé de vous voir partir, longue vie à vous.</p>
</div>";

        message.Body = bodyBuilder.ToMessageBody();

        // Envoi du mail
        SendMail(message);
    }
}
