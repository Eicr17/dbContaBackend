using dbContaLibrary.Interfaces;
using dbContaLibrary.Modelos;
using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dbContaLibrary.Servicios
{
    public class Libro: ILibro
    {
        private readonly IAPPConfiguracion _config;

        public Libro(IAPPConfiguracion pConfig) 
        {
            _config = pConfig;
        }

        public IEnumerable<MdlLibro> Get() 
        {
            using(var con = new OracleConnection(_config.CadenaConexion)) 
            {
                con.Open();
                var cmd = new OracleCommand("Select Id_Libro, Fecha, Folio, Monto, Id_Empresa, Id_Tipo_Libro, Usuario_Creacion, Fecha_Creacion from Libro");
                cmd.Connection = con;
                var lstLibro = new List<MdlLibro>();

                using(var dr = cmd.ExecuteReader())
                {
                    while (dr.Read()) 
                    {
                        var item = new MdlLibro();
                        item.IdLibro = int.Parse(dr.GetValue(0).ToString());
                        item.Fecha = DateTime.Parse(dr.GetValue(1).ToString());
                        item.Folio = int.Parse(dr.GetValue(2).ToString());
                        item.Monto = int.Parse(dr.GetValue(3).ToString());
                        item.IdEmpresa = int.Parse(dr.GetValue(4).ToString());
                        item.IdTipoLibro = int.Parse(dr.GetValue(5).ToString());
                        item.UsuarioCreacion = dr.GetValue(6).ToString();
                        item.FechaCreacion = DateTime.Parse(dr.GetValue(7).ToString());
                        lstLibro.Add(item);
                    }
                    return lstLibro;
                }
                
            
            }
        
        }

    }
}
