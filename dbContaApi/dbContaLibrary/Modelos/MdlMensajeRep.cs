using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dbContaLibrary.Modelos
{
    public class MdlMensajeRep
    {
        public int total { get; set; }
        public string mensaje_error { get; set; }
        public int codigo_operacion { get; set; }
        public string mensaje_exitoso { get; set; }
    }
}
