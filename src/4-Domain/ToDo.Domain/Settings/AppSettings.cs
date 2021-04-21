
using Microsoft.Extensions.Configuration;

namespace ToDo.Domain.Settings
{
    public class AppSettings
    {
        public string ApiCoutries { get; private set; }
        public string ConnectionStringDefault { get; private set; }
        public string ClientId { get; private set; }
        public JWTSettings JWTSettings { get; private set; }
        
        public AppSettings(IConfiguration configuration)
        {
            ApiCoutries = configuration["ApiCoutries:EndPoint"];
            ConnectionStringDefault = configuration["ConnectionString:Default"];
            ClientId = configuration.GetSection("Authentication:Google")["ClientId"];
            JWTSettings = new JWTSettings(configuration);
        }
    }
}