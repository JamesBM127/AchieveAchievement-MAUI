using JBMDatabase;
using JBMDatabase.Enum;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace AchieveAchievementLibrary.Data
{
    public static class AchieveAchievementDb
    {
        public static async void EnsureCreateDbAsync<TContext>(this IServiceCollection services,
                                                               string connectionString,
                                                               DatabaseOptions databaseOpt = DatabaseOptions.InMemoryDatabase,
                                                               QueryTrackingBehavior trackingBehavior = QueryTrackingBehavior.TrackAll)
                                                                    where TContext : DbContext
        {
            try
            {
            bool created = await services.EnsureCreateAsync<TContext>(connectionString, databaseOpt, trackingBehavior);
            }
            catch (Exception ex)
            {

            }
        }
    }
}
