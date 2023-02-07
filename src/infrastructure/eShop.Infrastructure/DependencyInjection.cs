﻿using eShop.Application.Common.Authentication;
using eShop.Domain.Persistence;
using eShop.Application.Common.Services;
using eShop.Infrastructure.Authentication;
using eShop.Infrastructure.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using eShop.Infrastructure.Persistence.Repositories;
using eShop.Infrastructure.Persistence.Data;
using Microsoft.EntityFrameworkCore;
using eShop.Domain.Common;

namespace eShop.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services,
            ConfigurationManager configuration)
        {
            services.Configure<JwtSettings>(configuration.GetSection(JwtSettings.SectionName));

            services.AddSingleton<IJwtTokenGenerator, JwtTokenGenerator>();
            services.AddSingleton<IDateTimeProvider, DateTimeProvider>();


            services.AddScoped(typeof(IRepository<,>), typeof(EFRepository<,>));
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IProductRepository, ProductRepository>();


            services.AddDbContext<ApplicationDbContext>(options =>
            {
                options.UseSqlServer(configuration.GetConnectionString("Default connection"));
            });

            return services;
        }
    }
}
