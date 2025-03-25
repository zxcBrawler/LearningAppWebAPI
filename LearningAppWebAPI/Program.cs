using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using System.Reflection;
using LearningAppWebAPI.Data;
using LearningAppWebAPI.Domain.Repository;
using LearningAppWebAPI.Domain.Service;

var builder = WebApplication.CreateBuilder(args);


var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

builder.Services.AddDbContext<AppDbContext>(options =>
{
    options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString));
});

builder.Services.AddControllers().AddJsonOptions(options =>
{
    options.JsonSerializerOptions.ReferenceHandler = System.Text.Json.Serialization.ReferenceHandler.IgnoreCycles;
});

builder.Services.AddScoped<UserService>();
builder.Services.AddScoped<RoleService>();
builder.Services.AddScoped<UserCourseService>();
builder.Services.AddScoped<TypeExerciseService>();
builder.Services.AddScoped<CourseService>();
builder.Services.AddScoped<ExerciseService>();
builder.Services.AddScoped<LessonService>();
builder.Services.AddScoped<MultipleChoiceExerciseService>();
builder.Services.AddScoped<OptionService>();
builder.Services.AddScoped<TextAnswerExerciseService>();
builder.Services.AddScoped<TrueFalseExerciseService>();

builder.Services.AddScoped<UserRepository>();
builder.Services.AddScoped<RoleRepository>();
builder.Services.AddScoped<UserCourseRepository>();
builder.Services.AddScoped<TypeExerciseRepository>();
builder.Services.AddScoped<CourseRepository>();
builder.Services.AddScoped<ExerciseRepository>();
builder.Services.AddScoped<LessonRepository>();
builder.Services.AddScoped<MultipleChoiceExerciseRepository>();
builder.Services.AddScoped<OptionRepository>();
builder.Services.AddScoped<TextAnswerExerciseRepository>();
builder.Services.AddScoped<TrueFalseExerciseRepository>();
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
    c.SwaggerDoc("exercises", new OpenApiInfo { Title = "LearningAppAPI Exercises", Version = "exercises", Description = "All HTTP Methods needed to interact with exercises" });
    c.SwaggerDoc("users", new OpenApiInfo { Title = "LearningAppAPI Users", Version = "users", Description = "All HTTP Methods needed to interact with users" });
    c.SwaggerDoc("admin", new OpenApiInfo { Title = "LearningAppAPI Admin", Version = "admin", Description = "Admin Methods" });
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
        c.SwaggerEndpoint("/swagger/exercises/swagger.json", "LearningAppAPI exercises");
        c.SwaggerEndpoint("/swagger/users/swagger.json", "LearningAppAPI users");
        c.SwaggerEndpoint("/swagger/admin/swagger.json", "LearningAppAPI admin");
        c.InjectStylesheet("/swagger/ui/custom.css");
    });
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseAuthorization();
app.MapControllers();
app.Run();

