using dbContaLibrary.Interfaces;
using dbContaLibrary.Modelos;
using Microsoft.Extensions.DependencyInjection;
    using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace dbContaLibrary.Servicios
{
    public class CategoriaDocumento : ICatDocumento
    {
        private readonly IAPPConfiguracion _config;
        public CategoriaDocumento(IAPPConfiguracion pconfig) 
        {
            _config = pconfig;
        }

        public IEnumerable<MdlCatDocumento> GetList() 
        {

            using (var con = new OracleConnection(_config.CadenaConexion)) 
            {
                var lst = new List<MdlCatDocumento>();
                con.Open();

                var cmd = new OracleCommand("Select Id_Categoria_Documento, Usuario_Creacion,Fecha_Creacion from Categoria_Documento");
                cmd.Connection = con;

                using (var dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        var item = new MdlCatDocumento();
                        item.IdCategoriaDocumento = int.Parse(dr.GetValue(0).ToString());
                        item.UsuarioCreacion = dr.GetValue(1).ToString();
                        item.FechaCreacion = DateTime.Parse(dr.GetValue(2).ToString());
                        lst.Add(item);
                    }

                    return lst;
                
                }
            }

        }

        public void Insertar(MdlCatDocCrear item) 
        {
            using(var con = new OracleConnection(_config.CadenaConexion))
            {
                con.Open();
                var cmd = new OracleCommand();
                cmd.Connection = con;

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "DBCONTA.PRC_GRABAR_CATEGORIA_DOCUMENTO";
                cmd.Parameters.Add("id:", item.IdCategoriaDocumento);
                cmd.Parameters.Add("id:", item.UsuarioCreacion);
                cmd.ExecuteNonQuery();
            
            }
            
        }

        public void Actualizar(MdlCatDocActualizar item) 
        {
            using (var con = new OracleConnection(_config.CadenaConexion)) 
            {
                con.Open();
                var cmd = new OracleCommand();
                cmd.Connection = con;

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "DBCONTA.PRC_GRABAR_CATEGORIA_DOCUMENTO";
                cmd.Parameters.Add(":id" , item.IdCategoriaDocumento);
                cmd.Parameters.Add(":usr", item.UsuarioCreacion);
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
                cmd.CommandText = "DBCONTA.PRC_ELIMINAR_CAT_DOCUMENTO";
                cmd.Parameters.Add("id", OracleDbType.Int64).Value = pId;
                cmd.ExecuteNonQuery();
            }
        }

    }
}
