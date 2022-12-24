﻿using Tema.Models.Users.Finder;
using Tema.Models.Users.Seeker;
using Tema.Repositories.CompaniesRepository;
using Tema.Repositories.GenericRepository;
using Tema.Repositories.UsersRepository;
using Tema.Repositories.UsersRepository.FindersRepository;
using Tema.Services.Companies;
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
            services.AddTransient<IGenericRepository<Finder>, GenericRepository<Finder>>();
            services.AddTransient<IGenericRepository<Seeker>, GenericRepository<Seeker>>();
            services.AddTransient<ICompanyRepository, CompanyRepository>();
            return services;
        }
        public static IServiceCollection AddServices(this IServiceCollection services)
        {
            services.AddTransient<IFinderService, FinderService>();
            services.AddTransient<ISeekerService, SeekerService>();
            services.AddTransient<ICompanyService, CompanyService>();
            return services;
        }
    }
}
