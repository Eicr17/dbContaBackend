using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dbContaLibrary.Modelos
{
    public class MdlTipoLibro
    {
        public int Id_Tipo_Libro { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }

        public string Usuario_Creacion { get; set; }
        public DateTime Fecha_Creacion { get; set; }
    }
}
