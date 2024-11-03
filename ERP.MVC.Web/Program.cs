using ERP.MVC.Domain.Interfaces;
using ERP.MVC.Infrastructure.Middleware;
using ERP.MVC.Infrastructure.Persistence;
using ERP.MVC.Infrastructure.Repositories;
using FluentValidation;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Serilog;

var builder = WebApplication.CreateBuilder(args);

// Configure Serilog
Log.Logger = new LoggerConfiguration()
    .Enrich.FromLogContext()
    .WriteTo.Console()
    .WriteTo.File("logs/log-.txt", rollingInterval: RollingInterval.Day,
                  formatProvider: null,
                  outputTemplate: "{Timestamp:yyyy-MM-dd HH:mm:ss} [{Level}] {Message}{NewLine}{Exception}")
    .CreateLogger();

builder.Host.UseSerilog(); // Use Serilog for logging

// Configure database context
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// Add MediatR
builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblyContaining<Program>());

// Add AutoMapper
builder.Services.AddAutoMapper(typeof(Program));

// Add FluentValidation
builder.Services.AddValidatorsFromAssemblyContaining<Program>();

// Register repositories
builder.Services.AddScoped<ICompanyRepository, CompanyRepository>();

// Add services to the container.
builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

// Register middleware
app.UseMiddleware<RequestResponseLoggingMiddleware>();

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
