using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Umniah_E_Sport.Application.Contracts.Persistence;
using Umniah_E_Sport.Domain;
using Umniah_E_Sport.Persistence;
using Umniah_E_Sport.Persistence.Repo;
using Umniah_E_Sport.Persistence.Repos;

namespace Umniah_E_Sport.Persistence
{
    public static class PersistenceServiceRegistration
    {
        public static IServiceCollection AddPersistenceServices(this IServiceCollection services, IConfiguration confiuration)
        {
            services.AddDbContext<UmniahContext>(options =>
            options.UseSqlServer(confiuration.GetConnectionString("DefualtConnectionString")));

            services.AddScoped(typeof(IAsyncManager<>), typeof(BaseManager<>));
            services.AddScoped<IArenaManager, ArenaRepo>();

            services.AddScoped<IUserManager, UserRepo>();
            services.AddScoped<IVideoManager, VideoRepo>();
            services.AddScoped<IGameManager, GameRepo>();
            services.AddScoped<INewsManager, NewsRepo>();
            services.AddScoped<ITournamentManager, TournamentRepo>();
            services.AddScoped<ILocationManager, LocationRepo>();
            services.AddScoped<IAchievementManager, AchievementRepo>();
            services.AddScoped<IUserGameManager, UserGameRepo>();
            services.AddScoped<IUserTournamentManager, UserTournamentRepo>();

            services.AddScoped<ITournamentTypeManager, TournamentTypeRepo>();

            services.AddScoped<IUsersTournamentScoresManager, UsersTournamentScoresRepo>();
            services.AddScoped<IBadgeManager, BadgeRepo>();
            services.AddScoped<INotificationLogManager, NotificationLogRepo>();
            services.AddScoped<ISubscriptionManager, SubscriptionRepo>();
            services.AddScoped<ICasualCategoryManager, CasualCategoryRepo>();
            services.AddScoped<ICasualGameManager, CasualGameRepo>();
            services.AddScoped<ICasualGameImagesManager, CasualGameImageRepo>();
            services.Configure<IntegrationConfig>(confiuration.GetSection("IntegrationConfig"));
            return services;
        }

    }
}