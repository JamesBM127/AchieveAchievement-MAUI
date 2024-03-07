namespace AATest
{
    public static class AAConfigSettings
    {
        public static AchieveAchievementContext GetAndCreateDbContext(DatabaseOptions databaseOptions = DatabaseOptions.InMemoryDatabase,
                                                             string connectionString = "DbNameTeste")
        {
            //IServiceCollection Service = new ServiceCollection();
            //DbContextOptions<AchieveAchievementContext> dbOptions = 
            //    Service.GetDbContextOptions<AchieveAchievementContext>(databaseOptions, connectionString);

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
    }
}
