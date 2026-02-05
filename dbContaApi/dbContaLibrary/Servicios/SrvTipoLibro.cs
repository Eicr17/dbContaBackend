using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.Common;
using Oracle.ManagedDataAccess.Client;
using dbContaLibrary.Modelos;


namespace dbContaLibrary.Servicios
{
    public  class SrvTipoLibro
    {

        public static List<MdlTipoLibro> GetList() 
        {
            var lst = new List<MdlTipoLibro>();

            var con  = new OracleConnection("Data Source=(DESCRIPTION=(ADDRESS=(PROTOCOL=TCP)(HOST=192.168.1.90)(PORT=1521))(CONNECT_DATA=(SERVICE_NAME=XE))); User Id=DBCONTA;Password=conta123");
            con.Open();

            var cmd = new OracleCommand();
            cmd.Connection = con;
            cmd.CommandText = "Select * from Tipo_Libro";

            using (IDataReader dr = cmd.ExecuteReader())
            {

                while(dr.Read())
                {
                    var item = new MdlTipoLibro();
                    item.Id_Tipo_Libro = int.Parse(dr.GetValue(0).ToString());
                    item.Nombre = dr.GetValue(1).ToString();
                    item.Descripcion = dr.GetValue(2).ToString();
                    item.Usuario_Creacion = dr.GetValue(3).ToString();
                    item.Fecha_Creacion = DateTime.Parse( dr.GetValue(4).ToString());
                    lst.Add(item);
                }
            }
            con.Close();
            con.Dispose();
            return lst;
        }
        public void InsertTipoLibro(MdlTipoLibroCrear item) 
        {          

            var con = new OracleConnection("Data Source=(DESCRIPTION=(ADDRESS=(PROTOCOL=TCP)(HOST=192.168.1.90)(PORT=1521))(CONNECT_DATA=(SERVICE_NAME=XE))); User Id=DBCONTA;Password=conta123");
            con.Open();

            var cmd = new OracleCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Connection = con;
            cmd.CommandText = "DBCONTA.PRC_GRABAR_TIPO_LIBRO";
            cmd.Parameters.Add(":Id_Tipo_Libro", item.IdTipoLibro);
            cmd.Parameters.Add(":nombre", item.Nombre);
            cmd.Parameters.Add(":descripcion", item.Descripcion);
            cmd.Parameters.Add(":Usuario_Creacion", item.UsuarioCreacion);
            cmd.ExecuteNonQuery();

            con.Dispose();
            con.Close();
        }
        


        public void ActualizarTipoLibro(MdlTipoLibroActualizar item)
        {

            var con = new OracleConnection("Data Source=(DESCRIPTION=(ADDRESS=(PROTOCOL=TCP)(HOST=192.168.1.90)(PORT=1521))(CONNECT_DATA=(SERVICE_NAME=XE))); User Id=DBCONTA;Password=conta123");
            con.Open();
            
            var cmd = new OracleCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Connection = con;
            cmd.CommandText = "DBCONTA.PRC_GRABAR_TIPO_LIBRO";
            cmd.Parameters.Add(":Id_Tipo_Libro", item.IdTipoLibro);
            cmd.Parameters.Add(":nombre", item.Nombre);
            cmd.Parameters.Add(":descripcion", item.Descripcion);
            cmd.Parameters.Add(":Usuario_Creacion", item.Usuario_Creacion);
            cmd.ExecuteNonQuery();

            con.Dispose();
            con.Close();

        }

        public void Eliminar(int pId)
        {
            var con = new OracleConnection("Data Source=(DESCRIPTION=(ADDRESS=(PROTOCOL=TCP)(HOST=192.168.1.90)(PORT=1521))(CONNECT_DATA=(SERVICE_NAME=XE))); User Id=DBCONTA;Password=conta123");
            con.Open();


            var cmd = new OracleCommand();
            cmd.Connection = con;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "DBCONTA.PRC_ELIMINAR_TIPO_LIBRO";
            cmd.Parameters.Add("@id", OracleDbType.Int64).Value = pId;
            cmd.ExecuteNonQuery();

            con.Dispose();
            con.Close();
        }
    }



}
