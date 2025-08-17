using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using dotnet_admin_dashboard.Data;
using dotnet_admin_dashboard.Domain.Interfaces;
using dotnet_admin_dashboard.Application.Services.Interfaces;
using dotnet_admin_dashboard.Application.Services.Implementations;
using dotnet_admin_dashboard.Infrastructure.Persistence.NoSql.Repositories;
using dotnet_admin_dashboard.Infrastructure.Persistence.AdoNet.Repositories;
using dotnet_admin_dashboard.Infrastructure.Persistence.EfCore.Repositories;
using dotnet_admin_dashboard.Repositories.EfCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo
    {
        Title = "Healthcare Command Center API",
        Version = "v1",
        Description = "API documentation for Healthcare Command Center."
    });
    options.EnableAnnotations();
});

// Enable CORS
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll", policy =>
        policy.AllowAnyOrigin()
              .AllowAnyHeader()
              .AllowAnyMethod()
    );
});

// Dependency Injection for repositories and services
// Repositories (EF Core, and AdoNet)
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<ICareGiverRepository, CareGiverRepository>();
builder.Services.AddScoped<IDoctorRepository, DoctorRepository>();
builder.Services.AddScoped<IEquipmentRepository, EquipmentRepository>();
builder.Services.AddScoped<INurseRepository, NurseRepository>();
builder.Services.AddScoped<IPatientRepository, PatientRepository>();
builder.Services.AddScoped<ISupplyRepository, SupplyRepository>();
builder.Services.AddScoped<IUserAccountRepository, UserAccountRepository>();
// ...add for all other entities as needed...

// Services (DTO and Model/Mongo)
builder.Services.AddScoped<ICareGiverService, CareGiverService>();
builder.Services.AddScoped<IDoctorService, DoctorService>();
builder.Services.AddScoped<IEquipmentService, EquipmentService>();
builder.Services.AddScoped<INurseService, NurseService>();
builder.Services.AddScoped<IPatientService, PatientService>();
builder.Services.AddScoped<ISupplyService, SupplyService>();
builder.Services.AddScoped<IUserAccountService, UserAccountService>();
builder.Services.AddScoped<IUserService, UserService>();
// ...add for all other entities as needed...

var app = builder.Build();

// Enable Swagger UI in all environments
app.UseSwagger();
app.UseSwaggerUI(options =>
{
    options.SwaggerEndpoint("/swagger/v1/swagger.json", "Healthcare Command Center API v1");
    options.RoutePrefix = string.Empty; // Swagger UI at root
});

app.UseCors("AllowAll");
app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();
