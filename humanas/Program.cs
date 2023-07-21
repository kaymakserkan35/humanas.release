using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using ui;
using Microsoft.Extensions.Configuration;
using System.Text;
using data.access.Context;
using data.access;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddScoped<IRepository, RepositoryFason>();


builder.Services.AddControllersWithViews();
builder.Services.AddHttpClient();
builder.Services.AddDbContext<Context_Concete>(options =>
{
    options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection"));
});

var jwtSettings = builder.Configuration.GetSection("JwtSettings");
var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtSettings["SecretKey"]));
builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
})
       .AddJwtBearer(options =>
       {
           options.RequireHttpsMetadata = false;
           options.SaveToken = true;
           options.TokenValidationParameters = new TokenValidationParameters
           {
               ValidateIssuerSigningKey = true,
               IssuerSigningKey = key,
               ValidateIssuer = true,
               ValidIssuer = jwtSettings["Issuer"],
               ValidateAudience = true,
               ValidAudience = jwtSettings["Audience"],
               ValidateLifetime = true,
           };
       });

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

app.UseAuthorization();


app.UseEndpoints(endpoints =>
{
    endpoints.RegisterMyRoutes();

endpoints.MapControllers(); });

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Auth}/{action=Auth}/{id?}");

app.Run();
