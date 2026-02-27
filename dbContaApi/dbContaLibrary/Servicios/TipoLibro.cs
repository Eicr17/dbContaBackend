using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.Common;
using Oracle.ManagedDataAccess.Client;
using dbContaLibrary.Modelos;
using dbContaLibrary.Interfaces;


namespace dbContaLibrary.Servicios
{    
    public  class TipoLibro : ITipoLibro
    {
        private  readonly IAPPConfiguracion _config;
        public TipoLibro(IAPPConfiguracion pConfig)
        {
            _config = pConfig;  
        }
        public List<MdlTipoLibro> GetList() 
        {

            using (var con = new OracleConnection(_config.CadenaConexion)) 
            {
                var lst = new List<MdlTipoLibro>();
                con.Open();
                var cmd = new OracleCommand("Select Id_Tipo_Libro, Nombre, Descripcion_ Usuario_Creacion, Fecha_Creacion from Tipo_Libro");
                cmd.Connection = con;

                using (IDataReader dr = cmd.ExecuteReader())
                {

                    while (dr.Read())
                    {
                        var item = new MdlTipoLibro();
                        item.IdTipoLibro = int.Parse(dr.GetValue(0).ToString());
                        item.Nombre = dr.GetValue(1).ToString();
                        item.Descripcion = dr.GetValue(2).ToString();
                        item.UsuarioCreacion = dr.GetValue(3).ToString();
                        item.FechaCreacion = DateTime.Parse(dr.GetValue(4).ToString());
                        lst.Add(item);
                    }
                }
                return lst;
            } 
            
        }
        public void InsertTipoLibro(MdlTipoLibroCrear item) 
        {
            using (var con = new OracleConnection(_config.CadenaConexion)) 
            {
                con.Open();
                var cmd = new OracleCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Connection = con;
                cmd.CommandText = "DBCONTA.PRC_GRABAR_TIPO_LIBRO";
                cmd.Parameters.Add(":Id_Tipo_Libro", item.IdTipoLibro);
                cmd.Parameters.Add(":nombre", item.Nombre);
                cmd.Parameters.Add(":descripcion", item.Descripcion);
                cmd.Parameters.Add(":usrc", item.UsuarioCreacion);
                cmd.ExecuteNonQuery();
            }
        }
        


        public void ActualizarTipoLibro(MdlTipoLibroActualizar item)
        {
            using(var con = new OracleConnection(_config.CadenaConexion))
            {
                con.Open();

                var cmd = new OracleCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Connection = con;
                cmd.CommandText = "DBCONTA.PRC_GRABAR_TIPO_LIBRO";
                cmd.Parameters.Add(":Id_Tipo_Libro", item.IdTipoLibro);
                cmd.Parameters.Add(":nombre", item.Nombre);
                cmd.Parameters.Add(":descripcion", item.Descripcion);
                cmd.Parameters.Add(":Usuario_Creacion", item.Usuario_Creacion);
                cmd.ExecuteNonQuery();
            }            

        }

        public void Eliminar(int pId)
        {

            using(var con = new OracleConnection(_config.CadenaConexion)) 
            {
                con.Open();

                var cmd = new OracleCommand();
                cmd.Connection = con;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "DBCONTA.PRC_ELIMINAR_TIPO_LIBRO";
                cmd.Parameters.Add("@id", OracleDbType.Int64).Value = pId;
                cmd.ExecuteNonQuery();
            }
        }
    }



}
