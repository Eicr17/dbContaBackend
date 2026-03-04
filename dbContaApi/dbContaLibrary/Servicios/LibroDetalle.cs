using dbContaLibrary.Interfaces;
using dbContaLibrary.Modelos;
using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing.Imaging;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace dbContaLibrary.Servicios
{
    public class LibroDetalle: ILibroDetalle
    {
        private readonly IAPPConfiguracion _config;

        public LibroDetalle(IAPPConfiguracion pconfig) 
        {
            _config = pconfig;
        }

        public IEnumerable<MdlLibroDetalle> Obtener()
        {
            using (var con = new OracleConnection(_config.CadenaConexion)) 
            {
                con.Open();
                var cmd = new OracleCommand("Select Id_Libro_Detalle, Id_Libro, Fecha, Numero,Serie,Tipo_Documento, Usuario_Creacion,Fecha_Creacion from Libro_Detalle");
                cmd.Connection = con;
                var lstLibroDetalle = new List<MdlLibroDetalle>();

                using (var dr = cmd.ExecuteReader()) 
                {
                    while (dr.Read()) 
                    {
                        var item = new MdlLibroDetalle();
                        item.IdLibroDetalle = int.Parse(dr.GetValue(0).ToString());
                        item.IdLibro = int.Parse(dr.GetValue(1).ToString());
                        item.Fecha = DateTime.Parse(dr.GetValue(2).ToString());
                        item.Numero = dr.GetValue(3).ToString();
                        item.Serie = int.Parse(dr.GetValue(4).ToString());
                        item.TipoDocumento = int.Parse(dr.GetValue(5).ToString());
                        item.UsuarioCreacion = dr.GetValue(6).ToString();
                        lstLibroDetalle.Add(item);
                    
                    }
                
                }

                return lstLibroDetalle;
            
            }
        
        }


        public void Eliminar(int pIdlibroDetalle,int pIdLibro) 
        {
            using (var con = new OracleConnection(_config.CadenaConexion)) 
            {
                con.Open();
                var cmd = new OracleCommand();
                cmd.Connection = con;

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText  = "PRC_ELIMINAR_LIBRO_DETALLE";
                cmd.Parameters.Add(":pIdLibroDetalle", OracleDbType.Int64).Value = pIdlibroDetalle;
                cmd.Parameters.Add(":pIdLibro", OracleDbType.Int64).Value = pIdLibro;
                cmd.ExecuteNonQuery();                    
            }
        }
    }
}
