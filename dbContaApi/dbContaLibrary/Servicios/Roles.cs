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
    public class Roles : IRoles
    {
        private readonly IAPPConfiguracion _config;

        public Roles(IAPPConfiguracion pConfig) 
        {
            _config = pConfig;
        }       

        public IEnumerable<MdlRoles> GetRoles() 
        {

            using (var con = new OracleConnection(_config.CadenaConexion)) 
            {
                con.Open();
                var cmd = new OracleCommand("Select Id_Rol, Nombre_Rol, Fecha_Creacion, Usuario_Creacion from Roles");
                cmd.Connection = con;
                var lstRoles = new List<MdlRoles>();


                using (var dr = cmd.ExecuteReader()) 
                {
                    while (dr.Read()) 
                    {
                        var item = new MdlRoles();
                        item.IdRol = int.Parse(dr.GetValue(0).ToString());
                        item.NombreRol = dr.GetValue(1).ToString();
                        item.FechaCreacion = DateTime.Parse(dr.GetValue(2).ToString());
                        item.UsuarioCreacion = dr.GetValue(3).ToString();
                        lstRoles.Add(item);
                    }

                    return lstRoles;
                }

            }

        }


        public void Insertar(MdlRolesInsertar item) 
        {
            using (var con = new OracleConnection(_config.CadenaConexion))
            {
                con.Open();
                var cmd = new OracleCommand();
                cmd.Connection = con;

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "DBCONTA.PRC_GRABAR_ROLES";
                cmd.Parameters.Add(":idrol" , item.IdRol);
                cmd.Parameters.Add(":nombrerol", item.NombreRol);
                cmd.Parameters.Add(":usc", item.UsuarioCreacion);
                cmd.ExecuteNonQuery();
                   
            }
        }


        public void Actualizar(MdlRolesActualizar item) 
        {

            using (var con = new OracleConnection(_config.CadenaConexion))
            {
                con.Open();
                var cmd = new OracleCommand();
                cmd.Connection = con;

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "DBCONTA.PRC_GRABAR_ROLES";
                cmd.Parameters.Add(":IdRol", item.IdRol);
                cmd.Parameters.Add(":NombreRol", item.NombreRol);
                cmd.Parameters.Add(":Usc", item.UsuarioCreacion);
                cmd.ExecuteNonQuery();
            }
        
        }
        

        public void Eliminar(int pIdRol)
        {

            using(var con = new OracleConnection(_config.CadenaConexion)) 
            {
                con.Open();
                var cmd = new OracleCommand();
                cmd.Connection = con;
                cmd.CommandText = "";

                cmd.Parameters.Add(":idrol" , OracleDbType.Int64).Value = pIdRol;
                cmd.ExecuteNonQuery();
            }
        
        
        
        }
    }
}
