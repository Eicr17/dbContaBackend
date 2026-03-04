using dbContaLibrary.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dbContaLibrary.Interfaces
{
    public interface ILibroDetalle
    {
        public IEnumerable<MdlLibroDetalle> Obtener();
        public void Eliminar(int pIdlibroDetalle, int pIdLibro);


    }
}
