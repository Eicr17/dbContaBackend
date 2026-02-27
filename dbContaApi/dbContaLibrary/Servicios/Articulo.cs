using dbContaLibrary.Interfaces;
using dbContaLibrary.Modelos;
using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace dbContaLibrary.Servicios
{
    public class Articulo : IArticulo
    {

        private readonly IAPPConfiguracion _config;

        public Articulo(IAPPConfiguracion pConfig) 
        {
            _config = pConfig;
        }
        public List<MdlArticulo> Get() 
        {
            using (var con = new OracleConnection(_config.CadenaConexion))
            {
                con.Open();
                var lst = new List<MdlArticulo>();
                var cmd = new OracleCommand("Select Id_Articulo, Id_Tipo_Articulo,Nombre,Descripcion,Usuario_Creacion,Fecha_Creacion from Articulo");
                cmd.Connection = con;

                using ( IDataReader  dr = cmd.ExecuteReader()) 
                {
                    while (dr.Read())
                    {
                        var item = new MdlArticulo();
                        item.IdArticulo = int.Parse(dr.GetValue(0).ToString());
                        item.IdTipoArticulo = int.Parse(dr.GetValue(1).ToString());
                        item.Nombre = dr.GetValue(2).ToString();
                        item.Descripcion = dr.GetValue(3).ToString();   
                        item.UsuarioCreacion = dr.GetValue(4).ToString();
                        item.FechaCreacion = DateTime.Parse(dr.GetValue(5).ToString());
                        lst.Add(item);
                    }
                }
                return lst;
            }

           
        
        }


        public void InsertarArticulo(MdlArticuloCrear item) 
        {
            using (var con = new OracleConnection(_config.CadenaConexion))
            {
                con.Open();
                var cmd = new OracleCommand();
                cmd.Connection = con;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "DBCONTA.PRC_GRABAR_ARTICULO";
                cmd.Parameters.Add(":id", item.IdArticulo);
                cmd.Parameters.Add(":idtipo", item.IdTipoArticulo);
                cmd.Parameters.Add(":nombre", item.Nombre);
                cmd.Parameters.Add(":desc", item.Descripcion);
                cmd.Parameters.Add(":usc", item.UsuarioCreacion);
                cmd.ExecuteNonQuery();   
            }
        }

        public void ActualizarArticulo(MdlArticuloActualizar item) 
        {

            using (var con = new OracleConnection(_config.CadenaConexion))
            {
                con.Open();
                var cmd = new OracleCommand();
                cmd.Connection = con;
                cmd.Parameters.Add(":id", item.IdArticulo);
                cmd.Parameters.Add(":idtp", item.IdTipoArticulo);
                cmd.Parameters.Add(":nombre", item.Nombre);
                cmd.Parameters.Add(":desc", item.Descripcion);
                cmd.Parameters.Add(":usr", item.UsuarioCreacion);
                cmd.ExecuteNonQuery();
               
            }
        
        }

        public void Eliminar(int pId) 
        {

            using (var con = new OracleConnection(_config.CadenaConexion)) 
            {
                con.Open();
                var cmd = new OracleCommand();
                cmd.Connection = con;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "DBCONTA.PRC_ELIMINAR_ARTICULO";
                cmd.Parameters.Add(":id", OracleDbType.Int64).Value = pId;
                cmd.ExecuteNonQuery();
           
            }
        
        }

    }
}
