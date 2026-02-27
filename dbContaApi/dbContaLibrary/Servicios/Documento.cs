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
    public class Documento : IDocumento
    {
        private readonly IAPPConfiguracion _config;

        public Documento(IAPPConfiguracion pConfig) 
        {
            _config = pConfig;
        }

        public IEnumerable<MdlDocumento> GetDoc() 
        {
            using(var con = new OracleConnection(_config.CadenaConexion)) 
            {
                con.Open();
                var lstDocumento = new List<MdlDocumento>();
                var cmd = new OracleCommand("Select  Numero,Serie,Tipo_Documento,Id_Empresa, Fecha, Monto, Usuario_Creacion,Fecha_Expiracion,Fecha_Creacion from Documento");
                cmd.Connection = con;

                using ( var dr = cmd.ExecuteReader()) 
                {
                    while (dr.Read())
                    {
                        var item = new MdlDocumento();
                        item.Numero = dr.GetValue(0).ToString();
                        item.Serie = dr.GetValue(1).ToString();
                        item.TipoDocumento = int.Parse(dr.GetValue(2).ToString());
                        item.IdEmpresa = int.Parse(dr.GetValue(3).ToString());
                        item.Fecha = DateTime.Parse(dr.GetValue(4).ToString());
                        item.Monto = int.Parse(dr.GetValue(5).ToString());
                        item.UsuarioCreacion = dr.GetValue(6).ToString();
                        item.FechaExpiracion = DateTime.Parse( dr.GetValue(7).ToString());
                        item.FechaCreacion = DateTime.Parse(dr.GetValue(8).ToString());
                        lstDocumento.Add(item);
                        
                    }

                    return lstDocumento;
                }
            }
        }


        public void Insertar(MdlDocCrear item) 
        {
            using (var con = new OracleConnection(_config.CadenaConexion))
            {
                con.Open();
                var cmd = new OracleCommand();
                cmd.Connection = con;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "DBCONTA.PRC_INSERTAR_DOCUMENTO";
                cmd.Parameters.Add(":pNumero", item.Numero);
                cmd.Parameters.Add(":pSerie", item.Serie);
                cmd.Parameters.Add(":pTipoDocumento",item.TipoDocumento);
                cmd.Parameters.Add(":pIdEmpresa", item.IdEmpresa);
                cmd.Parameters.Add(":pMonto", item.Monto);
                cmd.Parameters.Add(":pUsrc",item.UsuarioCreacion);
                cmd.Parameters.Add(":pFechaExp", item.FechaExpiracion);
                cmd.ExecuteNonQuery();
            }
        }

        public void Actualizar( MdlDocActualizar item) 
        {
            using(var con = new OracleConnection(_config.CadenaConexion)) 
            {
                con.Open();
                var cmd = new OracleCommand();
                cmd.Connection = con;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "DBCONTA.PRC_ACTUALIZAR_DOCUMENTO";
                cmd.Parameters.Add(":pIdEmpresa", item.IdEmpresa);
                cmd.Parameters.Add(":pFecha", item.Fecha);
                cmd.Parameters.Add(":pMonto", item.Monto);
                cmd.Parameters.Add(":pUsrc", item.UsuarioCreacion);
                cmd.Parameters.Add(":pNumero", item.Numero);
                cmd.Parameters.Add(":pSerie", item.Serie);
                cmd.Parameters.Add(":pTipoDocumento",item.TipoDocumento);
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
                cmd.CommandText = "DBCONTA.PRC_ELIMINAR_DOCUMENTO";
                cmd.Parameters.Add(":pNumero", OracleDbType.Varchar2).Value = pId;
                cmd.Parameters.Add(":pSerie", OracleDbType.Varchar2).Value = pId;
                cmd.Parameters.Add(":pTipoDocumento", OracleDbType.Varchar2).Value = pId;
                cmd.ExecuteNonQuery();

            }

        }
    }
}
