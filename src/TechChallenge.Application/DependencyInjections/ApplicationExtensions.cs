using System.Reflection;
using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using TechChallenge.Application.Queries;
using TechChallenge.Application.UseCases.CreateNews;
using TechChallenge.Application.UseCases.CreateUser;

namespace TechChallenge.Application.DependencyInjections;

public static class ApplicationExtensions
{
    public static IServiceCollection AddValidators(this IServiceCollection services)
    {
        services.AddScoped<IValidator<CreateNewsInput>, CreateNewsInputValidator>();
        services.AddScoped<IValidator<CreateUserInput>, CreateUserInputValidator>();

        return services;
    }

    public static IServiceCollection AddQueries(this IServiceCollection services)
    {
        services.AddScoped<INewsQueries, NewsQueries>();

        return services;
    }

    public static IServiceCollection AddUseCases(this IServiceCollection services)
    {
        services.AddMediatR(c => c.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));

        return services;
    }
}