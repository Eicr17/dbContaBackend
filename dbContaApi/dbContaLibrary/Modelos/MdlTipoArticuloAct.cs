using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dbContaLibrary.Modelos
{
    public class MdlTipoArticuloAct
    {
        public int IdTipoArticulo { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public string UsuarioCreacion { get; set; }
    }
}
