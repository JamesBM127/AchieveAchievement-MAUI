using AchieveAchievement.Data;
using AchieveAchievement.View;
using AchieveAchievement.ViewModel;
using AchieveAchievementLibrary.Data;

namespace AchieveAchievement
{
    public static class DependencyInjection
    {
        public static void AADependencyInjection(this IServiceCollection services)
        {
            services.AddScoped<AchieveAchievementContext>();
            services.AddScoped<IAAUoW, AAUoW>();

            services.AddScoped<LoginViewModel>();

            services.AddSingleton<LoginPage>();
        }
    }
}
