using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dbContaLibrary.Modelos
{
    public class MdlDocCrear
    {
        public string Numero { get; set; }
        public string Serie { get; set; }
        public int TipoDocumento { get; set; }
        public int IdEmpresa { get; set; }
        public DateTime Fecha { get; set; }
        public double Monto { get; set; }
        public string UsuarioCreacion { get; set; }
        public DateTime FechaExpiracion { get; set; }
    }
}
