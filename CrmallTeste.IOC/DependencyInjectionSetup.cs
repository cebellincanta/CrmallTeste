using CrmallTeste.AppService.Interface;
using CrmallTeste.AppService.Notification;
using CrmallTeste.AppService.Service;
using CrmallTeste.Domain.Interfaces;
using CrmallTeste.Domain.Interfaces.Base;
using CrmallTeste.Infra.Persistence;
using CrmallTeste.Infra.Repositories;
using CrmallTeste.Infra.Repositories.Base;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace CrmallTeste.IOC
{
    public static class DependencyInjectionSetup
    {
        public static void AddDependencyInjectionSetup(IServiceCollection services, IConfiguration configuration)
        {

            services.AddSingleton<ContextFactory>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddDbContext<CrmallContext>(options => options.UseMySQL(configuration.GetConnectionString("DefaultConnection")));
            services.AddScoped(typeof(IRepositoryBase<>), typeof(RepositoryBase<>));
            services.AddScoped<IPersonRepository, PersonalRepository>();
            services.AddScoped<INotifierAppService, NotifierAppService>();
            services.AddTransient<IPersonalAppService, PersonalAppService>();

        }
    }
}
