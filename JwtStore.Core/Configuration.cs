using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JwtStore.Core
{
    public static class Configuration
    {
        public static SecretsConfiguration Secrets { get; set; } = new();
        public static DatabaseConfiguration Database { get; set; } = new();
        public static EmailConfiguration Email { get; set; } = new();
        public static SendGridConfiguration SendGrid { get; set; } = new();
        public class DatabaseConfiguration
        {
            public string ConnectionString { get; set; } = string.Empty;
        }
        public class EmailConfiguration
        {
            public string DefaultFromName { get; set; } = "testando";
            public string DefaultFromEmail { get; set; } = "test@test.com";
        }
        public class SendGridConfiguration
        {
            public string ApiKey { get; set; } = string.Empty;
        }
        public class SecretsConfiguration
        {
            public string ApiKay { get; set; } = string.Empty;
            public string JwtPrivateKey { get; set; } = string.Empty;
            public string PasswordSaltKey { get; set; } = string.Empty;
        } 
    }
}


