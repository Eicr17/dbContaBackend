using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dbContaLibrary.Modelos
{
    public class MdlArticuloActualizar
    {
        public int IdArticulo { get; set; }
        public int IdTipoArticulo { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }

        public string UsuarioCreacion { get; set; }
    }
}
