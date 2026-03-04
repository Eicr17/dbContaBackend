using dbContaLibrary.Interfaces;
using dbContaLibrary.Modelos;
using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dbContaLibrary.Servicios
{
    public class GenerarTipoLibro : IGenTipoLibro
    {
        private readonly IAPPConfiguracion _config;

        public GenerarTipoLibro(IAPPConfiguracion pconfig) 
        {
            _config = pconfig;
        }

       public void Insertar(MdlGenTipoLibro item) 
        {
            using (var con = new OracleConnection(_config.CadenaConexion))
            {
                con.Open();
                var cmd = new OracleCommand();
                cmd.Connection = con;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "PRC_Generar_Tipo_Libro";
                cmd.Parameters.Add(":folio" , item.Folio);
                cmd.Parameters.Add(":Empresa", item.Empresa);
                cmd.Parameters.Add(":TipoLibro", item.TipoLibro);
                cmd.Parameters.Add(":Usuario", item.Usuario);
                cmd.Parameters.Add(":AnioLibro", item.AnioLibro);
                cmd.Parameters.Add(":MesLibro", item.MesLibro);
                cmd.Parameters.Add(":IdLibro", item.IdLibro);
                 
                cmd.ExecuteNonQuery();
            }
        }
    }
}
