using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dbContaLibrary.Modelos
{
    public class MdlRolUsuarioInsertar
    {
        public int IdRolUsuario { get; set; }
        public int IdRol { get; set; }
        public string IdUsuario { get; set; }

        public string UsuarioCreacion { get; set; }
    }
}
