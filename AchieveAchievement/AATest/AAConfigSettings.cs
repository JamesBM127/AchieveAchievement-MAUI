using Microsoft.Extensions.Configuration;

namespace AATest
{
    public static class AAConfigSettings
    {
        public static AchieveAchievementContext GetAndCreateDbContext(DatabaseOptions databaseOptions = DatabaseOptions.InMemoryDatabase,
                                                             string connectionString = "DbNameTeste")
        {
            IServiceCollection service = new ServiceCollection();
            AchieveAchievementContext dbContext = service.EnsureCreateAndGetDbContext<AchieveAchievementContext>
                (connectionString,
                databaseOptions);

            return dbContext;
        }

        public static TEntity GetEntity<TEntity>(this IConfiguration configuration, string section) where TEntity : class, new()
        {
            return configuration.ToCSharp<TEntity>(section);
        }

        public static Account GetAccountWithPlayer(IConfiguration configuration)
        {
            Account account = configuration.GetEntity<Account>("Account");
            account.Player =  configuration.GetEntity<Player>("Player");

            return account;
        }
    }
}
