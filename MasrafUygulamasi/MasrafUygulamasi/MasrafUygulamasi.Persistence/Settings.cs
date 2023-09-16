using Microsoft.Extensions.Configuration;

namespace MasrafUygulamasi.Persistence
{
	public static class Settings
    {
        public static string ConnString
        {
            get
            {
                ConfigurationManager configManager = new();
                configManager.AddJsonFile("appsettings.json");
                return configManager.GetConnectionString("MainSQLServer");
            }
        }
    }
}
