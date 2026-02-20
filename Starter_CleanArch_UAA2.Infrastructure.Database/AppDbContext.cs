using Microsoft.EntityFrameworkCore;
using Starter_CleanArch_UAA2.Domain.Models;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace Starter_CleanArch_UAA2.Infrastructure.Database
{
    public class AppDbContext : DbContext
    {
        // Table pour les enregistrements à la newsletter
        public DbSet<NewsletterSignUp> NewsletterSignUps {  get; set; }

        // Definition ctor pour l'injection de dépendance
        public AppDbContext(DbContextOptions options) : base(options) { }

        // Application de la config
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}
