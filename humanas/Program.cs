using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using ui;
using Microsoft.Extensions.Configuration;
using System.Text;
using data.access.Context;
using data.access;
using entity.entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.Data.Sqlite;
using web.api.Utilities.JwtToken;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddScoped<IRepository, RepositoryFason>();


builder.Services.AddControllersWithViews();
builder.Services.AddHttpContextAccessor();
builder.Services.AddHttpClient();



JwtConfig jwtConfig = JwtConfig.getInstance();
builder.Services.AddAuthentication(JwtConfig.shema)
    .AddJwtBearer(options => { options.SaveToken = true; jwtConfig.GetTokenValidationParameters(); });

builder.Services.AddAuthorizationCore();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();


app.RegisterMyRoutes();




app.Run();
