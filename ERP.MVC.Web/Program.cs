using ERP.MVC.Application.Commands.AccountHeadTypes;
using ERP.MVC.Application.Commands.AccountSubHeadTypes;
using ERP.MVC.Application.Commands.Branches;
using ERP.MVC.Application.Commands.Companies;
using ERP.MVC.Application.Commands.FinancialYears;
using ERP.MVC.Application.Commands.TransactionHeads;
using ERP.MVC.Application.Mappers;
using ERP.MVC.Application.Queries.AccountHeadTypes;
using ERP.MVC.Application.Queries.AccountSubHeadTypes;
using ERP.MVC.Application.Queries.Branches;
using ERP.MVC.Application.Queries.Company;
using ERP.MVC.Application.Queries.FinancialYears;
using ERP.MVC.Application.Queries.TransactionHeads;
using ERP.MVC.Domain.Interfaces;
using ERP.MVC.Infrastructure.Middleware;
using ERP.MVC.Infrastructure.Persistence;
using ERP.MVC.Infrastructure.Repositories;
using ERP.MVC.Infrastructure.Services;
using FluentValidation;
using FluentValidation.AspNetCore;
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

builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

// Register the TokenService
builder.Services.AddScoped<ITokenService, TokenService>();
builder.Services.AddScoped<IFileUploadService, FileUploadService>();



// Configure database context
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// Add MediatR
builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblyContaining<Program>());
builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(GetCompaniesQueryHandler).Assembly));
builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(GetBranchesQueryHandler).Assembly));
builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(GetFinancialYearsQueryHandler).Assembly));
builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(GetAccountsHeadTypesQueryHandler).Assembly));
builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(GetAccountsSubHeadTypesQueryHandler).Assembly));
builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(GetTransactionHeadsQueryHandler).Assembly));




// Register FluentValidation with ASP.NET Core DI
builder.Services.AddFluentValidation(fv => fv.RegisterValidatorsFromAssemblyContaining<CreateCompanyCommandValidator>());
builder.Services.AddFluentValidation(fv => fv.RegisterValidatorsFromAssemblyContaining<CreateBranchCommandValidator>());
builder.Services.AddFluentValidation(fv => fv.RegisterValidatorsFromAssemblyContaining<CreateFinancialYearCommandValidator>());
builder.Services.AddFluentValidation(fv => fv.RegisterValidatorsFromAssemblyContaining<CreateAccountHeadTypeCommandValidator>());
builder.Services.AddFluentValidation(fv => fv.RegisterValidatorsFromAssemblyContaining<CreateAccountSubHeadTypeCommandValidator>());
builder.Services.AddFluentValidation(fv => fv.RegisterValidatorsFromAssemblyContaining<CreateTransactionHeadCommandValidator>());



// Add AutoMapper
builder.Services.AddAutoMapper(typeof(MappingProfile));

// Add FluentValidation
builder.Services.AddValidatorsFromAssemblyContaining<Program>();

// Register repositories
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IUserService, UserService>();
//builder.Services.AddScoped<IMenuService, MenuService>();
builder.Services.AddScoped<IRoleRepository, RoleRepository>();
builder.Services.AddScoped<ICompanyRepository, CompanyRepository>();
builder.Services.AddScoped<IBranchRepository, BranchRepository>();
builder.Services.AddScoped<IFinancialYearRepository, FinancialYearRepository>();
builder.Services.AddScoped<IAccountHeadTypeRepository, AccountHeadTypeRepository>();
builder.Services.AddScoped<IAccountSubHeadTypeRepository, AccountSubHeadTypeRepository>();
builder.Services.AddScoped<ITransactionHeadRepository, TransactionHeadRepository>();



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
