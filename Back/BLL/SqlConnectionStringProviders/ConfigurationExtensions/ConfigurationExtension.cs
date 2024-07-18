using BLL.SqlConnectionStringProviders.Options;
using Microsoft.Extensions.Configuration;

namespace BLL.SqlConnectionStringProviders.ConfigurationExtensions
{
    public static class ConfigurationExtension
    {
        public static void BuildSqlConnectionStringOptions(this IConfigurationManager configuration, SqlConnectionStringOptions options)
        {
            options.DataSource = configuration[ConfigurationKeys.DataSource];
            options.InitialCatalog = configuration[ConfigurationKeys.InitialCatalog];
            options.UserId = configuration[ConfigurationKeys.UserId];
            options.Password = configuration[ConfigurationKeys.Password];
        }
    }
}
