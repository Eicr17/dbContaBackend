using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dbContaLibrary.Modelos
{
    public class MdlActualizarEmpresa
    {
        public int IdEmpresa { get; set; }
        public string Nombre { get; set; }
        public string UsuarioCreacion { get; set; }
        public string Nit { get; set; }
    }
}
