using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using SistemasTarefasNovo.API.Autenticates;
using SistemasTarefasNovo.API.Validation;
using SistemaTarefaNovo.Aplication.Interfaces;
using SistemaTarefaNovo.Aplication.Mappings;
using SistemaTarefaNovo.Aplication.Services;
using SistemaTarefaNovo.Domain.Entities;
using SistemaTarefaNovo.Domain.Interfaces;
using SistemaTarefaNovo.Domain.Validation;
using SistemaTarefaNovo.Infra.Data.Repositories;
using SistemaTarefaNovo.Infra.Ioc;
using System.Text;

var builder = WebApplication.CreateBuilder(args);


builder.Configuration.AddJsonFile("appsettings.json");
var Configuration = builder.Configuration;
// Add services to the container.

builder.Services.AddValidatorsFromAssemblyContaining<PessoaValidation>();
builder.Services.AddValidatorsFromAssemblyContaining<TarefaValidation>();
builder.Services.AddFluentValidationAutoValidation();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


//builder.Services.AddInfraestruturaSwagger();
builder.Services.AddScoped<ITokenService, TokenService>();
builder.Services.AddInfraestrutura(builder.Configuration);





builder.Services.AddSwaggerGen(c =>
{
   
    c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        Description = "JWT Authorization header using the Bearer scheme",
        Type = SecuritySchemeType.Http,
        Scheme = "bearer"
    });

    // Define os requisitos de seguran�a para as opera��es que exigem autentica��o JWT
    c.AddSecurityRequirement(new OpenApiSecurityRequirement
{
    {
        new OpenApiSecurityScheme
        {
            Reference = new OpenApiReference
            {
                Type = ReferenceType.SecurityScheme,
                Id = "Bearer"
            }
        },
        new string[] {}
    }
});



});
var configuration = new ConfigurationBuilder()
.SetBasePath(builder.Environment.ContentRootPath)
.AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
.Build();

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(options =>
{
    options.RequireHttpsMetadata = false; // Mudar para true em ambiente de produ��o
    options.SaveToken = true;
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuerSigningKey = true,
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["jwt:secretKey"]!)),
        ValidateIssuer = false,
        ValidateAudience = false
    };
});
builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("AdminPolicy", policy => policy.RequireRole("Administrador"));

});



var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();
