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
    public class TipoArticulo: ITipoArticulo
    {
        private readonly IAPPConfiguracion _config;
        public TipoArticulo(IAPPConfiguracion pconfig) 
        {
            _config = pconfig;
        }
        public List<MdlTipoArticulo> GetList()
        {

            using (var con = new OracleConnection(_config.CadenaConexion))
            {

                var lst = new List<MdlTipoArticulo>();
                con.Open();


                var cmd = new OracleCommand();
                cmd.Connection = con;
                cmd.CommandText = "Select Id_Tipo_Articulo, Nombre, Descripcion, Fecha_Creacion, Usuario_Creacion from Tipo_Articulo";

                using(IDataReader dr = cmd.ExecuteReader()) 
                {
                    while (dr.Read()) 
                    {
                        var item = new MdlTipoArticulo();
                        item.IdTipoArticulo = int.Parse(dr.GetValue(0).ToString());
                        item.Nombre = dr.GetValue(1).ToString();
                        item.Descripcion = dr.GetValue(2).ToString();
                        item.FechaCreacion = DateTime.Parse(dr.GetValue(3).ToString());
                        item.UsuarioCreacion = dr.GetValue(4).ToString();
                        lst.Add(item);
                 }

                }

                return lst;
            }


        }

        public void InsertarTpArticulo(MdlTipoArticuloCrear item)
        {
            using (var con = new OracleConnection(_config.CadenaConexion)) 
            {
                con.Open();
                var cmd = new OracleCommand();
                cmd.Connection = con;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "DBCONTA.PRC_GRABAR_TIPO_ARTICULO";
                cmd.Parameters.Add(":id", item.IdTipoArticulo);
                cmd.Parameters.Add(":nombre", item.Nombre);
                cmd.Parameters.Add(":descripcion", item.Descripcion);
                cmd.Parameters.Add(":usuariocreacion", item.UsuarioCreacion);
                cmd.ExecuteNonQuery();
            }
                     
        
        }



        public void ActualizarTpDoc(MdlTipoArticuloAct item)
        {
            using (var con = new OracleConnection(_config.CadenaConexion))
            {
                con.Open();
                var cmd = new OracleCommand();
                cmd.Connection = con;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "DBCONTA.PRC_GRABAR_TIPO_ARTICULO";
                cmd.Parameters.Add(":id", item.IdTipoArticulo);
                cmd.Parameters.Add(":nombre", item.Nombre);
                cmd.Parameters.Add(":descripcion", item.Descripcion);
                cmd.Parameters.Add("usrcreacion", item.UsuarioCreacion);
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
                cmd.CommandText = "DBCONTA.PRC_ELIMINAR_TIPO_Articulo";
                cmd.Parameters.Add(":id", OracleDbType.Int64).Value = pId;
                cmd.ExecuteNonQuery();
            }


        }
    }
}
    