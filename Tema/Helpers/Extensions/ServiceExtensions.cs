using Tema.Repositories.GenericRepository;
using Tema.Repositories.UsersRepository;
using Tema.Repositories.UsersRepository.FindersRepository;
using Tema.Repositories.UsersRepository.GenericUsersRepository;
using Tema.Services.Finders;
using Tema.Services.Seekers;

namespace Tema.Helpers.Extensions
{
    public static class ServiceExtensions
    {
        public static IServiceCollection AddRepositories(this IServiceCollection services)
        {
            services.AddTransient<IFindersRepository, FindersRepository>();
            services.AddTransient<ISeekersRepository, SeekersRepository>();
            return services;
        }
        public static IServiceCollection AddServices(this IServiceCollection services)
        {
            services.AddTransient<IFinderService, FinderService>();
            services.AddTransient<ISeekerService, SeekerService>();
            return services;
        }
    }
}
