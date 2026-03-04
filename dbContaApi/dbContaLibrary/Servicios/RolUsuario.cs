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
    public class RolUsuario : IRolUsuario
    {
        private readonly IAPPConfiguracion _config;

        public RolUsuario(IAPPConfiguracion pConfig) 
        {

            _config = pConfig;

        }


        public IEnumerable<MdlRolUsuario>Get()
        {
            using (var con = new OracleConnection(_config.CadenaConexion))
            {
                var lstRol = new List<MdlRolUsuario>();
                con.Open();

                var cmd = new OracleCommand("Select Id_Rol_Usuario, Id_Rol, Id_Usuario, Fecha_Creacion, Usuario_Creacion from Rol_Usuario");
                cmd.Connection = con;

                using (var dr = cmd.ExecuteReader()) 
                {
                    while (dr.Read()) 
                    {
                        var item = new MdlRolUsuario();
                        item.IdRolUsuario = int.Parse( dr.GetValue(0).ToString());
                        item.IdRol = int.Parse(dr.GetValue(1).ToString());
                        item.IdUsuario = dr.GetValue(2).ToString();
                        item.FechaCreacion = DateTime.Parse(dr.GetValue(3).ToString());
                        item.UsuarioCreacion = dr.GetValue(4).ToString();
                        lstRol.Add(item);

                    }
                

                }
                return lstRol;

            }
        
        
        }


        public void Insertar(MdlRolUsuarioInsertar item) 
        {
            using (var con = new OracleConnection(_config.CadenaConexion))
            {
                con.Open();
                var cmd = new OracleCommand();
                cmd.Connection = con;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "DBCONTA.PRC_ROL_USUARIO";
                cmd.Parameters.Add(":idrolusuario", item.IdRolUsuario);
                cmd.Parameters.Add(":idrol", item.IdRol);
                cmd.Parameters.Add(":idusuario", item.IdUsuario);
                cmd.Parameters.Add(":usc", item.UsuarioCreacion);
                cmd.ExecuteNonQuery();

            }
        
        
        }


        public void Actualizar(MdlRolUsuarioActualizar item)
        {
            using (var con = new OracleConnection(_config.CadenaConexion))
            {
                con.Open();
                var cmd = new OracleCommand();
                cmd.Connection = con;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "DBCONTA.PRC_ROL_USUARIO";
                cmd.Parameters.Add(":idrolusuario", item.IdRolUsuario);
                cmd.Parameters.Add(":idrol", item.IdRol);
                cmd.Parameters.Add(":idusuario", item.IdUsuario);
                cmd.Parameters.Add(":usc", item.UsuarioCreacion);
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
                cmd.CommandText = "PRC_ROL_USUARIO_ELIMINAR";
                cmd.Parameters.Add(":id", OracleDbType.Int64).Value = pId;
                cmd.ExecuteNonQuery();

            }

        }




    }
}
