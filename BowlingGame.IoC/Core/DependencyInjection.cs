using BowlingGame.Data.AzureCosmos.Context;
using BowlingGame.Data.SqlServer.Context;
using BowlingGame.Service.Interfaces;
using BowlingGame.Service.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace BowlingGame.Infra.IoC.Core
{
    public static class DependencyInjection
    {
        public static void AddDependencyInjection(this IServiceCollection services)
        {
            services.AddScoped<IGameService, GameService>();
            services.AddScoped<IScoreService, ScoreService>();
            services.AddScoped<IRollService, RollService>();
        }

        public static void AddSqlServerDependencyInjection(this IServiceCollection services, IConfiguration configuration)
        {
            
            services.AddScoped<IGameRepository, Data.SqlServer.Repository.GameRepository>();

            services.AddDbContext<SqlServerContext>(options =>
            {
                options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"));
            });

            services.AddScoped<SqlServerContext>();
        }

        public static void AddAzureCosmosDependencyInjection(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<IGameRepository, Data.AzureCosmos.Repository.GameRepository>();

            services.AddDbContext<AzureCosmosContext>(options =>
            {
                options.UseCosmos(configuration["AzureCosmosDb:EndPoint"],
                                  configuration["AzureCosmosDb:AccountKey"],
                                  configuration["AzureCosmosDb:Database"]);
            });

            services.AddScoped<AzureCosmosContext>();
        }
    }
}