using System;
using Microsoft.Extensions.Configuration;

namespace BowlingGame.API.Extensions
{
    public static class IConfigurationExtensions
    {
        public static bool DatabaseIsNoSql(this IConfiguration configuration)
        {
            return string.Equals(configuration["Database"], "nosql", StringComparison.CurrentCultureIgnoreCase);
        }
    }
}