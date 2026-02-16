using dbContaLibrary.Interfaces;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace dbContaLibrary.Servicios
{
    public class APPConfiguracion : IAPPConfiguracion
    {
        private readonly IConfiguration _config;
        public APPConfiguracion(IConfiguration config)
        {
            _config = config;
        }
        public string CadenaConexion
        {
            get
            {
                return _config["ConnectionStrings:DBCONTA"].ToString();
            }
        }
    }
}
