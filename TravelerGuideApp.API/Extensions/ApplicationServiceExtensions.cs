using MediatR;
using Microsoft.EntityFrameworkCore;
using TravelerGuideApp.API.Services;
using TravelerGuideApp.Application.Commands;
using TravelerGuideApp.Application.Interfaces;
using TravelerGuideApp.Infrastructure.Database.DatabaseContext;
using TravelerGuideApp.Infrastructure.Repositories;

namespace TravelerGuideApp.API.Extensions
{
    public static class ApplicationServiceExtensions
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services, IConfiguration Configuration)
        {
            services.AddSingleton<ISingletonService, SingletonService>();
            services.AddScoped<IScopedService, ScopedService>();
            services.AddTransient<ITransientService, TransientService>();
            services.AddScoped<ICityRepository, CityRepository>();
            services.AddScoped<ILocationRepository, LocationRepository>();
            services.AddScoped<ITravelItineraryRepository, TravelItineraryRepository>();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<ITravelItineraryLocationsRepository, TravelItineraryLocationsRepository>();
            services.AddScoped<IUserExperience, UserExperienceRepository>();
            services.AddScoped<ITokenService, TokenService>();
            services.AddDbContext<TravelerGuideAppDBContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("Default")));
            services.AddMediatR(typeof(CreateCityCommand));
            services.AddAutoMapper(typeof(Startup));
            return services;
        }
    }
}
