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
        public int Id_Tipo_Libro { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public string Usuario_Creacion { get; set; }
        public DateTime Fecha_Creacion { get; set; }

        public static List<MdlTipoLibro> GetList() 
        {
            var lst = new List<MdlTipoLibro>();

            var con = new OracleConnection("Data Source=(DESCRIPTION=(ADDRESS=(PROTOCOL=TCP)(HOST=192.168.1.90)(PORT=1521))(CONNECT_DATA=(SERVICE_NAME=XE))); User Id=DBCONTA;Password=conta123");
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
        public void InsertTipoLibro() 
        {
            string sql = @"Insert into Tipo_Libro (Nombre,Descripcion,Usuario_Creacion)
                           Values(:nombre, :descripcion, :usuario_creacion)";

            var con = new OracleConnection("Data Source=(DESCRIPTION=(ADDRESS=(PROTOCOL=TCP)(HOST=192.168.1.90)(PORT=1521))(CONNECT_DATA=(SERVICE_NAME=XE))); User Id=DBCONTA;Password=conta123");

            var cmd = new OracleCommand();
            cmd.Connection = con;
            cmd.Parameters.Add(":nombre", Nombre);
            cmd.Parameters.Add(":descripcion", Descripcion);
            cmd.Parameters.Add(":Usuario_Creacion", Usuario_Creacion);
            cmd.ExecuteNonQuery();

        }


        public void ActualizarTipoLibro()
        {

            string sql = @"Update Tipo_Libro set ( 
            Nombre = :nombre, 
            Descripcion = :descripcion,
            Usuario_Creacion = :usuario_creacion
            Where Id_Tipo_Libro: @id)";

            var con = new OracleConnection("Data Source=(DESCRIPTION=(ADDRESS=(PROTOCOL=TCP)(HOST=192.168.1.90)(PORT=1521))(CONNECT_DATA=(SERVICE_NAME=XE))); User Id=DBCONTA;Password=conta123");

            var cmd = new OracleCommand();
            cmd.Connection = con;
            cmd.CommandText = sql;
            cmd.Parameters.Add(":Id_Tipo_Libro", Id_Tipo_Libro);
            cmd.Parameters.Add(":nombre", Nombre);
            cmd.Parameters.Add(":descripcion", Descripcion);
            cmd.Parameters.Add(":Usuario_Creacion", Usuario_Creacion);
            cmd.ExecuteNonQuery();

        }


        public void EliminarTipoLibro() 
        {
            string sql = @"Delete from Tipo_Libro
                         Where Id_Tipo_libro = :id";

            var con = new OracleConnection("Data Source=(DESCRIPTION=(ADDRESS=(PROTOCOL=TCP)(HOST=192.168.1.90)(PORT=1521))(CONNECT_DATA=(SERVICE_NAME=XE))); User Id=DBCONTA;Password=conta123");


            var cmd = new OracleCommand();
            cmd.Connection = con;
            cmd.CommandText = sql;
            cmd.Parameters.Add(":id");
            cmd.ExecuteNonQuery();

        }
    }
}
