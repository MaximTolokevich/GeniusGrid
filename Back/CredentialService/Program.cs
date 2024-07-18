using BLL.SqlConnectionStringProviders.Options;
using BLL.SqlConnectionStringProviders.ConfigurationExtensions;
using BLL.SqlConnectionStringProviders;
using DAL.Repositories.Implementations;
using Microsoft.EntityFrameworkCore;

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
            builder.Services.AddTransient<ISqlConnectionStringProvider, SqlConnectionStringProvider>();
            builder.Services.AddDbContext<UnitOfWork>((serviceProvider, options) =>
            {
                var connectionStringProvider = serviceProvider.GetService<ISqlConnectionStringProvider>();
                if (connectionStringProvider is null)
                {
                    throw new ArgumentNullException(null, $"{nameof(connectionStringProvider)} can't be null");
                }

                options.UseSqlServer(connectionStringProvider.GetSqlDatabaseConnectionString());
            });
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
