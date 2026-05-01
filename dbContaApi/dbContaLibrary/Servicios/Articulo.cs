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
        public IEnumerable<MdlArticulo> Get(int IdArt, string Nombre)
        {
            using (var con = new OracleConnection(_config.CadenaConexion))
            {
                con.Open();
                var lst = new List<MdlArticulo>();
             
                string cadena = "select Id_Articulo, Id_Tipo_Articulo,Nombre,Descripcion,Usuario_Creacion,Fecha_Creacion from Articulo Where 1 = 1";
                if (IdArt != 0 )
                {
                    cadena += $"and id_Articulo = {IdArt}";
                }

                if (!string.IsNullOrEmpty(Nombre))
                {
                    cadena += $"and (upper(trim (nombre))  like '%{Nombre.ToUpper().Trim()}%' )";
                }

                var cmd = new OracleCommand(cadena);
                cmd.Connection = con;

                using (IDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        var item = new MdlArticulo();
                        item.IdArticulo = int.Parse(dr.GetValue(0).ToString());
                        item.IdTipoArticulo = int.Parse(dr.GetValue(1).ToString());
                        item.Nombre = dr.GetValue(2).ToString();
                        item.Descripcion = dr.GetValue(3).ToString();
                        item.UsuarioCreacion = dr.GetValue(4).ToString();
                        item.FechaCreacion = dr.GetValue(5).ToString();
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
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "DBCONTA.PRC_GRABAR_ARTICULO";
                cmd.Parameters.Add(":id", item.IdArticulo);
                cmd.Parameters.Add(":idtp", item.IdTipoArticulo);
                cmd.Parameters.Add(":nombre", item.Nombre);
                cmd.Parameters.Add(":desc", item.Descripcion);
                cmd.Parameters.Add(":usr", item.UsuarioCreacion);
                cmd.ExecuteNonQuery();

            }

        }

        public void Eliminar(int pIdArt, int pIdTpArt)
        {

            using (var con = new OracleConnection(_config.CadenaConexion))
            {
                con.Open();
                var cmd = new OracleCommand();
                cmd.Connection = con;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "DBCONTA.PRC_ELIMINAR_ARTICULO";
                cmd.Parameters.Add(":idArt", OracleDbType.Int64).Value = pIdArt;
                cmd.Parameters.Add(":idTpArt", OracleDbType.Int64).Value = pIdTpArt;

                cmd.ExecuteNonQuery();

            }

        }

    }
}
