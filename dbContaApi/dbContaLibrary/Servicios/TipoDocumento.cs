using dbContaLibrary.Interfaces;
using dbContaLibrary.Modelos;
using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace dbContaLibrary.Servicios
{
    public class TipoDocumento : ITipoDocumento
    {
        private readonly IAPPConfiguracion _config;
        public TipoDocumento(IAPPConfiguracion pConfig)
        {
            _config = pConfig;
        }

        public List<MdlTipoDocumento> GetList()
        {
            using (var con = new OracleConnection(_config.CadenaConexion))
            {

                var lst = new List<MdlTipoDocumento>();
                con.Open();

                var cmd = new OracleCommand();
                cmd.Connection = con;
                cmd.CommandText = "Select * from tipo_documento";

                using (IDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        var item = new MdlTipoDocumento();
                        item.IdTipoDocumento = int.Parse(dr.GetValue(0).ToString());
                        item.Nombre = dr.GetValue(1).ToString();
                        item.Descripcion = dr.GetValue(2).ToString();
                        item.UsuarioCreacion = dr.GetValue(3).ToString();
                        item.FechaCreacion = DateTime.Parse(dr.GetValue(4).ToString());
                        //item.IdCategoriaDocumento = int.Parse(dr.GetValue(5).ToString());
                        lst.Add(item);
                    }


                }
                return lst;
            }

        }


        public void InsertarTipoDoc(MdlTipoDocCrear item)
        {
            using (var con = new OracleConnection(_config.CadenaConexion))
            {

                con.Open();
                var cmd = new OracleCommand();
                cmd.Connection = con;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "DBCONTA.PRC_GRABAR_TIPO_DOCUMENTO";
                cmd.Parameters.Add("id:", item.IdTipoDocumento);
                cmd.Parameters.Add(":nombre", item.Nombre);
                cmd.Parameters.Add(":descripcion", item.Descripcion);
                cmd.Parameters.Add(":usuario_creacion", item.UsuarioCreacion);
                cmd.Parameters.Add(":idcat", item.IdCategoriaDocumento);
                cmd.ExecuteNonQuery();
            }
        }


        public void ActualizarTpDoc(MdlTpDocActualizar item)
        {
            using (var con = new OracleConnection(_config.CadenaConexion))
            {
                con.Open(); 
                var cmd = new OracleCommand();
                cmd.Connection = con;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "DBCONTA.PRC_GRABAR_TIPO_DOCUMENTO";
                cmd.Parameters.Add(":id", item.IdTipoDocumento); 
                cmd.Parameters.Add(":nombre", item.Nombre);
                cmd.Parameters.Add(":descripcion", item.Descripcion);
                cmd.Parameters.Add("usrcreacion", item.UsuarioCreacion);
                cmd.Parameters.Add("idcatdoc", item.IdCategoriaDocumento);
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
                cmd.CommandText = "DBCONTA.PRC_ELIMINAR_TIPO_DOCUMENTO";
                cmd.Parameters.Add(":id", OracleDbType.Int64).Value = pId;
                cmd.ExecuteNonQuery();
            }
        
        
        }
    }
}
