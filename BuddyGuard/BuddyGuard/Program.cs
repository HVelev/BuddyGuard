using BuddyGuard.Core.Contracts;
using BuddyGuard.Core.Data;
using BuddyGuard.Core.Data.Common;
using BuddyGuard.Core.Data.Models;
using BuddyGuard.Core.Services;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authentication.Negotiate;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Server.IISIntegration;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Text;
using RequestsService = BuddyGuard.Core.Services.RequestsService;

string CorsAllowSpecificOrigins = "_corsAllowSpecificOrigins";
var builder = WebApplication.CreateBuilder(args);

var username = System.Environment.UserName;

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

if (username == "HVelev")
{
    connectionString = builder.Configuration.GetConnectionString("LaptopConnection");
}

builder.Services.AddDbContext<BuddyguardDbContext>(options =>
    options.UseSqlServer(connectionString));
builder.Services.AddTransient<ILoginService, LoginService>();
builder.Services.AddScoped<IRepository, Repository>();
builder.Services.AddTransient<IRequestService, RequestsService>();
builder.Services.AddTransient<IProcessRequestService, ProcessRequestService>();
builder.Services.AddTransient<INotificationService, NotificationService>();
builder.Services.AddTransient<IUserService, UserService>();
builder.Services.AddTransient<IRegisterService, RegisterService>();
builder.Services.AddTransient<INomenclatureService, NomenclatureService>();
builder.Services.AddTransient<IMailService, MailService>();
builder.Services.AddTransient<IImageService, ImageService>();
builder.Services.AddTransient<IInquiryService, InquiryService>();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddSwaggerGen();
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddHttpContextAccessor();

IdentityBuilder identityBuilder = builder.Services.AddIdentity<User, IdentityRole>(options =>
{
    options.SignIn.RequireConfirmedAccount = false;
    options.SignIn.RequireConfirmedPhoneNumber = false;
    options.SignIn.RequireConfirmedEmail = false;
    options.User.RequireUniqueEmail = true;
}).AddEntityFrameworkStores<BuddyguardDbContext>();

builder.Services.AddScoped<IUserClaimsPrincipalFactory<User>, UserClaimsPrincipalFactory<User, IdentityRole>>();

identityBuilder.AddSignInManager<SignInManager<User>>();

identityBuilder.AddUserManager<UserManager<User>>();

builder.Services.AddControllers();

builder.Services.AddMvc();
builder.Services.AddCors(service =>
{
    service.AddPolicy(CorsAllowSpecificOrigins,
        builder =>
        {
            builder.AllowAnyOrigin()
            .AllowAnyHeader()
            .AllowAnyMethod();
        });
});

JwtSecurityTokenHandler.DefaultInboundClaimTypeMap.Clear();

builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(o =>
{
    o.TokenValidationParameters = new TokenValidationParameters
    {
        ValidIssuer = builder.Configuration["Jwt:Issuer"],
        ValidAudience = builder.Configuration["Jwt:Audience"],
        IssuerSigningKey = new SymmetricSecurityKey
        (Encoding.UTF8.GetBytes(builder.Configuration["Jwt:SecretKey"])),
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateLifetime = false,
        ValidateIssuerSigningKey = true,
        
    };
});

builder.Services.AddAuthentication(NegotiateDefaults.AuthenticationScheme)
   .AddNegotiate();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors(CorsAllowSpecificOrigins);

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.MapAreaControllerRoute(
    name: "Admin",
    areaName: "Admin",
    pattern: "Admin/{controller=Home}/{action=Index}/{id?}");

app.MapAreaControllerRoute(
    name: "User",
    areaName: "User",
    pattern: "User/{controller=Home}/{action=Index}/{id?}");

app.MapAreaControllerRoute(
    name: "Shared",
    areaName: "Shared",
    pattern: "Shared/{controller=Home}/{action=Index}/{id?}");

app.Run();
