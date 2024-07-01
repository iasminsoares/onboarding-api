using FluentAssertions.Common;
using IntegraApi.Application.Domain.Repositories;
using IntegraApi.Application.Domain.Services;
using IntegraApi.Application.Extensions;
using IntegraApi.Application.Persistence.Context;
using IntegraApi.Application.Persistence.Repositories;
using IntegraApi.Application.Services;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using System;
using System.Net.NetworkInformation;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

//builder.Services.AddDbContext<OnboardingContext>(opts => 
//    opts.UseLazyLoadingProxies().UseSqlServer(builder.Configuration.GetConnectionString("OnboardingConnection")));
builder.Services.AddDbContext<AppDbContext>(options => options
        .UseLoggerFactory(LoggerFactory.Create(builder => builder.AddConsole()))
        .UseSqlServer(builder.Configuration.GetConnectionString("OnboardingConnection"),
          b => b.MigrationsAssembly(typeof(AppDbContext).Assembly.FullName)));


// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddCustomSwagger();

builder.Services.AddMemoryCache();


//builder.Services.AddSwaggerGen(c =>
//{
//    c.SwaggerDoc("v1", new OpenApiInfo { Title = "IntegraApi", Version = "v1" });
//    var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
//    var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
//    c.IncludeXmlComments(xmlPath);
//});

//repositorios
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
builder.Services.AddScoped<ITotverRepository, TotverRepository>();
builder.Services.AddScoped<IAtividadeRepository, AtividadeRepository>();
builder.Services.AddScoped<IOnboardingRepository, OnboardingRepository>();
builder.Services.AddScoped<IAtividadeOnboardingRepository, AtividadeOnboardingRepository>();

//serviços
builder.Services.AddScoped<ITotverService, TotverService>();
builder.Services.AddScoped<IAtividadeService, AtividadeService>();
builder.Services.AddScoped<IOnboardingService, OnboardingService>();
builder.Services.AddScoped<IAtividadeOnboardingService, AtividadeOnboardingService>();


builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());


// Adicionar política de CORS
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowSpecificOrigin",
        builder => builder.WithOrigins("http://localhost:4200")
                          .AllowAnyMethod()
                          .AllowAnyHeader());
});


// Adicionar serviços ao contêiner.
builder.Services.AddControllers();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
    app.UseDeveloperExceptionPage();
}

// Usar política de CORS
app.UseCors("AllowSpecificOrigin");

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
