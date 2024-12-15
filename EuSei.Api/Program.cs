using EuSei.Api.Data;
using EuSei.Api.Data.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.Filters;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddSwaggerGen(option =>
{
    option.AddSecurityDefinition("oauth2", new Microsoft.OpenApi.Models.OpenApiSecurityScheme
    {
        In = Microsoft.OpenApi.Models.ParameterLocation.Header,
        Name = "Authorization",
        Type = SecuritySchemeType.ApiKey

    });
    option.OperationFilter<SecurityRequirementsOperationFilter>();
});


builder.Services.AddTransient<IPasswordHasher<User>, PasswordHasher<User>>();
builder.Services.AddDbContext<QuestionarioContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("EuSeiConn")));


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseSwagger();
app.UseSwaggerUI();


app.UseHttpsRedirection();

app.Run();
