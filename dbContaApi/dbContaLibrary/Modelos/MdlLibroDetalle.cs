using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dbContaLibrary.Modelos
{
    public class MdlLibroDetalle
    {
        public int IdLibroDetalle { get; set; }
        public int IdLibro { get; set; }
        public DateTime Fecha { get; set; }
        public string Numero { get; set; }
        public int Serie { get; set; }
        public int TipoDocumento { get; set; }
        public string UsuarioCreacion { get; set; }
    }
}
