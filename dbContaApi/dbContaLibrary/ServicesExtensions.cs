using dbContaLibrary.Interfaces;
using dbContaLibrary.Servicios;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dbContaLibrary
{
    public static class ServicesExtensions
    {
        public static IServiceCollection AddAPPConfiguration(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddSingleton<IAPPConfiguracion, APPConfiguracion>();            
            return services;
        }

        public static IServiceCollection AddTipoLibro(this IServiceCollection services)
        {            
            services.AddScoped<ITipoLibro, TipoLibro>()  ;
            return services;
        }

        public static IServiceCollection AddTipoDocumento(this IServiceCollection services) 
        {
            services.AddScoped<ITipoDocumento, TipoDocumento>();
            return services;
        }
    }
}
