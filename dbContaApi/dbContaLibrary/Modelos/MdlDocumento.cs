using dbContaLibrary.Servicios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dbContaLibrary.Modelos
{
    public class MdlDocumento
    {
        public string Numero { get; set; }
        public string Serie { get; set; }
        public int TipoDocumento {get; set;}
        public int IdEmpresa { get; set; }
        public string Fecha { get; set; }
        public int Monto { get; set; }
        public string UsuarioCreacion { get; set; }
        public string FechaExpiracion { get; set; }
        public string FechaCreacion { get; set; }
    }
}
