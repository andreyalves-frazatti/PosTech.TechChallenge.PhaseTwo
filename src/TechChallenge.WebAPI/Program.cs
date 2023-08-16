using Microsoft.EntityFrameworkCore;
using TechChallenge.Application.DependencyInjections;
using TechChallenge.Infrastructure;
using TechChallenge.Infrastructure.DependecyInjections;
using TechChallenge.WebAPI.Security;
using TechChallenge.WebAPI.Swagger;

var builder = WebApplication.CreateBuilder(args);

builder.AddSecurity();

var connectionString = builder
  .Configuration
  .GetConnectionString("SqlConnectionString");

builder.Services.AddDbContext<DatabaseContext>(options => options.UseSqlServer(connectionString));

builder.Services.AddRepositories();
builder.Services.AddQueries();
builder.Services.AddValidators();
builder.Services.AddUseCases();

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(_ =>
{
  _.ConfigureSwaggerDoc();
  _.EnableAnnotations();
  _.ConfigureSwaggerSecurityScheme();
});

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();

app.Run();