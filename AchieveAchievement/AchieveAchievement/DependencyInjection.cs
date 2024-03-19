using AchieveAchievement.Data;
using AchieveAchievement.ViewModel;
using AchieveAchievement.ViewPage;
using AchieveAchievementLibrary.Data;

namespace AchieveAchievement
{
    public static class DependencyInjection
    {
        public static void AADependencyInjection(this IServiceCollection services)
        {
            services.AddScoped<AchieveAchievementContext>();
            services.AddScoped<IAAUoW, AAUoW>();

            services.AddScoped<AppShellViewModel>();
            services.AddScoped<LoginViewModel>();
            services.AddScoped<AppShellViewModel>();
            services.AddScoped<SettingsViewModel>();

            services.AddSingleton<LoginDesktopPage>();
            services.AddSingleton<LoginMobilePage>();
            services.AddSingleton<InitialPage>();
            services.AddSingleton<SettingsPage>();
        }
    }
}
