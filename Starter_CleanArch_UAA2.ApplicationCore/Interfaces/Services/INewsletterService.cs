using Starter_CleanArch_UAA2.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Starter_CleanArch_UAA2.ApplicationCore.Interfaces.Services;

public interface INewsletterService
{
    NewsletterSignUp GetById(long id);
    NewsletterSignUp Create(NewsletterSignUp newsletterSignUp);
    void UpdateNewsChoice(long id, bool isNews, bool isMonthly, bool isDayFact);
    void Delete(long id);
}