using Starter_CleanArch_UAA2.ApplicationCore.Interfaces.Repositories;
using Starter_CleanArch_UAA2.ApplicationCore.Interfaces.Services;
using Starter_CleanArch_UAA2.ApplicationCore.Interfaces.Utils;
using Starter_CleanArch_UAA2.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Starter_CleanArch_UAA2.ApplicationCore.Services;

public class NewsletterService : INewsletterService
{
    private readonly INewsletterRepository _newsletterRepository;
    private readonly IMailerUtil _mailerUtil;

    public NewsletterService(INewsletterRepository newsletterRepository, IMailerUtil mailerUtil)
    {
        _newsletterRepository = newsletterRepository;
        _mailerUtil = mailerUtil;
    }

    public NewsletterSignUp Create(NewsletterSignUp data)
    {
        _mailerUtil.SendNewsEmail(data);
        return _newsletterRepository.Insert(data);
    }

    public void Delete(long id)
    {
        NewsletterSignUp? data = _newsletterRepository.GetById(id);
        bool success = _newsletterRepository.Delete(id);
        if (!success)
        {
            throw new Exception("Cet enregistrement est invalide !");
        }
        _mailerUtil.SendResignEmail(data);
    }

    public NewsletterSignUp GetById(long id)
    {
        NewsletterSignUp? data= _newsletterRepository.GetById(id);

        if(data is null)
        {
            throw new Exception("Cet enregistrement est invalide !");
        }
        return data;
    }

    public void UpdateNewsChoice(long id, bool isNews, bool isMonthly, bool isDayFact)
    {
        NewsletterSignUp? data = _newsletterRepository.GetById(id);

        if (data is null)
        {
            throw new Exception("Cet enregistrement est invalide !");
        }

        data.ChangeSubscription(isNews, isMonthly, isDayFact);

        _newsletterRepository.Update(data);
        _mailerUtil.SendNewsEmail(data);
    }
}
