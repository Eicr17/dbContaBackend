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
    public class Empresa: IEmpresa
    {
        private readonly IAPPConfiguracion _config;

        public Empresa(IAPPConfiguracion pconfig)
        {
            _config = pconfig;
        }

        public IEnumerable<MdlEmpresa> Get() 
        {
            using(var con = new OracleConnection(_config.CadenaConexion)) 
            {
                con.Open();
                var lst = new List<MdlEmpresa>();
                var cmd = new OracleCommand("Select Id_Empresa,Nombre,Usuario_Creacion,Fecha_Creacion,Nit from Empresa");
                cmd.Connection = con;

                using(var dr = cmd.ExecuteReader()) 
                {
                    while (dr.Read()) 
                    {
                        var item = new MdlEmpresa();
                        item.IdEmpresa = int.Parse(dr.GetValue(0).ToString());
                        item.Nombre = dr.GetValue(1).ToString();
                        item.UsuarioCreacion = dr.GetValue(2).ToString();
                        item.FechaCreacion = DateTime.Parse(dr.GetValue(3).ToString());
                        item.Nit = dr.GetValue(4).ToString();
                        lst.Add(item);
                    }
                  
                }
                return lst;
            }
        }


        public void Insertar(MdlEmpresaInsertar item) 
        {
            using(var con = new OracleConnection(_config.CadenaConexion))
            {
                con.Open();
                var cmd = new OracleCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Connection = con;
                cmd.CommandText = "DBCONTA.PRC_GRABAR_EMPRESA";
                cmd.Parameters.Add(":id", item.IdEmpresa);
                cmd.Parameters.Add(":nombre", item.Nombre);
                cmd.Parameters.Add(":usr", item.UsuarioCreacion);
                cmd.Parameters.Add(":nit", item.Nit);
                cmd.ExecuteNonQuery();
            }
        }


        public void Actualizar(MdlActualizarEmpresa item) 
        {
            using ( var con = new OracleConnection(_config.CadenaConexion)) 
            {
                con.Open();
                var cmd = new OracleCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Connection = con;
                cmd.CommandText = "DBCONTA.PRC_GRABAR_EMPRESA";
                cmd.Parameters.Add(":id", item.IdEmpresa);
                cmd.Parameters.Add(":nombre", item.Nombre);
                cmd.Parameters.Add(":usrc", item.UsuarioCreacion);
                cmd.Parameters.Add(":nit", item.Nit);
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
                cmd.CommandText = "DBCONTA.PRC_ELIMINAR_EMPRESA";
                cmd.Parameters.Add(":id", OracleDbType.Int64).Value = pId;
                cmd.ExecuteNonQuery();
      
            }
        
        }
    }
}
