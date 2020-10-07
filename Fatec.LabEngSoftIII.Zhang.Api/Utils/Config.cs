using Microsoft.Extensions.Configuration;
using System.IO;

namespace Fatec.LabEngSoftIII.Zhang.Api.Utils
{
    public class Config
    {
        public string ConnetionString { get; set; }
        public string Email { get; set; }
        public string SenhaEmail { get; set; }
        public string ChaveCriptografia { get; set; }

        public Config()
        {
            var configuration = new ConfigurationBuilder()
             .SetBasePath(Directory.GetCurrentDirectory())
             .AddJsonFile("appsettings.json")
             .Build();

            this.ConnetionString = configuration["ConnectionString"];
            this.Email = configuration["Email"];
            this.SenhaEmail = configuration["Senha"];
            this.ChaveCriptografia = configuration["ChaveCriptografia"];
        }
    }
}
