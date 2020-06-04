using Microsoft.Extensions.Configuration;

namespace APIAutomationFramework.Support
{
    internal static class TestConfiguration
    {
        private static readonly IConfiguration Configuration;

        static TestConfiguration()
        {
            var builder = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json");

            Configuration = builder.Build();

        }

        public static string GetEnvironment()
        {
            return Configuration.GetSection("EnvironmentSelected")["Environment"];
        }
        public static IConfigurationSection GetEnvironmentInfo()
        {
            var env = GetEnvironment();
            return Configuration.GetSection($@"Environments:{env}");
        }
    }
}
