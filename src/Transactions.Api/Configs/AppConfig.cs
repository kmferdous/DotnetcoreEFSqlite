namespace Transactions.Api.Configs
{
    public class AppConfig : IAppConfig
    {
        private readonly IConfiguration configuration;
        private readonly IHostEnvironment hostEnvironment;

        public AppConfig(IConfiguration configuration, IHostEnvironment hostEnvironment)
        {
            this.configuration = configuration;
            this.hostEnvironment = hostEnvironment;
        }

        public string DbServer => configuration.GetValue<string>(nameof(DbServer));

        public string DbName => configuration.GetValue<string>(nameof(DbName));
    }
}
