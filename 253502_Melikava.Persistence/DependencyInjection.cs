using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _253502_Melikava.Persistence.Repository;
using _253502_Melikava.Persistence.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace _253502_Melikava.Persistence
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddPersistence(this IServiceCollection services)
        {
            services.AddSingleton<IUnitOfWork, EfUnitOfWork>(); //EfUnitOfWork
            return services;
        }
        public static IServiceCollection AddPersistence(this IServiceCollection services,DbContextOptions options)
        {
            services.AddPersistence().AddSingleton<AppDbContext>(new AppDbContext((DbContextOptions<AppDbContext>)options));
            return services;
        }
    }
}
