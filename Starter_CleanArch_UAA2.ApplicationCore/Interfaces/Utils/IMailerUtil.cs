using Starter_CleanArch_UAA2.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Starter_CleanArch_UAA2.ApplicationCore.Interfaces.Utils;

public interface IMailerUtil
{
    void SendNewsEmail(NewsletterSignUp newsletterSignUp);

    void SendResignEmail(NewsletterSignUp newsletterSignUp);
}
