using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;

namespace TechChallenge.WebAPI.Security;

public static class SecurityExtensions
{
    public static void AddSecurity(this WebApplicationBuilder builder)
    {
        var securityOptions = new SecurityOptions();

        builder.Configuration
            .GetSection(SecurityOptions.OptionSection)
            .Bind(securityOptions);

        builder.Services.AddScoped(_ => securityOptions);
        builder.Services.AddScoped<SecurityService>();

        var secretKey = Encoding.ASCII.GetBytes(securityOptions.SecretKey);

        builder.Services.AddAuthentication(x =>
        {
            x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
            x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
        })
        .AddJwtBearer(x =>
        {
            x.RequireHttpsMetadata = false;
            x.SaveToken = true;
            x.TokenValidationParameters = new TokenValidationParameters
            {
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = new SymmetricSecurityKey(secretKey),
                ValidateIssuer = false,
                ValidateAudience = false
            };
        });        
    }
}