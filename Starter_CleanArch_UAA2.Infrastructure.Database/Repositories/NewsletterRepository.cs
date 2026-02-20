using Microsoft.EntityFrameworkCore.ChangeTracking;
using Starter_CleanArch_UAA2.ApplicationCore.Interfaces.Repositories;
using Starter_CleanArch_UAA2.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Starter_CleanArch_UAA2.Infrastructure.Database.Repositories;

public class NewsletterRepository : INewsletterRepository
{
    private readonly AppDbContext _dbContext;

    public NewsletterRepository(AppDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public bool Delete(long id)
    {
        NewsletterSignUp? target = GetById(id);

        if (target is null) return false;
        _dbContext.Remove(target);
        _dbContext.SaveChanges();
        return true;
    }

    public NewsletterSignUp? GetById(long id)
    {
        return _dbContext.NewsletterSignUps
            .SingleOrDefault(n => n.Id == id);
    }

    public NewsletterSignUp Insert(NewsletterSignUp data)
    {
        // Création de l'élément à insérer
        NewsletterSignUp dataToInsert = new NewsletterSignUp(
                data.Email,
                data.IsNews,
                data.IsMonthly,
                data.IsDayFact
            );
        // Ajout du contexte
        EntityEntry<NewsletterSignUp> element = _dbContext.NewsletterSignUps.Add(dataToInsert);
        // Application de la modif du contexte dans la bdd
        _dbContext.SaveChanges();
        return element.Entity;

    }

    public NewsletterSignUp Update(NewsletterSignUp data)
    {
        // Pour modifier l'objet dans le contexte
        EntityEntry<NewsletterSignUp> result = _dbContext.Update(data);
        // Appliquer les modification
        _dbContext.SaveChanges();
        // Renvoyer l'element ajouté up to date
        return result.Entity;
    }
}
