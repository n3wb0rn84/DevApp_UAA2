using System;
using System.Collections.Generic;
using System.Net.Mail;
using System.Text;

namespace Starter_CleanArch_UAA2.Domain.Models;

public class NewsletterSignUp
{
    // Propriétés
    public long Id { get; private set; }
    public string Email { get; private set; }
    public bool IsNews {  get; private set; }
    public bool IsMonthly { get; private set; }
    public bool IsDayFact { get; private set; }
    // Ctor vide pour Entity Framework
    public NewsletterSignUp() { }
    // Ctor avec params
    public NewsletterSignUp(string email, bool isNews, bool isMonthly, bool isDayFact)
    {
        if (string.IsNullOrWhiteSpace(email) || !MailAddress.TryCreate(email, out _))
            throw new ArgumentException("L'adresse email n'est pas valide", nameof(email));

        Email = email;
        IsNews = isNews;
        IsMonthly = isMonthly;
        IsDayFact = isDayFact;
    }

    // Méthode
    public NewsletterSignUp ChangeSubscription(bool isNews, bool isMonthly, bool isDayFact)
    {
        IsNews = isNews;
        IsMonthly = isMonthly;
        IsDayFact = isDayFact;

        return this; 
    }

}
