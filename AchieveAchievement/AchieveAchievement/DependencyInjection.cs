using AchieveAchievement.View;
using AchieveAchievement.ViewModel;

namespace AchieveAchievement
{
    public static class DependencyInjection
    {
        public static void AADependencyInjection(this IServiceCollection services)
        {
            services.AddScoped<LoginViewModel>();

            services.AddSingleton<LoginPage>();
        }
    }
}
