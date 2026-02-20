using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Starter_CleanArch_UAA2.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Starter_CleanArch_UAA2.Infrastructure.Database.Configs;

internal class NewsletterSignUpConfig : IEntityTypeConfiguration<NewsletterSignUp>
{
    public void Configure(EntityTypeBuilder<NewsletterSignUp> builder)
    {
        // Table
        builder.ToTable("Newsletter_Sign_Up");

        // Clef
        builder.HasKey(n => n.Id)
            .HasName("PK_Newsletter_Sign_Up")
            .IsClustered();
        // Colonnes
        builder.Property(n => n.Id)
            .ValueGeneratedOnAdd();

        builder.Property(n => n.Email)
            .HasMaxLength(320)
            .IsUnicode()
            .IsRequired();

        builder.Property(n => n.IsNews)
            .HasColumnName("Is_News")
            .IsRequired();

        builder.Property(n => n.IsMonthly)
            .HasColumnName("Is_Monthly")
            .IsRequired();

        builder.Property(n => n.IsDayFact)
            .HasColumnName("Is_Day_Fact")
            .IsRequired();

        //Index
        builder.HasIndex(n => n.Email)
            .IsUnique()
            .HasDatabaseName("IDX_Newsletter__Email");
    }
}
