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

        public static IServiceCollection AddTipoArticulo(this IServiceCollection services)
        { 
            services.AddScoped<ITipoArticulo, TipoArticulo>();
            return services;
            
        }


        public static IServiceCollection AddArticulo(this IServiceCollection services)
        {
            services.AddScoped<IArticulo, Articulo>();
            return services;
            
        }

        public static IServiceCollection AddCatDocumento(this IServiceCollection services) 
        {
            services.AddScoped<ICatDocumento, CategoriaDocumento>();
            return services;
        
        }


        public static IServiceCollection AddEmpresa (this IServiceCollection services)
        {
            services.AddScoped<IEmpresa, Empresa>();
            return services;
        }
         
       public static IServiceCollection AddDocumento (this IServiceCollection services)
        {

            services.AddScoped<IDocumento, Documento>();
            return services;
        }

        public static IServiceCollection AddDtDetalle(this IServiceCollection services) 
        {
            services.AddScoped<IDocumentoDetalle, DocumentoDetalle>();
            return services;
        }

        public static IServiceCollection AddGenTipoLibro(this IServiceCollection services) 
        {
            services.AddScoped<IGenTipoLibro, GenerarTipoLibro>();
             return services;
        }

        public static IServiceCollection AddLibroDetalle(this IServiceCollection services) 
        {
            services.AddScoped<ILibroDetalle, LibroDetalle>();
            return services;
        
        }

        public static IServiceCollection AddLibro(this IServiceCollection services) 
        {
            services.AddScoped<ILibro, Libro>();
            return services;
        }

        public static IServiceCollection AddUsuario (this IServiceCollection services) 
        {
            services.AddScoped<IUsuario, Usuario>();
            return services;
        }

        public static IServiceCollection AddRoles (this IServiceCollection services) 
        {

            services.AddScoped<IRoles,Roles>();
            return services;
        }
    }
}
