using System;
using BowlingGame.Service.ObjectOfValues;
using Microsoft.Extensions.Configuration;

namespace BowlingGame.API.Extensions
{
    public static class IConfigurationExtensions
    {
        public static bool DatabaseIsNoSql(this IConfiguration configuration)
        {
            return string.Equals(configuration["Database"], Constants.NoSqlDatabase, StringComparison.CurrentCultureIgnoreCase);
        }
    }
}