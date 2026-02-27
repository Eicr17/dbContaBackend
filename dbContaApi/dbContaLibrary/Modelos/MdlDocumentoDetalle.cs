using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dbContaLibrary.Modelos
{
    public class MdlDocumentoDetalle
    {
        public int IdDocumentoDetalle { get; set; }
        public string Numero { get; set; }
        public string Serie { get; set; }
        public int TipoDocumento { get; set; }
        public int IdArticulo { get; set; }
        public int Cantidad { get; set; }
        public int Precio { get; set; }
        public string UsuarioCreacion { get; set; }
        public DateTime FechaCreacion { get; set; }

    }
}
