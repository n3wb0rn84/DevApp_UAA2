using Starter_CleanArch_UAA2.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Starter_CleanArch_UAA2.ApplicationCore.Interfaces.Repositories;

public interface INewsletterRepository
{
    NewsletterSignUp? GetById(long id);

    NewsletterSignUp Insert(NewsletterSignUp newsletterSignUp);
    NewsletterSignUp Update(NewsletterSignUp newsletterSignUp);
    bool Delete(long id);
}
