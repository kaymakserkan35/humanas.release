using data.access;
using data.access.Context;
using entity.entities;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Text;
using web.api.Utilities.JwtToken;
using web.api.Utilities.JwtTokenHelper;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddScoped<IRepository, RepositoryFason>();
builder.Services.AddScoped<ITokenHelper, TokenHelper>();


string ConnectionString = new SqliteConnectionStringBuilder()
{
    DataSource = "humanas.db",
    ForeignKeys = true

}.ConnectionString;
builder.Services.AddDbContext<ContextConcete>(options =>
    options.UseSqlite(ConnectionString));

builder.Services.AddIdentity<UserExt, IdentityRole<int>>(options =>
{
    options.SignIn.RequireConfirmedEmail = false;
    options.SignIn.RequireConfirmedPhoneNumber = false;
}).AddEntityFrameworkStores<ContextConcete>().AddDefaultTokenProviders();


JwtConfig jwtConfig = JwtConfig.getInstance();
builder.Services.AddAuthentication(JwtConfig.shema)
    .AddJwtBearer(options =>
    { options.SaveToken = true; options.TokenValidationParameters = jwtConfig.GetTokenValidationParameters(); });
builder.Services.AddAuthorizationCore();
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "myAPI Name", Version = "v1" });
});




// Diğer konfigürasyon ve servisler





var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthentication(); // Doğrulama middleware'ini ekleyin.
app.UseAuthorization(); // Yetkilendirme middleware'ini ekleyin.

app.MapControllers();

app.Run();
