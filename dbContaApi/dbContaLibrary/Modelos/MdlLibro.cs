using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dbContaLibrary.Modelos
{
    public class MdlLibro
    {
        public int IdLibro { get; set; }
        public DateTime Fecha { get; set; }
        public int Folio { get; set;}
        public int Monto { get; set;}
        public int IdEmpresa { get; set; }
        public int IdTipoLibro { get; set; }
        public string UsuarioCreacion { get; set;  }

        public DateTime FechaCreacion { get; set;}
    }
}
