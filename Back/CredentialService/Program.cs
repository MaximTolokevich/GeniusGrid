using Api.Services;
using Api.Services.Interfaces;
using BLL.SqlConnectionStringProviders;
using BLL.SqlConnectionStringProviders.ConfigurationExtensions;
using BLL.SqlConnectionStringProviders.Options;
using BLL.TokenHandler;
using BLL.TokenHandler.Options;
using DAL.Repositories.Implementations;
using DAL.Repositories.Interfaces;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Text;

namespace CredentialService
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            builder.Services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(bearerOptions =>
            {
                var jwtOptions = builder.Configuration.GetSection(nameof(JwtOptions)).Get<JwtOptions>();

                bearerOptions.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    ValidateIssuer = false,
                    ValidateAudience = false,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtOptions.SecretValue)),
                    ValidAlgorithms = jwtOptions.EncryptionAlgorithms
                };
            });
            builder.Services.AddAuthorization(options =>
            {
                options.FallbackPolicy = new AuthorizationPolicyBuilder()
                    .RequireAuthenticatedUser()
                    .Build();
            });
            builder.Services.Configure<SqlConnectionStringOptions>(options => builder.Configuration.BuildSqlConnectionStringOptions(options));
            builder.Services.AddTransient<IRegistrationService, UserRegisterService>();
            builder.Services.AddTransient<ISqlConnectionStringProvider, SqlConnectionStringProvider>();
            builder.Services.AddTransient<IUserAuthenticateService, UserAuthenticateService>();
            builder.Services.AddDbContext<UnitOfWork>((serviceProvider, options) =>
            {
                var connectionStringProvider = serviceProvider.GetService<ISqlConnectionStringProvider>();
                if (connectionStringProvider is null)
                {
                    throw new ArgumentNullException(null, $"{nameof(connectionStringProvider)} can't be null");
                }

                options.UseSqlServer(connectionStringProvider.GetSqlDatabaseConnectionString());
            });
            builder.Services.AddTransient<SecurityTokenHandler, JwtSecurityTokenHandler>()
                    .AddTransient<ISecurityTokenHandler, SecurityTokenHandlerAdapter>();
            builder.Services.AddTransient<IUnitOfWork, UnitOfWork>();
            builder.Services.Configure<JwtOptions>(builder.Configuration.GetSection("JwtOptions"));
            var app = builder.Build();

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
        }
    }
}
