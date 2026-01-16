/// --------------------------------------------------
/// Application: WebApiBoilerplate
/// Project: DotNet-WebAPI-Boilerplate
/// File name: Program.cs
/// File Description: The entry point
/// Author: Alessio Giacché (ale.giacc.dev@gmail.com)
/// License: MIT
/// --------------------------------------------------

#region Using directives

using WebApiBoilerplate.Models.EFC;
using WebApiBoilerplate.Repositories.Category;
using WebApiBoilerplate.Repositories.Category.Interfaces;
using WebApiBoilerplate.Services.Category;
using WebApiBoilerplate.Services.Category.Interfaces;
using WebApiBoilerplate.Helpers;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi;
using WebApiBoilerplate.Mappers;

#endregion Using directives

// Build builder
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();

// Add database context
builder.Services.AddDbContext<ApplicationDbContext>(options =>
{
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection"));
});

// Register repositories
builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();

// Register services
builder.Services.AddScoped<ICategoryService, CategoryService>();

// Register mappers
builder.Services.AddSingleton<CategoryMapper>();

// Register HttpClient for external API calls
builder.Services.AddHttpClient();

// Swagger initialization
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    // Define the API info
    c.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "WebApiBoilerplate API",
        Version = "v1",
        Description = "WebApiBoilerplate API Documentation"
    });
});

// Add CORS
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAllOrigins", policy =>
    {
        policy.AllowAnyOrigin()
              .AllowAnyMethod()
              .AllowAnyHeader();
    });
});

var app = builder.Build();

// Test database connection at startup
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
var logger = LoggerFactory.Create(logging => logging.AddConsole()).CreateLogger("ConnectionTester");
await ConnectionTester.TestNeonAsync(connectionString, logger);

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "WebApiBoilerplate API v1");
        c.RoutePrefix = "swagger";
    });
    app.UseDeveloperExceptionPage();
}

// Some app configuration
app.UseHttpsRedirection();
app.UseCors("AllowAllOrigins");

// Use Authentication & Authorization
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();
app.Run();
