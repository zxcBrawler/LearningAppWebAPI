using System.IdentityModel.Tokens.Jwt;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using System.Reflection;
using System.Security.Claims;
using System.Text;
using Coravel;
using LearningAppWebAPI.Data;
using LearningAppWebAPI.Domain.Facade;
using LearningAppWebAPI.Security;
using LearningAppWebAPI.Utils;
using LearningAppWebAPI.Utils.CustomAttributes;
using LearningAppWebAPI.Utils.DatabaseCleanup;
using LearningAppWebAPI.Utils.Job;
using LearningAppWebAPI.Utils.RequestFilter;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;

var builder = WebApplication.CreateBuilder(args);

if (builder.Environment.IsDevelopment())
{
    builder.Configuration.AddJsonFile("appsettings.Development.json", optional: false);
}

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

builder.Services.AddDbContext<AppDbContext>(options =>
{
    options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString));
});


builder.Services.AddControllers(options => 
{
    options.Filters.Add<CurrentUserFilter>();
}).AddJsonOptions(options =>
{
    options.JsonSerializerOptions.ReferenceHandler = System.Text.Json.Serialization.ReferenceHandler.IgnoreCycles;
    
});

builder.Services.Scan(scan => scan
    .FromAssemblyOf<Program>()
    .AddClasses(classes => classes.WithAttribute<ScopedServiceAttribute>())
    .AsSelfWithInterfaces()
    .WithScopedLifetime()
);
builder.Services.AddScoped<UserActionsFacade, UserActionsFacadeImpl>();
builder.Services.AddScoped<ITokenService, TokenService>();
builder.Services.AddScoped<ITokenCleanupService, TokenCleanupService>();

builder.Services.AddScoped<TokenCleanupJob>();
builder.Services.AddScheduler();

var jwtKey = builder.Configuration["Jwt:Key"];
if (string.IsNullOrEmpty(jwtKey) || jwtKey.Length < 32)
    throw new ApplicationException("Key must be at least 32 characters long");

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,
            ValidIssuer = builder.Configuration["Jwt:Issuer"],
            ValidAudience = builder.Configuration["Jwt:Audience"],
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtKey)),
            
        };
        options.Events = new JwtBearerEvents
        {
            OnTokenValidated = async context =>
            {
                if (context.Principal != null)
                {
                    var tokenService = context.HttpContext.RequestServices
                        .GetRequiredService<ITokenService>();
                    
                    var jti = context.Principal.FindFirstValue(JwtRegisteredClaimNames.Jti);
                    var isBlacklisted = jti != null && await tokenService.IsTokenBlacklisted(jti);
                    
                    if (isBlacklisted)
                    {
                        context.Fail("Token revoked");
                    }
                }
            }
        };
    });


builder.Services.AddAuthorization();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.OrderActionsBy((apiDesc) => $"{apiDesc.ActionDescriptor.RouteValues["controller"]}_{apiDesc.HttpMethod}");

    c.EnableAnnotations();
    c.SwaggerDoc("base", new OpenApiInfo
    {
        Title = "LearningAppAPI",
        Version = "base",
        Description = "My New API for CrossPlatform Avalonia English Learning App",
        TermsOfService = new Uri("https://github.com/zxcBrawler"),
        Contact = new OpenApiContact
        {
            Name = "Rindesuu",
            Email = "zxcBrawlerGithub@gmail.com",
            Url = new Uri("https://github.com/zxcBrawler")
        }
    });
    c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        Description = "JWT Authorization header using the Bearer scheme. Enter just the token in the text input below. Example: 'eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJodHRwOi8vc2NoZW1hcy54bWxzb2FwLm9yZy93cy8yMDA1LzA1L2lkZW50aXR5L2NsYWltcy9uYW1laWRlbnRpZmllciI6IjEiLCJodHRwOi8vc2NoZW1hcy54bWxzb2FwLm9yZy93cy8yMDA1LzA1L2lkZW50aXR5L2NsYWltcy9uYW1lIjoidGVzdHVzZXIiLCJodHRwOi8vc2NoZW1hcy54bWxzb2FwLm9yZy93cy8yMDA1LzA1L2lkZW50aXR5L2NsYWltcy9lbWFpbGFkZHJlc3MiOiJ0ZXN0QGV4YW1wbGUuY29tIiwiaHR0cDovL3NjaGVtYXMubWljcm9zb2Z0LmNvbS93cy8yMDA4LzA2L2lkZW50aXR5L2NsYWltcy9yb2xlIjoiVXNlciIsImV4cCI6MTc0MzQ0OTg3NywiaXNzIjoiaHR0cHM6Ly9sb2NhbGhvc3Q6NzA4NyIsImF1ZCI6Imh0dHBzOi8vbG9jYWxob3N0OjcwODcifQ.4ZgfLkqD-lOad4tpdKXf30gKeaXm6PL567XiDRFbkiw'",
        Name = "Authorization",
        In = ParameterLocation.Header,
        Type = SecuritySchemeType.Http,
        Scheme = "Bearer",
        BearerFormat = "JWT"
    });

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
            Array.Empty<string>()
        }
    });

    c.SwaggerDoc("users",
        new OpenApiInfo
        {
            Title = "LearningAppAPI Users", Version = "users",
            Description = "All HTTP Methods needed to interact with users"
        });
    c.SwaggerDoc("admin",
        new OpenApiInfo { Title = "LearningAppAPI Admin", Version = "admin", Description = "Admin Methods" });
    var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
    c.IncludeXmlComments(xmlPath);
});

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/base/swagger.json", "LearningAppAPI base version");
        c.SwaggerEndpoint("/swagger/users/swagger.json", "LearningAppAPI users");
        c.SwaggerEndpoint("/swagger/admin/swagger.json", "LearningAppAPI admin");
        c.InjectStylesheet("/swagger/ui/custom.css");
    });
}
app.Services.UseScheduler(scheduler =>
{
    scheduler.Schedule<TokenCleanupJob>()
        .EveryFifteenMinutes();
});

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseAuthorization();
app.MapControllers();
app.Run();