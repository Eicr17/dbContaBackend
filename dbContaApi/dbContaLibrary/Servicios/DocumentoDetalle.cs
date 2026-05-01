using dbContaLibrary.Interfaces;
using dbContaLibrary.Modelos;
using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Data;
using System.Dynamic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace dbContaLibrary.Servicios
{
    
    public class DocumentoDetalle  : IDocumentoDetalle
    {
        private readonly IAPPConfiguracion _config;

        public DocumentoDetalle(IAPPConfiguracion pConfig)
        {
            _config = pConfig;
        }
        
        public IEnumerable<MdlDocumentoDetalle> Get(int idDocDet, string numero) 
        {
            using(var con = new OracleConnection(_config.CadenaConexion))
            {
                con.Open();

                string cadena = "Select id_documento_detalle,Numero,Serie,tipo_documento, id_articulo, cantidad,precio, usuario_creacion from Documento_Detalle where 1 = 1";

                if (idDocDet != 0)
                {
                    cadena += $"and id_documento_detalle  = {idDocDet} ";
                }

                if (!string.IsNullOrEmpty(numero))
                {
                    cadena += $" and (upper(trim(numero))  like '%{numero.ToUpper().Trim()}%' )";
                }
                

                var lstDocDt = new List<MdlDocumentoDetalle>();
                var cmd = new OracleCommand(cadena);
                cmd.Connection = con;

                using (var dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        var item = new MdlDocumentoDetalle();
                        item.IdDocumentoDetalle = int.Parse(dr.GetValue(0).ToString());
                        item.Numero = dr.GetValue(1).ToString();
                        item.Serie = dr.GetValue(2).ToString();
                        item.TipoDocumento = int.Parse(dr.GetValue(3).ToString());
                        item.IdArticulo = int.Parse(dr.GetValue(4).ToString());
                        item.Cantidad = int.Parse(dr.GetValue(5).ToString());
                        item.Precio = int.Parse(dr.GetValue(6).ToString());
                        item.UsuarioCreacion = dr.GetValue(7).ToString();
                        lstDocDt.Add(item);
                    }
                
                }
                return lstDocDt; 

            }
        }

        public void Insertar(MdlDocumentoDetalleCrear item) 
        {
            using(var con = new OracleConnection(_config.CadenaConexion)) 
            {
                con.Open();
                var cmd = new OracleCommand();
                cmd.Connection = con;

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "DBCONTA.PRC_GRABAR_DOCUMENTO_DETALLE";
                cmd.Parameters.Add(":id",item.IdDocumentoDetalle);
                cmd.Parameters.Add(":numero", item.Numero);
                cmd.Parameters.Add(":Serie", item.Serie);
                cmd.Parameters.Add(":tipodocumento", item.TipoDocumento);
                cmd.Parameters.Add(":idArticulo", item.IdArticulo);
                cmd.Parameters.Add(":Cantidad", item.Cantidad);
                cmd.Parameters.Add(":Precio", item.Precio);
                cmd.Parameters.Add(":Usc", item.UsuarioCreacion);
                cmd.ExecuteNonQuery();
            }
        }

        public void Actualizar(MdlDtDocumentoActualizar item) 
        {
            using (var con = new OracleConnection(_config.CadenaConexion)) 
            {
                con.Open();
                var cmd = new OracleCommand();
                cmd.Connection = con;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = ("DBCONTA.PRC_GRABAR_DOCUMENTO_DETALLE");
                cmd.Parameters.Add(":id", item.IdDocumentoDetalle);
                cmd.Parameters.Add(":numero", item.Numero);
                cmd.Parameters.Add(":serie", item.Serie);
                cmd.Parameters.Add(":tipodocumento", item.TipoDocumento);
                cmd.Parameters.Add(":idarticulo", item.IdArticulo);
                cmd.Parameters.Add(":cantidad", item.Cantidad);
                cmd.Parameters.Add(":precio", item.Precio);
                cmd.Parameters.Add(":usr", item.UsuarioCreacion);
                cmd.ExecuteNonQuery();
            }
        }

        public void Eliminar(int pId) 
        {
            using (var con = new OracleConnection(_config.CadenaConexion)) 
            {
                con.Open();
                var cmd =  new OracleCommand();
                cmd.Connection = con;
                cmd.Parameters.Add(":id", OracleDbType.Int64).Value = pId;
                cmd.ExecuteNonQuery();
            }
        }

    }
}
