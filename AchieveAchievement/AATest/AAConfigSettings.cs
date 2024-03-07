namespace AATest
{
    public static class AAConfigSettings
    {
        public static AchieveAchievementContext GetDbContext()
        {
            IServiceCollection Service = new ServiceCollection();
            DbContextOptions<AchieveAchievementContext> dbOptions = 
                Service.GetDbContextOptions<AchieveAchievementContext>(DatabaseOptions.InMemoryDatabase, "DbNameTeste");

            return new(dbOptions);
        }

        public static TEntity GetEntity<TEntity>(this IConfiguration configuration, string section) where TEntity : class, new()
        {
            return configuration.ToCSharp<TEntity>(section);
        }
    }
}
