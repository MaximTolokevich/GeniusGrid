using Api.Services;
using Api.Services.Interfaces;
using BLL.SqlConnectionStringProviders;
using BLL.SqlConnectionStringProviders.ConfigurationExtensions;
using BLL.SqlConnectionStringProviders.Options;
using BLL.TokenHandler;
using BLL.TokenHandler.Options;
using DAL.Repositories.Implementations;
using DAL.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;

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
            builder.Services.AddAuthentication("Bearer").AddJwtBearer();
            builder.Services.AddAuthorization();
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
