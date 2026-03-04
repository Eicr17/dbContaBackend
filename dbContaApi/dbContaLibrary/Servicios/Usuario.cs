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
    public class Usuario : IUsuario
    {
        private readonly IAPPConfiguracion _config;

        public Usuario(IAPPConfiguracion pconfig) 
        {

            _config = pconfig;
        }


        public IEnumerable<MdlUsuario> GetUsuario()
        {
            using (var con = new OracleConnection(_config.CadenaConexion))
            {
                con.Open();
                var lstUsuario = new List<MdlUsuario>();
                var cmd = new OracleCommand("Select Id_Usuario, Nombre_Usuario, Password, Email, Fecha_Creacion, Usuario_Creacion from Usuario");
                cmd.Connection = con;

                using (var dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        var item = new MdlUsuario();
                        item.IdUsuario = dr.GetValue(0).ToString();
                        item.NombreUsuario = dr.GetValue(1).ToString();
                        item.Password = dr.GetValue(2).ToString();
                        item.UsuarioCreacion = dr.GetValue(3).ToString();
                        item.FechaCreacion = DateTime.Parse( dr.GetValue(4).ToString());
                        lstUsuario.Add(item);
                    }

                }

                return lstUsuario;

            }

        }


        public void Insertar(MdlUsuarioInsertar item) 
        {
            using (var con = new OracleConnection(_config.CadenaConexion))
            {
                con.Open();
                var cmd = new OracleCommand();
                cmd.Connection = con;

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "DBCONTA.PRC_GRABAR_USUARIO ";
                cmd.Parameters.Add(":idusuario", item.IdUsuario);
                cmd.Parameters.Add(":nombre", item.NombreUsuario);
                cmd.Parameters.Add(":password", item.Password);
                cmd.Parameters.Add(":email", item.Email);
                cmd.Parameters.Add(":usr", item.UsuarioCreacion);
                cmd.ExecuteNonQuery();
            }
        }


        public void Actualizar(MdlUsuarioActualizar item) 
        {

            using (var con = new OracleConnection(_config.CadenaConexion))
            {
                con.Open();
                var cmd = new OracleCommand();
                cmd.Connection = con;

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "PRC_ACTUALIZAR_USUARIO ";
                cmd.Parameters.Add(":idusuario", item.IdUsuario);
                cmd.Parameters.Add(":nombre", item.NombreUsuario);
                cmd.Parameters.Add(":password", item.Password);
                cmd.Parameters.Add(":email", item.Email);
                cmd.Parameters.Add(":usr", item.UsuarioCreacion);
                cmd.ExecuteNonQuery();

            }
        
        }

        public void Eliminar(string pId)
        {
            using (var con = new OracleConnection(_config.CadenaConexion))
            {
                con.Open();
                var cmd = new OracleCommand();
                cmd.Connection = con;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "DBCONTA.PRC_USUARIO_ELIMINAR ";
                cmd.Parameters.Add("idusuario", OracleDbType.Varchar2).Value = pId;
                cmd.ExecuteNonQuery();

            }
        }
    }
}
