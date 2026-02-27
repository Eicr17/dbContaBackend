using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dbContaLibrary.Modelos
{
    public class MdlGenTipoLibro
    {
        public int Folio { get; set; }
        public int Empresa { get; set; }
        public int TipoLibro { get; set; }
        public string Usuario { get; set; }
        public int AnioLibro { get; set; }
        public int MesLibro { get; set; }
    }
}
