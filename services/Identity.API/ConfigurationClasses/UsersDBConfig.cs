namespace Identity.API.ConfigurationClasses
{
    using Identity.API.Models.Implementation;
    using Microsoft.Extensions.Configuration;
    public class UsersDBConfig
    {
        private readonly IConfiguration _config;

        public UsersDBConfig(IConfiguration config)
        {
           _config = config;
        }


        public void OnGet()
        {
            var mongoConfig = new MongoConfig();
            var mongoSettingSection = _config.GetSection("MongoProps");
            mongoSettingSection.Bind(mongoConfig);
        }
    }
}