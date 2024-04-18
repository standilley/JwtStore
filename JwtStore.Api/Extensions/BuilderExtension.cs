using JwtStore.Core;

namespace JwtStore.Api.Extensions
{
    public static class BuilderExtension
    {
        public static void AddConfiguration(this WebApplicationBuilder builder)
        {
            Configuration.Database.ConnectionString =
                builder.Configuration.GetConnectionString("DefaultConnection") ?? string.Empty;
        }
    }
}
