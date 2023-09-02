namespace Transactions.Api.Configs
{
    public static class AppConfigurationBuilder
    {
        public static IConfiguration BuildConfiguration(IHostEnvironment env)
        {
            var environmentName = env.EnvironmentName;
            var contentRootPath = env.ContentRootPath;

            var builder = new ConfigurationBuilder()
                .SetBasePath(contentRootPath)
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                .AddJsonFile($"appsettings.{environmentName}.json", optional: true)
                .AddEnvironmentVariables();

            return builder.Build();
        }
    }
}
