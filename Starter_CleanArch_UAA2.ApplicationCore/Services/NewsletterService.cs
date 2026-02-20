using Starter_CleanArch_UAA2.ApplicationCore.Interfaces.Repositories;
using Starter_CleanArch_UAA2.ApplicationCore.Interfaces.Services;
using Starter_CleanArch_UAA2.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Starter_CleanArch_UAA2.ApplicationCore.Services;

public class NewsletterService : INewsletterService
{
    private readonly INewsletterRepository _newsletterRepository;

    public NewsletterService(INewsletterRepository newsletterRepository)
    {
        _newsletterRepository = newsletterRepository;
    }

    public NewsletterSignUp Create(NewsletterSignUp data)
    {
        return _newsletterRepository.Insert(data);
    }

    public void Delete(long id)
    {
        bool success = _newsletterRepository.Delete(id);
        if (!success)
        {
            throw new Exception("Cet enregistrement est invalide !");
        }
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
    }
}
