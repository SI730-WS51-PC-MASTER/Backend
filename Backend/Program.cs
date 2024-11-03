using Backend.Interaction.Application.Internal.CommandServices;
using Backend.Interaction.Application.Internal.QueryServices;
using Backend.Interaction.Domain.Services;
using Backend.Interaction.Infrastructure.Persistence.EFC.Repositories;
using Backend.Shared.Domain.Repositories;
using Backend.Shared.Infrastructure.Persistence.EFC.Configuration;
using Backend.Shared.Infrastructure.Persistence.EFC.Repositories;
using Backend.Shared.Interfaces.ASAP.Configuration;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

//configure Lower Case URLs
builder.Services.AddRouting(options => options.LowercaseUrls = true);

// Configure Kebab Case Route Naming Convention
builder.Services.AddControllers(options => options.Conventions.Add(new KebabCaseRouteNamingConvention()));

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options => options.EnableAnnotations());

/////////////////////////Begin Database Configuration/////////////////////////
// Add DbContext
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

// Verify Database Connection string
if (connectionString is null)
    throw new Exception("Database connection string is not set");

// Configure Database Context and Logging Levels
if (builder.Environment.IsDevelopment())
    builder.Services.AddDbContext<AppDbContext>(
        options =>
        {
            options.UseMySQL(connectionString)
                .EnableSensitiveDataLogging()
                .EnableDetailedErrors();
        });
else if (builder.Environment.IsProduction())
    builder.Services.AddDbContext<AppDbContext>(
        options =>
        {
            options.UseMySQL(connectionString)
                .LogTo(Console.WriteLine, LogLevel.Error)
                .EnableDetailedErrors();
        });

// Configure Dependency Injection

// Shared Bounded Context Injection Configuration
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

// Bounded Context Injection Configuration for Business
/*builder.Services.AddScoped<IFavoriteSourceRepository, FavoriteSourceRepository>();
builder.Services.AddScoped<IFavoriteSourceQueryService, FavoriteSourceQueryService>();
builder.Services.AddScoped<IFavoriteSourceCommandService, FavoriteSourceCommandService>();*/
builder.Services.AddScoped<IReviewComponentRepository, ReviewComponentRepository>();
builder.Services.AddScoped<IReviewComponentQueryService, ReviewComponentQueryService>();
builder.Services.AddScoped<IReviewComponentCommandService, ReviewComponentCommandService>();

builder.Services.AddScoped<IReviewTechnicalSupportRepository, ReviewTechnicalSupportRepository>();
builder.Services.AddScoped<IReviewTechnicalSupportQueryService, ReviewTechnicalSupportQueryService>();
builder.Services.AddScoped<IReviewTechnicalSupportCommandService, ReviewTechnicalSupportCommandService>();

/////////////////////////End Database Configuration/////////////////////////
var app = builder.Build();

// Verify Database Objects are created
using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    var context = services.GetRequiredService<AppDbContext>();
    context.Database.EnsureCreated();
}

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();