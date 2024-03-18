using AchieveAchievementLibrary.Data;
using JBMDatabase;
using JBMDatabase.Enum;
using Microsoft.Extensions.Logging;

namespace AchieveAchievement
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                });

#if DEBUG
            builder.Logging.AddDebug();
#endif

            string connectionString = ConnectionStringSettings.GetSqliteConnectionString("aatest");
            //string connectionString = "server=.;database=aadbtest;trustservercertificate=true;trusted_connection=true;integrated security=true;";
            try
            {
                builder.Services.EnsureCreateAsync<AchieveAchievementContext>
                (connectionString, DatabaseOptions.Sqlite);
                //builder.Services.JustAddDbContext<AchieveAchievementContext>
                //    (connectionString, DatabaseOptions.SqlServer);
            }
            catch (Exception ex)
            {

            }

            builder.Services.AADependencyInjection();

            return builder.Build();
        }
    }
}
