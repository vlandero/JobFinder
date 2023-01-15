using Tema.Helpers.JwtHelpers;
using Tema.Models.Companies;
using Tema.Models.Jobs;
using Tema.Models.Users.BaseUser;
using Tema.Models.Users.Finder;
using Tema.Models.Users.Seeker;
using Tema.Repositories.CompaniesRepository;
using Tema.Repositories.GenericRepository;
using Tema.Repositories.JobsRepository;
using Tema.Repositories.UsersRepository;
using Tema.Repositories.UsersRepository.FindersRepository;
using Tema.Repositories.UsersRepository.GenericUsersRepository;
using Tema.Services.Applicants;
using Tema.Services.Companies;
using Tema.Services.Finders;
using Tema.Services.Jobs;
using Tema.Services.Seekers;
using Tema.Services.Users;

namespace Tema.Helpers.Extensions
{
    public static class ServiceExtensions
    {
        public static IServiceCollection AddRepositories(this IServiceCollection services)
        {
            services.AddTransient<IFindersRepository, FindersRepository>();
            services.AddTransient<ISeekersRepository, SeekersRepository>();
            services.AddTransient<IGenericRepository<Finder>, GenericRepository<Finder>>();
            services.AddTransient<IGenericRepository<Seeker>, GenericRepository<Seeker>>();
            services.AddTransient<IGenericRepository<Company>, GenericRepository<Company>>();
            services.AddTransient<IGenericRepository<User>, GenericRepository<User>>();
            services.AddTransient<IGenericRepository<Job>, GenericRepository<Job>>();
            services.AddTransient<IGenericUsersRepository<Seeker>, GenericUsersRepository<Seeker>>();
            services.AddTransient<IGenericUsersRepository<Finder>, GenericUsersRepository<Finder>>();
            services.AddTransient<IGenericUsersRepository<User>, GenericUsersRepository<User>>();
            services.AddTransient<ICompanyRepository, CompanyRepository>();
            services.AddTransient<IJobsRepository, JobsRepository>();
            services.AddTransient<IApplicantService, ApplicantService>();
            return services;
        }
        public static IServiceCollection AddServices(this IServiceCollection services)
        {
            services.AddTransient<IFinderService, FinderService>();
            services.AddTransient<ISeekerService, SeekerService>();
            services.AddTransient<IUserService<Finder>, UserService<Finder>>();
            services.AddTransient<IUserService<Seeker>, UserService<Seeker>>();
            services.AddTransient<IUserService<User>, UserService<User>>();
            services.AddTransient<ICompanyService, CompanyService>();
            services.AddTransient<IJobService, JobService>();
            return services;
        }
        public static IServiceCollection AddUtils(this IServiceCollection services)
        {
            services.AddScoped<IJwtHelpers<User>, JwtHelpers<User>>();
            services.AddScoped<IJwtHelpers<Seeker>, JwtHelpers<Seeker>>();
            services.AddScoped<IJwtHelpers<Finder>, JwtHelpers<Finder>>();

            return services;
        }
    }
}
