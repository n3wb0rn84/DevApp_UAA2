using Microsoft.EntityFrameworkCore;
using Scalar.AspNetCore;
using Starter_CleanArch_UAA2.ApplicationCore.Interfaces.Repositories;
using Starter_CleanArch_UAA2.ApplicationCore.Interfaces.Services;
using Starter_CleanArch_UAA2.ApplicationCore.Interfaces.Utils;
using Starter_CleanArch_UAA2.ApplicationCore.Services;
using Starter_CleanArch_UAA2.Infrastructure.Database;
using Starter_CleanArch_UAA2.Infrastructure.Database.Repositories;
using Starter_CleanArch_UAA2.Infrastructure.Mailer;

var builder = WebApplication.CreateBuilder(args);

// -Tool Mailer
builder.Services.AddSingleton<IMailerUtil, MailerUtil>(service =>
{
    return new MailerUtil(
        builder.Configuration["Mailer:Host"]!,
        builder.Configuration.GetValue<int>("Mailer:Port", 25),
        builder.Configuration["Mailer:Username"]!,
        builder.Configuration["Mailer:Password"]!,
        builder.Configuration["Mailer:AppEmail"]!,
        builder.Configuration["Mailer:AppName"]!
    );
});
// Add services to the container.
builder.Services.AddSingleton<Random>();
builder.Services.AddScoped<IExampleMessageService, ExampleMessageService>();
builder.Services.AddScoped<INewsletterService, NewsletterService>();
// Add Repositories
builder.Services.AddScoped<INewsletterRepository, NewsletterRepository>();
// - DB Context
builder.Services.AddDbContext<AppDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("Default"));
});
// Mapping controller
builder.Services.AddControllers();

// Gestion exception AspNetCore
builder.Services.AddProblemDetails();



// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.MapScalarApiReference();
}

app.UseHttpsRedirection();

app.UseExceptionHandler();

app.UseAuthorization();

app.MapControllers();

app.Run();
