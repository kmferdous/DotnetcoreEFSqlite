namespace Transactions.Api
{
    public class ApplicationInitializer
    {
        
        public void Initialize(IConfiguration configuration)
        {
            Infrastructure.Initializer.Initialize(configuration);
        }
    }
}
